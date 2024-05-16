using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public int resistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resistance <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        
    }

    public virtual void RebounceBall()
    {

    }
}
