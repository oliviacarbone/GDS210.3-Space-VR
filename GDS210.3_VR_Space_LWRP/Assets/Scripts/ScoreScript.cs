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
    public string name;
    public int currentTopScores;
    public int currentScore;

}


public class ScoreScript : MonoBehaviour
{
    public int currentScore;

    /*
    public int highScore;
    public int firstPlayerScore;
    public int secondPlayerScore;
    public int thirdPlayerScore;
    public int fourthPlayerScore;
    public int fifthPlayerScore;
    */

    public Text currentScoreText;
    public Text highScoreText;
    public Text secondPlayerScoreText;
    public Text thirdlayerScoreText;
    public Text fourthPlayerScoreText;
    public Text fifthPlayerScoreText;

    public bool gameIsOver = false;

    public string[] sceneNames = new string[3];

    public ScoreValues[] scoreValueNames;
    public List<ScoreIntValues> scoreIntValuesList;

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
        scoreIntValuesList[Random.Range(0,5)].currentScore = currentScore;

        //currentScoreText.text = highScore.ToString();
        highScoreText.text = scoreIntValuesList[0].currentTopScores.ToString();
        secondPlayerScoreText.text = scoreIntValuesList[1].currentTopScores.ToString();
        thirdlayerScoreText.text = scoreIntValuesList[2].currentTopScores.ToString();
        fourthPlayerScoreText.text = scoreIntValuesList[3].currentTopScores.ToString();
        fifthPlayerScoreText.text = scoreIntValuesList[4].currentTopScores.ToString();
    }

    void ScoreSystem(int sceneIndex)
    {
        int test = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].HighScore, scoreIntValuesList[sceneIndex].currentTopScores);
        Debug.Log(test);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].CurrentScore, currentScore);
        int test2 = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FirstScore, scoreIntValuesList[1].currentTopScores);
        Debug.Log(test2);
        /*
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].SecondScore, secondPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].ThirdScore, thirdPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FourthScore, fourthPlayerScore);
        PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FifthScore, fifthPlayerScore);
        */
    }

    public void EndOfGameScores(int sceneIndex)
    {
        //So this script will go down the list of highscore to see where tht player score should go.
        for (int i = 0; i < scoreIntValuesList.Count; i++)
        {
            if (scoreIntValuesList[i].currentScore > scoreIntValuesList[i].currentTopScores)
            {
                scoreIntValuesList[i].currentTopScores = scoreIntValuesList[i].currentScore;
                return;
            }

        }


        /*
        //So this script will go down the list of highscore to see where tht player score should go.
        for (int i = 0; i < scoreIntValuesList.Count; i++)
        {
            for (int j = i + 1; j < scoreIntValuesList.Count; j++)
            {
                //If the score is greater than the high score, than they will swap.
                if (scoreIntValuesList[j].currentScore > scoreIntValuesList[i].highScores)
                {
                    ScoreIntValues tmp = scoreIntValuesList[i];
                    scoreIntValuesList[i] = scoreIntValuesList[j];
                    scoreIntValuesList[j] = tmp;
                }
            }
        }
        */

    }

}
