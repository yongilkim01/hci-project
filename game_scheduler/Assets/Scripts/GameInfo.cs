using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static MainManager;

public class GameInfo : MonoBehaviour
{
    public static GameInfo instance;

    [Header("Game List")]
    public List<GameIcon> gameIconList;
    
    [Header("Lost Ark information")]
    public string loa_name;
    public Sprite loa_icon;

    [Header("Maple story information")]
    public string map_name;
    public Sprite map_icon;

    [Header("Lost Ark Day work")]
    public List<GameWork> loa_dayWorkList;

    [Header("Lost Ark Week work")]
    public List<GameWork> loa_weekWorkList;

    [Header("Lost Ark Month work")]
    public List<GameWork> loa_monthWorkList;

    [Header("Maple story Day work")]
    public List<GameWork> maple_dayWorkList;

    [Header("Maple story Week work")]
    public List<GameWork> maple_weekWorkList;

    [Header("Loa character list")]
    public List<LoaCharacter> loa_characterList = new List<LoaCharacter>();

    [Header("Maple character list")]
    public List<MapleCharacter> maple_characterList = new List<MapleCharacter>();

    [Header("Current Type")]
    public GameType gameType = GameType.LostArk;
    public TimeType timeType = TimeType.Week;

    [Header("Game Time")]
    public float loaDayWorkCount = 0.0f;
    public float loaDayDoWork = 0.0f;
    public float loaDayCurWork = 0.0f;

    public float loaWeekWorkCount = 0.0f;
    public float loaWeekDoWork = 0.0f;
    public float loaWeekCurWork = 0.0f;

    public float mapleDayWorkCount = 0.0f;
    public float mapleDayDoWork = 0.0f;
    public float mapleDayCurWork = 0.0f;

    public float mapleWeekWorkCount = 0.0f;
    public float mapleWeekDoWork = 0.0f;
    public float mapleWeekCurWork = 0.0f;

    public float mapleMonthWorkCount = 0.0f;
    public float mapleMonthDoWork = 0.0f;
    public float mapleMonthCurWork = 0.0f;


    public int characterNumber;

    private void Awake()
    {
        /*�̱���ȭ.*/
        if (instance == null)
        {
            instance = this;
        }//single tone.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject); //Scene�� �Ѿ�� �ı����� ����� ���̴�.

        InitLoaCharacter();
        InitMapleCharacter();
        Debug.Log(loa_characterList.Count);
    }

    public void InitLoaCharacter()
    {
        LoaCharacter _loaCharacter = new LoaCharacter();
        _loaCharacter.className = "��Ʈ���̾�";
        _loaCharacter.characterName = "�����ٸ麮";
        _loaCharacter.level = "1597";
        loa_characterList.Add(_loaCharacter);

        LoaCharacter _loaCharacter2 = new LoaCharacter();
        _loaCharacter2.className = "�Ƹ�ī��";
        _loaCharacter2.characterName = "����";
        _loaCharacter2.level = "1597";
        loa_characterList.Add(_loaCharacter2);

        LoaCharacter _loaCharacter3 = new LoaCharacter();
        _loaCharacter3.className = "Ȧ������Ʈ";
        _loaCharacter3.characterName = "������";
        _loaCharacter3.level = "1597";
        loa_characterList.Add(_loaCharacter3);
    }

    public void InitMapleCharacter()
    {
        MapleCharacter _mapleCharacter = new MapleCharacter();
        _mapleCharacter.className = "������";
        _mapleCharacter.characterName = "�����";
        _mapleCharacter.level = "230";
        maple_characterList.Add(_mapleCharacter);
    }

}
