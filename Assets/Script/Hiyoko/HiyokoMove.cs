using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoMove : MonoBehaviour
{
    Rigidbody2D _rb;
    float speed = 1.0f;
    float jumpForce = 7.0f;
    public LayerMask obstacleLayer;  // ��Q���Ƃ��Č��m���郌�C���[
    public bool canJump = true;
    public bool isJump = false;

    // ���E�̕����𔻒肷�邽�߂̕ϐ��i�E: 1�A��: -1�j
    int direction = 1;

    // �ʒu��ǐՂ��邽�߂̕ϐ�
    Vector2 lastPosition;
    float stuckTime = 0.0f; // �Ђ悱�������Ȃ����Ԃ�ǐ�

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        lastPosition = transform.position;
    }

    void Update()
    {
        // �Ђ悱����Ɉړ�������
        _rb.velocity = new Vector2(speed * direction, _rb.velocity.y);

        // �Ђ悱�������Ă��Ȃ����Ԃ𑪒�
        if (Mathf.Abs(transform.position.x - lastPosition.x) < 0.0001f)
        {
            stuckTime += Time.deltaTime;
        }
        else
        {
            stuckTime = 0.0f;
        }

        // 1�b�ȏ㓮���Ȃ��ꍇ�A�������t�ɂ���
        if (stuckTime >= 0.5f)
        {
            //�T���Ă��܂�����W�����v
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

            // �X�v���C�g�̌�����ύX
            Vector3 scale = transform.localScale;
            scale.x *= -1;  // X���𔽓]
            transform.localScale = scale;
        }

        // �O���ɏ�Q�������邩���`�F�b�N
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(direction, 0), 0.5f, obstacleLayer);

        // ��Q��������΃W�����v����
        if (hit.collider != null && Mathf.Abs(_rb.velocity.y) < 0.01f && !isJump && canJump)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }

        // ���݂̈ʒu��ۑ�
        lastPosition = transform.position;
    }
}
