using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainManager;

public class UpdateLoaCharacter : MonoBehaviour
{
    public GameObject loaCharacterList;
    public GameObject loaCharacterListObj;

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
        Transform[] childList = loaCharacterList.GetComponentsInChildren<Transform>();
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

        for (int i = 0; i < gameInfo.loa_characterList.Count; i++)
        {
            GameObject _gameListObj = Instantiate(loaCharacterListObj, loaCharacterList.transform.position, Quaternion.identity);
            LoaCharacterObj _loaCharacterObj = _gameListObj.GetComponent<LoaCharacterObj>();
            _loaCharacterObj.uptLoaCha = this;
            _loaCharacterObj.UpdateInfo(gameInfo.loa_characterList[i]);
            _gameListObj.transform.SetParent(loaCharacterList.transform);
        }
    }
}
