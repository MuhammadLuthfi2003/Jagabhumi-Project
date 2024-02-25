using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    [SerializeField] public GameObject light; // the illumination
    [SerializeField] public GameObject bulb; // the thing
    public Animator animator; // the thing to animate while its on

    // Start is called before the first frame update
    void Start()
    {
        // deactivate the light from the start
        light.GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLights()
    {
        light.GetComponent<Light>().enabled = true;
        animator.SetBool("isActivated", true);
    }

    public void DeactivateLights()
    {
        light.GetComponent <Light>().enabled = false;
        animator.SetBool("isActivated", false);
    }

    
}
