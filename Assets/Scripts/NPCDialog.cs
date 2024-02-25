using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text dialogText;
    public GameObject interactText;
    public string[] dialog;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public GameObject contButton;
    
    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F) && playerIsClose){
            interactText.SetActive(false);

            // dialogPanel.SetActive(true);
            // StartCoroutine(Typing());
            // Typing();

            if(dialogPanel.activeInHierarchy){
                zeroText();
                
            }

            // if(Input.GetKeyDown(KeyCode.R)){
            //     NextLine();
            // }
            
            else{
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());

                
            }
        }

        if(dialogText.text == dialog[index]){
            contButton.SetActive(true);
        }

        // if(Input.GetKeyDown(KeyCode.R)){
        //     NextLine();
        // }
    }

    public void zeroText(){
        dialogText.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }

    IEnumerator Typing(){
        foreach(char letter in dialog[index].ToCharArray()){
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine(){

        contButton.SetActive(false);

        if(index < dialog.Length-1){
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else{
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            playerIsClose = true;
            interactText.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            playerIsClose = false;
            zeroText();
            interactText.SetActive(false);
        }
    }
}
