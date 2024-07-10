using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIce : Block
{
    // Start is called before the first frame update
    void Start()
    {
        //We won't change the base resistance, it will break in a single hit, we'll just change the effect when broke
        this.speedModifier = 0.7f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void BounceBall(Collision collision)
    {
        base.BounceBall(collision);
    }

    public override void DecreaseResistance()
    {
        base.DecreaseResistance();
    }
}
