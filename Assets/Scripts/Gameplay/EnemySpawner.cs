using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    private IncreaseDifficulty increaseDifficulty;

    public GameObject enemyPrefab;
    public GameObject warningLight_Left;
    public GameObject warningLight_Mid;
    public GameObject warningLight_Right;

    public Transform spawnPoint_Left;
    public Transform spawnPoint_Mid;
    public Transform spawnPoint_Right;

    private SpriteRenderer spriteRenderer;

    private int spawnedEnemies;
    public Text waveText;

    void Start()
    {
        increaseDifficulty = GetComponent<IncreaseDifficulty>();

        UpdateSkin();
        StartCoroutine("Spawner");
    }

    void Update()
    {
        if(spawnedEnemies >= 3)
        {
            spawnedEnemies = 0;
            increaseDifficulty.NextWave();
            waveText.text = increaseDifficulty.wave.ToString();
            Debug.Log("WAVE " + increaseDifficulty.wave + 
                "// nextSpawnDelay = " + increaseDifficulty.nextSpawnDelay);
        }
    }
    /// <summary>
    /// This coroutine will generate a random number between 1 and 3. This random number will be used in the following switch case 
    /// to determine the spawn position of the enemy and to actually spawn the enemy accordingly. This coroutine will loop until the player has died.
    /// </summary>
    IEnumerator Spawner()
    {
        while (true)
        {
            int enemyPosition = Random.Range(1, 4);
            switch (enemyPosition)
            {
                case 1:
                    warningLight_Left.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    warningLight_Left.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                    Instantiate(enemyPrefab, spawnPoint_Left.position, spawnPoint_Left.rotation);
                    spawnedEnemies += 1;
                    break;
                case 2:
                    warningLight_Mid.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    warningLight_Mid.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                    Instantiate(enemyPrefab, spawnPoint_Mid.position, spawnPoint_Mid.rotation);
                    spawnedEnemies += 1;
                    break;
                case 3:
                    warningLight_Right.SetActive(true);
                    yield return new WaitForSeconds(0.5f);
                    warningLight_Right.SetActive(false);
                    yield return new WaitForSeconds(0.5f);
                    Instantiate(enemyPrefab, spawnPoint_Right.position, spawnPoint_Right.rotation);
                    spawnedEnemies += 1;
                    break;
            }

            yield return new WaitForSeconds(increaseDifficulty.nextSpawnDelay);
        }
    }

    void UpdateSkin()
    {
        switch(SkinManager.instance.skinColor)
        {
            case "Default":
                spriteRenderer = enemyPrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.red;
                break;
            case "Yellow":
                spriteRenderer = enemyPrefab.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.yellow;
                break;
        }
    }
}
