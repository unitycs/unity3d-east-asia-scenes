using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public static AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
    }

    public void ButtonFunc_StartGame()
    {
        //SceneManager.LoadScene(1);
        async.allowSceneActivation = true;
    }

    public void ButtonFunc_Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(async.progress);
    }
}
