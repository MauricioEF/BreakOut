using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIce : Block
{
    // Start is called before the first frame update
    void Start()
    {
        //We won't change the base resistance, it will break in a single hit, we'll just change the effect when broke
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
