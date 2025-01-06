using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public string nextLevel = "Level1";
    public GameObject SkillSelector;
    public GameObject TimerText;
    public GameObject readyText;
    public GameObject goText;
    
    public float TimeLeft;
    public bool TimerOn = false;

    private void Start()
    {
        FormatTimerText(TimeLeft);
    }

    void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                TimerFinish();
            }
        }
    }

    public void TimerStart()
    {
        readyText.SetActive(false);
        goText.SetActive(false);

        TimerOn = true;
    }
    
    void TimerFinish()
    {
        TimeLeft = 0;
        TimerOn = false;
        SkillSelector.SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        FormatTimerText(currentTime);
    }

    void FormatTimerText(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
