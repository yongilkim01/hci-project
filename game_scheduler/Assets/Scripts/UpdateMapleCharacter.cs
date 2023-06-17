using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMapleCharacter : MonoBehaviour
{
    public GameObject mapleCharacterList;
    public GameObject mapleCharacterListObj;

    public GameInfo gameInfo;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    private void Start()
    {
        InitCharacterList();
    }

    public void InitCharacterList()
    {
        Transform[] childList = mapleCharacterList.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                {
                    Destroy(childList[i].gameObject);
                }
            }
        }

        for (int i = 0; i < gameInfo.maple_characterList.Count; i++)
        {
            GameObject _gameListObj = Instantiate(mapleCharacterListObj, mapleCharacterList.transform.position, Quaternion.identity);
            MapleCharacterObj _mapleCharacterObj = _gameListObj.GetComponent<MapleCharacterObj>();
            _mapleCharacterObj.uptMapleCha = this;
            _mapleCharacterObj.UpdateInfo(gameInfo.maple_characterList[i]);
            _gameListObj.transform.SetParent(mapleCharacterList.transform);
        }
    }

}
