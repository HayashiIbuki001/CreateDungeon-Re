using UnityEngine;

public class BeamCollision : GameOverTrigger
{
    public AudioClip deathSound;  // ���S���̌��ʉ�
    private AudioSource audioSource;  // AudioSource�R���|�[�l���g

    void Awake()
    {
        // AudioSource�R���|�[�l���g�̎擾
        audioSource = gameObject.AddComponent<AudioSource>();
        if (deathSound != null)
        {
            audioSource.clip = deathSound;
        }
    }

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
            // ���ʉ����Đ�
            if (deathSound != null)
            {
                audioSource.Play();
            }
            GameOver(); // GameOverTrigger ����p�������Q�[���I�[�o�[�������Ăяo��
        }
    }
}
