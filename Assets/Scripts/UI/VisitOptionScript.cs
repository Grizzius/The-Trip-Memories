using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisitOptionScript : MonoBehaviour
{
    public bool update;
    [Space]
    public VisitPlace visit;
    [Header("UI elements")]
    public Slider priceSlider;
    public TextMeshProUGUI visitName;
    public TextMeshProUGUI visitDescription;
    public TextMeshProUGUI priceText;
    public TextMeshProUGUI FunValueText;
    public Button confirmButton;
    
    int visitPrice;
    int funValue;

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

        UpdatePrice();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    public void PressConfirmButton()
    {
        EventSystem.current.StartVisitMode(visit);
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
}
