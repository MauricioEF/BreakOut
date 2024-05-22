using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public bool isGameStarted = false;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialPosition.y += 2;
        this.transform.position = initialPosition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)||Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = Vector3.up * speed;
            }
        }
    }
}
