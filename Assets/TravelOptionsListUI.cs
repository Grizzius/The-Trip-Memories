using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelOptionsListUI : UIParentScript
{
    public Voyage[] voyages;
    public Transform transportOptionsParent;
    public TransportOptionUI template;

    public static TravelOptionsListUI current;
    protected override void Start()
    {
        base.Start();
        current = this;
        UpdateContent();
    }

    void UpdateContent()
    {
        ResetContent();
        foreach (Voyage voyage in voyages)
        {
            TransportOptionUI newTransportOption = Instantiate(template);
            newTransportOption.transform.SetParent(transportOptionsParent);
            newTransportOption.voyage = voyage;
        }
    }

    void ResetContent()
    {
        for(int i = 0; i < transportOptionsParent.childCount; i++)
        {
            Destroy(transportOptionsParent.GetChild(i).gameObject);
        }
    }

    protected override void OnOpenTab()
    {
        base.OnOpenTab();
        PlayerScript.SetState(new PlayerUIState(PlayerScript.current));
    }

    protected override void OnCloseTab()
    {
        base.OnCloseTab();
        PlayerScript.SetState(new PlayerRoomState(PlayerScript.current));
    }

    public void OnCloseButton()
    {
        EventSystem.current.CloseUI(ID);
    }
}
