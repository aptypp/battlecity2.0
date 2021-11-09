using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBlock : BaseBlock
{
    public override void Damage()
    {
        Destroy(gameObject);
    }
}
