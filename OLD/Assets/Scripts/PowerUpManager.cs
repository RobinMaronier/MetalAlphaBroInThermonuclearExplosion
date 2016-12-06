using UnityEngine;
using System.Collections;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] weapons;
    private int powerLevel = -1;

    void PowerUp()
    {
        powerLevel++;
        if (powerLevel < weapons.Length)
        {
            weapons[powerLevel].SetActive(true);
            weapons[++powerLevel].SetActive(true);
        }
    }
}
