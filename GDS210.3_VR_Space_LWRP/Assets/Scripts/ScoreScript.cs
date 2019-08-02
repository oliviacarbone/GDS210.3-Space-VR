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

        currentScoreText.text = currentScore.ToString();
        highScoreText.text = scoreIntValuesList[0].currentTopScores.ToString();
        secondPlayerScoreText.text = scoreIntValuesList[1].currentTopScores.ToString();
        thirdlayerScoreText.text = scoreIntValuesList[2].currentTopScores.ToString();
        fourthPlayerScoreText.text = scoreIntValuesList[3].currentTopScores.ToString();
        fifthPlayerScoreText.text = scoreIntValuesList[4].currentTopScores.ToString();
    }

    void GetScoreSystem(int sceneIndex)
    {
        #region Scene.Guillaume
        if (SceneManager.GetActiveScene().name == "Guillaume")
        {
            int test = 0;

            if (PlayerPrefs.HasKey(scoreValueNames[0].HighScore))
            {
                test = scoreIntValuesList[0].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[0].HighScore);
            }
            else
            {
                Debug.LogWarning("HighScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].SecondScore))
            {
                scoreIntValuesList[1].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[0].SecondScore);
            }
            else
            {
                Debug.LogError("SecondScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].ThirdScore))
            {
                scoreIntValuesList[2].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[0].ThirdScore);
            }
            else
            {
                Debug.LogError("ThirdScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FourthScore))
            {
                test = scoreIntValuesList[3].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[0].FourthScore);
            }
            else
            {
                Debug.LogError("FourthScore not found!!");
            }

            if (PlayerPrefs.HasKey(scoreValueNames[0].FifthScore))
            {
                test = scoreIntValuesList[4].currentTopScores = PlayerPrefs.GetInt(scoreValueNames[0].FifthScore);
            }
            else
            {
                Debug.LogError("FifthScore not found!!");
            }
            Debug.Log(test);
        }
        #endregion
        #region Scene.TestScore1
        else if (SceneManager.GetActiveScene().name == "TestScore1")
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
        else if (SceneManager.GetActiveScene().name == "TestScore2")
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
                    if (currentScore > scoreIntValuesList[j].currentTopScores)
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
                    if (currentScore > scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].SecondScore, scoreIntValuesList[j].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].SecondScore, scoreIntValuesList[j].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }

                }
            }
            ThirdScoreSystem();

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
                    if (currentScore > scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].ThirdScore, scoreIntValuesList[j].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].ThirdScore, scoreIntValuesList[j].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }
                }
            }
            FourthScoreSystem();

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
                    if (currentScore > scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].FourthScore, scoreIntValuesList[j].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].FourthScore, scoreIntValuesList[j].currentTopScores));
                        currentScore = scoreIntValuesList[j].oldCurrentTopScores;
                        break;
                    }
                }
            }
            FifthScoreSystem();

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
                    if (currentScore > scoreIntValuesList[j].currentTopScores)
                    {
                        scoreIntValuesList[j].oldCurrentTopScores = scoreIntValuesList[j].currentTopScores;
                        scoreIntValuesList[j].currentTopScores = currentScore;
                        PlayerPrefs.SetInt(scoreValueNames[i].FifthScore, scoreIntValuesList[j].currentTopScores);
                        print(PlayerPrefs.GetInt(scoreValueNames[i].FifthScore, scoreIntValuesList[j].currentTopScores));
                        return;
                    }
                }
            }

        }
    }
    #endregion

}
