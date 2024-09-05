using UnityEngine;
using UnityEngine.UI;

public class HelpMenuController : MonoBehaviour
{
    public GameObject[] helpPages;  // �e�y�[�W�̃p�l�����i�[����z��
    public Button nextButton;       // ���̃y�[�W�փ{�^��
    public Button previousButton;   // �O�̃y�[�W�փ{�^��
    private int currentPageIndex = 0; // ���ݕ\�����̃y�[�W�C���f�b�N�X

    void Start()
    {
        UpdatePage(); // ������Ԃ̃y�[�W��\��
    }

    // ���̃y�[�W�ɐi��
    public void ShowNextPage()
    {
        if (currentPageIndex < helpPages.Length - 1)
        {
            currentPageIndex++;
            UpdatePage();
        }
    }

    // �O�̃y�[�W�ɖ߂�
    public void ShowPreviousPage()
    {
        if (currentPageIndex > 0)
        {
            currentPageIndex--;
            UpdatePage();
        }
    }

    // ���݂̃y�[�W���X�V���ĕ\��
    private void UpdatePage()
    {
        // �S�Ẵy�[�W���\���ɂ��Ă���A���݂̃y�[�W�̂ݕ\������
        for (int i = 0; i < helpPages.Length; i++)
        {
            helpPages[i].SetActive(i == currentPageIndex);
        }

        // �{�^���̗L���E�������X�V
        nextButton.interactable = (currentPageIndex < helpPages.Length - 1);
        previousButton.interactable = (currentPageIndex > 0);
    }
}
