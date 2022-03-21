using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JobOfferUIScript : UIParentScript
{
    public TextMeshProUGUI JobNameText;
    public TextMeshProUGUI JobDescriptionText;
    public TextMeshProUGUI[] WeekDays;
    public TextMeshProUGUI payText;

    public static JobOfferUIScript current;

    public Jobs job;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        current = this;

        UpdateUI();

        EventSystem.current.OnActivateJobOfferUI += OpenTab;
    }

    void OpenTab(int id, Jobs newJob)
    {
        if(id == ID)
        {
            job = newJob;
            EventSystem.current.OpenUI(ID);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        JobNameText.text = job.jobName;
        JobDescriptionText.text = job.jobDescription; 
        
        CheckIfWorkDay(job.openLundi, 0);
        CheckIfWorkDay(job.openMardi, 1);
        CheckIfWorkDay(job.openMercredi, 2);
        CheckIfWorkDay(job.openJeudi, 3);
        CheckIfWorkDay(job.openVendredi, 4);
        CheckIfWorkDay(job.openSamedi, 5);
        CheckIfWorkDay(job.openDimanche, 6);

        payText.text = "Paie : " + job.Pay.ToString();
    }

    void CheckIfWorkDay(bool check, int dayID)
    {
        if (check)
        {
            WeekDays[dayID].color = Color.blue;
        }
        else
        {
            WeekDays[dayID].color = Color.gray;
        }
    }

    public void OnCloseButton()
    {
        EventSystem.current.CloseUI(ID);
    }

    public void OnAcceptButton()
    {
        EventSystem.current.CloseUI(ID);
        GameSystem.current.UpdateJob(job);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
