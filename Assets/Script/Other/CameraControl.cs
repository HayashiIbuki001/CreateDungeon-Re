using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera vcam;
    public float moveAmount = 2.0f;  // �J�����̓�����
    public float moveSpeed = 5.0f;   // �J�����̈ړ����x

    private Vector3 originalOffset;  // ���̃J�����̃I�t�Z�b�g

    void Start()
    {
        // CinemachineVirtualCamera�R���|�[�l���g�̎擾
        if (vcam == null)
        {
            vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        }

        // �����̃J�����̃I�t�Z�b�g��ۑ�
        originalOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    void Update()
    {
        // ���݂̃I�t�Z�b�g���擾
        Vector3 currentOffset = vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;

        // ���L�[��������Ă��邩���`�F�b�N
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // �E���L�[��������Ă���Ƃ�
            Vector3 targetOffset = originalOffset + new Vector3(moveAmount, 0, 0);
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // �����L�[��������Ă���Ƃ�
            Vector3 targetOffset = originalOffset - new Vector3(moveAmount, 0, 0);
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // �����L�[��������Ă���Ƃ�
            Vector3 targetOffset = originalOffset - new Vector3(0, moveAmount, 0);  // Y�������ɉ�����
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, targetOffset, Time.deltaTime * moveSpeed);
        }
        else
        {
            // ���L�[��������Ă��Ȃ��Ƃ��͌��̈ʒu�ɖ߂�
            vcam.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = Vector3.Lerp(currentOffset, originalOffset, Time.deltaTime * moveSpeed);
        }
    }
}
