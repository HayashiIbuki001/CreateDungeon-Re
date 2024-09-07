using UnityEngine;

public class GameOverOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // �Q�[���I�[�o�[��臒l

    private GameOverTrigger gameOverTrigger; // GameOverTrigger �ւ̎Q��

    void Start()
    {
        // GameOverTrigger �R���|�[�l���g���擾
        gameOverTrigger = GetComponent<GameOverTrigger>();
        if (gameOverTrigger == null)
        {
            Debug.LogError("GameOverTrigger �R���|�[�l���g���A�^�b�`����Ă��܂���B");
        }
    }

    void Update()
    {
        // �v���C���[�̈ʒu���`�F�b�N
        if (transform.position.y < fallThreshold)
        {
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
