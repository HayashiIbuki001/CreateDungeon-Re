using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectSceneController : MonoBehaviour
{
    public AudioClip buttonClickSound; // ボタンを押したときの効果音
    private AudioSource audioSource;   // AudioSourceコンポーネント
    public float delayBeforeSceneChange = 0.5f; // シーン遷移の前に待つ時間

    private void Awake()
    {
        // AudioSourceコンポーネントを追加
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // ステージ選択画面からステージ1に移行する
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
