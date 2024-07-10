using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{

    public int resistance = 1;
    public float speedModifier = 1;
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
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        collision.rigidbody.velocity = (collision.gameObject.GetComponent<Ball>().speed * speedModifier) * direction;
        DecreaseResistance();
    }

    public virtual void DecreaseResistance()
    {
        resistance--;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (resistance <= 0)
        {
            increaseScore.Invoke();
            Destroy(this.gameObject);
            return;
        }
        
    }
}
