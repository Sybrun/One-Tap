using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money;

    void Awake()
    {
        MakeSingleton();

        money = PlayerPrefs.GetInt("Money", money);
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
