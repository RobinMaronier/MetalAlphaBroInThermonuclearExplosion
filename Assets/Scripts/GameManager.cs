using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;

    private bool isMuted = false;

    void OnGUI()
    {
        if (gameOver)
        {
            GUILayout.Label("GAME OVER");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isMuted == false)
            {
                GetComponent<AudioSource>().volume = 0.0f;
                isMuted = true;
            }
            else
            {
                GetComponent<AudioSource>().volume = 1.0f;
                isMuted = false;
            }
        }
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
}
