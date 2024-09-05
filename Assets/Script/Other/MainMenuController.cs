using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpMenuCanvas; // 操作説明の Canvas
    public GameObject titleText;
    public GameObject startButton;
    public GameObject helpButton;

    // 操作説明ボタンが押されたときに呼び出されるメソッド
    public void OpenHelpMenu()
    {
        // 操作説明画面を表示
        helpMenuCanvas.SetActive(true);
        titleText.SetActive(false);
        startButton.SetActive(false);
        helpButton.SetActive(false);
    }

    // 操作説明画面を閉じるメソッド
    public void CloseHelpMenu()
    {
        // 操作説明画面を非表示
        helpMenuCanvas.SetActive(false);
        titleText.SetActive(true);
        startButton.SetActive(true);
        helpButton.SetActive(true);
    }
}
