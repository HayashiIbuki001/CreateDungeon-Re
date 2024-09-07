using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public CheckpointManager checkpointManager; // CheckpointManager への参照

    // ゲームオーバー時の共通処理
    public virtual void GameOver()
    {
        Debug.Log("Game Over!");

        // チェックポイントマネージャーが設定されているか確認
        if (checkpointManager != null)
        {
            checkpointManager.TeleportToCheckpoint();
            Debug.Log("Teleported");
        }
        else
        {
            Debug.LogError("CheckpointManager が設定されていません。");
        }

        // ここに他のゲームオーバー時の処理を追加
        // 例: ゲームオーバー画面の表示やシーンのリロードなど
    }

    // Start メソッドで自動的に checkpointManager を設定
    protected virtual void Start()
    {
        if (checkpointManager == null)
        {
            // "hiyoko" という名前のゲームオブジェクトを探す
            GameObject hiyoko = GameObject.Find("Hiyoko");
            if (hiyoko != null)
            {
                // hiyoko にアタッチされた CheckpointManager コンポーネントを取得
                checkpointManager = hiyoko.GetComponent<CheckpointManager>();
                if (checkpointManager == null)
                {
                    Debug.LogError("GameObject 'hiyoko' に CheckpointManager コンポーネントがアタッチされていません。");
                }
            }
            else
            {
                Debug.LogError("GameObject 'hiyoko' がシーン内に存在しません。");
            }
        }
    }
}
