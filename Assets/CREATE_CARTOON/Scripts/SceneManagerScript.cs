using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void NextSceneString(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void NextSceneIndex(int indx)
    {
        SceneManager.LoadScene(indx);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
}
