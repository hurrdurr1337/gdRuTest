using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UshlyiMerchant : Merchant
{

    bool[] dealArray = new bool[4] { true, false, true, true };

    bool isTrickedFlag = false;
    public override bool DoDeal()
    {
        if (numberOfDeals < 4)
        {
            if (!isLastOpponentDealFair)
            {
                isTrickedFlag = true;
            }
            return dealArray[numberOfDeals];
        }
        else if (isTrickedFlag)
        {
            return false;
        }
        else
        {
            if (numberOfDeals == 5) return true;
            else return (isLastOpponentDealFair);         
        }
    }
}
