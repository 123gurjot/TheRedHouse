using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Buttons : MonoBehaviour
{
    [SerializeField] private BackgroundMusic backgroundMusic;
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
        backgroundMusic.SceneChangeMusic();
    }

    public void OnQuitButtonClicked() 
    { 
        Application.Quit();
    }
}
