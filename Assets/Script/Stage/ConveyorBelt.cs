using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ConveyorBelt : MonoBehaviour
{
    public float moveSpeed = 2f; // �u���b�N���ړ����鑬�x
    public bool moveRight = true; // �E�ɓ����������ɓ�������

    private void Update()
    {
        // �x���g�R���x�A���͈̂ړ����Ȃ��̂ŁA���̃N���X�ł͉������܂���
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �u���b�N���R���x�A�ɏ���Ă���Ƃ��̏���
        if (collision.CompareTag("Obstacles"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // �u���b�N���x���g�̕����ɓ�����
                Vector2 movement = (moveRight ? Vector2.right : Vector2.left) * moveSpeed * Time.deltaTime;
                rb.position += movement;
            }
        }
    }
}
