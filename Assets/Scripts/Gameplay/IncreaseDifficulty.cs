using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{
    public int wave = 1;
    public float nextSpawnDelay = 2f;

    public void NextWave()
    {
        if (wave < 10)
        { 
            wave += 1;
            nextSpawnDelay -= 0.15f;
        }
    }  
}
