using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; // ポーズ画面の Panel
    private bool isPaused = false; // ゲームがポーズされているかどうかのフラグ

    void Update()
    {
        // Escキーが押されたときにポーズの表示・非表示を切り替える（必要に応じて）
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused); // ポーズ画面の表示・非表示を切り替え
        Time.timeScale = isPaused ? 0 : 1; // ゲームの進行を一時停止
    }

    // 再開ボタンが押されたときに呼び出す
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1; // ゲームの進行を再開
    }

    // タイトルに戻るボタンが押されたときに呼び出す
    public void ReturnToTitle()
    {
        Time.timeScale = 1; // ゲームの進行を再開
        SceneManager.LoadScene("TitleScene");
    }

    // ステージ選択画面に戻るボタンが押されたときに呼び出す
    public void ReturnToStageSelect()
    {
        Time.timeScale = 1; // ゲームの進行を再開
        SceneManager.LoadScene("StageSelectScene"); // ステージ選択シーンの名前に合わせて変更
    }
}
