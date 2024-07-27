using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBorders : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radius = 1f;
    public bool keepInScreen = false;

    [Header("Configuraciones dinámicas")]
    public bool isInScreen = true;
    public float cameraAnchor;
    public float cameraWidth;
    public float cameraHeight;
    public bool comingFromRight, comingFromLeft, comingFromTop, comingFromBottom;

    public GameObject ColliderTop, ColliderBottom, ColliderLeft, ColliderRight;
    public void Awake()
    {
       
        ColliderTop = GameObject.FindGameObjectWithTag("ColliderTop");
        ColliderBottom = GameObject.FindGameObjectWithTag("ColliderBottom");
        ColliderLeft = GameObject.FindGameObjectWithTag("ColliderLeft");
        ColliderRight = GameObject.FindGameObjectWithTag("ColliderRight");

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.aspect * cameraHeight;

        ColliderTop.transform.position = new Vector3(0, cameraHeight, -10);
        ColliderBottom.transform.position = new Vector3(0, -cameraHeight, -7);
        ColliderLeft.transform.position = new Vector3(-cameraWidth, 0, -7);
        ColliderRight.transform.position = new Vector3(cameraWidth, 0, -7);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ColliderTop && comingFromTop == false)
        {
            this.GetComponent<Ball>().ReachedTop();
        }
        if (other.gameObject == ColliderBottom)
        {
            this.GetComponent<Ball>().ReachedBottom();
        }
        if (other.gameObject == ColliderRight && comingFromRight == false)
        {
            this.GetComponent<Ball>().ReachedRight();
        }
        if (other.gameObject == ColliderLeft && comingFromLeft == false)
        {
            this.GetComponent<Ball>().ReachedLeft();
        }
    }
    private void LateUpdate()
    {
        //We use after all the Update Logic.
        Vector3 position = transform.position;
        isInScreen = true;
        comingFromRight = comingFromTop = comingFromBottom = comingFromLeft = false;
        if(position.x > cameraWidth - radius)
        {
            position.x = cameraWidth - radius;
            comingFromRight = true;
        }
        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
            comingFromLeft = true;
        }
        if(position.y> cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
            comingFromTop = true;
        }
        if(position.y < -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
            comingFromBottom = true;
        }
        isInScreen = !(comingFromBottom||comingFromTop||comingFromRight||comingFromLeft);
        if (keepInScreen && !isInScreen)
        {
            transform.position = position;
            isInScreen = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 borderSize = new Vector3(cameraWidth * 2, cameraHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, borderSize);
    }
    

}
