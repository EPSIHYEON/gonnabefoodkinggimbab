using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JY3_Script : MonoBehaviour
{
    public Text nameText;// Reference to your UI Text component

    string first = "정말.. 많이 컸구나.. 야채가 고기를 이기다니...";
    string[] dialogues = {"모든 건.. 스승님 덕분이죠... ", "선생님이 알려주시지 않았습니까? 제육인 자신도 야채와 함께 볶일 정도로 야채는 소중한 존재라고...",
    "맞아.. 그랬지.. 내가 중요한 걸 잊었구나.. ","음식은... '맛'으로 통하는 것이라고..", "마지막으로... 너에게 전하고 싶은 말이 있다.. ",
    ".....무엇입니까? ", "세상에서 제일 귀한 금이 무엇인 줄 아느냐.. ", "........ ", "제육보금!!!! ",
    "스승님!!!!!!!!!!!!!!!! "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "김밥", "제육","제육",  "제육", "김밥", "제육", "김밥", "제육", "김밥"};
    public Image[] characterImage;
    public bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 1, 2, 6, 6, 7, 3, 8, 3, 9, 4 };
 
    public GameObject BlackOut;
    public GameObject BlackMove;
    public Text dialogueText;
    public AudioSource scriptSound;
    private Coroutine typingCoroutine;

    void Start()
    {
        BlackMove.SetActive(true);
        firstshowImage(true);
        firstshowName();
        firstshowDialogue();
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
                BlackOut.SetActive(true);
                Invoke("SetScene", 1f);
            }
        }
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

    
    void showName() {
        string currentname = namepanel[currentDialogueIndex1];

        nameText.text = currentname;

        currentDialogueIndex1++;
        Debug.Log("문자2");
    }

    void showImage() {


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
            
            scriptSound.Play();

            if (currentDialogue == dialogues[3]) {
                dialogueText.text = currentDialogue.Substring(0, i); 

                yield return new WaitForSeconds(0.15f);

            }
            else if (currentDialogue == dialogues[7]) {
                dialogueText.text = currentDialogue.Substring(0, i); 

                yield return new WaitForSeconds(0.0001f); 

            }

            dialogueText.text = currentDialogue.Substring(0, i);
            // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
            

        }
        isTyping = false;
    }

    void firstshowDialogue()
    {
        string currentDialogue = first;

        dialogueText.text = currentDialogue;
    }

    void firstshowName()
    {
        string currentname = "제육";

        nameText.text = currentname;

    }

    void firstshowImage(bool active = true)
    {

        if (active)
        {
            characterImage[5].gameObject.SetActive(true);
        }
        else
        {
            characterImage[5].gameObject.SetActive(false);
        }


    }


    IEnumerator firsttyping(string firstDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= firstDialogue.Length; i++)
        {
            
            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            scriptSound.Play();
            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
           

        }
        isTyping = false;

    }


    void SetScene()
    {
        SceneManager.LoadScene("제육2");
    }
}
