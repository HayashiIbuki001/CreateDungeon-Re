using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneController : MonoBehaviour
{
    //�X�e�[�W�I����ʂ���X�e�[�W�P�Ɉڍs����
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
