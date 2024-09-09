using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioClip bgmClip; // BGM用のAudioClip
    public AudioSource audioSource; // BGM再生用のAudioSource

    void Awake()
    {
        // AudioSourceコンポーネントを追加または取得
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSourceの設定
        audioSource.clip = bgmClip;
        audioSource.loop = true; // ループ再生する
        audioSource.playOnAwake = false; // 起動時には再生しない
    }

    // BGMの再生を開始する
    public void PlayBGM()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // BGMの再生を停止する
    public void StopBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    // BGMの一時停止
    public void PauseBGM()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // BGMの再開
    public void ResumeBGM()
    {
        if (audioSource != null && audioSource.time > 0)
        {
            audioSource.UnPause();
        }
    }
}
