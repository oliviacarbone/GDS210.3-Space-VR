using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//In this script, you will need to be specific on what you put down in the inpector.
//Make sure that as well everything is in order so that it can work properly as well.

//Setting up the tier list for the leaderboard
[System.Serializable]
public class ScoreIntValues1
{
    public string name;
    public int currentTopScores;
    public int oldCurrentTopScores;
}

public class ScoreScript1 : MonoBehaviour
{
    public enum ScoreState { Save, Done };
    public ScoreState state = ScoreState.Save;

    public int currentScore;

    public Text currentScoreText;
    public Text highScoreText;
    public Text secondPlayerScoreText;
    public Text thirdlayerScoreText;
    public Text fourthPlayerScoreText;
    public Text fifthPlayerScoreText;

    public bool gameIsOver = false;

    public List<ScoreIntValues1> scoreIntValuesList;
    public string[] scoreNames = new string[5];

    private void Awake()
    {
        GetTheScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == false)
        {
            state = ScoreState.Done;
        }

        if (gameIsOver == true)
        {
            state = ScoreState.Save;
            EndOfGameScores();
        }

        currentScoreText.text = currentScore.ToString();
        highScoreText.text = scoreIntValuesList[0].currentTopScores.ToString();
        secondPlayerScoreText.text = scoreIntValuesList[1].currentTopScores.ToString();
        thirdlayerScoreText.text = scoreIntValuesList[2].currentTopScores.ToString();
        fourthPlayerScoreText.text = scoreIntValuesList[3].currentTopScores.ToString();
        fifthPlayerScoreText.text = scoreIntValuesList[4].currentTopScores.ToString();
    }

    void GetTheScore()
    {
        scoreIntValuesList[0].currentTopScores = PlayerPrefs.GetInt(scoreNames[0]);
        scoreIntValuesList[1].currentTopScores = PlayerPrefs.GetInt(scoreNames[1]);
        scoreIntValuesList[2].currentTopScores = PlayerPrefs.GetInt(scoreNames[2]);
        scoreIntValuesList[3].currentTopScores = PlayerPrefs.GetInt(scoreNames[3]);
        scoreIntValuesList[4].currentTopScores = PlayerPrefs.GetInt(scoreNames[4]);
    }

    public void EndTheGame()
    {
        gameIsOver = true;
    }

    //This is where we place the player score onto the leader board.
    //It also makes sure that it is place in the right spot.
    #region EndOFGameScoringSystem
    void EndOfGameScores()
    {
        if (state == ScoreState.Save)
        {
            for (int i = 0; i < scoreIntValuesList.Count; i++)
            {
                if (currentScore > scoreIntValuesList[i].currentTopScores)
                {
                    scoreIntValuesList[i].oldCurrentTopScores = scoreIntValuesList[i].currentTopScores;
                    scoreIntValuesList[i].currentTopScores = currentScore;
                    PlayerPrefs.SetInt(scoreNames[i], scoreIntValuesList[i].currentTopScores);
                    print(PlayerPrefs.GetInt(scoreNames[i], scoreIntValuesList[i].currentTopScores));
                    currentScore = scoreIntValuesList[i].oldCurrentTopScores;
                    EndOfGameScores();
                }
            }

            ChangeTheState();

        }
    }

    void ChangeTheState()
    {
        currentScore = 0;
        gameIsOver = false;
    }
    #endregion

}
