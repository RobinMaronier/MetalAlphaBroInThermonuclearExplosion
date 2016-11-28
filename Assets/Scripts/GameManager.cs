using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public GameObject[] players;
    public Sprite[] weapons;

    private bool isMuted = false;

    void Start()
    {
        float randomPlayer;
        randomPlayer = Random.Range(0.0f, players.Length);
        Debug.Log("Player to Instantiate: " + ((int)randomPlayer + 1));
        Instantiate(players[(int)randomPlayer], new Vector3(0.5f, 0.6f, 0), players[(int)randomPlayer].transform.rotation);
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        MainCamera.GetComponent<CameraController>().player = Player;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MapLimit"))
        {
            obj.GetComponent<LimitFollowPlayer>().player = Player;
            obj.GetComponent<LimitFollowPlayer>().CheckOffset();
        }
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[5] = MainCamera.transform.Find("Numbers/Number01").gameObject;
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[4] = MainCamera.transform.Find("Numbers/Number02").gameObject;
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[3] = MainCamera.transform.Find("Numbers/Number03").gameObject;
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[2] = MainCamera.transform.Find("Numbers/Number04").gameObject;
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[1] = MainCamera.transform.Find("Numbers/Number05").gameObject;
        Player.transform.Find("PlayerScore").GetComponent<playerScore>().scoreNumbers[0] = MainCamera.transform.Find("Numbers/Number06").gameObject;
        MainCamera.transform.Find("Weapon").GetComponent<SpriteRenderer>().sprite = weapons[(int)randomPlayer];
        if ((int)randomPlayer == 2) // If Russian
        {
            int i = 0;
            while (i < 12)
            {
                if (i + 1 <= 9)
                    Player.transform.Find("Shotgun").GetComponent<PlayerShootShotgun>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet0" + (i + 1)).gameObject;
                else
                    Player.transform.Find("Shotgun").GetComponent<PlayerShootShotgun>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet" + (i + 1)).gameObject;
                ++i;
            }
        }
        else if ((int)randomPlayer == 4) // If Baracuda
        {
            int i = 0;
            while (i < 12)
            {
                if (i + 1 <= 9)
                    Player.transform.Find("Minigun").GetComponent<PlayerShootMinigun>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet0" + (i + 1)).gameObject;
                else
                    Player.transform.Find("Minigun").GetComponent<PlayerShootMinigun>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet" + (i + 1)).gameObject;
                ++i;
            }
        }
        else if ((int)randomPlayer == 5) // If Sniper
        {
            int i = 0;
            while (i < 12)
            {
                if (i + 1 <= 9)
                    Player.transform.Find("SniperRifle").GetComponent<PlayerShootSniper>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet0" + (i + 1)).gameObject;
                else
                    Player.transform.Find("SniperRifle").GetComponent<PlayerShootSniper>().HUD[i] = MainCamera.transform.Find("HUDBullets/HUDBullet" + (i + 1)).gameObject;
                ++i;
            }
        }
    }

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
            if (GetComponent<AudioSource>())
            {
                GetComponent<AudioSource>().Stop();
            }
            Invoke("LoadGameOverAfterDelay", 3.0f);
            /*if (Input.GetKeyDown(KeyCode.Return))
            {
#pragma warning disable CS0618 // Type or member is obsolete
                Application.LoadLevel(Application.loadedLevel);
#pragma warning restore CS0618 // Type or member is obsolete
            }*/
        }
    }

    void LoadGameOverAfterDelay()
    {
        SceneManager.LoadScene("GameOver");
    }
}
