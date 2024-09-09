using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonClickSound; // ボタンが押されたときの効果音
    private AudioSource audioSource;   // AudioSourceコンポーネント

    void Awake()
    {
        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // 効果音を再生するメソッド
    public void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
