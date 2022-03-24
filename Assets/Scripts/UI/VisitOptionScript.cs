using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisitOptionScript : UIParentScript
{
    public VisitPlace visit;
    
    [Header("UI elements")]
    public Slider priceSlider;
    public TextMeshProUGUI visitName;
    public TextMeshProUGUI visitDescription;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI FunValueText;
    public Button confirmButton;
    public Image image;
    
    int visitPrice;
    int funValue;

    public static VisitOptionScript current;

    private void OnValidate()
    {
        Initialize();
    }

    private void Initialize()
    {
        funValue = visit.DefaultFunValue;

        FunValueText.text = funValue.ToString();
        visitName.text = visit.visitName;
        visitDescription.text = visit.VisitDescription;

        priceSlider.minValue = visit.minPrice;
        priceSlider.maxValue = visit.maxPrice;

        priceSlider.value = priceSlider.minValue;
        image.sprite = visit.paint;

        UpdatePrice();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Initialize();

        EventSystem.current.OnActivateVisitOptionUI += OpenTab;
        current = this;
    }

    public void PressConfirmButton()
    {

        VisitUIScript.visit = visit;
        VisitUIScript.price = visitPrice;
        EventSystem.current.StartVisitMode(visit);

        CloseTab();
    }

    public void UpdatePrice()
    {
        visitPrice = Mathf.RoundToInt(priceSlider.value);
        priceText.text = ("$ " + visitPrice);
        if (visitPrice > GameSystem.playerMoney)
        {
            priceText.color = Color.red;
            confirmButton.interactable = false;
        }
        else
        {
            priceText.color = Color.black;
            confirmButton.interactable = true;
        }

        funValue = Mathf.RoundToInt(visit.DefaultFunValue * 0.05f * visitPrice);
        FunValueText.text = funValue.ToString();
    }

    public void OpenTab(int id, VisitPlace newVisit)
    {
        if(id == ID)
        {
            visit = newVisit;
            EventSystem.current.OpenUI(ID);
            Initialize();
        }
    }

    public void CloseTab()
    {
        EventSystem.current.CloseUI(ID);
    }

    public void PressCloseButton()
    {
        PlayerScript.SetState(new PlayerStateZoom(PlayerScript.current));
        ZoomInUI.current.ToggleButtonClickable(true);
        CloseTab();
    }

    protected override void OnOpenTab()
    {
        PlayerScript.SetState(new PlayerUIState(PlayerScript.current));
        ZoomInUI.current.ToggleButtonClickable(false);
    }

    protected override void OnCloseTab()
    {
        
    }
}
