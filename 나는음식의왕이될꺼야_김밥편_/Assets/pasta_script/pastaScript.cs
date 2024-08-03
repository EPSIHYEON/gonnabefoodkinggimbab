using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pastaScript : MonoBehaviour
{
    public GameObject All;
    public GameObject BlackOut;
    public GameObject BlackMove;
    //public Image pasta;
    public Text dialogueText;
    public Text nameText;
    string Secondphase = "크흑... 하지만.. 이건 어떠냐!! ";
   //string[] dialogues = {  "당신한테는 부족한 점이 있어 ",
    public Image[] characterImage;
    private bool isTyping = false;
    //private int exnumber = 0;
    //private int currentDialogueIndex1 = 0;
    //private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 1, 1 };


    private Coroutine typingCoroutine;
    void Start()
    {

        //pasta.gameObject.SetActive(true);
        SecondphaseName();
        SecondphaseDialogue();
        StartCoroutine(Secondphasetyping(Secondphase));

        All.SetActive(false);
       // pasta.gameObject.SetActive(false);
    }


    void SecondphaseDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = Secondphase;


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        // Move to the next dialogue in the array

        Debug.Log("문자");
    }
    void SecondphaseName()
    {
        string currentname = "파스타";

        nameText.text = currentname;


        Debug.Log("문자2");
    }

    void SecondphaseImage()
    {



    
            characterImage[1].gameObject.SetActive(true);
      


    }


    IEnumerator Secondphasetyping(string SecondphaseDialogue)
    {
        isTyping = true;
        for (int i = 0; i <= SecondphaseDialogue.Length; i++)
        {

            dialogueText.text = SecondphaseDialogue.Substring(0, i); // 현재 인덱스까지의 문자열을 표시

            yield return new WaitForSeconds(0.05f); // 0.05초마다 한 글자씩 표시


        }
        isTyping = false;



    }

}
