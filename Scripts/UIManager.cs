using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int activeScene;


    private void Start()
    {
        activeScene = SceneManager.GetActiveScene().buildIndex;
        //Debug.Log(activeScene);

    }
    //Resets game progress and progress to first level
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("level", SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }
    //Load main menu scene
    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }

    //Restarts current level
    public void Resume()
    {
        SceneManager.LoadScene(activeScene);
    }

    public void NextLevel()
    {
        activeScene++;
        SceneManager.LoadScene(activeScene);
    }


    public void PlayLvl1()
    {
        SceneManager.LoadScene(1);

    }

    public void PlayLvl2()
    {
        SceneManager.LoadScene(2);

    }    

}
