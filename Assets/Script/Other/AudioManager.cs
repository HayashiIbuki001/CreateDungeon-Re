using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // �{�^���������ꂽ�Ƃ��̌��ʉ�
    private AudioSource audioSource;   // AudioSource�R���|�[�l���g

    void Awake()
    {
        // AudioSource�R���|�[�l���g��ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // ���ʉ����Đ����郁�\�b�h
    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
