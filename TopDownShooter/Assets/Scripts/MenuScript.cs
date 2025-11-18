using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(1);
    }




}
