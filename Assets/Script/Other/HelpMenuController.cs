using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenuController : MonoBehaviour
{
    public GameObject[] pages; // ��������̊e�y�[�W�̃p�l��
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
        // ���̃y�[�W�֐i��
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetMouseButtonDown(1))
        {
            NextPage();
        }

        // �O�̃y�[�W�֖߂�
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetMouseButtonDown(0))
        {
            PreviousPage();
        }

        // ���������ʂ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseHelpMenu();
        }
    }

    // ���̃y�[�W��\������
    void NextPage()
    {
        if (currentPageIndex < pages.Length - 1)
        {
            currentPageIndex++;
            ShowPage(currentPageIndex);
        }
    }

    // �O�̃y�[�W��\������
    void PreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            ShowPage(currentPageIndex);
        }
    }

    // �w�肳�ꂽ�y�[�W��\������
    void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == pageIndex);
        }
    }

    // ���������ʂ����
    void CloseHelpMenu()
    {
        // Help�I�u�W�F�N�g���\���ɂ���A�܂��͕K�v�ɉ����ăV�[����؂�ւ���
        gameObject.SetActive(false);

        titleText.SetActive(true);
        startButton.SetActive(true);
        helpButton.SetActive(true);
    }
}
