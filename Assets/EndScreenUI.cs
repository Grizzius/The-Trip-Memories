using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenUI : MonoBehaviour
{
    public string mainMenuName;
    public TextMeshProUGUI ScoreCount;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCount.text = "Score final : " + GameSystem.playerMemories;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuName);
    }
}
