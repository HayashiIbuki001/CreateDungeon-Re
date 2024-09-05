using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuController : MonoBehaviour
{
    public GameObject[] pages; // 操作説明の各ページのパネル
    private int currentPageIndex = 0;

    public GameObject titleText;
    public GameObject startButton;
    public GameObject helpButton;

    void Start()
    {
        ShowPage(currentPageIndex);
    }

    void Update()
    {
        // 次のページへ進む
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1))
        {
            NextPage();
        }

        // 前のページへ戻る
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetMouseButtonDown(0))
        {
            PreviousPage();
        }

        // 操作説明画面を閉じる
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseHelpMenu();
        }
    }

    // 次のページを表示する
    void NextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            currentPageIndex++;
            ShowPage(currentPageIndex);
        }
    }

    // 前のページを表示する
    void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            ShowPage(currentPageIndex);
        }
    }

    // 指定されたページを表示する
    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }

    // 操作説明画面を閉じる
    void CloseHelpMenu()
    {
        // Helpオブジェクトを非表示にする、または必要に応じてシーンを切り替える
        gameObject.SetActive(false);

        titleText.SetActive(true);
        startButton.SetActive(true);
        helpButton.SetActive(true);
    }
}
