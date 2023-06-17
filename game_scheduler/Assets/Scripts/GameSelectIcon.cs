using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSelectIcon : MonoBehaviour
{
    public Sprite icon;
    public MainManager.GameType gameType;

    public void UpdateInfo()
    {
        gameObject.GetComponent<Image>().sprite = icon;
    }

    public void MoveGameScene()
    {
        if(gameType == MainManager.GameType.LostArk)
        {
            SceneManager.LoadScene("LostArkUpdateScene");
        }
        else if (gameType == MainManager.GameType.MapleStory)
        {
            SceneManager.LoadScene("MapleUpdateScene");
        }
    }
}
