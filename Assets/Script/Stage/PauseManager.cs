using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // �|�[�Y��ʂ� Panel
    private bool isPaused = false; // �Q�[�����|�[�Y����Ă��邩�ǂ����̃t���O

    void Update()
    {
        // Esc�L�[�������ꂽ�Ƃ��Ƀ|�[�Y�̕\���E��\����؂�ւ���i�K�v�ɉ����āj
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused); // �|�[�Y��ʂ̕\���E��\����؂�ւ�
        Time.timeScale = isPaused ? 0 : 1; // �Q�[���̐i�s���ꎞ��~
    }

    // �ĊJ�{�^���������ꂽ�Ƃ��ɌĂяo��
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1; // �Q�[���̐i�s���ĊJ
    }

    // �^�C�g���ɖ߂�{�^���������ꂽ�Ƃ��ɌĂяo��
    public void ReturnToTitle()
    {
        Time.timeScale = 1; // �Q�[���̐i�s���ĊJ
        SceneManager.LoadScene("TitleScene");
    }

    // �X�e�[�W�I����ʂɖ߂�{�^���������ꂽ�Ƃ��ɌĂяo��
    public void ReturnToStageSelect()
    {
        Time.timeScale = 1; // �Q�[���̐i�s���ĊJ
        SceneManager.LoadScene("StageSelectScene"); // �X�e�[�W�I���V�[���̖��O�ɍ��킹�ĕύX
    }
}
