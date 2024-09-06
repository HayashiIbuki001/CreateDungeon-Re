using UnityEngine;

public class BeamCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ビームが障害物（ブロックや壁）に当たった場合、ビームを削除
        if (collision.CompareTag("Obstacles"))
        {
            Destroy(gameObject); // ビームを削除
        }
        // ビームがひよこに当たった場合、ゲームオーバー
        else if (collision.CompareTag("Player"))
        {
            Debug.Log("ゲームオーバー");
            // ゲームオーバー処理をここに追加
        }
    }
}
