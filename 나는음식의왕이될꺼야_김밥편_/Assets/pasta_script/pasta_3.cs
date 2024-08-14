using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class pasta_3 : MonoBehaviour
{
    public GameObject panel;
    public GameObject BlackOut;
    public GameObject BlackMove;
    public AudioSource typingsound;
    public AudioSource Effectsound;
    public AudioSource Backroundsound;
    public AudioSource eathquake;


    public GameObject gimbablaser;

    public Text dialogueText;

    public Text nameText;// Reference to your UI Text component

    string first = "저게... 뭐지..? ";
    string[] dialogues = {  "이것이.. 우리의 '분위기'다!! ","무슨 소리냐!!!!!!", "대체 그 모습이 어디서 '분위기'가 나오냐는 것이냐!!!!!! ", "소풍을 갈때.. 대장금님께서는 언제나 말하셨지 ",
        "오늘은 김밥이 활약을 할 차례네?","나는 슬펐어", "소풍 날에는 김밥에게만 주목을 해주었으니깐 말이야.. ",
        "하지만, 먹기도 편하고, 영양소도 풍부한 김밥이 소풍날 주목받는 건 당연했지.. ","그치만 대장금님께서는 그것을 아시고, 김밥이에게 능력을 주셨다 ",
        "그것은 바로... '모두를 포용하는 능력'이다!! "
       ,"이제 소풍에서 김밥이 돋보이는게 아냐! ","김밥이 모두를 돋보이게 하는 것이다!! " ,"소풍은... 모두와 함께하는 추억이니까!!!!! ",
        "모두와 함께하는 이 '분위기'를 너는 우매하다고 하는 것이냐!!!!!!!! " };
    // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김치제육김밥", "파스타", "파스타", "김치", "대장금","김치", "김치","김치", "제육","제육",  "김치제육김밥",
        "김치제육김밥", "김치제육김밥","김치제육김밥" };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 5, 3, 2, 8, 13, 9, 9, 9, 10, 12,6,6,6, 14 }; //12


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
            eathquake.Pause();
            BlackMove.SetActive(false);
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
                characterImage[imageNumber[exnumber - 1]].gameObject.SetActive(false);
                panel.SetActive(false);
                gimbablaser.SetActive(true);

            }
        }
    }


    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = first;


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;

        eathquake.Play();


        // Move to the next dialogue in the array

        Debug.Log("문자");
    }



    void ShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = dialogues[currentDialogueIndex2];



        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        if (currentDialogue == dialogues[0] || currentDialogue == dialogues[13])
        {
            Effectsound.Play();
            currentDialogueIndex2++;
        }
        else if (currentDialogue == dialogues[3]) {

           
            Backroundsound.Play();
            currentDialogueIndex2++;
        }
       
        else
        {

            // Move to the next dialogue in the array
            currentDialogueIndex2++;
        }
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
        bool soundPlayed = false;
        for (int i = 0; i <= currentDialogue.Length; i++)
        {
            if (i < currentDialogue.Length && currentDialogue[i] != ' ')
            {
                typingsound.Play();
            }

            if (currentDialogue == dialogues[9])
            {
                if (i < 7) 
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

            else
            {
                dialogueText.text = currentDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시
            }

            if (!soundPlayed && currentDialogue == dialogues[9] && i == 10)
            {
                Effectsound.Play();
                soundPlayed = true; // Ensure the sound plays only once
            }

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

    void firstshowName()
    {
        string currentname = "파스타";

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
           if (i < firstDialogue.Length && firstDialogue[i] != ' ')
            {
                typingsound.Play();
            }

            dialogueText.text = firstDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.1f); 


        }
        isTyping = false;



    }

    void SetScene()
    {
        SceneManager.LoadScene("파스타3");
    }
}
