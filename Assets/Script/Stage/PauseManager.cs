using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // ポーズ画面の Panel
    private bool isPaused = false; // ゲームがポーズされているかどうかのフラグ

    public AudioClip buttonClickSound; // ボタンを押したときの効果音
    public AudioSource audioSource; // AudioSource コンポーネント

    void Start()
    {
        // AudioSource コンポーネントを追加または取得
        audioSource = gameObject.AddComponent<AudioSource>();
        // 効果音の設定
        if (buttonClickSound != null)
        {
            audioSource.clip = buttonClickSound;
        }
    }

    void Update()
    {
        // Escキーが押されたときにポーズの表示・非表示を切り替える（必要に応じて）
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        //audioSource.enabled = true;
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused); // ポーズ画面の表示・非表示を切り替え
        Time.timeScale = isPaused ? 0 : 1; // ゲームの進行を一時停止
        audioSource.PlayOneShot(buttonClickSound); // 効果音を再生

        if (!audioSource.enabled)
        {
            Debug.LogWarning("この警告は無視してね");
        }
    }

    // 再開ボタンが押されたときに呼び出す
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1; // ゲームの進行を再開
        //audioSource.PlayOneShot(buttonClickSound);
    }

    // タイトルに戻るボタンが押されたときに呼び出す
    public void ReturnToTitle()
    {
        Time.timeScale = 1; // ゲームの進行を再開
        SceneManager.LoadScene("TitleScene");
        //audioSource.PlayOneShot(buttonClickSound);
    }

    // ステージ選択画面に戻るボタンが押されたときに呼び出す
    public void ReturnToStageSelect()
    {
        Time.timeScale = 1; // ゲームの進行を再開
        SceneManager.LoadScene("StageSelectScene"); // ステージ選択シーンの名前に合わせて変更
        //audioSource.PlayOneShot(buttonClickSound);
    }
}
