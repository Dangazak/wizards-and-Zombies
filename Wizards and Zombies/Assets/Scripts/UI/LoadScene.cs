using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public int sceneIndex;

    public void LoadSceneWithIndex()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }
}
