using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ��ġ��script : MonoBehaviour
{   public GameObject BlackMove;
    public GameObject BlackOut;
    public Text dialogueText;
    public AudioSource scriptSound;
    

    public Text nameText;// Reference to your UI Text component

    string first = "������ ���� �Ƿ� ������!! ";
    string[] dialogues = { "���!!! ", 
        "��� �� �Ļ縶�� �ȳ����� ���� ������ ���� �Ƿ� ��!!! ", "����!! �ʵ� ������ �����ڰ� �ǰ� �����ų�!! ",
    "�翬����!! ��ġ ������ ���ĵ��� �Ѿ�⳪ ��???", "��𿡳� �־���ϴ� ���簡 �翬�� �������� ���� �ƴϰھ�? ","ũ��...��¿ �� ����.... ���� ��Ʋ�� ����!!! ","��! �翬�� ���� �¸���!!! "}; // Array of dialogues to display  //�� �����̽��� �������� �����ּ���
    string[] namepanel = {  "???", "��ġ","���","��ġ","��ġ","���","��ġ"  };
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
            //scriptSound.Play();

            dialogueText.text = currentDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��
            
            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��
        
            

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
        string currentname = "���";

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
            
            dialogueText.text = firstDialogue.Substring(0, i); // ���� �ε��������� ���ڿ��� ǥ��
            //scriptSound.Play();
            yield return new WaitForSeconds(0.05f); // 0.05�ʸ��� �� ���ھ� ǥ��
           

        }
        isTyping = false;



    }

    void SetScene()
        {
            SceneManager.LoadScene("��ġ2");
        }
    }



    
