using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    public int resistance = 1;
    public float speedModifier = 1;
    public int score = 100;
    public UnityEvent increaseScore;
    public bool countable = true;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BounceBall(collision);
        }
    }

    public virtual void BounceBall(Collision collision)
    {
        DecreaseResistance();
    }

    public virtual void DecreaseResistance()
    {
        resistance--;
        Debug.Log(resistance);
    }
    public virtual void Update()
    {
        if (resistance <= 0)
        {
            Camera.main.gameObject.GetComponent<Score>().IncreaseScore(score);
            Destroy(this.gameObject);
            return;
        }
        
    }
}
