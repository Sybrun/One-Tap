using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int health = 100;
    public Rigidbody2D rigidBody;
    public float speed = 30f;

    private UI UIScript;

    public Image healthBar;

    /// <summary>
    /// Gives the Enemy pace.
    /// </summary>
    void Start ()
    {
        UIScript = FindObjectOfType<UI>();
        rigidBody.velocity = transform.right * speed;
    }

    /// <summary>
    /// Checks the health of the Enemy. If health is, or is less than, 0, the game object (Enemy) will be destroyed. 
    /// </summary>
	void Update ()
    {
        healthBar.fillAmount = health / 100f;

        if (health <= 0)
        {
            Destroy(gameObject);
            UIScript.killCount += 1;
        }
		
	}

}
