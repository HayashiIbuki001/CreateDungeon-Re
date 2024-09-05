using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    //タイトル画面からステージ選択画面に移行する

    public void SelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
