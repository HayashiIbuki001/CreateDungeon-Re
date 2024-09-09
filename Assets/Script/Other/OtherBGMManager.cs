using UnityEngine;

public class OtherBGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // 設定するBGMのAudioClip
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceをシーンのBGM設定用に作成
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgmClip;
        audioSource.loop = true; // BGMをループ再生
        audioSource.playOnAwake = false; // 自動再生しないように設定

        // BGMを再生
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
