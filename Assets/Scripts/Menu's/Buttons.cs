using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void Retry()
    {
        Destroy(GameObject.Find("SaveScore"));
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Destroy(GameObject.Find("SaveScore"));
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        SceneManager.LoadScene(3);
    }

    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
