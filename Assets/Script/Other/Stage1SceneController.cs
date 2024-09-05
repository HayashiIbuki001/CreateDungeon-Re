using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1SceneController : MonoBehaviour
{
    //ステージ選択画面からステージ１に移行する

    public void PushedButton()
    {
        SceneManager.LoadScene("Stage 1");
    }
}
