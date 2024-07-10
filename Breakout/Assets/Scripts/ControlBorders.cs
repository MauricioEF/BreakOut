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

    public void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.aspect * cameraHeight;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
