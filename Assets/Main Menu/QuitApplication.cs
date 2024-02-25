using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using Application = UnityEngine.Application;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }        
    }
}
