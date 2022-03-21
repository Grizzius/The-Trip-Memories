using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Job", menuName = "Create new job")]
public class Jobs : ScriptableObject
{
    public string jobName;
    [TextArea]
    public string jobDescription;
    [Header("Jours de travail")]
    public bool openLundi;
    public bool openMardi;
    public bool openMercredi;
    public bool openJeudi;
    public bool openVendredi;
    public bool openSamedi;
    public bool openDimanche;
    [Space(20)]
    [Range(1,999)]
    public int Pay;
}
