using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ��ġ��script : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;// Reference to your UI Text component
    string[] dialogues = { "������ ���� �Ƿ� ������!! ", "���!!! ", 
        "��� �� �Ļ縶�� �ȳ����� ���� ������ ���� �Ƿ� ��!!! ", "����!! �ʵ� ������ �����ڰ� �ǰ� �����ų�!! ",
    "�翬����!! ��ġ ������ ���ĵ��� �Ѿ�⳪ ��???", "��𿡳� �־���ϴ� ���簡 �翬�� �������� ���� �ƴϰھ�? ","ũ��...��¿ �� ����.... ���� ��Ʋ�� ����!!! ","��! �翬�� ���� �¸���!!! "}; // Array of dialogues to display  //�� �����̽��� �������� �����ּ���
    string[] namepanel = { "���", "???", "��ġ","���","��ġ","��ġ","���","��ġ"  };
    public Image[] characterImage;
    private int exnumber = 0;
    private int currentDialogueIndex1 = 0;
    private int currentDialogueIndex2 = 0;
    int[] imageNumber = { 0, 1, 1, 0,0,0,0, 0 };

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
                typingCoroutine = StartCoroutine(_typing(dialogues[currentDialogueIndex2 - 1]));
                // Display the next dialogue


            }

            else
            {
                //BlackOut.SetActive(true);
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
            SceneManager.LoadScene("��ġ2");
        }
    }



    
