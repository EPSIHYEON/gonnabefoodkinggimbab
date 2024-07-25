using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 김치편script : MonoBehaviour
{   public GameObject BlackMove;
    public GameObject BlackOut;
    public Text dialogueText;
    public AudioSource scriptSound;
    

    public Text nameText;// Reference to your UI Text component

    string first = "음식의 왕이 되러 가볼까!! ";
    string[] dialogues = { "잠깐!!! ", 
        "어디서 매 식사마다 안나오는 것이 음식의 왕이 되려 햇!!! ", "뭐냐!! 너도 음식의 지배자가 되고 싶은거냐!! ",
    "당연하지!! 김치 없으면 음식들이 넘어가기나 해???", "어디에나 있어야하는 존재가 당연히 지배자의 자질 아니겠어? ","크윽...어쩔 수 없군.... 음식 배틀로 붙자!!! ","흥! 당연히 나의 승리짓!!! "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = {  "???", "김치","김밥","김치","김치","김밥","김치"  };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
   
    int[] imageNumber = { 1, 1, 0,0,0,1, 1 };

    
    private Coroutine typingCoroutine;


    void Start()
    {

        BlackMove.SetActive(true);
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
            //scriptSound.Play();

            dialogueText.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            
            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
        
            

        }
        isTyping = false;



    }
    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = first;


        // Update the text component with the current dialogue
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
            characterImage[0].gameObject.SetActive(true);
        }
        else
        {
            characterImage[0].gameObject.SetActive(false);
        }


    }


    IEnumerator firsttyping(string firstDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= firstDialogue.Length; i++)
        {
            
            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            //scriptSound.Play();
            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시
           

        }
        isTyping = false;



    }

    void SetScene()
        {
            SceneManager.LoadScene("김치2");
        }
    }



    
