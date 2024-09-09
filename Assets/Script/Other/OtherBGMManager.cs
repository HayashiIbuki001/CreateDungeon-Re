using UnityEngine;

public class OtherBGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // �ݒ肷��BGM��AudioClip
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource���V�[����BGM�ݒ�p�ɍ쐬
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true; // BGM�����[�v�Đ�
        audioSource.playOnAwake = false; // �����Đ����Ȃ��悤�ɐݒ�

        // BGM���Đ�
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
