using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerHouseUI roomUI;
    public VisitSelectScript VisitSelectUI;
    public Canvas VisitUI;

    private void Start()
    {
        roomUI.gameObject.SetActive(true);
        VisitSelectUI.gameObject.SetActive(false);

        EventSystem.current.onStartVisitMode += BeginVisitUI;
    }

    public void ToggleUI(Canvas UI, bool enabled)
    {
        UI.gameObject.SetActive(enabled);
        switch (enabled)
        {
            case true:
                PlayerScript.SetState(new PlayerUIState(FindObjectOfType<PlayerScript>()));
                break;
            case false:
                PlayerScript.SetState(new PlayerRoomState(FindObjectOfType<PlayerScript>()));
                break;
        }
    }

    public void BeginVisitUI(VisitPlace visit)
    {
        ToggleUI(roomUI.transform.GetComponent<Canvas>(), false);
        ToggleUI(VisitSelectUI.transform.GetComponent<Canvas>(), false);
        ToggleUI(VisitUI.transform.GetComponent<Canvas>(), true);
    }
}
