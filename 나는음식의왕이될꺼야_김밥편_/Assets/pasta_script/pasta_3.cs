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
    

    public GameObject gimbablaser;

    public Text dialogueText;

    public Text nameText;// Reference to your UI Text component

    string first = "����... ����..? ";
    string[] dialogues = {  "�̰���.. �츮�� '������'��!! ","���� �Ҹ���!!!!!!", "��ü �� ����� ��� '������'�� �����Ĵ� ���̳�!!!!!! ", "��ǳ�� ����.. ����ݴԲ����� ������ ���ϼ��� ",
        "������ ����� Ȱ���� �� ���ʳ�?","���� �����", "��ǳ ������ ��信�Ը� �ָ��� ���־����ϱ� ���̾�.. ",
        "������, �Ա⵵ ���ϰ�, ����ҵ� ǳ���� ����� ��ǳ�� �ָ�޴� �� �翬����.. ","��ġ�� ����ݴԲ����� �װ��� �ƽð�, ����̿��� �ɷ��� �̴ּ� ",
        "�װ��� �ٷ�... '��θ� �����ϴ� �ɷ�'�̴�!! "
       ,"���� ��ǳ���� ����� �����̴°� �Ƴ�! ","����� ��θ� �����̰� �ϴ� ���̴�!! " ,"��ǳ��... ��ο� �Բ��ϴ� �߾��̴ϱ�!!!!! ",
        "��ο� �Բ��ϴ� �� '������'�� �ʴ� ����ϴٰ� �ϴ� ���̳�!!!!!!!! " };
    // Array of dialogues to display  //�� �����̽��� �������� �����ּ���
    string[] namepanel = { "��ġ�������", "�Ľ�Ÿ", "�Ľ�Ÿ", "��ġ", "�����","��ġ", "��ġ","��ġ", "����","����",  "��ġ�������", 
        "��ġ�������", "��ġ�������","��ġ�������" };
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


        // Move to the next dialogue in the array

        Debug.Log("����");
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
                    yield return new WaitForSeconds(0.2f); // ������ ǥ��
                }
                else
                {
                    dialogueText.text = currentDialogue.Substring(0, i);
                    yield return new WaitForSeconds(0.005f);
                }
            }

            else
            {
                dialogueText.text = currentDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��
            }

            if (!soundPlayed && currentDialogue == dialogues[9] && i == 10)
            {
                Effectsound.Play();
                soundPlayed = true; // Ensure the sound plays only once
            }

            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��


        }
        isTyping = false;



    }

    void firstshowName()
    {
        string currentname = "�Ľ�Ÿ";

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
           if (i < firstDialogue.Length && firstDialogue[i] != ' ')
            {
                typingsound.Play();
            }

            dialogueText.text = firstDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��

            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��


        }
        isTyping = false;



    }

    void SetScene()
    {
        SceneManager.LoadScene("�Ľ�Ÿ3");
    }
}
