using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoneyCounter : MonoBehaviour
{
    Text moneyText;

    void Start()
    {
        moneyText = GetComponent<Text>(); 
    }

    void Update()
    {
        moneyText.text = MoneyManager.instance.money.ToString();
    }
}
