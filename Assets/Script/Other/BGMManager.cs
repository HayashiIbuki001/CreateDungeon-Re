using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // BGM�p��AudioClip
    public AudioSource audioSource; // BGM�Đ��p��AudioSource

    void Awake()
    {
        // AudioSource�R���|�[�l���g��ǉ��܂��͎擾
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSource�̐ݒ�
        audioSource.clip = bgmClip;
        audioSource.loop = true; // ���[�v�Đ�����
        audioSource.playOnAwake = false; // �N�����ɂ͍Đ����Ȃ�
    }

    // BGM�̍Đ����J�n����
    public void PlayBGM()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // BGM�̍Đ����~����
    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // BGM�̈ꎞ��~
    public void PauseBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // BGM�̍ĊJ
    public void ResumeBGM()
    {
        if (audioSource != null && audioSource.time > 0)
        {
            audioSource.UnPause();
        }
    }
}
