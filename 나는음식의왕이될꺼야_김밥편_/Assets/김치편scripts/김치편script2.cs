using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 김치편script2 : MonoBehaviour
{
    public GameObject BlackOut;

    
    public Text dialogueText;

    public Text nameText;// Reference to your UI Text component

    string first = "너따위한테 지다니! 인정 못해!! 모두한테 어울리는 내가 진정한 왕이지!!! ";
    string[] dialogues = {  "당신한테는 부족한 점이 있어 ",
        "뭐? 대체 내가 뭐가 부족하지? ", "당신은... 밥이 아니라는 것이다!!!! ",
    "!!!!!!!!!!!!! ", "음식의 왕이 남이 아니면 먹히지 않을 존재라는 것이 ", "말이 된다고 생각하는가?? ","크윽...하지만....나는....없으면...안되는 존재... ","가... 아닌건가.... ","아니! 당신은 없으면 안되는 존재다! ","!! 방금전까지는!! ",
        "당신이 없으면, 음식의 왕은 진가를 발휘하지 못해!! ","그러니 내가 왕이 되면.. 나를 도와줘!! 나는 너의 도움이 필요하니까!! ",".........","(큐-융)  (발그레) "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "김치", "김밥", "김치", "김밥","김밥", "김치", "김치", "김밥","김치","김밥","김밥","김치","김치" };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 0, 1, 0, 1, 0, 0, 1, 1,0,1,0,0,1,1 };


    private Coroutine typingCoroutine;

     void Start()
    {

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
                BlackOut.SetActive(true);
                Invoke("SetScene", 1f);
            }
        }
    }


    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue =first;


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

            if (currentDialogue == dialogues[7]|| currentDialogue == dialogues[12]) {
                dialogueText.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

                yield return new WaitForSeconds(0.2f); // 0.25초마다 한 글자씩 표시

            }

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

    void SetScene()
    {
        SceneManager.LoadScene("김치2");
    }
}
