using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1SceneController : MonoBehaviour
{
    //�X�e�[�W�I����ʂ���X�e�[�W�P�Ɉڍs����

    public void PushedButton()
    {
        SceneManager.LoadScene("Stage 1");
    }
}
