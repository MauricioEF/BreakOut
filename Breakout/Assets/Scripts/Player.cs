using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int LimitX = 48;
    public float speed = 50.0f;
    new Transform transform;
    Vector3 mousePosition2D;
    Vector3 mousePosition3D;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition2D = Input.mousePosition;
        mousePosition2D.z = -Camera.main.transform.position.z;
        mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);


        //Keyboard
        //if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);
        //}
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.down);
        Vector3 pos = transform.position;
        //pos.x = mousePosition3D.x;
        if (pos.x < -LimitX)
        {
            pos.x = -LimitX;
        }
        else if(pos.x> LimitX)
        {
            pos.x = LimitX;
        }
        transform.position = pos;
    }

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
        collision.rigidbody.velocity = (collision.gameObject.GetComponent<Ball>().savedSpeed) * direction;
    }
}
