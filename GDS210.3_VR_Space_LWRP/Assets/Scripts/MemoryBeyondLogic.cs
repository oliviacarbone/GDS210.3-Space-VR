using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemoryBeyondLogic : MonoBehaviour
{
    public MemoryBeyondButtons[] buttons;
    public List<int> colorList;

    public float hLTime = 0.5f; //highLightTime, the time a block stays on the secondary material
    public float delayTime = 0.2f; //the time before the next block changes material

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
        startButton.interactable = true;
        startButtonText.text = "Start";

        restartButton.interactable = false;
        restartButtonText.text = "";
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
        if (logic)
        {
            logic = false;
            StartCoroutine(GameLogic()); //starts the random button functions
        }
    }

    void ButtonClicked(int number)
    {
        if (player)
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
            yield return new WaitForSeconds(hLTime);

            buttons[colorList[i]].UnclickedColor();
            yield return new WaitForSeconds(delayTime);
        }
        player = true;
    }

    public void StartGame() //the button for the start of the game, turns on the logic and turns off the start button
    {
        logic = true;
        playerLevel = 0;
        level = 2;
        startButton.interactable = false;
        startButtonText.text = "";
    }

    void GameOver()
    {
        player = false;
        restartButton.interactable = true;
        restartButtonText.text = "Restart";
        colorList.Clear();
    }

    public void RestartButton()
    {
        startButton.interactable = true;
        startButtonText.text = "Start";
        restartButton.interactable = false;
        restartButtonText.text = "";
    }
}
