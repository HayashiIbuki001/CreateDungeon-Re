using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonClickSound; // �{�^�����������Ƃ��̌��ʉ�
    private AudioSource audioSource;   // AudioSource�R���|�[�l���g
    public float delayBeforeSceneChange = 0.5f; // �V�[���J�ڂ̑O�ɑ҂���

    void Awake()
    {
        // AudioSource�R���|�[�l���g��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // �^�C�g����ʂ���X�e�[�W�I����ʂɈڍs����
    public void SelectButton()
    {
        // �{�^�����������Ƃ��̏������R���[�`���ōs��
        StartCoroutine(PlaySoundAndChangeScene("StageSelectScene"));
    }

    private IEnumerator PlaySoundAndChangeScene(string sceneName)
    {
        // ���ʉ����Đ�
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        // ���ʉ����Đ�����鎞�Ԃ����ҋ@
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // �V�[����ύX
        SceneManager.LoadScene(sceneName);
    }
}
