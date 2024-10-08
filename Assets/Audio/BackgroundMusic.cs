using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    #region Assigning
    private FMOD.Studio.EventInstance backgroundMusic_Instance;
    public FMODUnity.EventReference backgroundMusic_Event;

    [SerializeField][Range(0f, 1f)]
    private float sceneNumber;
    private float MenuMusicNumber = 0f;
    private float MainGameNumber = 1f;

    private Scene currentScene;
    private string currentSceneName;
    #endregion

    private void Start() 
    {
        DontDestroyOnLoad(this.gameObject);
        backgroundMusic_Instance = FMODUnity.RuntimeManager.CreateInstance (backgroundMusic_Event);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(backgroundMusic_Instance, GetComponent<Transform>(), GetComponent<Rigidbody>());
        sceneNumber = MenuMusicNumber;
        backgroundMusic_Instance.setParameterByName("WhatIsPlaying", sceneNumber);
        backgroundMusic_Instance.start();
    }


    //Call when scenes change
    public void SceneChangeMusic()
    {
        Debug.Log("MainGame scene");
        sceneNumber = MainGameNumber;
        backgroundMusic_Instance.setParameterByName("WhatIsPlaying", sceneNumber);
    }
}
