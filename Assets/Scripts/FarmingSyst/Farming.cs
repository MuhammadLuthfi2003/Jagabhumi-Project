using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farming : MonoBehaviour
{
    public int tanaman = 0;
    public bool playerIsClose;
    public GameObject interactTanaman;
    public GameObject gerobakIsi;
    public GameObject gerobakKosong;
    [SerializeField] public Text textTanaman;
    [SerializeField] private AudioSource tanamSound;

    void Update(){
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose){

            while(tanaman < 11){
                textTanaman.text = ":" + tanaman;
                tanaman++; 
                gerobakIsi.SetActive(false);
                gerobakKosong.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = true;
            interactTanaman.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = false;
            interactTanaman.SetActive(false);
        }
    }
}
