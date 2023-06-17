using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainManager;
using UnityEngine.SceneManagement;

public class AddCharacter : MonoBehaviour
{
    public MainManager mainManager;
    public GameInfo gameInfo;


    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
        gameInfo = FindObjectOfType<GameInfo>();
    }
    
    public void MoveScene()
    {
        if (gameInfo.gameType == MainManager.GameType.LostArk)
        {
            SceneManager.LoadScene("LostArkUpdateScene");
        }
        else if (gameInfo.gameType == MainManager.GameType.MapleStory)
        {
            SceneManager.LoadScene("MapleUpdateScene");
        }
    }
}
