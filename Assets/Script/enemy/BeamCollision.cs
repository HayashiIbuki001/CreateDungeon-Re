using UnityEngine;

public class BeamCollision : GameOverTrigger
{
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
            GameOver(); // GameOverTrigger から継承したゲームオーバー処理を呼び出す
        }
    }
}
