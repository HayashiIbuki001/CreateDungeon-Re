using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject helpMenuCanvas; // ��������� Canvas
    public GameObject titleText;
    public GameObject startButton;
    public GameObject helpButton;

    // ��������{�^���������ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void OpenHelpMenu()
    {
        // ���������ʂ�\��
        helpMenuCanvas.SetActive(true);
        titleText.SetActive(false);
        startButton.SetActive(false);
        helpButton.SetActive(false);
    }

    // ���������ʂ���郁�\�b�h
    public void CloseHelpMenu()
    {
        // ���������ʂ��\��
        helpMenuCanvas.SetActive(false);
        titleText.SetActive(true);
        startButton.SetActive(true);
        helpButton.SetActive(true);
    }
}
