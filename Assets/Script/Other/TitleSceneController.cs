using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonClickSound; // ボタンを押したときの効果音
    private AudioSource audioSource;   // AudioSourceコンポーネント
    public float delayBeforeSceneChange = 0.5f; // シーン遷移の前に待つ時間

    void Awake()
    {
        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // タイトル画面からステージ選択画面に移行する
    public void SelectButton()
    {
        // ボタンを押したときの処理をコルーチンで行う
        StartCoroutine(PlaySoundAndChangeScene("StageSelectScene"));
    }

    private IEnumerator PlaySoundAndChangeScene(string sceneName)
    {
        // 効果音を再生
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        // 効果音が再生される時間だけ待機
        yield return new WaitForSeconds(delayBeforeSceneChange);

        // シーンを変更
        SceneManager.LoadScene(sceneName);
    }
}
