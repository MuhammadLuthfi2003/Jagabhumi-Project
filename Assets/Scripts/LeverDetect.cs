using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDetect : MonoBehaviour
{
    //access animator
    public Animator animator;
    public bool isActivated = false;
    private bool keyPressed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("isNear", true);        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("isNear", false);
    }

    private void Update()
    {
        keyPressed = Input.GetKeyDown(KeyCode.F);

        if (keyPressed)
        {

            Debug.Log(keyPressed);
            if (!isActivated)
            {
                isActivated = true;
            }
            else if (isActivated)
            {
                isActivated = false;
            }
        }

        SetAnimatorIsActivated();
    }

    private void SetAnimatorIsActivated()
    {
        if (isActivated)
        {
            animator.SetBool("isActivated", true);
        }
        else if (!isActivated)
        {
            animator.SetBool("isActivated", false);
        }
    }
}
