using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    public string nextLevel = "Level1";
    public float TimeLeft;
    public bool TimerOn = false;

    private void Start()
    {
        UISystemManager.instance.ShowCombatUI();
        UISystemManager.instance.SetTimer(TimeLeft);
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
        UISystemManager.instance.readyText.SetActive(false);
        UISystemManager.instance.goText.SetActive(false);
        
        TimerOn = true;
    }
    
    void TimerFinish()
    {
        TimeLeft = 0;
        TimerOn = false;
        
        UISystemManager.instance.HideCombatUI();
        UISystemManager.instance.ShowSkillSelectorUI();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
    
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        UISystemManager.instance.SetTimer(currentTime);
    }
}
