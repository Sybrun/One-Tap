using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    public float switchTime;
    public int bulletStage;

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public GameObject stage4;

    /// <summary>
    /// Sets the values of the variables: switchTime and bulletStage. "switchTime" controls the pause time between switching Stages, whereas "bulletSatge"
    /// simply keeps track of the current Stage. And finally, the BulletStageSwitch Coroutine will be started.
    /// </summary>
    void Start ()
    {
        switchTime = 1f;
        bulletStage = 1;
        StartCoroutine("BulletStageSwitch");
    }

    /// <summary>
    /// Checks the value of the bulletStage and will match the UI to this value (e.g. if it's Stage 2, the UI of Stage 2 will be set active).
    /// After that, it will wait for the value of switchTime in seconds and will increase the bulletStage count by 1. 
    /// If it's done with everything it will start the Coroutine again, and will repeat the whole process untill the bulletStage reaches a value 
    /// that is not 1, 2, 3 or 4. In that case, it will simply set the count to 1 again resulting in an endless loop.
    /// </summary>
    /// <returns></returns>
    IEnumerator BulletStageSwitch()
    {
        while (true)
        {
            if (bulletStage == 1)
            {
                stage1.SetActive(true);
                stage2.SetActive(false);
                stage3.SetActive(false);
                stage4.SetActive(false);
                switchTime = 0.6f;

                yield return new WaitForSeconds(switchTime);
                bulletStage++;
            }
            else if (bulletStage == 2)
            {
                stage1.SetActive(true);
                stage2.SetActive(true);
                stage3.SetActive(false);
                stage4.SetActive(false);
                switchTime = 0.5f;

                yield return new WaitForSeconds(switchTime);
                bulletStage++;
            }
            else if (bulletStage == 3)
            {
                stage1.SetActive(true);
                stage2.SetActive(true);
                stage3.SetActive(true);
                stage4.SetActive(false);
                switchTime = 0.4f;

                yield return new WaitForSeconds(switchTime);
                bulletStage++;
            }
            else if (bulletStage == 4)
            {
                stage1.SetActive(false);
                stage2.SetActive(false);
                stage3.SetActive(false);
                stage4.SetActive(true);
                switchTime = 0.3f;

                yield return new WaitForSeconds(switchTime);
                bulletStage++;
            }
            else
            {
                bulletStage = 1;
                stage1.SetActive(true);
                stage2.SetActive(false);
                stage3.SetActive(false);
                stage4.SetActive(false);
            }

        }
    }
}
