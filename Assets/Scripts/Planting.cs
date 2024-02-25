using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planting : MonoBehaviour
{
    // private int tanaman;
    public GameObject tanamanObj;
    public bool playerIsClose;
    public Farming Farming;
    public GameObject placeTanaman;
    // [SerializeField] private Text textTanaman;


    void Update()
    {
        if (Farming.tanaman > 0){
            if(Input.GetKeyDown(KeyCode.F) && playerIsClose){
                tanamanObj.SetActive(true);
                
                while(Farming.tanaman > 9){
                    Farming.textTanaman.text = "Plant: " + (Farming.tanaman-1);
                    Farming.tanaman -= 1;
                }
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = true;
            placeTanaman.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = false;
            placeTanaman.SetActive(false);
            // tanamanObj.SetActive(false);
        }
    }
}
