using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZlopyamyatMerchant : Merchant
{
    public override bool DoDeal()
    {
        if (isLastOpponentDealFair)
            return true;
        else return false;
    }
}
