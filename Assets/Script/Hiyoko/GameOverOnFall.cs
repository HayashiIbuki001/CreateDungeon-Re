using UnityEngine;

public class GameOverOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // ゲームオーバーの閾値

    private GameOverTrigger gameOverTrigger; // GameOverTrigger への参照

    void Start()
    {
        // GameOverTrigger コンポーネントを取得
        gameOverTrigger = GetComponent<GameOverTrigger>();
        if (gameOverTrigger == null)
        {
            Debug.LogError("GameOverTrigger コンポーネントがアタッチされていません。");
        }
    }

    void Update()
    {
        // プレイヤーの位置をチェック
        if (transform.position.y < fallThreshold)
        {
            // ゲームオーバー処理を呼び出す
            if (gameOverTrigger != null)
            {
                gameOverTrigger.GameOver();
            }
            else
            {
                Debug.LogError("GameOverTrigger が設定されていません。");
            }
        }
    }
}
