using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PA_Script : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;// Reference to your UI Text component
    string[] dialogues = {"드디어!! 부엌인가!! 드디어..! 내가 왕이 되.. ", "꺄악 왕자님!!! ", "뭐...뭐지??? 저... 해괴망측한 음식은??? ","까아ㅏ악!! 파스타 왕자님!!!! ", "(뭐??? 파스타??? 대장금께서도... 한번도 알려주신 적 없는 음식인데???) ", "(설마... 양(洋)의 것인가?? 어째서 왕의 자리인 저 자리에???) ", "어째서 거기 있을 수 있는거냐!!!! ", "One's desires are insatiable ", "뭐..뭣..?? 뭐래는 거냐!!!! ", "'사람의 욕망은 만족할 줄 모른다.' 영어도 모르는거냐. 우매하군. ", "사람은 음식에게 어떤 것을 가장 높이 평가한다고 생각하는가? ", "그건... 당연히... 합리적인 가격이 아니겠어?? ", "그럼.. 나는 합리적인 가격인 것인가? ", "(보자... 가격이... 말도 안돼!! 16000원?? 저딴 게 어떻게 왕에 자리에???) ", "꺄아ㅏ악! 왕자님!!! ", "(잔치국수는 4500원에도 먹는데, 저딴 면쪼까리랑 뭐가 다르다고 저 가격에 열광하는 거지??) ", "가장 높은 가치는..... ", "분위기다. ","만족할 줄 모르는 인간은 이제 맛과 모양과 가격보다.. 분위기를 따지게 된 것이다. ", "거짓말치지 마!! 대장금께서 음식은 모든 인간을 보살피는 존재랬어!! 너같은 가격은 그저 상류층을 위한 것일 뿐이야! ", "뭐..? 분위기라면...! 음식을 먹는 그 자체로 행복한! 그게 분위... ", "우매하군 우매해. ", "음식은 이제... '먹기만' 해서는 안돼... ", "뭐???? 무슨 소리지??? ", "가르쳐주지.. 덤벼라. "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "?????", "김밥", "?????", "김밥", "김밥", "김밥", "파스타", "김밥", "파스타", "파스타", "김밥", "파스타", "김밥", "?????", "김밥", "파스타", "파스타", "파스타", "김밥",  "파스타", "김밥", "파스타", "파스타", "김밥", "파스타"};
    public Image[] characterImage;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 0, 2, 0, 2, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 2, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1};
 
    public GameObject BlackOut;
    private Coroutine typingCoroutine;

    void Update()
    {
        // Check if the mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {

            // Check if there are more dialogues to display
            if (currentDialogueIndex2 < dialogues.Length)
            {
                showImage();
                showName();
                ShowDialogue();
                typingCoroutine = StartCoroutine(_typing(dialogues[currentDialogueIndex2 -1]));
                // Display the next dialogue


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



    IEnumerator _typing(string currentDialogue)
    {
         for (int i = 0; i < currentDialogue.Length; i++)
            {

                dialogueText.text = currentDialogue.Substring(0, i);


            yield return new WaitForSeconds(0.15f);


            }


    }

    void SetScene()
    {
        SceneManager.LoadScene("제육2");
    }
}
