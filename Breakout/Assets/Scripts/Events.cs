using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public UnityEvent myUnityEvent;
    public event EventHandler OnSpacePressed;

    // Start is called before the first frame update
    void Start()
    {
        OnSpacePressed += EventTriggered;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);
            myUnityEvent.Invoke();
        }
    }
    
    public void EventTriggered(object sender, EventArgs e)
    {
        Debug.Log("Event Triggered");
    }

    public void EventTriggeredUnityEvent()
    {
        Debug.Log("Unity Event triggered");
    }
}
