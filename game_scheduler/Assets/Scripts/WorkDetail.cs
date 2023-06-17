using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class WorkDetail : MonoBehaviour
{
    public bool isFirst = true;
    public WorkInfo workInfo;
    public bool isWorked;
    public MainManager mainManager;
    public GameObject toggleCheck;

    private void Awake()
    {
        mainManager = FindObjectOfType<MainManager>();
    }
    void Start()
    {
        workInfo = GetComponentInParent<WorkInfo>();
        //toggle.onValueChanged.AddListener(WorkCheck);
        isWorked = false;
    }

    private void Update()
    {

    }

    public void WorkCheck(bool _check)
    {
        isWorked = !isWorked;
        toggleCheck.SetActive(isWorked);
        //workInfo.IsWorked();
    }


    public void OnOffWorked()
    {
        isWorked = !isWorked;
        toggleCheck.SetActive(isWorked);
        workInfo.IsWorked();
        if(isWorked)
        {
            mainManager.doWork++;
            mainManager.curWork = mainManager.doWork / mainManager.workCount;
        }
        else
        {
            mainManager.doWork--;
            mainManager.curWork = mainManager.doWork / mainManager.workCount;
        }
        mainManager.UpdateWorkText();
    }
}
