using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingArea : MonoBehaviour
{
    
    public GameObject plant;
    public GameObject textPlant;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            plant.SetActive(true);
            textPlant.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            plant.SetActive(false);
            textPlant.SetActive(false);
        }
    }
}
