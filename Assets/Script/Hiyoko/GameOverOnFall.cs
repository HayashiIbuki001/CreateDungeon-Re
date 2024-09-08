using UnityEngine;

public class GameOverOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // �Q�[���I�[�o�[��臒l
    public AudioClip fallSound;  // �������̌��ʉ�
    private AudioSource audioSource;  // AudioSource�R���|�[�l���g

    private GameOverTrigger gameOverTrigger; // GameOverTrigger �ւ̎Q��

    void Start()
    {
        // GameOverTrigger �R���|�[�l���g���擾
        gameOverTrigger = GetComponent<GameOverTrigger>();
        if (gameOverTrigger == null)
        {
            Debug.LogError("GameOverTrigger �R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }

        // AudioSource �R���|�[�l���g�̎擾�܂��͒ǉ�
        audioSource = gameObject.AddComponent<AudioSource>();
        if (fallSound != null)
        {
            audioSource.clip = fallSound;
        }
    }

    void Update()
    {
        // �v���C���[�̈ʒu���`�F�b�N
        if (transform.position.y < fallThreshold)
        {
            // �������̌��ʉ����Đ�
            if (fallSound != null)
            {
                audioSource.Play();
            }

            // �Q�[���I�[�o�[�������Ăяo��
            if (gameOverTrigger != null)
            {
                gameOverTrigger.GameOver();
            }
            else
            {
                Debug.LogError("GameOverTrigger ���ݒ肳��Ă��܂���B");
            }
        }
    }
}
