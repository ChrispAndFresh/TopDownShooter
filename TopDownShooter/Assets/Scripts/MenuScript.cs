using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Dominic Paxson
 * 12/2/25
 * Handles menu and button mechanics
 */

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
