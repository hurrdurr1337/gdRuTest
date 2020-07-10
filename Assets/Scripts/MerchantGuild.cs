using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MerchantGuild : MonoBehaviour
{
    public int maxMerchants = 50;
    public int exclusionPercentage = 20;

    public GameObject merchantPrefab;


    public Merchant[] merchants { get; private set; }



    void Awake()
    {
        InitGuild();
    }

    private void InitGuild()
    {
        var merchantTypesCount = Enum.GetValues(typeof(MerchantTypes)).Length;

        merchants = new Merchant[maxMerchants];
        for (int i = 0; i < maxMerchants; i++)
        {
            merchants[i] = CreateNewMerchant((MerchantTypes)(i % merchantTypesCount));
        }
        Scoreboard.instance.UpdateUI(merchants);
    }


    public void StartTraiding()
    {

        for (int i = 0; i < merchants.Length; i++)
        {
            for (int j = 0; j < merchants.Length; j++)
            {
                if (i == j)
                    continue;
                Trade(merchants[i], merchants[j]);
            }
        }
        merchants = merchants.OrderBy(c => -c.CurrentMoney).ToArray();
        //sort in hierarchy
        for (int i = 0; i < merchants.Length; i++)
        {
            merchants[i].transform.SetSiblingIndex(i);
        }
        Scoreboard.instance.UpdateUI(merchants);

    }

    void Trade(Merchant merchantOne, Merchant merchantTwo)
    {
        int numberOfTrades = UnityEngine.Random.Range(5, 10);
        for (int i = 0; i < numberOfTrades; i++)
        {
            //Debug.Log(merchantOne.DoDeal());
            //Debug.Log(merchantTwo.DoDeal());
            bool resultOfDealOne = MistakeChance(merchantOne.DoDeal());
            bool resultOfDealTwo = MistakeChance(merchantTwo.DoDeal());
            if (resultOfDealOne && resultOfDealTwo)
            {
                merchantOne.CheckDeal(4, true);
                merchantTwo.CheckDeal(4, true);
            }
            else if (!resultOfDealOne && !resultOfDealTwo)
            {
                merchantOne.CheckDeal(2);
                merchantTwo.CheckDeal(2);
            }
            else
            {
                if (resultOfDealOne)
                {
                    merchantOne.CheckDeal(1);
                    merchantTwo.CheckDeal(5, true);
                }
                else
                {
                    merchantOne.CheckDeal(5, true);
                    merchantTwo.CheckDeal(1);
                }
            }
        }
    }
    bool MistakeChance(bool initalBool)
    {
        bool result = UnityEngine.Random.value > 0.95f ? !initalBool : initalBool;
        return result;
    }
    public void EndOfTheYear()
    {
        int badMerchantsCount = Mathf.RoundToInt(maxMerchants * (exclusionPercentage / 100f));
        int j = 0;
        for (int i = maxMerchants - 1; i >= maxMerchants - badMerchantsCount; i--)
        {
            Destroy(merchants[i].gameObject);
            merchants[i] = CreateNewMerchant((merchants[j++].MerchantType));
        }
        for (int i = 0; i < merchants.Length; i++)
        {
            merchants[i].ReInitMerchant();
        }
        Scoreboard.instance.UpdateUI(merchants);


    }

    //argument can be set as int
    Merchant CreateNewMerchant(MerchantTypes merchantType)
    {
        GameObject merchantGO = Instantiate(merchantPrefab);
        System.Type merchantTypeScript = System.Type.GetType(merchantType.ToString() + ",Assembly-CSharp");
        Merchant newMerchant = (Merchant)merchantGO.AddComponent(merchantTypeScript);
        newMerchant.SetMerchantType(merchantType);
        newMerchant.transform.SetParent(this.transform);
        return newMerchant;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTraiding();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EndOfTheYear();
        }
    }
}