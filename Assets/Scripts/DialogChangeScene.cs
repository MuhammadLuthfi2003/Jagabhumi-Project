using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;
using UnityEngine.SceneManagement;

public class DialogChangeScene : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject dialogChangeScene;
    public Text dialogText;
    public GameObject interactText;
    public string[] dialog;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public GameObject contButton;
    public GameObject changeSceneButton;
    public GameObject cancel;
    
    // Update is called once per frame
    [SerializeField] int sceneId;
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.F) && playerIsClose){
            interactText.SetActive(false);

            if(dialogPanel.activeInHierarchy){
                zeroText(); 
            }

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

        else if(index == dialog.Length-1){
            
            dialogPanel.SetActive(false);
            ChangeScene();
            dialogChangeScene.SetActive(true);    
        }

        else{
            zeroText();
        }
    }

    private void ChangeScene(){
        changeSceneButton.SetActive(true);
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
            dialogChangeScene.SetActive(false);
            cancel.SetActive(true);
        }
    }

    public void GoToScene() {
        SceneManager.LoadScene(sceneId);
    }

    public void Cancel(){
        dialogChangeScene.SetActive(false);
        cancel.SetActive(true);
    }
}
