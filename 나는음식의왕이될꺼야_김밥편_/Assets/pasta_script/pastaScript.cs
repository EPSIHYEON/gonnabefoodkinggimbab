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
    string Secondphase = "ũ��... ������.. �̰� ���!! ";
   //string[] dialogues = {  "������״� ������ ���� �־� ",
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

        Debug.Log("����");
    }
    void SecondphaseName()
    {
        string currentname = "�Ľ�Ÿ";

        nameText.text = currentname;


        Debug.Log("����2");
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

            dialogueText.text = SecondphaseDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��

            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��


        }
        isTyping = false;



    }

}
