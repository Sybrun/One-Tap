using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField] int price_ES_Yellow = 50;
    //[SerializeField] int price_ES_Blue = 10000;
    //[SerializeField] int price_ES_Purple = 24000;
    //[SerializeField] int price_ES_White = 98000;

    [Header("Yellow Panels")]
    public GameObject selectPanel_Yellow;
    public GameObject boughtPanel_Yellow;
    public GameObject buyPanel_Yellow;

    [SerializeField] private int selectedSkin;

    [SerializeField] private int yellowState;
    [SerializeField] private int defaultState;

    void Start()
    { 
        instance = this;

        yellowState = PlayerPrefs.GetInt("YellowState");
        CheckStates();

        selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
        SelectSkin();
    }

    public void BuyYellow()
    {
        if(MoneyManager.instance.money >= price_ES_Yellow)
        {
            MoneyManager.instance.money -= price_ES_Yellow;
            PlayerPrefs.SetInt("Money", MoneyManager.instance.money);

            yellowState += 1;
            PlayerPrefs.SetInt("YellowState", yellowState);
            CheckStates();
        }
    }
    public void SelectYellow()
    {
        Debug.Log("Selected Yellow");

        selectedSkin = 1;
        PlayerPrefs.SetInt("SelectedSkin", selectedSkin);
        SelectSkin();

        yellowState += 1;
        PlayerPrefs.SetInt("YellowState", yellowState);
        CheckStates();

        SkinManager.instance.skinColor = "Yellow";
        PlayerPrefs.SetString("SkinColor", SkinManager.instance.skinColor);
    }

    void SelectSkin()
    {
        switch (selectedSkin)
        {
            case 0:
                //equip default (red) skin
                Debug.Log("Default Skin equipped!");
                break;
            case 1:
                //equip yellow skin
                Debug.Log("Yellow Skin equipped!");
                selectPanel_Yellow.SetActive(true);
                break;
            case 2:
                //equip blue skin
                break;
            case 3:
                //equip purple skin
                break;
            case 4:
                //equip white skin
                break;
        }
    }

    void CheckStates()
    {
        switch (yellowState)
        {
            case 0:
                buyPanel_Yellow.SetActive(true);
                boughtPanel_Yellow.SetActive(false);
                break;
            case 1:
                buyPanel_Yellow.SetActive(false);
                boughtPanel_Yellow.SetActive(true);
                break;
            case 2:
                buyPanel_Yellow.SetActive(false);
                boughtPanel_Yellow.SetActive(false);
                break;
        }
    }
}
