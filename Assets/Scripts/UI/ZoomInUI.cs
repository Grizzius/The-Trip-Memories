using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInUI : UIParentScript
{
    public static ZoomClickable zoomClickableScript;
    public static ZoomInUI current;

    public Button button;
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
        CloseTab();
        zoomClickableScript.ReturnToOrigin();
    }

    public void CloseTab()
    {

        EventSystem.current.CloseUI(ID);
        
    }

    protected override void OnOpenTab()
    {
        base.OnOpenTab();
        ToggleButtonClickable(true);
    }

    public void ToggleButtonClickable(bool active)
    {
        button.enabled = active;
    }
}
