using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planting8 : MonoBehaviour
{
    // private int tanaman;
    public GameObject tanamanObj;
    public bool playerIsClose;
    public Farming Farming;
    public GameObject placeTanaman;
    [SerializeField] private GameObject nomer;
    // [SerializeField] private Text textTanaman;


    void Update()
    {
        if (Farming.tanaman > 0){
            if(Input.GetKeyDown(KeyCode.F) && playerIsClose){
                
                
                if(Farming.tanaman > 2 && Farming.tanaman < 4){
                    Farming.textTanaman.text = ":" + (Farming.tanaman-1);
                    Farming.tanaman -= 1;
                    tanamanObj.SetActive(true);
                }
                // else{
                //     tanamanObj.SetActive(false);
                // }
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = true;
            placeTanaman.SetActive(true);
            nomer.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            playerIsClose = false;
            placeTanaman.SetActive(false);
            nomer.SetActive(false);
            // tanamanObj.SetActive(false);
        }
    }
}
