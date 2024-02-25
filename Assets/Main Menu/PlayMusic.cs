using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{

    static PlayMusic instance = null;

    void Awake()
    {
        /*
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        */
        PlayMusic[] playMusics = FindObjectsOfType<PlayMusic>();
        int numOfMusicPlayers = FindObjectsOfType<PlayMusic>().Length;

        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        if (numOfMusicPlayers == 0)
        {
            Instantiate(gameObject);
        }

        //playMusics[0].GetComponent<AudioSource>().Play();
        Debug.Log(playMusics.Length);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    /*
    //


    else
    {
        DontDestroyOnLoad(gameObject);
    }
    */

}



