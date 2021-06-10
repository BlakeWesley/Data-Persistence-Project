using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] Text highScoreText;

    private void Start()
    {
        highScoreText.text = KeepData.Instance.highScoreInfo;
        username.text = KeepData.Instance.dataToSave.username;
    }


    // Load the main scene when the Play button is pressed
    public void PlayGame()
    {
        KeepData.Instance.dataToSave.username = username.text;
        SceneManager.LoadScene(1); 
    }

    public void StopGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }

}
