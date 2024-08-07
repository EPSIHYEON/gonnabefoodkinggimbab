using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pastaScript1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject BlackOut;
    public GameObject BlackMove;
    public GameObject pboss;
    public GameObject babbullet;
   
    public Text dialogueText;

    public Text nameText;// Reference to your UI Text component

    string first = "어쩌지? 이젠.. 피할 수 없어...! ";
    string[] dialogues = {  "난.. 결국.. 여기까지인건가... ","잠깐!!! ", "....?","당신들은..?","우리가 있다는 것을 잊었나???? ","..뭐지? 저 분위기 없는 것들은?? "
    ,"아직 포기하기에는 이르다! 우리에게는 '그것'이 있으니!! ","네..? '그것'이... 대체 뭐죠? ","파스타는 할 수 없는... 김밥 너만이 할 수 있는 것! ", "나만이 할 수 있는... "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "???", "김밥", "김밥", "김치 & 제육", "파스타", "제육", "김밥", "김치", " 김밥" };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };


    private Coroutine typingCoroutine;

    void Start()
    {
        pboss.SetActive(true);
        babbullet.SetActive(false);
        firstshowImage();
        firstshowName();
        firstShowDialogue();
        StartCoroutine(firsttyping(first));
    }

    void Update()
    {
        // Check if the mouse button is clicked
        if ((Input.GetKeyDown("space") && !isTyping) || Input.GetMouseButtonDown(0) && !isTyping)
        {
            firstshowImage(false);

            // Check if there are more dialogues to display
            if (currentDialogueIndex2 < dialogues.Length)
            {
                showImage();
                showName();
                ShowDialogue();
                typingCoroutine = StartCoroutine(typing(dialogues[currentDialogueIndex2 - 1]));

            }


            else
            {
                BlackMove.SetActive(true);
                SetScene();

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
        string currentname = "김밥";

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

    void SetScene()
    {
        SceneManager.LoadScene("pasta3");
    }
}
