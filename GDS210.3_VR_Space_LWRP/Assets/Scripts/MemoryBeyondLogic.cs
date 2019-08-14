using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBeyondLogic : MonoBehaviour
{
    //to prevent the player to spam the button
    public enum StartTheGameState { Start, RoundScreen, DoNothing};
    public StartTheGameState state = StartTheGameState.Start;
    public MemoryBeyondButtons[] buttons;
    public List<int> colorList;

    public TimeScript timer;

    private float hLTime; //highLightTime, the time a block stays on the secondary material
    public float HLTime
    {
        get { return hLTime; }

        set
        {
            if (value < 0.1f)
            {
                hLTime = 0.1f;
            }
            else
            {
                hLTime = value;
            }
        }

    }

    private float delayTime; //the time before the next block changes material
    public float DelayTime
    {
        get { return delayTime; }

        set
        {
            if (value < 0.05f)
            {
                delayTime = 0.05f;
            }
            else
            {
                delayTime = value;
            }
        }
    }

    public int level = 2; //the beginning number of cubes to change material 
    public int playerLevel = 0;
    public int round = 1;

    public bool logic = false;
    public bool player = false;

    private int randomInt;

    public GameObject gameOverScreen;
    public GameObject roundScreen;

    private void Awake()
    {
        hLTime = 1f;
        delayTime = 0.75f;
        gameOverScreen.SetActive(false);
        roundScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++) //loops through the available buttons
        {
            buttons[i].OnClick += ButtonClicked;
            buttons[i].buttonNumber = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        LogicCheck();
        if(timer.minute == 0 && timer.second == 0)
        {
            GameOver();
        }
    }

    void ButtonClicked(int number)
    {
        if (player == true)
        {
            if (number == colorList[playerLevel]) //checks if the player has followed the pattern, adding to the pattern if true or running game over if false
            {
                playerLevel += 1;
            }
            else
            {
                GameOver();
            }
            if (playerLevel == level)
            {
                NextRound();
            }
        }
    }

    private IEnumerator GameLogic()
    {
        yield return new WaitForSeconds(0.5f); //adds to the pattern if the player is keeping track, and highlights the next cube

        for (int i = 0; i < level; i++)
        {
            if (colorList.Count < level)
            {
                randomInt = Random.Range(0, buttons.Length);
                colorList.Add(randomInt);
            }
            
            buttons[colorList[i]].ClickedColor();
            yield return new WaitForSeconds(HLTime);

            buttons[colorList[i]].UnclickedColor();
            yield return new WaitForSeconds(DelayTime);  
        }
        player = true;
    }

    private IEnumerator RoundScreenManager()
    {
        yield return new WaitForSeconds(2f);

        if (roundScreen == true)
        {
            state = StartTheGameState.DoNothing;
            roundScreen.SetActive(false);
            logic = true;
        }
    }

    private void LogicCheck()
    {
        if (logic == true)
        {
            logic = false;
            StartCoroutine(GameLogic());
        }
    }

    public void StartGame() //the button for the start of the game, turns on the logic and turns off the start button
    {
        if (state == StartTheGameState.Start)
        {
            gameOverScreen.SetActive(false);
            roundScreen.SetActive(false);
            logic = true;
            playerLevel = 0;
            level = 2;
            timer.state = TimeScript.TimeState.Countdown;

            state = StartTheGameState.DoNothing;
        }
    }

    void GameOver()
    {
        player = false;
        logic = false;
        colorList.Clear();
        gameOverScreen.SetActive(true);

        state = StartTheGameState.Start;
    }

    public void RoundChange()
    {
        if (state == StartTheGameState.RoundScreen)
        {
            roundScreen.SetActive(true);
            player = false;
            logic = false;
            StartCoroutine(RoundScreenManager());
        }
    }

    private void NextRound()
    {
        level += 1;
        playerLevel = 0;
        colorList.Clear();
        //TimeDecrease();
        round = round + 1;
        state = StartTheGameState.RoundScreen;
        RoundChange();
    }

    private void TimeDecrease()
    {
        hLTime = hLTime - 0.05f;
        delayTime = delayTime - 0.03f;
    }
}
