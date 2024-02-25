using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainLevel : MonoBehaviour
{
    [SerializeField] int SceneId;
    public void LoadGame()
    {
        //resumes the flow of the game before going to another scene

        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene(SceneId);
    }
}
