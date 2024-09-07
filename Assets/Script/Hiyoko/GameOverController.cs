using UnityEngine;

public class GameOverController : GameOverTrigger
{
    //public CheckpointManager checkpointManager; // �`�F�b�N�|�C���g�Ǘ��p�̃X�N���v�g

    public override void GameOver()
    {
        // �Q�[���I�[�o�[���������s
        if (checkpointManager != null)
        {
            checkpointManager.TeleportToCheckpoint();
        }
    }
}
