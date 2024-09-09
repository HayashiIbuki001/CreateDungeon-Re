using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneController : MonoBehaviour
{
    public AudioClip buttonClickSound; // �{�^�����������Ƃ��̌��ʉ�
    private AudioSource audioSource;   // AudioSource�R���|�[�l���g
    public float delayBeforeSceneChange = 0.5f; // �V�[���J�ڂ̑O�ɑ҂���

    private void Awake()
    {
        // AudioSource�R���|�[�l���g��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // �X�e�[�W�I����ʂ���X�e�[�W1�Ɉڍs����
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            StartCoroutine(PlaySoundAndChangeScene("TitleScene"));
        }
    }

    public void PushedButton()
    {
        StartCoroutine(PlaySoundAndChangeScene("Stage 1"));
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
