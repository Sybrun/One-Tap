using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public int score;
    public int killCount;
    public int oneTaps;

    public Text scoreText;
    public Text killCountText;
    public Text oneTapsText;

    SaveScore SaveScoreRef;

    public GameObject GameManager;

    /// <summary>
    /// In this Awake function we make a reference to our "SaveScore" script in order to push our score values to that script.
    /// This is necessary to maintain consistency in our score values after switching scenes.
    /// </summary>
    void Awake()
    {
        SaveScoreRef = FindObjectOfType<SaveScore>();
        score = SaveScoreRef.score;
        killCount = SaveScoreRef.killCount;
        oneTaps = SaveScoreRef.oneTaps;
    }

    /// <summary>
    /// Here we update the player's score continually and send it to our UI elements, so that the score will display correctly.
    /// </summary>
    void Update()
    {
        scoreText.text = score.ToString();
        killCountText.text = killCount.ToString();
        oneTapsText.text = oneTaps.ToString();
    }
}
