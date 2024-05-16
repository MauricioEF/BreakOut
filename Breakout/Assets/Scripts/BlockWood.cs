using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWood : Block
{
    // Start is called before the first frame update
    void Start()
    {
        resistance = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void RebounceBall()
    {
        base.RebounceBall();
    }
}
