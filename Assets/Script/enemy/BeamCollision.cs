using UnityEngine;

public class BeamCollision : GameOverTrigger
{
    public AudioClip deathSound;  // 死亡時の効果音
    private AudioSource audioSource;  // AudioSourceコンポーネント

    void Awake()
    {
        // AudioSourceコンポーネントの取得
        audioSource = gameObject.AddComponent<AudioSource>();
        if (deathSound != null)
        {
            audioSource.clip = deathSound;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 障害物タグに当たった場合、ビームを消去
        if (other.CompareTag("Obstacles"))
        {
            Destroy(gameObject); // ビームオブジェクトを削除
        }
        // プレイヤータグに当たった場合、ゲームオーバー処理を実行
        else if (other.CompareTag("Player"))
        {
            // 効果音を再生
            if (deathSound != null)
            {
                audioSource.Play();
            }
            GameOver(); // GameOverTrigger から継承したゲームオーバー処理を呼び出す
        }
    }
}
