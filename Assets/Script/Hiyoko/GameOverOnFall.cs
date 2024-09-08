using UnityEngine;

public class GameOverOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // ゲームオーバーの閾値
    public AudioClip fallSound;  // 落下時の効果音
    private AudioSource audioSource;  // AudioSourceコンポーネント

    private GameOverTrigger gameOverTrigger; // GameOverTrigger への参照

    void Start()
    {
        // GameOverTrigger コンポーネントを取得
        gameOverTrigger = GetComponent<GameOverTrigger>();
        if (gameOverTrigger == null)
        {
            Debug.LogError("GameOverTrigger コンポーネントがアタッチされていません。");
        }

        // AudioSource コンポーネントの取得または追加
        audioSource = gameObject.AddComponent<AudioSource>();
        if (fallSound != null)
        {
            audioSource.clip = fallSound;
        }
    }

    void Update()
    {
        // プレイヤーの位置をチェック
        if (transform.position.y < fallThreshold)
        {
            // 落下時の効果音を再生
            if (fallSound != null)
            {
                audioSource.Play();
            }

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
