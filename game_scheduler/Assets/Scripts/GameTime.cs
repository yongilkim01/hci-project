using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainManager;

public class GameTime : MonoBehaviour   
{
    private MainManager mainManager;
    private GameInfo gameInfo;

    public GameObject mapleTimeBtnObj;
    public GameObject loaTimeBtnObj;

    public GameObject mapleDayHighlightObj;
    public GameObject mapleWeekHighlightObj;
    public GameObject mapleMonthHighlightObj;

    public GameObject loaDayHighlightObj;
    public GameObject loaWeekHighlightObj;

    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
        gameInfo = FindObjectOfType<GameInfo>();
    }

    private void Start()
    {
        if(gameInfo.gameType == MainManager.GameType.MapleStory)
        {
            if(gameInfo.timeType == MainManager.TimeType.Day)
            {
                mapleDayHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                mapleWeekHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Month)
            {
                mapleMonthHighlightObj.SetActive(true);
            }
        }
        else if (gameInfo.gameType == MainManager.GameType.LostArk)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                loaDayHighlightObj.SetActive(true);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                loaWeekHighlightObj.SetActive(true);
            }
        }
    }

    public void MapleDayButton()
    {
        SetWork();
        gameInfo.timeType = MainManager.TimeType.Day;
        SetHightLightActive();
        mapleDayHighlightObj.SetActive(true);
        mainManager.UpdateCharacterList();
    }

    public void MapleWeekButton()
    {
        SetWork();
        gameInfo.timeType = MainManager.TimeType.Week;
        SetHightLightActive();
        mapleWeekHighlightObj.SetActive(true);
        mainManager.UpdateCharacterList();
    }

    public void MapleMonthButton()
    {
        SetWork();
        gameInfo.timeType = MainManager.TimeType.Month;
        SetHightLightActive();
        mapleMonthHighlightObj.SetActive(true);
        mainManager.UpdateCharacterList();
    }

    public void LoaDayButton()
    {
        SetWork();
        gameInfo.timeType = MainManager.TimeType.Day;
        SetHightLightActive();
        loaDayHighlightObj.SetActive(true);
        mainManager.UpdateCharacterList();
    }

    public void LoaWeekButton()
    {
        SetWork();
        gameInfo.timeType = MainManager.TimeType.Week;
        SetHightLightActive();
        loaWeekHighlightObj.SetActive(true);
        mainManager.UpdateCharacterList();
    }

    public void SetWork()
    {
        //if (gameInfo.gameType == GameType.MapleStory)
        //{
        //    if (gameInfo.timeType == TimeType.Day)
        //    {
        //        gameInfo.mapleDayWorkCount = mainManager.workCount;
        //        gameInfo.mapleDayDoWork = mainManager.doWork;
        //        gameInfo.mapleDayCurWork = mainManager.curWork;
        //    }
        //    else if (gameInfo.timeType == TimeType.Week)
        //    {
        //        gameInfo.mapleWeekWorkCount = mainManager.workCount;
        //        gameInfo.mapleWeekDoWork = mainManager.doWork;
        //        gameInfo.mapleWeekCurWork = mainManager.curWork;
        //    }
        //    else if (gameInfo.timeType == TimeType.Month)
        //    {
        //        gameInfo.mapleMonthWorkCount = mainManager.workCount;
        //        gameInfo.mapleMonthDoWork = mainManager.doWork;
        //        gameInfo.mapleMonthCurWork = mainManager.curWork;
        //    }
        //}
        //else if (gameInfo.gameType == GameType.LostArk)
        //{
        //    if (gameInfo.timeType == TimeType.Day)
        //    {
        //        gameInfo.loaDayWorkCount = mainManager.workCount;
        //        gameInfo.loaDayDoWork = mainManager.doWork;
        //        gameInfo.loaDayCurWork = mainManager.curWork;
        //    }
        //    else if (gameInfo.timeType == TimeType.Week)
        //    {
        //        gameInfo.loaWeekWorkCount = mainManager.workCount;
        //        gameInfo.loaWeekDoWork = mainManager.doWork;
        //        gameInfo.loaWeekCurWork = mainManager.curWork;
        //    }
        //    else if (gameInfo.timeType == TimeType.Month)
        //    {
        //        gameInfo.timeType = TimeType.Week;
        //        gameInfo.loaWeekWorkCount = mainManager.workCount;
        //        gameInfo.loaWeekDoWork = mainManager.doWork;
        //        gameInfo.loaWeekCurWork = mainManager.curWork;
        //    }
        //}
        gameInfo.mapleDayWorkCount = 0.0f;
        gameInfo.mapleDayWorkCount = 0.0f;
        gameInfo.mapleDayWorkCount = 0.0f;

        gameInfo.mapleWeekWorkCount = 0.0f;
        gameInfo.mapleWeekWorkCount = 0.0f;
        gameInfo.mapleWeekWorkCount = 0.0f;

        gameInfo.mapleMonthWorkCount = 0.0f;
        gameInfo.mapleMonthWorkCount = 0.0f;
        gameInfo.mapleMonthWorkCount = 0.0f;

        gameInfo.loaDayWorkCount = 0.0f;
        gameInfo.loaDayWorkCount = 0.0f;
        gameInfo.loaDayWorkCount = 0.0f;

        gameInfo.loaWeekWorkCount = 0.0f;
        gameInfo.loaWeekWorkCount = 0.0f;
        gameInfo.loaWeekWorkCount = 0.0f;
    }

    public void SetHightLightActive()
    {
        if (loaDayHighlightObj.activeSelf) loaDayHighlightObj.SetActive(false);
        if (loaWeekHighlightObj.activeSelf) loaWeekHighlightObj.SetActive(false);
        if (mapleDayHighlightObj.activeSelf) mapleDayHighlightObj.SetActive(false);
        if (mapleWeekHighlightObj.activeSelf) mapleWeekHighlightObj.SetActive(false);
        if (mapleMonthHighlightObj.activeSelf) mapleMonthHighlightObj.SetActive(false);
    }
}
