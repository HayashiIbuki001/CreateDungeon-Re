using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    //�^�C�g����ʂ���X�e�[�W�I����ʂɈڍs����

    public void SelectButton()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
