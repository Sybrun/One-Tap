using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;

    public string skinColor;


    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        skinColor = PlayerPrefs.GetString("SkinColor", "Default");
    }

    void Update()
    {
        
    }

    void MakeSingleton()
    {
        if(instance == null)
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
