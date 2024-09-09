using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 2f; // ブロックが移動する速度
    public bool moveRight = true; // 右に動かすか左に動かすか

    private void Update()
    {
        // ベルトコンベア自体は移動しないので、このクラスでは何もしません
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ブロックがコンベアに乗っているときの処理
        if (collision.CompareTag("Obstacles"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // ブロックをベルトの方向に動かす
                Vector2 movement = (moveRight ? Vector2.right : Vector2.left) * moveSpeed * Time.deltaTime;
                rb.position += movement;
            }
        }
    }
}
