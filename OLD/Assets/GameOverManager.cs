using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Invoke("LoadMainMenuAfterDelay", 4.0f);
    }

    void LoadMainMenuAfterDelay()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
