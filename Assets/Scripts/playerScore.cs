using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerScore : MonoBehaviour
{
    //public Text scoreText;
    public GameObject[] scoreNumbers;
    public Sprite[] digits;

    private int score;

	// Use this for initialization
	void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void AddToScoreThenDisplay(int points)
    {
        string scoreStr;
        string zeros = "";
        int i = 0;

        score += points;
        while (i < 9 - score.ToString().Length)
        {
            zeros += "0";
            ++i;
        }
        //scoreText.text = zeros + score.ToString();

        scoreStr = score.ToString();
        i = 0;
        while (i < scoreStr.Length)
        {
            switch (scoreStr[i])
            {
                case '0':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[0];
                    break;
                case '1':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[1];
                    break;
                case '2':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[2];
                    break;
                case '3':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[3];
                    break;
                case '4':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[4];
                    break;
                case '5':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[5];
                    break;
                case '6':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[6];
                    break;
                case '7':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[7];
                    break;
                case '8':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[8];
                    break;
                case '9':
                    scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().sprite = digits[9];
                    break;
            }
            scoreNumbers[i + 6 - scoreStr.Length].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            StartCoroutine(GoBackToNormalAlpha(scoreNumbers[i + 6 - scoreStr.Length], 0.05f));
            ++i;
        }
    }

    IEnumerator GoBackToNormalAlpha(GameObject Number, float delay)
    {
        yield return new WaitForSeconds(delay);

        Number.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }
}
