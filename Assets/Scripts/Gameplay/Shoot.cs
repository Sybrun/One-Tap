using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    private bool isReloading = false;

    public Transform firePoint_Left;
    public Transform firePoint_Mid;
    public Transform firePoint_Right;

    public GameObject bulletPrefab;
    public GameObject ReloadText;

    public int reloadTimer = 1;

    /// <summary>
    /// This function will be called whenever the player taps the left button;
    /// If the player is not reloading, a bullet prefab will be instantiated on the position and rotation of the firePoint_Left (empty) GameObject. 
    /// </summary>
    public void ShootLeft()
    {
        if(isReloading == false)
        {
            Instantiate(bulletPrefab, firePoint_Left.position, firePoint_Left.rotation);

            isReloading = true;
            StartCoroutine("Reload");
        }
    }

    /// <summary>
    /// This function will be called whenever the player taps the middle button;
    /// If the player is not reloading, a bullet prefab will be instantiated on the position and rotation of the firePoint_Mid (empty) GameObject. 
    /// </summary>
    public void ShootMid()
    {
        if(isReloading == false)
        {
            Instantiate(bulletPrefab, firePoint_Mid.position, firePoint_Mid.rotation);

            isReloading = true;
            StartCoroutine("Reload");
        } 
    }

    /// <summary>
    /// This function will be called whenever the player taps the right button;
    /// If the player is not reloading, a bullet prefab will be instantiated on the position and rotation of the firePoint_Right (empty) GameObject. 
    /// </summary>
    public void ShootRight()
    {
        if (isReloading == false)
        {
            Instantiate(bulletPrefab, firePoint_Right.position, firePoint_Right.rotation);

            isReloading = true;
            StartCoroutine("Reload");
        }
    }

    /// <summary>
    /// This Coroutine will be called after the player has fired a bullet. Here, we notify the player that we are reloading with text displaying on the screen.
    /// Also we have a timer for the reload and a boolean to communicate with the rest of the code that we are actually reloading.
    /// </summary>
    IEnumerator Reload()
    {
        ReloadText.SetActive(true);
        yield return new WaitForSeconds(reloadTimer);
        isReloading = false;
        ReloadText.SetActive(false);
    }

}
