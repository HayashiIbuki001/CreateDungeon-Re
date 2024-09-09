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
    public bool teleported;
    public bool right;

    // 左右の方向を判定するための変数（右: 1、左: -1）
    int direction = 1;

    // 位置を追跡するための変数
    Vector2 lastPosition;
    float stuckTime = 0.0f; // ひよこが動かない時間を追跡

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;

        right = true;
    }

    void Update()
    {
        Teleported();

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
            // 躓いてしまったらジャンプ
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

            right = !right;
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

    public void Teleport(Vector3 newPosition)
    {
        transform.position = newPosition;
        // テレポート後に右に歩くように方向を設定
        SetTeleportDirection(Vector2.right); // 右方向に設定
    }

    public void SetTeleportDirection(Vector2 newDirection)
    {
        direction = newDirection.x > 0 ? 1 : -1;
        // 速度も更新
        _rb.velocity = new Vector2(speed * direction, _rb.velocity.y);
    }

    public void Teleported()
    {
        if (teleported)
        {
            if (!right)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;  // X軸を反転
                transform.localScale = scale;
                direction *= -1;

                teleported = false;
                Debug.Log("てれぽーてっど");

                right = true;
            }
        }
    }
}
