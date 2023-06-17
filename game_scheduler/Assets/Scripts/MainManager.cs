using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public enum GameType
    {
        LostArk,
        MapleStory
    }
    public enum TimeType
    {
        Day,
        Week,
        Month
    }

    [Header("Main manager")]
    public GameInfo gameInfo;

    public GameObject characterList;
    public GameObject characterListObj;

    public GameObject gameList;
    public GameObject gameListObj;

    public GameObject categoryList;
    public GameObject addButton;

    public List<Sprite> characterSprites;
    public int spriteIndex = 0;

    public Text workText;
    public float workCount = 0.0f;
    public float doWork = 0.0f;
    public float curWork = 0.0f;

    [Header("Time Object")]
    public GameTime gameTime;

    [Header("Category")]
    public Category category;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        gameTime = FindObjectOfType<GameTime>();
    }

    private void Start()
    {
        //MapleUpdateGameList();
        //LostArkUpdateGameList();
        UpdateTimeBtn();
        UpdateCharacterList();
        UpdateWorkText();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Game Type : " + gameType.ToString());
    }

    public void MapleUpdateGameList()
    {
        GameObject _gameListObj = Instantiate(gameListObj, gameList.transform.position, Quaternion.identity);
        GameIcon _gameListObjIcon = _gameListObj.GetComponent<GameIcon>();
        _gameListObjIcon.icon = gameInfo.map_icon;
        _gameListObjIcon.gameType = GameType.MapleStory;
        _gameListObjIcon.UpdateInfo();
        _gameListObj.transform.SetParent(gameList.transform);
    }

    public void LostArkUpdateGameList()
    {
        GameObject _gameListObj = Instantiate(gameListObj, gameList.transform.position, Quaternion.identity);
        GameIcon _gameListObjIcon = _gameListObj.GetComponent<GameIcon>();
        _gameListObjIcon.icon = gameInfo.loa_icon;
        _gameListObjIcon.gameType = GameType.LostArk;
        _gameListObjIcon.UpdateInfo();
        _gameListObj.transform.SetParent(gameList.transform);
    }

    public void UpdateWorkText()
    {
        int workRating = (int)Math.Round(curWork * 100.0f);
        workText.text = workRating + "%";
        if (workRating < 50)
        {
            workText.color = Color.red;
        }
        else if (workRating < 90)
        {
            workText.color = Color.yellow;
        }
        else
        {
            workText.color = Color.green;
        }
    }

    public void UpdateCharacterList()
    {
        Transform[] childList = characterList.GetComponentsInChildren<Transform>();
        if(childList != null)
        {
            for(int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }
        spriteIndex = 0;
        
        if(gameInfo.gameType == GameType.MapleStory)
        {
            if(gameInfo.timeType == TimeType.Day)
            {
                workCount = gameInfo.mapleDayWorkCount;
                doWork = gameInfo.mapleDayDoWork;
                curWork = gameInfo.mapleDayCurWork;
            }
            else if (gameInfo.timeType == TimeType.Week)
            {
                workCount = gameInfo.mapleWeekWorkCount;
                doWork = gameInfo.mapleWeekDoWork;
                curWork = gameInfo.mapleWeekCurWork;
            }
            else if (gameInfo.timeType == TimeType.Month)
            {
                workCount = gameInfo.mapleMonthWorkCount;
                doWork = gameInfo.mapleMonthDoWork;
                curWork = gameInfo.mapleMonthCurWork;
            }
        }
        else if(gameInfo.gameType == GameType.LostArk)
        {
            if (gameInfo.timeType == TimeType.Day)
            {
                workCount = gameInfo.loaDayWorkCount;
                doWork = gameInfo.loaDayDoWork;
                curWork = gameInfo.loaDayCurWork;
            }
            else if (gameInfo.timeType == TimeType.Week)
            {
                workCount = gameInfo.loaWeekWorkCount;
                doWork = gameInfo.loaWeekDoWork;
                curWork = gameInfo.loaWeekCurWork;
            }
            else if (gameInfo.timeType == TimeType.Month)
            {
                gameInfo.timeType = TimeType.Week;
                workCount = gameInfo.loaWeekWorkCount;
                doWork = gameInfo.loaWeekDoWork;
                curWork = gameInfo.loaWeekCurWork;
            }
        }
        
        if(doWork == 0.0f || workCount == 0.0f)
        {
            curWork = 0.0f;
        }
        else
        {
            curWork = doWork / workCount;
        }

        UpdateWorkText();

        GameObject _categoryList = Instantiate(categoryList, characterList.transform.position, Quaternion.identity);
        _categoryList.transform.SetParent(characterList.transform);
        if(gameInfo.gameType == GameType.MapleStory)
        {
            for (int i = 0; i < gameInfo.maple_characterList.Count; i++)
            {
                GameObject _characterListObj = Instantiate(characterListObj, characterList.transform.position, Quaternion.identity);
                _characterListObj.GetComponent<Image>().sprite = characterSprites[spriteIndex];
                if (spriteIndex >= 4) spriteIndex = 0;
                else spriteIndex++;
                CharacterInfo _characterInfo = _characterListObj.GetComponent<CharacterInfo>();
                _characterInfo.UpdateCharacterInfo(
                    gameInfo.maple_characterList[i].characterName,
                    gameInfo.maple_characterList[i].className,
                    gameInfo.maple_characterList[i].level);
                _characterListObj.transform.SetParent(characterList.transform);
            }
        }
        else if (gameInfo.gameType == GameType.LostArk)
        {
            for (int i = 0; i < gameInfo.loa_characterList.Count; i++)
            {
                GameObject _characterListObj = Instantiate(characterListObj, characterList.transform.position, Quaternion.identity);
                _characterListObj.GetComponent<Image>().sprite = characterSprites[spriteIndex];
                if (spriteIndex >= 4) spriteIndex = 0;
                else spriteIndex++;
                CharacterInfo _characterInfo = _characterListObj.GetComponent<CharacterInfo>();
                _characterInfo.UpdateCharacterInfo(
                    gameInfo.loa_characterList[i].characterName,
                    gameInfo.loa_characterList[i].className,
                    gameInfo.loa_characterList[i].level);
                _characterListObj.transform.SetParent(characterList.transform);
            }
        }
        GameObject _addButton = Instantiate(addButton, characterList.transform.position, Quaternion.identity);
        _addButton.transform.SetParent(characterList.transform);
    }

    public void UpdateTimeBtn()
    {
        if(gameInfo.gameType == GameType.MapleStory)
        {
            gameTime.mapleTimeBtnObj.SetActive(true);
            gameTime.loaTimeBtnObj.SetActive(false);
        }
        else if (gameInfo.gameType == GameType.LostArk)
        {
            gameTime.mapleTimeBtnObj.SetActive(false);
            gameTime.loaTimeBtnObj.SetActive(true);
        }

        if (gameInfo.gameType == MainManager.GameType.MapleStory)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                gameTime.mapleDayHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                gameTime.mapleWeekHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Month)
            {
                gameTime.mapleMonthHighlightObj.SetActive(true);
            }
        }
        else if (gameInfo.gameType == MainManager.GameType.LostArk)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                gameTime.loaDayHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                gameTime.loaWeekHighlightObj.SetActive(true);
            }
        }
    }
}
