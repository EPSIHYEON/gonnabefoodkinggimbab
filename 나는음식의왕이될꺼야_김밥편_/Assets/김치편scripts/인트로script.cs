using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 인트로script : MonoBehaviour
{
    public Text dialogueText1;
    public Text nextText2;
    public Text nameText;// Reference to your UI Text component
    public GameObject 김밥panel;
    public GameObject BlackMove;


    string first = "떄로는 2004년... 음식을 다스리던 대장금께서 돌아가시고 만다.... ";
    string[] dialogues = {  "급작스럽게 돌아가신 대장금께서는\n차기의 후계자를 설정하시지 못하고\n음식의 나라는 혼란에 빠지고 만다. ",
        "그 혼란을 지켜보던 ((((   ))))이는... 혼란을 막고 싶었다  ",
    "그는.... 혼란을 막고자... ","<<<<왕>>>>>이 되고자 했고" ,"궁궐인 부엌으로 향하게 된다 "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] dialogues2 = { "그래서 내가 누구냐고? ", "아~ 측면으로 있어서 안보였구나! ", "김밥이야!!! ", "맛과 모양, 가격까지 갖춘 내가 당연히 왕의 될 존재 아니겠어? " };
    string[] namepanel = { "???", "???", "김밥", "김밥" };
    public Image[] characterImage;
    public Image Gimbab;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    private int currentDialogue2Index = 0;

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
                if (currentDialogue2Index < dialogues2.Length)
                {
                    dialogueText1.enabled = false;
                    김밥panel.SetActive(true);

                    showName();
                    ShowDialogue2();
                    StartCoroutine(typing2(dialogues2[currentDialogue2Index - 1]));
                }


                else {
                    BlackMove.SetActive(true);
                    Invoke("SetScene", 1f);
                }
            }
        }
    }


    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = first;


        // Update the text component with the current dialogue
        dialogueText1.text = currentDialogue;


        // Move to the next dialogue in the array

        Debug.Log("문자");
    }



    void ShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = dialogues[currentDialogueIndex2];

       
        // Update the text component with the current dialogue
        dialogueText1.text = currentDialogue;


        // Move to the next dialogue in the array
        currentDialogueIndex2++;
        Debug.Log("문자");
    }

    void ShowDialogue2() {

        string currentDialogue = dialogues2[currentDialogue2Index];

        if (currentDialogue == dialogues2[2]) {
            Gimbab.gameObject.SetActive(true);
        }
        // Update the text component with the current dialogue
        nextText2.text = currentDialogue;


        // Move to the next dialogue in the array
        currentDialogue2Index++;
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
          
                
            

            dialogueText1.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

    IEnumerator typing2(string currentDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= currentDialogue.Length; i++)
        {




            nextText2.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

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

            dialogueText1.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

    void SetScene()
    {
        SceneManager.LoadScene("김치1");
    }
}
