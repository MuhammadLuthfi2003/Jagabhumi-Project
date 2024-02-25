using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelComplete : MonoBehaviour
{
    public GameObject panelToShow;
    public GameObject[] panelToHide;
    public GameObject bgToHide;
    public GameObject bgToShow;
    public GameObject transitionBg;
    public GameObject Character;
    public GameObject AudioToDisable;
    public GameObject AudioToEnable;

    private bool hasComplete = false;
    private bool hasFadeIn = false; // fade from 0 to 1
    private bool hasFadeOut = false; // fade from 1 to 0
    private float timer = 0f;

    [SerializeField] float timeToFade = 3f;
    [SerializeField] float cameraMovementSpeed = 3f;
    [SerializeField] Vector3 cameraMoveDistance;
    [SerializeField] float timerLimit = 100f;

    private void Update()
    {
        // set visibility from 0 to 1 slowly
        if (hasComplete && !hasFadeIn)
        {
            //start fade
            Character.SetActive(false);
            transitionBg.SetActive(true);
            //from 0 to 1
            timer += (timeToFade * Time.deltaTime) / 30;

            transitionBg.GetComponent<CanvasGroup>().alpha += timer;
            AudioToDisable.GetComponent<AudioSource>().volume -= timer;

            if (transitionBg.GetComponent<CanvasGroup>().alpha >= 1)
            {
                timer = 0;
                hasFadeIn = true;
                AudioToDisable.SetActive(false);
            }
        }

        if (AudioToEnable.activeInHierarchy)
        {
            if (!AudioToEnable.GetComponent<AudioSource>().isPlaying)
            {
                AudioToEnable.GetComponent<AudioSource>().Play();
            }
        }

        if (hasComplete && hasFadeIn && !hasFadeOut)
        {
            SwapBG();
            AudioToEnable.SetActive(true);

            //start fade out
            timer += (timeToFade * Time.deltaTime) / 30;

            transitionBg.GetComponent<CanvasGroup>().alpha -= timer;

            if (AudioToEnable.GetComponent<AudioSource>().volume < 0.8)
            {
                AudioToEnable.GetComponent<AudioSource>().volume += timer;
            }

            if (transitionBg.GetComponent<CanvasGroup>().alpha <= 0)
            {
                timer = 0;
                hasFadeOut = true;
            }
        }

        if (hasComplete && hasFadeIn && hasFadeOut)
        {
            transitionBg.SetActive(false);
            //move the camera left
            timer += (cameraMovementSpeed * Time.deltaTime) / 30;

            if (timer < timerLimit)
            {
                Camera.main.transform.position += new Vector3(cameraMoveDistance.x * timer, cameraMoveDistance.y * timer, cameraMoveDistance.z * timer);
            }

            StartCoroutine(swapUI());
        }
    }

    IEnumerator swapUI()
    {
        yield return new WaitForSeconds(5);
        SwapPanel();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasComplete = true;
    }

    private void SwapPanel()
    {
        foreach (GameObject panel in panelToHide)
        {
            panel.SetActive(false);
        }
        panelToShow.SetActive(true);
    }

    private void SwapBG()
    {
        bgToHide.SetActive(false);
        bgToShow.SetActive(true);
    }

}
