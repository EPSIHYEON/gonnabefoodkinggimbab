using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PA4_Script : MonoBehaviour
{
    public Text nameText;// Reference to your UI Text component

    string first = "크흑..... ";
    string[] dialogues = {"그래서... 이렇게 외로웠던 것인가... ", "타지에서... 왕의 자리까지 오르면... 기쁠 줄 알았는데..... ",
    "그렇지 않을 지도 모르겠군... ", "내가 잊고 있었던 건.... '모두'인가..... ", "아니!!! ", "????? ", "잊지 않았다!!! ",
    "무슨 소리지??? ", "나는 너가 필요하다! ", "타지에서 이 정도까지 올라온 너에게.... 나는 배우고 싶다!! ",
    "우리의 목적은 '인간들을 보살피는 것' ", "너의 지식과 나의 지식이 합쳐지면,", "대장금님처럼 나라를 다스릴 수 있을 거야! ",
    "이제부터, 모두가 함께이면 되지 않겠어? ", "..... ", "하하! ", "이것이 바로 '포용하는 능력'인가?? ",
    "대답은? ", "좋다! "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "파스타", "파스타", "파스타","파스타", "김밥", "파스타", "김밥", "파스타",
    "김밥", "김밥", "김밥", "김밥", "김밥", "김밥","파스타", "파스타", "파스타", "김밥", "파스타"};
    public Image[] characterImage;
    public bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 8, 9, 10, 12,
    0, 16, 1, 11,
    2, 3, 4, 5, 5, 6, 13, 14, 14, 7, 15 };
 
    public GameObject BlackOut;
    public GameObject BlackMove;
    public GameObject Ending;
    public GameObject Endingbtn;
    public Text dialogueText;
    public AudioSource scriptSound;
    public AudioSource BackgroundSound;
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
                Ending.SetActive(true);
                Invoke("lateButton", 5f);
            }
        }
    }

    void lateButton() {

        Endingbtn.SetActive(true);
    }
    
    

    void ShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = dialogues[currentDialogueIndex2];


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;

        if (currentDialogue == dialogues[4]) {
            BackgroundSound.Play();
        }


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
        string currentname = "파스타";

        nameText.text = currentname;

    }

    void firstshowImage(bool active = true)
    {

        if (active)
        {
            characterImage[9].gameObject.SetActive(true);
        }
        else
        {
            characterImage[9].gameObject.SetActive(false);
        }


    }


    IEnumerator firsttyping(string firstDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= firstDialogue.Length; i++)
        {
            
            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            if (i < firstDialogue.Length && firstDialogue[i] != ' ') {
                scriptSound.Play();
            }
            
            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
           

        }
        isTyping = false;

    }


    void SetScene()
    {
        SceneManager.LoadScene("ending");
    }
}


