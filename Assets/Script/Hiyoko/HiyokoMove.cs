using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoMove : MonoBehaviour
{
    Rigidbody2D _rb;
    float speed = 1.0f;
    float jumpForce = 7.0f;
    public LayerMask obstacleLayer;  // 障害物として検知するレイヤー
    public bool canJump = true;
    public bool isJump = false;

    // 左右の方向を判定するための変数（右: 1、左: -1）
    int direction = 1;

    // 位置を追跡するための変数
    Vector2 lastPosition;
    float stuckTime = 0.0f; // ひよこが動かない時間を追跡

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // ひよこを常に移動させる
        _rb.velocity = new Vector2(speed * direction, _rb.velocity.y);

        // ひよこが動いていない時間を測定
        if (Mathf.Abs(transform.position.x - lastPosition.x) < 0.0001f)
        {
            stuckTime += Time.deltaTime;
        }
        else
        {
            stuckTime = 0.0f;
        }

        // 1秒以上動かない場合、方向を逆にする
        if (stuckTime >= 0.5f)
        {
            //躓いてしまったらジャンプ
            if (canJump && !isJump)
            {
                _rb.AddForce(Vector2.up * jumpForce / 2, ForceMode2D.Impulse);
                isJump = true;
            }
        }
        if (stuckTime >= 2.0f)
        {
            direction *= -1;
            stuckTime = 0.0f;

            // スプライトの向きを変更
            Vector3 scale = transform.localScale;
            scale.x *= -1;  // X軸を反転
            transform.localScale = scale;
        }

        // 前方に障害物があるかをチェック
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.5f, obstacleLayer);

        // 障害物があればジャンプする
        if (hit.collider != null && Mathf.Abs(_rb.velocity.y) < 0.01f && !isJump && canJump)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }

        // 現在の位置を保存
        lastPosition = transform.position;
    }
}
