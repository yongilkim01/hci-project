using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WorkInfo : MonoBehaviour
{
    private bool isOpen;
    private bool isFirst;
    private Vector3 workMainNamePosition;
    private GameInfo gameInfo;
    private MainManager mainManager;

    public GameObject workMainName;
    public Text workNameText;
    public int index;

    [Header("Character")]
    public CharacterInfo character;

    [Header("Is Work")]
    public bool isWorked;
    public GameObject toggleCheck;

    [Header("Size")]
    public float width = 0.0f;
    public float height = 0.0f;
    public float open_height = 0.0f;

    [Header("Work Detail")]
    public GameObject workDetailObj;
    public List<GameObject> workDetailObjList;
    public List<WorkDetail> workDetailList;
    
    

    // Start is called before the first frame update
    void Start()
    {
        width = gameObject.GetComponent<RectTransform>().rect.width;
        height = gameObject.GetComponent<RectTransform>().rect.height;
        isOpen = false;
        toggleCheck.SetActive(false);
        isWorked = false;
        workMainNamePosition = workMainName.GetComponent<RectTransform>().localPosition;
        gameInfo = FindObjectOfType<GameInfo>();
        mainManager = FindObjectOfType<MainManager>();

        MakeList();

        if (workDetailList.Count > 0)
        {
            mainManager.workCount = mainManager.workCount + workDetailList.Count;
        }
        else
        {
            mainManager.workCount = mainManager.workCount + 1;
        }

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        workMainName.GetComponent<RectTransform>().localPosition = workMainNamePosition;
        for (int i = 0; i < workDetailObjList.Count; i++)
        {
            workDetailObjList[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(IsWorked()) 
    }

    public void OnWorkMenu()
    {
        if (isOpen)
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
            workMainName.GetComponent<RectTransform>().localPosition = workMainNamePosition;
            for(int i = 0; i < workDetailObjList.Count; i++)
            {
                workDetailObjList[i].gameObject.SetActive(false);
            }
            isOpen = false;
        }
        else
        {
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, open_height);
            workMainName.GetComponent<RectTransform>().position = new Vector3(
                gameObject.GetComponent<RectTransform>().position.x,
                gameObject.GetComponent<RectTransform>().position.y - 35,
                gameObject.GetComponent<RectTransform>().position.z);
            for (int i = 0; i < workDetailObjList.Count; i++)
            {
                workDetailObjList[i].gameObject.SetActive(true);
            }
            isOpen = true;
            //MakeList();
        }
    }

    public void MakeList()
    {
        if(gameInfo.gameType == MainManager.GameType.LostArk)
        {
            if(gameInfo.timeType == MainManager.TimeType.Day)
            {
                open_height = 75.0f + (gameInfo.loa_dayWorkList[index].workList.Count * 60.0f);
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, open_height);
                workMainName.GetComponent<RectTransform>().position = new Vector3(
                    gameObject.GetComponent<RectTransform>().position.x,
                    gameObject.GetComponent<RectTransform>().position.y - 35,
                    gameObject.GetComponent<RectTransform>().position.z);

                for (int i = 0; i < gameInfo.loa_dayWorkList[index].workList.Count; i++)
                {
                    GameObject _workDetailObj = Instantiate(workDetailObj, gameObject.transform.position, Quaternion.identity);
                    WorkDetail _workDetail = _workDetailObj.GetComponent<WorkDetail>();
                    workDetailList.Add(_workDetail);
                    _workDetailObj.transform.SetParent(gameObject.transform);
                    workDetailObjList.Add(_workDetailObj);
                    _workDetailObj.GetComponentInChildren<Text>().text = gameInfo.loa_dayWorkList[index].workList[i];
                    _workDetailObj.GetComponent<RectTransform>().position = new Vector3(
                        gameObject.GetComponent<RectTransform>().position.x,
                        (gameObject.GetComponent<RectTransform>().position.y - 100) - (i * 60),
                        gameObject.GetComponent<RectTransform>().position.z);
                }
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                open_height = 75.0f + (gameInfo.loa_weekWorkList[index].workList.Count * 60.0f);
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, open_height);
                workMainName.GetComponent<RectTransform>().position = new Vector3(
                    gameObject.GetComponent<RectTransform>().position.x,
                    gameObject.GetComponent<RectTransform>().position.y - 35,
                    gameObject.GetComponent<RectTransform>().position.z);

                for (int i = 0; i < gameInfo.loa_weekWorkList[index].workList.Count; i++)
                {
                    GameObject _workDetailObj = Instantiate(workDetailObj, gameObject.transform.position, Quaternion.identity);
                    WorkDetail _workDetail = _workDetailObj.GetComponent<WorkDetail>();
                    workDetailList.Add(_workDetail);
                    _workDetailObj.transform.SetParent(gameObject.transform);
                    workDetailObjList.Add(_workDetailObj);
                    _workDetailObj.GetComponentInChildren<Text>().text = gameInfo.loa_weekWorkList[index].workList[i];
                    _workDetailObj.GetComponent<RectTransform>().position = new Vector3(
                        gameObject.GetComponent<RectTransform>().position.x,
                        (gameObject.GetComponent<RectTransform>().position.y - 100) - (i * 60),
                        gameObject.GetComponent<RectTransform>().position.z);
                }
            }
            else if (gameInfo.timeType == MainManager.TimeType.Month)
            {
                for (int i = 0; i < gameInfo.loa_monthWorkList.Count; i++)
                {

                }
            }
        }
        else if(gameInfo.gameType == MainManager.GameType.MapleStory)
        {
            if (gameInfo.timeType == MainManager.TimeType.Day)
            {
                open_height = 75.0f + (gameInfo.maple_dayWorkList[index].workList.Count * 60.0f);
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, open_height);
                workMainName.GetComponent<RectTransform>().position = new Vector3(
                    gameObject.GetComponent<RectTransform>().position.x,
                    gameObject.GetComponent<RectTransform>().position.y - 35,
                    gameObject.GetComponent<RectTransform>().position.z);

                for (int i = 0; i < gameInfo.maple_dayWorkList[index].workList.Count; i++)
                {
                    GameObject _workDetailObj = Instantiate(workDetailObj, gameObject.transform.position, Quaternion.identity);
                    WorkDetail _workDetail = _workDetailObj.GetComponent<WorkDetail>();
                    workDetailList.Add(_workDetail);
                    _workDetailObj.transform.SetParent(gameObject.transform);
                    workDetailObjList.Add(_workDetailObj);
                    _workDetailObj.GetComponentInChildren<Text>().text = gameInfo.maple_dayWorkList[index].workList[i];
                    _workDetailObj.GetComponent<RectTransform>().position = new Vector3(
                        gameObject.GetComponent<RectTransform>().position.x,
                        (gameObject.GetComponent<RectTransform>().position.y - 100) - (i * 60),
                        gameObject.GetComponent<RectTransform>().position.z);
                }
            }
            else if (gameInfo.timeType == MainManager.TimeType.Week)
            {
                open_height = 75.0f + (gameInfo.maple_weekWorkList[index].workList.Count * 60.0f);
                gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, open_height);
                workMainName.GetComponent<RectTransform>().position = new Vector3(
                    gameObject.GetComponent<RectTransform>().position.x,
                    gameObject.GetComponent<RectTransform>().position.y - 35,
                    gameObject.GetComponent<RectTransform>().position.z);

                for (int i = 0; i < gameInfo.maple_weekWorkList[index].workList.Count; i++)
                {
                    GameObject _workDetailObj = Instantiate(workDetailObj, gameObject.transform.position, Quaternion.identity);
                    WorkDetail _workDetail = _workDetailObj.GetComponent<WorkDetail>();
                    workDetailList.Add(_workDetail);
                    _workDetailObj.transform.SetParent(gameObject.transform);
                    workDetailObjList.Add(_workDetailObj);
                    _workDetailObj.GetComponentInChildren<Text>().text = gameInfo.maple_weekWorkList[index].workList[i];
                    _workDetailObj.GetComponent<RectTransform>().position = new Vector3(
                        gameObject.GetComponent<RectTransform>().position.x,
                        (gameObject.GetComponent<RectTransform>().position.y - 100) - (i * 60),
                        gameObject.GetComponent<RectTransform>().position.z);
                }
            }
            else if (gameInfo.timeType == MainManager.TimeType.Month)
            {
                for (int i = 0; i < gameInfo.loa_monthWorkList.Count; i++)
                {

                }
            }
        }
    }

    public void AllWorkCheck()
    {
        isWorked = !isWorked;
        toggleCheck.SetActive(isWorked);
        for (int i = 0; i < workDetailList.Count; i++)
        {
            workDetailList[i].isWorked = isWorked;
            workDetailList[i].toggleCheck.SetActive(isWorked);
        }

        character.UpdateCompleteObj();

        if (isWorked)
        {
            if(workDetailList.Count > 0)
            {
                mainManager.doWork = mainManager.doWork + workDetailList.Count;
            }
            else
            {
                mainManager.doWork = mainManager.doWork + 1;
            }
            mainManager.curWork = mainManager.doWork / mainManager.workCount;
        }
        else
        {
            mainManager.doWork = mainManager.doWork -  workDetailList.Count;
            mainManager.curWork = mainManager.doWork / mainManager.workCount;
        }
        mainManager.UpdateWorkText();
    }

    public void IsWorked()
    {
        Debug.Log("Work function");
        for (int i = 0; i < workDetailList.Count; i++)
        {
            if(!workDetailList[i].isWorked)
            {
                isWorked = false;
                toggleCheck.SetActive(isWorked);
                character.UpdateCompleteObj();
                return;
            }
        }
        isWorked = true;
        toggleCheck.SetActive(isWorked);
        character.UpdateCompleteObj();
    }
}
