using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapleCharacterObj : MonoBehaviour
{
    [Header("Character Info obj")]
    public GameObject characterNameObj;
    public GameObject levelObj;

    public UpdateMapleCharacter uptMapleCha;

    private GameInfo gameInfo;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    public void UpdateInfo(MapleCharacter _mapleChracter)
    {
        characterNameObj.GetComponent<Text>().text = _mapleChracter.characterName;
        levelObj.GetComponent<Text>().text = "lv. " + _mapleChracter.level;
    }

    public void OnClickDeleteCha()
    {
        for (int i = 0; i < gameInfo.maple_characterList.Count; i++)
        {
            if (gameInfo.maple_characterList[i].characterName == characterNameObj.GetComponent<Text>().text)
            {
                gameInfo.maple_characterList.RemoveAt(i);
            }
        }
        uptMapleCha.InitCharacterList();

    }
}
