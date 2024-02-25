using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemorySwitch : MonoBehaviour
{

    //initialize a list full of levers and lights to put onto the linkedlist
    [SerializeField] List<LeverDetect> Lever = new List<LeverDetect> ();
    [SerializeField] List<Lights> Lights = new List<Lights>();

    //README : THE AMOUNT OF LIGHTS AND LEVERS MUST BE THE SAME

    //refrencing the barrier
    [SerializeField] GameObject door;

    //extra helper variables
    bool isSolved = false;
    bool startSequence = false;
    int activateStage = 0; 
    int playerActivate = 0; // the index of switch that the player has activated, if wrong, wont add up 1
    
    // Start is called before the first frame update
    void Start()
    {



        
    }

    // Update is called once per frame
    void Update()
    {
        if (startSequence)
        {
            if(Time.time % 5 == 0)
            {

            }

            
        }    
    }

    // start the sequence when the player enters the collision box
    private void OnTriggerEnter2D(Collider2D collision)
    {
        startSequence = true;
        activateStage = 0;
        playerActivate = 0;
    }

    // stops the sequence and reset when the player exits the collision box
    // dont reset when the player has solved the puzzle
    private void OnTriggerExit2D(Collider2D collision)
    {
        startSequence = false;
    }


}
