using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBeyondLogic : MonoBehaviour
{
    public MemoryBeyondButtons[] buttons;
    public List<int> colorList;

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

    public bool logic = false;
    public bool player = false;

    private int randomInt;

    public Button startButton;
    public Text startButtonText;

    public Button restartButton;
    public Text restartButtonText;

    private void Awake()
    {
        hLTime = 0.75f;
        delayTime = 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());

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
                level += 1;
                playerLevel = 0;
                player = false;
                colorList.Clear();
                TimeDecrease();
                logic = true;
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

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(3);

        StartGame();
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
        logic = true;
        playerLevel = 0;
        level = 2;
    }

    void GameOver()
    {
        player = false;
        colorList.Clear();
    }

    private void TimeDecrease()
    {
        hLTime = hLTime - 0.05f;
        delayTime = delayTime - 0.03f;
        //Debug.Log(hLTime);
        //Debug.Log(delayTime);
    }
}
