using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pastaScript1 : MonoBehaviour
{
    public GameObject panel;
    public GameObject BlackOut;
    public GameObject BlackMove;
    public GameObject pboss;
    public GameObject babbullet;
   
    public Text dialogueText;

    public Text nameText;// Reference to your UI Text component

    string first = "��¼��? ����.. ���� �� ����...! ";
    string[] dialogues = {  "��.. �ᱹ.. ��������ΰǰ�... ","���!!! ", "....?","��ŵ���..?","�츮�� �ִٴ� ���� �ؾ���???? ","..����? �� ������ ���� �͵���?? "
    ,"���� �����ϱ⿡�� �̸���! �츮���Դ� '�װ�'�� ������!! ","��..? '�װ�'��... ��ü ����? ","�Ľ�Ÿ�� �� �� ����... ��� �ʸ��� �� �� �ִ� ��! ", "������ �� �� �ִ�... "}; // Array of dialogues to display  //�� �����̽��� �������� �����ּ���
    string[] namepanel = { "���", "???", "���", "���", "��ġ & ����", "�Ľ�Ÿ", "����", "���", "��ġ", " ���" };
    public Image[] characterImage;
    private bool isTyping = false;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;

    int[] imageNumber = { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 };


    private Coroutine typingCoroutine;

    void Start()
    {
        pboss.SetActive(true);
        babbullet.SetActive(false);
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
                BlackMove.SetActive(true);
                SetScene();

            }
        }
    }


    void firstShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = first;


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        // Move to the next dialogue in the array

        Debug.Log("����");
    }



    void ShowDialogue()
    {
        // Get the next dialogue from the array
        string currentDialogue = dialogues[currentDialogueIndex2];


        // Update the text component with the current dialogue
        dialogueText.text = currentDialogue;


        // Move to the next dialogue in the array
        currentDialogueIndex2++;
        Debug.Log("����");
    }
    void showName()
    {
        string currentname = namepanel[currentDialogueIndex1];

        nameText.text = currentname;

        currentDialogueIndex1++;
        Debug.Log("����2");
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


            dialogueText.text = currentDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��

            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��


        }
        isTyping = false;



    }

    void firstshowName()
    {
        string currentname = "���";

        nameText.text = currentname;


        Debug.Log("����2");
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

            dialogueText.text = firstDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��

            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��


        }
        isTyping = false;



    }

    void SetScene()
    {
        SceneManager.LoadScene("pasta3");
    }
}
