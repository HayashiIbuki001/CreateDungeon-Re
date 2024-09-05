using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSenser : MonoBehaviour
{
    private HiyokoMove hiyokoMove;

    void Start()
    {
        // HiyokoオブジェクトにアタッチされているHiyokoMoveスクリプトを取得
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
