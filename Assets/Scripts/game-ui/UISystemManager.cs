using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UISystemManager : MonoBehaviour
{
    public static UISystemManager instance;

    private GameObject gameUI;
    private GameObject skillSelectorUI;
    private GameObject TimerText;
    private GameObject LevelSystem;
    public GameObject readyText;
    public GameObject goText;

    public bool isDashDisabled = false;
    public bool isShootDisabled = false;
    public bool isBombDisabled = false;
    public bool isWaveDisabled = false;

    public List<string> skillRemovedOrder = new List<string>();
    public int killedEnemies = 0;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            RemoveHealth();
        }
        if (Input.GetKeyDown("2"))
        {
            AddHealth();
        }
        
        if (Input.GetKeyDown("3"))
        {
            DoDash(5);
        }
        
        if (Input.GetKeyDown("4"))
        {
            DoWave(5);
        }
        
        if (Input.GetKeyDown("5"))
        {
            DoBomb(5);
        }
        
        if (Input.GetKeyDown("6"))
        {
            DoShoot(5);
        }
    }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region GameUIFnc

    public void ShowCombatUI()
    {
        if (gameUI == null)
        {
            gameUI = Instantiate(Resources.Load("GameUI", typeof(GameObject))) as GameObject;
            TimerText = gameUI.transform.Find("Background/Timer/timer").gameObject;
            readyText = gameUI.transform.Find("Try_to:survive_text").gameObject;
            goText = gameUI.transform.Find("Go_text").gameObject;
            LevelSystem = GameObject.Find("LevelSystem");
            if (isDashDisabled) gameUI.GetComponent<GameUI>().RemoveDash();
            if (isShootDisabled) gameUI.GetComponent<GameUI>().RemoveShoot();
            if (isBombDisabled) gameUI.GetComponent<GameUI>().RemoveBomb();
            if (isWaveDisabled) gameUI.GetComponent<GameUI>().RemoveWave();
        }

        gameUI.SetActive(true); 
    }
    
    public void HideCombatUI()
    {
        gameUI.SetActive(false);
    }

    public void StartLevel()
    {
        LevelSystem.GetComponent<LevelSystem>().TimerStart();
    }
    #endregion
    
    #region SkillSelectionFnc
    
    public void ShowSkillSelectorUI()
    {
        if (!skillSelectorUI)
        {
            skillSelectorUI = Instantiate(Resources.Load("SkillSelector", typeof(GameObject))) as GameObject;
        }      
        
        gameUI?.SetActive(false);
        skillSelectorUI.SetActive((true));
    }
    
    public void HideSkillSelectorUI()
    {
        skillSelectorUI.SetActive(false);
    }

    public void SetTimer(float time)
    {
        FormatTimerText(time);
    }
    
    void FormatTimerText(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    #endregion

    #region Health
    public void AddHealth()
    {
        gameUI.GetComponent<GameUI>().AddHealth();
    }

    public void RemoveHealth()
    {
        gameUI.GetComponent<GameUI>().RemoveHealth();
    }

    #endregion

    public void DoDash(float cooldown)
    {
        if (!isDashDisabled)
        {
            gameUI.GetComponent<GameUI>().DoDash(cooldown);
        }
    }
    
    public void RemoveDash()
    {
        skillRemovedOrder.Add("Dash");
        isDashDisabled = true;
        gameUI.GetComponent<GameUI>().RemoveDash();
        PlayerController.instance.RemoveDashSkill();
    }
    
    public void DoShoot(float cooldown)
    {
        if (!isShootDisabled)
        {
            gameUI.GetComponent<GameUI>().DoShoot(cooldown);
        }
    }
    
    public void RemoveShoot()
    {
        skillRemovedOrder.Add("Shoot");
        isShootDisabled = true;
        gameUI.GetComponent<GameUI>().RemoveShoot();
        PlayerController.instance.RemoveShootSkill();
    }
    
    public void DoBomb(float cooldown)
    {
        if (!isBombDisabled)
        {
            gameUI.GetComponent<GameUI>().DoBomb(cooldown);
        }
    }
    
    public void RemoveBomb()
    {
        skillRemovedOrder.Add("Bomb");
        isBombDisabled = true;
        gameUI.GetComponent<GameUI>().RemoveBomb();
        PlayerController.instance.RemoveBombSkill();
    }
    
    public void DoWave(float cooldown)
    {
        if (!isWaveDisabled)
        {
            gameUI.GetComponent<GameUI>().DoWave(cooldown);
        }
    }
    
    public void RemoveWave()
    {
        skillRemovedOrder.Add("Wave");
        isWaveDisabled = true;
        gameUI.GetComponent<GameUI>().RemoveWave();
        PlayerController.instance.RemoveWaveSkill();
    }
    
    public void LoadNextLevel()
    {
        var nextLevel = LevelSystem.GetComponent<LevelSystem>().nextLevel;

        gameUI = null;
        TimerText = null;
        readyText = null;
        goText = null;
        
        SceneManager.LoadScene(nextLevel);
    }
}
