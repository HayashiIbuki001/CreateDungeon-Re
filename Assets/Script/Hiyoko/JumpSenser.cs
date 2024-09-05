using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSenser : MonoBehaviour
{
    private HiyokoMove hiyokoMove;

    void Start()
    {
        // Hiyoko�I�u�W�F�N�g�ɃA�^�b�`����Ă���HiyokoMove�X�N���v�g���擾
        hiyokoMove = GetComponentInParent<HiyokoMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            hiyokoMove.canJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            hiyokoMove.canJump = true;
        }
    }
}
