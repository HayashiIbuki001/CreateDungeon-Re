using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            HiyokoMove hiyokoMove;
            GameObject obj = GameObject.Find("Hiyoko");
            hiyokoMove = obj.GetComponent<HiyokoMove>();
            hiyokoMove.isJump = false;
        }
    }
}
