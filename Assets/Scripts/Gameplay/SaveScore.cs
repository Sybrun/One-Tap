using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour {

    public int score;
    public int killCount;
    public int oneTaps;

    UI UIRef;

    /// <summary>
    /// In order to display the score of the player after he has died, we have collect the scores of the player from the UI script.
    /// In this Awake method we make a reference to the UI script to allow us access to these scores. We also use the DontDestroyOnLoad() 
    /// to keep the GameObject this script is attached to after switching scenes.
    /// </summary>
    void Awake () {
        UIRef = FindObjectOfType<UI>();
        DontDestroyOnLoad(this);
	}
	
	/// <summary>
    /// Here we export the score values to our UI elements from the UI script, resulting in a correct display of the player's score in the "RetryMenu" scene.
    /// </summary>
	void Update () {
        score = UIRef.score;
        killCount = UIRef.killCount;
        oneTaps = UIRef.oneTaps;
    }
}
