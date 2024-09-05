using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneController : MonoBehaviour
{
    //ステージ選択画面からステージ１に移行する
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    public void PushedButton()
    {
        SceneManager.LoadScene("Stage 1");
    }
}
