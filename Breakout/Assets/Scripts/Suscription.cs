using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suscription : MonoBehaviour
{
    Events events;
    // Start is called before the first frame update
    void Start()
    {
        events = GetComponent<Events>();
        events.OnSpacePressed += MessageListenedBySuscriptor;
    }

    private void MessageListenedBySuscriptor(object sender,EventArgs e)
    {
        Debug.Log("The class suscription was connected to main event");
        events.OnSpacePressed -= MessageListenedBySuscriptor;
    }
}
