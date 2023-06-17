using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameIcon : MonoBehaviour
{
    private MainManager mainManager;
    private GameInfo gameInfo;

    public Sprite icon;
    public MainManager.GameType gameType;

    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
        gameInfo = FindObjectOfType<GameInfo>();
    }


    public void UpdateInfo()
    {
        gameObject.GetComponent<Image>().sprite = icon;
    }

    public void UpdateGame()
    {
        gameInfo.gameType = gameType;
        mainManager.UpdateCharacterList();
        mainManager.UpdateTimeBtn();
    }
}
