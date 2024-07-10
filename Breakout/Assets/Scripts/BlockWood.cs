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
