using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryBeyondLogic : MonoBehaviour
{
    public MemoryBeyondButtons[] buttons;
    public List<int> colorList;

    public float hLTime = 0.5f;
    public float delayTime = 0.5f;

    public int level = 2;
    public int playerLevel = 0;

    public bool logic = false;
    public bool player = false;

    private int randomInt;

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
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
            StartCoroutine(GameLogic());
        }
    }

    void ButtonClicked(int number)
    {
        if (player)
        {
            if (number == colorList[playerLevel])
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
        yield return new WaitForSeconds(1f);

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

    public void StartGame()
    {
        logic = true;
        playerLevel = 0;
        level = 2;
        startButton.interactable = false;
    }

    void GameOver()
    {
        startButton.interactable = true;
        player = false;
    }
}
