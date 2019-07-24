using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{

    public enum TimeState { Tutorial, Countdown, Wait, TimeIsUp, DoNothing};
    public TimeState state = TimeState.Tutorial;

    public Text timeText;
    public int minute;
    public int second;

    public GameObject tutorialScreen;
    public GameObject gameIsOverScreen;

    // Update is called once per frame
    void Update()
    {
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
                    StopCoroutine("LoseTime");
                    state = TimeState.TimeIsUp;
                }
                break;
            case (TimeState.TimeIsUp):
                GameIsOver();
                break;
        }

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
