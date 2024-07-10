using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIron : Block
{

    private void Awake()
    {
        countable = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.speedModifier = 2;
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void BounceBall(Collision collision)
    {
        base.BounceBall(collision);
    }

}
