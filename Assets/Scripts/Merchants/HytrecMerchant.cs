using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HytrecMerchant : Merchant
{

    public override bool DoDeal()
    {
        if (numberOfDeals == 0)
            return true;
        else return isLastOpponentDealFair;
        
    }
}
