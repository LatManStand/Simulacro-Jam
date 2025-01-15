using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    public GameObject shoot;
    public GameObject shootDisabled;
    
    public GameObject dash;
    public GameObject dashDisabled;
    
    public GameObject bomb;
    public GameObject bombDisabled;
    
    public GameObject wave;
    public GameObject waveDisabled;

    void Start()
    {
        dash.SetActive(!UISystemManager.instance.isDashDisabled);
        dashDisabled.SetActive(UISystemManager.instance.isDashDisabled);
        
        shoot.SetActive(!UISystemManager.instance.isShootDisabled);
        shootDisabled.SetActive(UISystemManager.instance.isShootDisabled);
        
        bomb.SetActive(!UISystemManager.instance.isBombDisabled);
        bombDisabled.SetActive(UISystemManager.instance.isBombDisabled);
        
        wave.SetActive(!UISystemManager.instance.isWaveDisabled);
        waveDisabled.SetActive(UISystemManager.instance.isWaveDisabled);
    }
    
    public void RemoveSkill(string skillName)
    {
        Debug.Log($"Remove {skillName}");

        switch (skillName)
        {
            case "shoot":
                UISystemManager.instance.RemoveShoot();
                break;
            
            case "dash":
                UISystemManager.instance.RemoveDash();
                break;
            
            case "bomb":
                UISystemManager.instance.RemoveBomb();
                break;
            
            case "wave":
                UISystemManager.instance.RemoveWave();
                break;
        }
        
        UISystemManager.instance.LoadNextLevel();
    }
}
