using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardEntryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI entryNameText = null;
    [SerializeField]
    private TextMeshProUGUI entryMoneyText = null;
    [SerializeField]
    private TextMeshProUGUI entryTypeText = null;
   

    public void Initialize(Merchant merchantData)
    {
        entryNameText.text = merchantData.Name;
        entryMoneyText.text = merchantData.CurrentMoney.ToString();
        entryTypeText.text = merchantData.MerchantType.ToString();
    }

}
