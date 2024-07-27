using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    public bool isGameStarted = false;
    [SerializeField] public float speed;

    Rigidbody rigidBody;
    private ControlBorders borderControl;
    public UnityEvent BallDestroyed;
    public Settings settings;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Debug.Log(gameManager);
        borderControl = GetComponent<ControlBorders>();
        speed = (int)settings.BallSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        Vector3 initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialPosition.y += 2;
        this.transform.position = initialPosition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
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

    public void ReachedTop()
    {
        Vector3 direction = rigidBody.velocity;
        direction.y *= -1;
        rigidBody.velocity = direction.normalized * speed;
        borderControl.comingFromRight = borderControl.comingFromLeft = false;
    }

    public void ReachedBottom()
    {
        BallDestroyed.Invoke();
        Destroy(this.gameObject);
    }

    public void ReachedLeft() 
    {
        Vector3 direction = rigidBody.velocity;
        direction.x *= -1;
        rigidBody.velocity = direction.normalized * speed;
        borderControl.comingFromRight = borderControl.comingFromTop = false;
    }

    public void ReachedRight()
    {
        Vector3 direction = rigidBody.velocity;
        direction.x *= -1;
        rigidBody.velocity = direction.normalized * speed;
        borderControl.comingFromLeft = borderControl.comingFromTop = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block") || collision.gameObject.CompareTag("Player"))
        {
            var speedModifier = collision.gameObject.CompareTag("Block") ?collision.gameObject.GetComponent<Block>().speedModifier:1;
            BounceWithPlayerOrBlock(collision.GetContact(0).point, collision.gameObject.transform.position,speedModifier);
        }
    }

    public void BounceWithPlayerOrBlock(Vector3 point, Vector3 posOther,float speedModifier)
    {
        borderControl.comingFromTop = borderControl.comingFromLeft = borderControl.comingFromRight = false;
        Vector3 direction = point - posOther;
        Debug.Log("current Speed: " + rigidBody.velocity.magnitude);
        speed = settings.BallSpeed;
        rigidBody.velocity = direction.normalized * speed;
    }

    public void Reset()
    {
        Vector3 initialPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        initialPosition.y += 2;
        this.transform.position = initialPosition;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        this.rigidBody.velocity = new Vector3(0, 0, 0);
        isGameStarted = false;
    }
}
