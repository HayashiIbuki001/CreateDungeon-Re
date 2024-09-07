using UnityEngine;

public class BeamCollision : GameOverTrigger
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // ��Q���^�O�ɓ��������ꍇ�A�r�[��������
        if (other.CompareTag("Obstacles"))
        {
            Destroy(gameObject); // �r�[���I�u�W�F�N�g���폜
        }
        // �v���C���[�^�O�ɓ��������ꍇ�A�Q�[���I�[�o�[���������s
        else if (other.CompareTag("Player"))
        {
            GameOver(); // GameOverTrigger ����p�������Q�[���I�[�o�[�������Ăяo��
        }
    }
}
