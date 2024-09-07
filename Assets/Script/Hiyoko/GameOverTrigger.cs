using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public CheckpointManager checkpointManager; // CheckpointManager �ւ̎Q��

    // �Q�[���I�[�o�[���̋��ʏ���
    public virtual void GameOver()
    {
        Debug.Log("Game Over!");

        // �`�F�b�N�|�C���g�}�l�[�W���[���ݒ肳��Ă��邩�m�F
        if (checkpointManager != null)
        {
            checkpointManager.TeleportToCheckpoint();
            Debug.Log("Teleported");
        }
        else
        {
            Debug.LogError("CheckpointManager ���ݒ肳��Ă��܂���B");
        }

        // �����ɑ��̃Q�[���I�[�o�[���̏�����ǉ�
        // ��: �Q�[���I�[�o�[��ʂ̕\����V�[���̃����[�h�Ȃ�
    }

    // Start ���\�b�h�Ŏ����I�� checkpointManager ��ݒ�
    protected virtual void Start()
    {
        if (checkpointManager == null)
        {
            // "hiyoko" �Ƃ������O�̃Q�[���I�u�W�F�N�g��T��
            GameObject hiyoko = GameObject.Find("Hiyoko");
            if (hiyoko != null)
            {
                // hiyoko �ɃA�^�b�`���ꂽ CheckpointManager �R���|�[�l���g���擾
                checkpointManager = hiyoko.GetComponent<CheckpointManager>();
                if (checkpointManager == null)
                {
                    Debug.LogError("GameObject 'hiyoko' �� CheckpointManager �R���|�[�l���g���A�^�b�`����Ă��܂���B");
                }
            }
            else
            {
                Debug.LogError("GameObject 'hiyoko' ���V�[�����ɑ��݂��܂���B");
            }
        }
    }
}
