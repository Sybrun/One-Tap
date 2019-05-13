using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour {

    public float speed;
    public Rigidbody2D rigidBody;
    public int damage;
    private StageManager stageManager;
    private UI UIScript;
    private Enemy EnemyScript;

    /// <summary>
    /// Refers to 3 other scripts and gives the bullet pace.
    /// </summary>
    void Start ()
    {
        stageManager = FindObjectOfType<StageManager>();
        UIScript = FindObjectOfType<UI>();
        EnemyScript = FindObjectOfType<Enemy>();
        rigidBody.velocity = transform.right * speed;

    }

    /// <summary>
    /// Checks in the StageManager script, which stage is currently active and determines the Random Range accordingly.
    /// After that, the damage will be set to the random number generated.
    /// </summary>
    void Update()
    {
        switch (stageManager.bulletStage)
        {
            case 1:
                damage = Random.Range(25, 32);
                break;

            case 2:
                damage = Random.Range(34, 49);
                break;

            case 3:
                damage = Random.Range(65, 94);
                break;

            case 4:
                damage = 200;
                break;

            default:
                Debug.Log("Something went wrong.");
                break;
        }
   
    }

    /// <summary>
    /// Checks tag of the collider. If it's the "Enemy" tag, damage will be dealt (+ shown to player through visual feedback and logged in the console) 
    /// accordingly to the random damage each stage provides, points (total damage) will be added to the Player's score and the Bullet will be destroyed. 
    /// If the collider has the "Barrier" tag, the bullet will simply be destroyed.
    /// </summary>
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "Enemy" && stageManager.bulletStage == 4)
        {
            Handheld.Vibrate();
            if(EnemyScript.health == 100)
            {
                UIScript.oneTaps += 1;
            }

            hit.GetComponent<Enemy>().health -= damage;
            UIScript.score += damage;
            Debug.Log("Stage:" + stageManager.bulletStage + " Hit: " + damage);

            MoneyManager.instance.money += damage / 10;
            PlayerPrefs.SetInt("Money", MoneyManager.instance.money);

            Destroy(gameObject);
        }
        else if (hit.tag == "Enemy")
        {
            hit.GetComponent<Enemy>().health -= damage;
            UIScript.score += damage;
            Debug.Log("Stage:" + stageManager.bulletStage + " Hit: " + damage + ";   25-32 / 34-49 / 65-94");

            MoneyManager.instance.money += damage / 10;
            PlayerPrefs.SetInt("Money", MoneyManager.instance.money);

            Destroy(gameObject);
            int totalDamage = 100 - hit.GetComponent<Enemy>().health;
            hit.GetComponentInChildren<Text>().text = "-" + totalDamage;
        }
        else if (hit.tag == "Barrier")
        {
            Destroy(gameObject);
        }

    }

}
