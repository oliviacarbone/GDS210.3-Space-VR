using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//In this script, you will need to be specific on what you put down in the inpector.
//Make sure that as well everything is in order so that it can work properly as well.

//Setting up the structure of the score in order to call it easy.
[System.Serializable]
public struct ScoreValues
{
    public string Name;
    public string HighScore;
    public string CurrentScore;
    public string SecondScore;
    public string ThirdScore;
    public string FourthScore;
    public string FifthScore;
}

//Setting up the tier list for the leaderboard
[System.Serializable]
public class ScoreIntValues
{
    public string name;
    public int currentTopScores;
    public int oldCurrentTopScores;
}


public class ScoreScript : MonoBehaviour
{
    public int currentScore;

    public Text currentScoreText;
    public Text highScoreText;
    public Text secondPlayerScoreText;
    public Text thirdlayerScoreText;
    public Text fourthPlayerScoreText;
    public Text fifthPlayerScoreText;

    public bool gameIsOver = false;

    public string[] sceneNames = new string[3];

    public List<ScoreValues> scoreValueNames;
    public List<ScoreIntValues> scoreIntValuesList;

    void Awake()
    {
        //When the game starts, it will try and find what scene we are in before start the game.
        for(int i = 0; i < sceneNames.Length; i++ )
        {
            if(SceneManager.GetActiveScene().name == sceneNames[i]) 
            {
                GetScoreSystem(i);
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == true)
        {
            EndOfGameScores();
        }
        currentScoreText.text = currentScore.ToString();
        highScoreText.text = scoreIntValuesList[0].currentTopScores.ToString();
        secondPlayerScoreText.text = scoreIntValuesList[1].currentTopScores.ToString();
        thirdlayerScoreText.text = scoreIntValuesList[2].currentTopScores.ToString();
        fourthPlayerScoreText.text = scoreIntValuesList[3].currentTopScores.ToString();
        fifthPlayerScoreText.text = scoreIntValuesList[4].currentTopScores.ToString();
    }

    void GetScoreSystem(int sceneIndex)
    {
        //Reminder that we need to change some of the names in order to get this work on certain scenes.
        //This right here is the way to call each leaderboard script in our game.
        //Make sure that you write the right scene name properly otherwise this won't work.
        #region Scene.ColonyManager
        if (SceneManager.GetActiveScene().name == "ColonyManager")
        {
            int test = 0;

            if (PlayerPrefs.HasKey(scoreValueNames[sceneIndex].HighScore))
            {
                test = scoreIntValuesList[0].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].HighScore);
            }
            else
            {
                Debug.LogWarning("HighScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[sceneIndex].SecondScore))
            {
                scoreIntValuesList[1].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].SecondScore);
            }
            else
            {
                Debug.LogError("SecondScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[sceneIndex].ThirdScore))
            {
                scoreIntValuesList[2].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].ThirdScore);
            }
            else
            {
                Debug.LogError("ThirdScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[sceneIndex].FourthScore))
            {
                test = scoreIntValuesList[3].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FourthScore);
            }
            else
            {
                Debug.LogError("FourthScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[sceneIndex].FifthScore))
            {
                test = scoreIntValuesList[4].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[sceneIndex].FifthScore);
            }
            else
            {
                Debug.LogError("FifthScore not found!!");
            }
            Debug.Log(test);
        }
        #endregion
        #region Scene.TestScore1
        else if (SceneManager.GetActiveScene().name == "ScoreTest1")
        {
            if (PlayerPrefs.HasKey(scoreValueNames[0].HighScore))
            {
                scoreIntValuesList[0].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[1].HighScore);
            }
            else
            {
                Debug.LogWarning("HighScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].SecondScore))
            {
                scoreIntValuesList[1].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[1].SecondScore);
            }
            else
            {
                Debug.LogError("SecondScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].ThirdScore))
            {
                scoreIntValuesList[2].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[1].ThirdScore);
            }
            else
            {
                Debug.LogError("ThirdScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FourthScore))
            {
                scoreIntValuesList[3].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[1].FourthScore);
            }
            else
            {
                Debug.LogError("FourthScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FifthScore))
            {
                scoreIntValuesList[4].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[1].FifthScore);
            }
            else
            {
                Debug.LogError("FifthScore not found!!");
            }
        }
        #endregion
        #region Scene.TestScore2
        else if (SceneManager.GetActiveScene().name == "ScoreTest2")
        {
            if (PlayerPrefs.HasKey(scoreValueNames[0].HighScore))
            {
                scoreIntValuesList[0].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[2].HighScore);
            }
            else
            {
                Debug.LogWarning("HighScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].SecondScore))
            {
                scoreIntValuesList[1].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[2].SecondScore);
            }
            else
            {
                Debug.LogError("SecondScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].ThirdScore))
            {
                scoreIntValuesList[2].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[2].ThirdScore);
            }
            else
            {
                Debug.LogError("ThirdScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FourthScore))
            {
                scoreIntValuesList[3].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[2].FourthScore);
            }
            else
            {
                Debug.LogError("FourthScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FifthScore))
            {
                scoreIntValuesList[4].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[2].FifthScore);
            }
            else
            {
                Debug.LogError("FifthScore not found!!");
            }
        }
        #endregion

    }

    //This is where we place the player score onto the leader board.
    //It also makes sure that it is place in the right spot.
    #region EndOFGameScoringSystem
    public void EndOfGameScores()
    {
        //So this script will go down the list of highscore to see where tht player score should go.

        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                for (int j = 0; j < scoreIntValuesList.Count; j++)
                {
                    if (currentScore >= scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].HighScore, scoreIntValuesList[j].currentTopScores);
                        print (PlayerPrefs.GetInt(scoreValueNames[i].HighScore, scoreIntValuesList[j].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }
                }

                SecondScoreSystem();

            }

        }

    }

    void SecondScoreSystem()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                for (int j = 0; j < scoreIntValuesList.Count; j++)
                {
                    if (currentScore >= scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].SecondScore, scoreIntValuesList[1].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].SecondScore, scoreIntValuesList[1].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }

                }

                ThirdScoreSystem();

            }
        }
    }

    void ThirdScoreSystem()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                for (int j = 0; j < scoreIntValuesList.Count; j++)
                {
                    if (currentScore >= scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].ThirdScore, scoreIntValuesList[2].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].ThirdScore, scoreIntValuesList[2].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }
                }

                FourthScoreSystem();

            }

        }
    }

    void FourthScoreSystem()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                for (int j = 0; j < scoreIntValuesList.Count; j++)
                {
                    if (currentScore >= scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].FourthScore, scoreIntValuesList[3].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].FourthScore, scoreIntValuesList[3].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }
                }

                FifthScoreSystem();

            }

        }
    }

    void FifthScoreSystem()
    {
        for (int i = 0; i < sceneNames.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == sceneNames[i])
            {
                for (int j = 0; j < scoreIntValuesList.Count; j++)
                {
                    if (currentScore >= scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].FifthScore, scoreIntValuesList[4].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].FifthScore, scoreIntValuesList[4].currentTopScores));
                        currentScore = 0;
                        return;
                    }
                }
            }

        }
    }
    #endregion

}
