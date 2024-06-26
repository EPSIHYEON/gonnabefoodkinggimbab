using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JY_Script : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;// Reference to your UI Text component
    string[] dialogues = { "허억.. 허억.. 집 안인가.... 이제 곧.. 부엌에 도달할 수 있는건가..? ", "으디서 피도 안 마른 것이 왕이 되려혀!!!!!!!!!!!!!!! ", "아, 아닛 스승님!!! ",
    "그래 이놈아, 겨우겨우 인간 놈들에게 먹히라고 햄 끼워넣어줬더니 뭐??? 왕?????? ", "스승님, 예전에 야채맛 가득 나는 제가 아닙니다!! 제 당근도 이제 볶.은.당.근 이라구요!!!! ",
    "볶.은.당.근??? 난 태생부터 볶는 제육인디 어딜 덤비려 혀!!!!!!!!!!! ", "크흑...! 스승님... 결국... 저는 스승님을 이겨야 나아갈 수 있는 겁니까!! ", "나의 살갖이 다 타버리기 전까진 절대 보내줄수 없는 기야!!!!!!!!! 덤벼라!!!! "}; // Array of dialogues to display  //꼭 스페이스를 마지막에 눌러주세요
    string[] namepanel = { "김밥", "?????" , "김밥", "제육", "김밥", "제육", "김밥", "제육"};
    public Image[] characterImage;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 0, 1, 0, 1, 0, 1, 0, 1};
 
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
