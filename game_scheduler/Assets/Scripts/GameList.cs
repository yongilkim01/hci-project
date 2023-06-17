using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainManager;

public class GameList : MonoBehaviour
{
    public GameObject gameList;
    public GameObject gameListObj;

    public GameInfo gameInfo;

    // Start is called before the first frame update
    void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    private void Start()
    {
        InitGameList();
    }

    // Update is called once per frame
    public void InitGameList()
    {
        GameObject _gameListObj = Instantiate(gameListObj, gameList.transform.position, Quaternion.identity);
        GameSelectIcon _gameListObjIcon = _gameListObj.GetComponent<GameSelectIcon>();
        _gameListObjIcon.icon = gameInfo.map_icon;
        _gameListObjIcon.gameType = GameType.MapleStory;
        _gameListObjIcon.UpdateInfo();
        _gameListObj.transform.SetParent(gameList.transform);

        GameObject _gameListObj2 = Instantiate(gameListObj, gameList.transform.position, Quaternion.identity);
        GameSelectIcon _gameListObjIcon2 = _gameListObj2.GetComponent<GameSelectIcon>();
        _gameListObjIcon2.icon = gameInfo.loa_icon;
        _gameListObjIcon2.gameType = GameType.LostArk;
        _gameListObjIcon2.UpdateInfo();
        _gameListObj2.transform.SetParent(gameList.transform);
    }

    public void MoveGameScene()
    {

    }
}
