using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    //Seperating them into different state to make the timer work properly
    public enum TimeState { Tutorial, Countdown, Wait, TimeIsUp, DoNothing};
    public TimeState state = TimeState.Tutorial;

    public Text timeText;
    //Setting up the timer.
    public int minute;
    public int second;

    public GameObject tutorialScreen;
    public GameObject gameIsOverScreen;

    // Update is called once per frame
    void Update()
    {
        //To prevent anyone to make the seconds go over 60 seconds.
        if (second >= 60)
        {
            second = 59;
        }

        //To make sure that everything is working as intended to.
        switch(state)
        {
            case (TimeState.Tutorial):
                TutorialScreen();
                break;
            case (TimeState.Countdown):
                StartCoroutine("LoseTime");
                state = TimeState.Wait;
                break;
            case (TimeState.Wait):
                if (minute > 0 && second < 0)
                {
                    minute--;
                    second = 59;
                }
                else if (minute == 0 && second == 0)
                {
                    //Once the timer is done, it stops everthing. 
                    StopCoroutine("LoseTime");
                    state = TimeState.TimeIsUp;
                }
                break;
            case (TimeState.TimeIsUp):
                GameIsOver();
                break;
        }

        //combining it together to make it work.
        timeText.text = minute.ToString("00") + ":" + second.ToString("00");

    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            second--;
        }
    }

    void TutorialScreen()
    {
        Time.timeScale = 0;
        tutorialScreen.SetActive(true);
    }

    public void StartTheGame()
    {
        Time.timeScale = 1;
        tutorialScreen.SetActive(false);
        state = TimeState.Countdown;
    }

    void GameIsOver()
    {
        Debug.Log("Game is done.");
        state = TimeState.DoNothing;
    }
}
