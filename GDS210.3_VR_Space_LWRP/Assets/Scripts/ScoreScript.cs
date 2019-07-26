using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Setting up the structure of the score in order to call it easy.
[System.Serializable]
public struct ScoreValues
{
    public string Name;
    public string HighScore;
    public string CurrentScore;
    public string FirstScore;
    public string SecondScore;
    public string ThirdScore;
    public string FourthScore;
    public string FifthScore;
}

[System.Serializable]
public class ScoreIntValues
{
    public int highScore;
    public int currentScore;
    public List<int> highScoreList = new List<int>();

}


public class ScoreScript : MonoBehaviour
{
    public int highScore;
    public int currentScore;
    public int firstPlayerScore;
    public int secondPlayerScore;
    public int thirdPlayerScore;
    public int fourthPlayerScore;
    public int fifthPlayerScore;

    public Text highScoreText;
    public Text currentScoreText;
    public Text firstPlayerScoreText;
    public Text secondPlayerScoreText;
    public Text thirdlayerScoreText;
    public Text fourthPlayerScoreText;
    public Text fifthPlayerScoreText;

    public bool gameIsOver = false;

    public string[] sceneNames = new string[3];

    public ScoreValues[] scoreValueNames;
    public ScoreIntValues[] scoreIntValues;

    void Awake()
    {

        //scoreIntValues[0].highScoreList.ins

        /*
        if (!PlayerPrefs.HasKey(scoreValueNames[0].HighScore))
        {
            return;]
        }
        */
        for(int i = 0; i < sceneNames.Length; i++ )
        {
            if(SceneManager.GetActiveScene().name == sceneNames[i])
            {
                ScoreSystem(i);
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        //highScoreText.text = scoreIntValues[i].highScore.ToString();
        currentScoreText.text = highScore.ToString();
        firstPlayerScoreText.text = firstPlayerScore.ToString();
        secondPlayerScoreText.text = secondPlayerScore.ToString();
        thirdlayerScoreText.text = thirdPlayerScore.ToString();
        fourthPlayerScoreText.text = fourthPlayerScore.ToString();
        firstPlayerScoreText.text = firstPlayerScore.ToString();
    }

    void ScoreSystem(int sceneIndex)
    {
        int test = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].HighScore, scoreIntValues[sceneIndex].highScore);
        Debug.Log(test);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].CurrentScore, currentScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FirstScore, firstPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].SecondScore, secondPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].ThirdScore, thirdPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FourthScore, fourthPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FifthScore, fifthPlayerScore);
    }

    void EndOfGameScores(int sceneIndex)
    {


        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].HighScore, currentScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FirstScore, highScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].SecondScore, firstPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].ThirdScore, secondPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FourthScore, thirdPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, fourthPlayerScore);
        }
        else if (currentScore > firstPlayerScore)
        {
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FirstScore, currentScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].SecondScore, firstPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].ThirdScore, secondPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FourthScore, thirdPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, fourthPlayerScore);
        }
        else if (currentScore > secondPlayerScore)
        {
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].SecondScore, currentScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].ThirdScore, secondPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FourthScore, thirdPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, fourthPlayerScore);
        }
        else if (currentScore > thirdPlayerScore)
        {
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].ThirdScore, currentScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FourthScore, thirdPlayerScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, fourthPlayerScore);
        }
        else if (currentScore > fourthPlayerScore)
        {
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FourthScore, currentScore);
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, fourthPlayerScore);
        }
        else if (currentScore > firstPlayerScore)
            PlayerPrefs.SetInt(scoreValueNames[sceneIndex].FifthScore, currentScore);
    }

}
