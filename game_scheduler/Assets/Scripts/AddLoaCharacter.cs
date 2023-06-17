using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLoaCharacter : MonoBehaviour
{
    [Header("Object")]
    public InputField characterNameInput;
    public InputField characterClassInput;
    public InputField characterLevelInput;

    public GameInfo gameInfo;
    public UpdateLoaCharacter updateLoa;

    private void Awake()
    {
        gameInfo = FindObjectOfType<GameInfo>();
        updateLoa = FindObjectOfType<UpdateLoaCharacter>();
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
        LoaCharacter _loaCharacter = new LoaCharacter();
        _loaCharacter.characterName = characterNameInput.text;
        _loaCharacter.className = characterClassInput.text;
        _loaCharacter.level = characterLevelInput.text;

        characterNameInput.text = "";
        characterClassInput.text = "";
        characterLevelInput.text = "";

        gameInfo.loa_characterList.Add(_loaCharacter);
        updateLoa.InitCharacterList();
    }

}
