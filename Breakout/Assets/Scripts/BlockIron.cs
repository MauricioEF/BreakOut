using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIron : Block
{
    // Start is called before the first frame update
    void Start()
    {
        //This block will be unbreakable, useful for some levels where we want to add difficulty
        resistance = 100000000;
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
