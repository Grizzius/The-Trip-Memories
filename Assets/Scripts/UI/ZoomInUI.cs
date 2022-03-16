using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInUI : UIParentScript
{
    public static ZoomClickable zoomClickableScript;
    public static ZoomInUI current;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        zoomClickableScript.ReturnToOrigin();
    }
}
