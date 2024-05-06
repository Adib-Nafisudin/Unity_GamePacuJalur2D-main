using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IStop : Item
{
    Movement boat;

    public override void Acive(Movement collision)
    {
        boat = collision;
        boat.isStop = true;
    }
}
