using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    //specifies the door to open
    [SerializeField] GameObject door;
    //specifies the distance it will be traversing, put negatives to go down
    [SerializeField] float heightDistance = 1f;
    // idk what the unit is in lol
    [SerializeField] float timeTaken = 3f;
    // 
    [SerializeField] bool isRetractable = false;
    //tracks the time
    float timer = 0f;
    bool isOpen = false;
    Vector2 startPosition, endPosition, difference;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //sets isopen to true once collided
        isOpen = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isRetractable)
        {
            isOpen = false;
        }
    }
    private void Start()
    {
        startPosition = door.transform.position;
        endPosition = new Vector2 (startPosition.x, startPosition.y + heightDistance);
    }

    private void Update()
    {
        if (isOpen && !isRetractable)
        {
            // timer will increase from 0 to 1 over time
            timer += (timeTaken * Time.deltaTime) / 10;
            door.transform.position = Vector2.Lerp(startPosition, endPosition, timer);  
        }
        
        // increase the height
        else if (isOpen && isRetractable)
        {
            timer += (timeTaken * Time.deltaTime) / 10;
            // lets timer be 1 if it has stepped on the pressure plate for a long time
            if (timer > 1)
            {
                timer = 1;
            }
            door.transform.position = Vector2.Lerp(startPosition, endPosition, timer);
        }
        // decrease the height
        else if (!isOpen && isRetractable)
        {
            timer -= (timeTaken * Time.deltaTime) / 10;
            // lets timer be 0 if it has retracted a long time
            if (timer < 0)
            {
                timer = 0;
            }
            door.transform.position = Vector2.Lerp(startPosition, endPosition, timer);
        }
    }
}
