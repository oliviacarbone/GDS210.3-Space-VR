﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
            */

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
