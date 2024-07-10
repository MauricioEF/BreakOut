using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{

    public bool isGameStarted = false;
    [SerializeField] public float speed = 10.0f;

    Vector3 lastPosition = Vector3.zero;
    Vector3 direction = Vector3.zero;
    Rigidbody rigidBody;
    private ControlBorders borderControl;
    public UnityEvent BallDestroyed;
    public Settings settings;
    private GameManager gameManager;
    private Vector3 savedVelocity;
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
        if (gameManager.isPaused)
        {
            if (rigidBody.IsSleeping())
            {

            }
            else
            {
                savedVelocity = rigidBody.velocity;
                rigidBody.Sleep();
            }
        }
        else
        {
            if (!rigidBody.IsSleeping())
            {

            }
            else
            {
                Debug.Log("Waking Up");
                rigidBody.WakeUp();
                rigidBody.velocity = savedVelocity;
            }
        }
        if (borderControl.comingFromBottom)
        {
            BallDestroyed.Invoke();
            Destroy(this.gameObject);
            borderControl.comingFromBottom = false;
        }
        if (borderControl.comingFromTop)
        {
            direction = transform.position - lastPosition;
            Debug.Log("Ball touched top Border");
            direction.y *= -1;
            direction = direction.normalized;
            rigidBody.velocity = speed * direction;
            borderControl.comingFromTop = false;
            borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2f);
        }
        if (borderControl.comingFromRight)
        {
            direction = transform.position - lastPosition;
            Debug.Log("Ball touched right Border");
            direction.x *= -1;
            direction = direction.normalized;
            rigidBody.velocity = speed * direction;
            borderControl.comingFromRight = false;
            borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2f);
        }
        if (borderControl.comingFromLeft)
        {
            direction = transform.position - lastPosition;
            Debug.Log("Ball touched left Border");
            direction.x *= -1;
            direction = direction.normalized;
            rigidBody.velocity = speed * direction;
            borderControl.comingFromLeft = false;
            borderControl.enabled = false;
            Invoke(nameof(EnableBorderControl), 0.2f);
        }

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
    private void FixedUpdate()
    {
        if (gameManager.isPaused)
        {
            Debug.Log("Wont change");
            return;
        }
        lastPosition =  transform.position;
    }

    private void LateUpdate()
    {
        if (gameManager.isPaused)
        {
            Debug.Log("Shouldn't move");
            return;
        }
        if (direction != Vector3.zero)
        {
            direction = Vector3.zero;
        }
    }
    private void EnableBorderControl()
    {
        borderControl.enabled = true;
    }
}
