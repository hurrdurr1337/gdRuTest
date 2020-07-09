using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NepredskazMerchant : Merchant
{
    public override bool DoDeal()
    {
        bool result = UnityEngine.Random.value > 0.5f ? true : false;
        return result;
    }
}
