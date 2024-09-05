using UnityEngine;
using UnityEngine.UI;

public class HelpMenuController : MonoBehaviour
{
    public GameObject[] helpPages;  // 各ページのパネルを格納する配列
    public Button nextButton;       // 次のページへボタン
    public Button previousButton;   // 前のページへボタン
    private int currentPageIndex = 0; // 現在表示中のページインデックス

    void Start()
    {
        UpdatePage(); // 初期状態のページを表示
    }

    // 次のページに進む
    public void ShowNextPage()
    {
        if (currentPageIndex < helpPages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    // 前のページに戻る
    public void ShowPreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }

    // 現在のページを更新して表示
    private void UpdatePage()
    {
        // 全てのページを非表示にしてから、現在のページのみ表示する
        for (int i = 0; i < helpPages.Length; i++)
        {
            helpPages[i].SetActive(i == currentPageIndex);
        }

        // ボタンの有効・無効を更新
        nextButton.interactable = (currentPageIndex < helpPages.Length - 1);
        previousButton.interactable = (currentPageIndex > 0);
    }
}
