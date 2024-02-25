using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject interactText;
    public string dialog;
    private string originalDialog;

    public float wordSpeed;
    private bool playerIsClose;
    private bool isTrivia = true;
    private bool isCorrect = false;

    public GameObject option1button; // button located on left
    public GameObject option2button; // button located on right

    [SerializeField] public bool isOption1Correct;

    //variables to lift the barrier
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float timer = 0f;

    [SerializeField] public GameObject barrier;
    [SerializeField] float heightDistance = 0f;
    [SerializeField] float timeTaken = 5f;

    public GameObject closeButton; // button to close the dialog

    private void Start()
    {
        startPosition = barrier.transform.position;
        endPosition = new Vector2(startPosition.x, startPosition.y + heightDistance);

        originalDialog = dialog;
        dialogText.text = "";
    }


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            dialogText.text = "";
            interactText.SetActive(false);
            // dialogPanel.SetActive(true);
            // StartCoroutine(Typing());
            // Typing();

            if (dialogPanel.activeInHierarchy)
            {
                zeroText();
            }

            // if(Input.GetKeyDown(KeyCode.R)){
            //     NextLine();
            // }

            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
            
        }

        if (dialogText.text == dialog)
        {
            if (isTrivia)
            {
                option1button.SetActive(true);
                option2button.SetActive(true);
            }
            else
            {
                closeButton.SetActive(true);
            }

        }

        if (Input.GetKeyDown(KeyCode.R)) // right option
        {
            if (option1button.activeInHierarchy)
            {
                chooseFirst();
            }
            else if (closeButton.activeInHierarchy)
            {
                closePanel();
            }

        }

        else if (Input.GetKeyDown(KeyCode.E)) // left option
        {
            chooseSecond();
        }

        if (isCorrect)
        {
            timer += (timeTaken * Time.deltaTime) / 10;
            barrier.transform.position = Vector2.Lerp(startPosition, endPosition, timer);
        }
    }

    public void zeroText()
    {
        dialogText.text = "";
        dialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void chooseFirst()
    {
        dialogText.text = "";
        option1button.SetActive(false);
        option2button.SetActive(false);

        if (isOption1Correct)
        {
            isTrivia = false;
            dialog = "Jawaban Anda Benar!";
            isCorrect = true;
            StartCoroutine(Typing());
        }
        else
        {
            isTrivia = false;
            dialog = "Jawaban Anda Kurang Tepat!";
            StartCoroutine(Typing());            
        }
    }

    public void chooseSecond()
    {
        dialogText.text = "";
        option1button.SetActive(false);
        option2button.SetActive(false);

        if (!isOption1Correct)
        {
            isTrivia = false;
            isCorrect = true;
            dialog = "Jawaban Anda Benar!";
            StartCoroutine(Typing());
        }
        else
        {
            isTrivia = false;
            dialog = "Jawaban Anda Kurang Tepat!";
            StartCoroutine(Typing());
        }
    }

    public void ResetPanel()
    {
        if (!isCorrect)
        {
            isTrivia = true;
            dialog = originalDialog;
        }

        dialogText.text = "";

        closeButton.SetActive(false);
    }

    public void closePanel()
    {
        if (isCorrect)
        {
            isTrivia = false;
        }

        ResetPanel();
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            interactText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
            interactText.SetActive(false);
        }
    }
}
