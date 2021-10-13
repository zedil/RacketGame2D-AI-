using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIRacket : Racket
{
    public Transform ball;
    protected override void HareketEt()
    {

        float mesafe = Mathf.Abs(ball.position.y - transform.position.y);
        if (mesafe > 2)
        {
            //top yukarıdaysa yukarı, aşağıdaysa aşağı
            if(ball.position.y > transform.position.y)
            {
                //Raket yukarı hareket eder
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,1) * moveSpeed; 
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1) * moveSpeed; 
            }

        }


    }


}
