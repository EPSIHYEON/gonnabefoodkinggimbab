using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JY1_Script : MonoBehaviour
{
    public Text nameText;// Reference to your UI Text component

    string first = "허억.. 허억.. 집 안인가.... 이제 곧.. 부엌에 도달할 수 있는건가..? ";
    string[] dialogues = { "으디서 피도 안 마른 것이 왕이 되려혀!!!!!!!!!!!!!! ", "아, 아닛 스승님!!! ",
    "그래 이놈아, 겨우겨우 인간 놈들에게 먹히라고 햄 끼워넣어줬더니",  "뭐??  왕????? ", "스승님, 예전에 야채맛 가득 나는 제가 아닙니다!!" ,"제 당근도 이제 볶.은.당.근 이라구요!!!! ",
    "볶.은.당.근???", "난 태생부터 볶는 제육인디 어딜 덤비려 혀!!!!!!!!!! ", "크흑...! 스승님... 결국... 저는 스승님을 이겨야 나아갈 수 있는 겁니까!! ", "나의 살갖이 다 타버리기 전까진 절대 보내줄수 없는 기야!!!!!!!!!", "덤벼라!!!! "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "?????" , "김밥", "제육", "제육", "김밥","김밥", "제육", "제육", "김밥", "제육","제육"};
    public Image[] characterImage;
    public bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 1, 2, 8, 8, 0, 4, 9, 9, 2, 7, 7 };
 
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
                Invoke("SetScene", 2f);
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
            if (i < currentDialogue.Length && currentDialogue[i] != ' ') {
                scriptSound.Play();
            }
            

            // "'볶.은.당.근" 부분을 체크
            if (currentDialogue == dialogues[5])
            {
                if (i >= 9 && i < 17) 
                {
                    dialogueText.text = currentDialogue.Substring(0, i);
                    yield return new WaitForSeconds(0.2f); // 느리게 표시
                }
                else
                {
                    dialogueText.text = currentDialogue.Substring(0, i);
                    yield return new WaitForSeconds(0.005f);
                }
            }

            else if (currentDialogue == dialogues[8]) {
                dialogueText.text = currentDialogue.Substring(0, i); 

                yield return new WaitForSeconds(0.00000001f); 

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
        string currentname = "김밥";

        nameText.text = currentname;

    }

    void firstshowImage(bool active = true)
    {

        if (active)
        {
            characterImage[6].gameObject.SetActive(true);
        }
        else
        {
            characterImage[6].gameObject.SetActive(false);
        }


    }


    IEnumerator firsttyping(string firstDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= firstDialogue.Length; i++)
        {
            
    
            if (i >= 0 && i < 10) 
            {
                dialogueText.text = firstDialogue.Substring(0, i);
                yield return new WaitForSeconds(0.1f); // 느리게 표시
            }
            else
            {
                dialogueText.text = firstDialogue.Substring(0, i);
                yield return new WaitForSeconds(0.005f);
            }
        

            if (i < firstDialogue.Length && firstDialogue[i] != ' ') {
                scriptSound.Play();
            }

            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            scriptSound.Play();
            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
           

        }
        isTyping = false;

    }


    void SetScene()
    {
        SceneManager.LoadScene("JY2");
    }
}
