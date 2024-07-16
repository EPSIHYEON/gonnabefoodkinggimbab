using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 인트로script : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;// Reference to your UI Text component
    public GameObject 김밥panel;


    string first = "떄로는 2004년... 음식을 다스리던 대장금께서 돌아가시고 만다.... ";
    string[] dialogues = {  "급작스럽게 돌아가신 대장금께서는\n차기의 후계자를 설정하시지 못하고\n음식의 나라는 혼란에 빠지고 만다. ",
        "그 혼란을 지켜보던 ((((   ))))이는... 혼란을 막고 싶었다  ",
    "그는.... 혼란을 막고자... ","<size=25><<<<<</size><size=40>왕</size><size=25>>>>>이 되고자 했고, </size>" ,"궁궐인 부엌으로 향하게 된다 "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "김치", "김밥", "김치", "김밥", "김밥", "김치", "김치", "김밥", "김치", "김밥", "김밥", "김치", "김치" };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1 };


    private Coroutine typingCoroutine;

    void Start()
    {

        firstShowDialogue();
        StartCoroutine(firsttyping(first));
    }

    void Update()
    {
        // Check if the mouse button is clicked
        if ((Input.GetKeyDown("space") && !isTyping) || Input.GetMouseButtonDown(0) && !isTyping)
        {
           

            // Check if there are more dialogues to display
            if (currentDialogueIndex2 < dialogues.Length)
            {
               
                ShowDialogue();
                typingCoroutine = StartCoroutine(typing(dialogues[currentDialogueIndex2 - 1]));

            }


            else
            {
              
                //Invoke("SetScene", 1f);
            }
        }
    }


    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = first;


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        // Move to the next dialogue in the array

        Debug.Log("문자");
    }



    void ShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = dialogues[currentDialogueIndex2];


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        // Move to the next dialogue in the array
        currentDialogueIndex2++;
        Debug.Log("문자");
    }
    void showName()
    {
        string currentname = namepanel[currentDialogueIndex1];

        nameText.text = currentname;

        currentDialogueIndex1++;
        Debug.Log("문자2");
    }

    void showImage()
    {


        if (exnumber != 0)
        {
            characterImage[imageNumber[exnumber - 1]].gameObject.SetActive(false);

        }
        characterImage[imageNumber[exnumber]].gameObject.SetActive(true);
        Debug.Log("Showing image at index: " + imageNumber[exnumber]);
        exnumber++;

    }



    IEnumerator typing(string currentDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= currentDialogue.Length; i++)
        {

            dialogueText.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

    void firstshowName()
    {
        string currentname = "김치";

        nameText.text = currentname;


        Debug.Log("문자2");
    }

    void firstshowImage(bool active = true)
    {



        if (active)
        {
            characterImage[1].gameObject.SetActive(true);
        }
        else
        {
            characterImage[1].gameObject.SetActive(false);
        }


    }


    IEnumerator firsttyping(string firstDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= firstDialogue.Length; i++)
        {

            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

}
