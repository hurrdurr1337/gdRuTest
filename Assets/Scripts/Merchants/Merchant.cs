using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MerchantTypes
{
    AltruistMerchant,
    KydalaMerchant,
    HytrecMerchant,
    NepredskazMerchant,
    ZlopyamyatMerchant,
    UshlyiMerchant
}


public abstract class Merchant : MonoBehaviour
{
    public string Name;
    [SerializeField]
    private int currentMoney;
    public MerchantTypes MerchantType { get; private set; }
    public int CurrentMoney
    {
        get
        {
            return currentMoney;
        }

    }

    protected bool isLastOpponentDealFair = true;
    protected int numberOfDeals = 0;
    protected virtual void Start()
    {
        this.Name = new NameGenerator().Name;
        gameObject.name = this.Name;
    }

    public void CheckDeal(int moneyAmount, bool isFair = false)
    {
        currentMoney += moneyAmount;
        isLastOpponentDealFair = isFair;
        numberOfDeals++;
    }
    public abstract bool DoDeal();

    public void ReInitMerchant()
    {
        currentMoney = 0;
        isLastOpponentDealFair = true;
        numberOfDeals = 0;
    }
    public void SetMerchantType(MerchantTypes merchantType)
    {
        MerchantType = merchantType;
    }
}
