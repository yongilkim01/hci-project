using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterInfo : MonoBehaviour
{
    private GameInfo gameInfo;
    private MainManager mainManager;

    public GameObject characterNameObj;
    public GameObject characterClassObj;
    public GameObject levelObj;

    [Header("Scroll")]
    public GameObject contentObj;
    public GameObject workObj;
    GameObject _workObj;

    [Header("Complete object")]
    public GameObject completeObj;

    public List<WorkInfo> workList = new List<WorkInfo>();

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        mainManager = FindObjectOfType<MainManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameInfo.gameType == MainManager.GameType.LostArk)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                for (int i = 0; i < gameInfo.loa_dayWorkList.Count; i++)
                    AddWork(gameInfo.loa_dayWorkList[i].gameWorkName, i);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                for (int i = 0; i < gameInfo.loa_weekWorkList.Count; i++)
                    AddWork(gameInfo.loa_weekWorkList[i].gameWorkName, i);
            }
        }
        else if(gameInfo.gameType == MainManager.GameType.MapleStory)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                for (int i = 0; i < gameInfo.maple_dayWorkList.Count; i++)
                    AddWork(gameInfo.maple_dayWorkList[i].gameWorkName, i);
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                for (int i = 0; i < gameInfo.maple_weekWorkList.Count; i++)
                    AddWork(gameInfo.maple_weekWorkList[i].gameWorkName, i);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCharacterInfo(string _characterName, string _className, string _level)
    {
        characterNameObj.GetComponent<Text>().text = _characterName;
        //characterClassObj.GetComponent<Text>().text = _className;
        levelObj.GetComponent<Text>().text = _level;
    }

    public void AddWork(string _text, int  _index)
    {
        _workObj = Instantiate(workObj, contentObj.transform.position, Quaternion.identity);
        _workObj.transform.SetParent(contentObj.transform);
        _workObj.GetComponent<WorkInfo>().workNameText.text = _text;
        _workObj.GetComponent<WorkInfo>().character = this;
        workList.Add(_workObj.GetComponent<WorkInfo>());
        _workObj.GetComponent<WorkInfo>().index = _index;
    }

    public void UpdateCompleteObj()
    {
        for(int i = 0; i < workList.Count; i++)
        {
            if (!workList[i].isWorked)
            {
                completeObj.SetActive(false);
                return;
            }
        }
        completeObj.SetActive(true);
    }


}
