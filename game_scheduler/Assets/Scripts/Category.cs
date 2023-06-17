using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static MainManager;

public class Category : MonoBehaviour
{
    private MainManager mainManager;
    private GameInfo gameInfo;

    public GameObject mapleCheckObj;
    public GameObject loaCheckObj;

    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
        mainManager.category = this;
        gameInfo = FindObjectOfType<GameInfo>();
    }

    private void Start()
    {
        if(gameInfo.gameType == GameType.LostArk)
        {
            loaCheckObj.SetActive(true);
            mapleCheckObj.SetActive(false);
        }
        else
        {
            loaCheckObj.SetActive(false);
            mapleCheckObj.SetActive(true);
        }
    }

    public void MoveGameScene()
    {
        SceneManager.LoadScene("GameAddScene");
    }

    public void SetMapleGame()
    {
        gameInfo.gameType = MainManager.GameType.MapleStory;
        loaCheckObj.SetActive(false);
        mapleCheckObj.SetActive(true);
        mainManager.UpdateCharacterList();
        mainManager.UpdateTimeBtn();
    }

    public void SetLostArk()
    {
        gameInfo.gameType = MainManager.GameType.LostArk;
        loaCheckObj.SetActive(true);
        mapleCheckObj.SetActive(false);
        mainManager.UpdateCharacterList();
        mainManager.UpdateTimeBtn();
    }
}
