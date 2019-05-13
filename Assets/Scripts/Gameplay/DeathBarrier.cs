using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBarrier : MonoBehaviour {

    /// <summary>
    /// Checks tag of the collider. If it's the "Enemy" tag, the time scale will be set to 0 and it will set the retryMenu GameObject active.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Handheld.Vibrate();
            SceneManager.LoadScene(2);
        }
    }
}
