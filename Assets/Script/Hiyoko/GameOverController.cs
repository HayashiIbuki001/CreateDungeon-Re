using UnityEngine;

public class GameOverController : GameOverTrigger
{
    //public CheckpointManager checkpointManager; // チェックポイント管理用のスクリプト

    public override void GameOver()
    {
        // ゲームオーバー処理を実行
        if (checkpointManager != null)
        {
            checkpointManager.TeleportToCheckpoint();
        }
    }
}
