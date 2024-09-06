using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : GameOverTrigger
{
    public float DeadY = -10;

    private void Update()

       
    {
        if (transform.position.y < DeadY)
        {
            GameOver();                           
        }
    }
}
