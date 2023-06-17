using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoaCharacterObj : MonoBehaviour
{
    [Header("Character Info obj")]
    public GameObject characterNameObj;
    public GameObject levelObj;

    public UpdateLoaCharacter uptLoaCha;

    private GameInfo gameInfo;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
    }

    public void UpdateInfo(LoaCharacter _loaChracter)
    {
        characterNameObj.GetComponent<Text>().text = _loaChracter.characterName;
        levelObj.GetComponent<Text>().text = "lv. " + _loaChracter.level;
    }

    public void OnClickDeleteCha()
    { 
        for(int i = 0; i < gameInfo.loa_characterList.Count; i++)
        {
            if (gameInfo.loa_characterList[i].characterName == characterNameObj.GetComponent<Text>().text)
            {
                gameInfo.loa_characterList.RemoveAt(i);
            }
        }
        uptLoaCha.InitCharacterList();

    }
}
