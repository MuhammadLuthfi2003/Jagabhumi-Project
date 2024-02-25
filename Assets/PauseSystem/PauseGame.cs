using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField] GameObject panelToShow;
    [SerializeField] GameObject panelToHide;
    [SerializeField] GameObject CanvasToPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void setIsPaused()
    {
        isPaused = !isPaused;
    }

    public void setPanel()
    {
        panelToHide.SetActive(false);
        panelToHide.GetComponent<CanvasGroup>().alpha = 0;
        panelToHide.GetComponent<CanvasGroup>().interactable = false;
  
        panelToShow.GetComponent<CanvasGroup>().alpha = 1;
        panelToShow.GetComponent<CanvasGroup>().interactable = true;
        panelToShow.SetActive(true);
    }


}
