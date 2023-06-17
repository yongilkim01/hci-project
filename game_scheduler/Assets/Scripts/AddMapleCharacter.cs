using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMapleCharacter : MonoBehaviour
{
    [Header("Object")]
    public InputField characterNameInput;
    public InputField characterClassInput;
    public InputField characterLevelInput;

    public GameInfo gameInfo;
    public UpdateMapleCharacter updateMaple;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        updateMaple = FindObjectOfType<UpdateMapleCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddClickEvent()
    {
        MapleCharacter _mapleCharacter = new MapleCharacter();
        _mapleCharacter.characterName = characterNameInput.text;
        _mapleCharacter.className = characterClassInput.text;
        _mapleCharacter.level = characterLevelInput.text;

        characterNameInput.text = "";
        characterClassInput.text = "";
        characterLevelInput.text = "";

        gameInfo.maple_characterList.Add(_mapleCharacter);
        updateMaple.InitCharacterList();
    }
}
