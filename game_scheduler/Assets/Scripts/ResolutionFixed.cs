using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionFixed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResolution()
    {
        int _setWidth = 1920;
        int _setHeight = 1080;

        Screen.SetResolution(_setWidth, _setHeight, true);

    }
}
