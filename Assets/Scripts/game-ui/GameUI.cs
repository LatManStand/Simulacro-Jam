using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Dash")]
    public Sprite dashFullTitle;
    public Sprite dashUsed;
    public Sprite dashRemoved;
    public Sprite dashBarFull;
    public Sprite dashBarUsed;
    public Sprite dashBarRemoved;
    public Sprite[] dashSprites;
    public GameObject DashTitle;
    public GameObject DashBar;

    [Space(20)]
    [Header("Bomb")]
    public Sprite bombFullTitle;
    public Sprite bombUsed;
    public Sprite bombRemoved;
    public Sprite bombBarFull;
    public Sprite bombBarUsed;
    public Sprite bombBarRemoved;
    public Sprite[] bombSprites;
    public GameObject bombTitle;
    public GameObject bombBar;
    
    [Space(20)]
    [Header("Shoot")]
    public Sprite shootFullTitle;
    public Sprite shootUsed;
    public Sprite shootRemoved;
    public Sprite shootBarFull;
    public Sprite shootBarUsed;
    public Sprite shootBarRemoved;
    public Sprite[] shootSprites;
    public GameObject shootTitle;
    public GameObject shootBar;
    
    [Space(20)]
    [Header("Wave")]
    public Sprite waveFullTitle;
    public Sprite waveUsed;
    public Sprite waveRemoved;
    public Sprite waveBarFull;
    public Sprite waveBarUsed;
    public Sprite waveBarRemoved;
    public Sprite[] waveSprites;
    public GameObject waveTitle;
    public GameObject waveBar;
    
    
    [Space(20)]
    [Header("Health")]
    private int healthCount = 4;
    public int maxHealthCount = 4;
    public Sprite fullheart;
    public Sprite emptyHeart;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;

    #region Dash

    public void DoDash(float cooldown)
    {
        DashTitle.GetComponent<Image>().sprite = dashUsed;
        DashBar.GetComponent<Image>().sprite = dashBarUsed;
        
        StartCoroutine(_Animate(cooldown, DashBar, dashSprites, ResetDash));
    }
    
    public void ResetDash()
    {
        DashTitle.GetComponent<Image>().sprite = dashFullTitle;
        DashBar.GetComponent<Image>().sprite = dashBarFull;
        DashTitle.GetComponent<Animator>().SetBool("play", true);
        //DashTitle.GetComponent<Animator>().Play("DashTitleAnimation", -1, 0f);
    }

    public void RemoveDash()
    {
        DashTitle.GetComponent<Image>().sprite = dashRemoved;
        DashBar.GetComponent<Image>().sprite = dashBarRemoved;
    }

    #endregion
    
    #region Bomb

    public void DoBomb(float cooldown)
    {
        bombTitle.GetComponent<Image>().sprite = bombUsed;
        bombBar.GetComponent<Image>().sprite = bombBarUsed;
        
        StartCoroutine(_Animate(cooldown, bombBar, bombSprites, ResetBomb));
    }
    
    public void ResetBomb()
    {
        bombBar.GetComponent<Image>().sprite = bombBarFull;
        bombTitle.GetComponent<Image>().sprite = bombFullTitle;
        bombTitle.GetComponent<Animator>().SetBool("play", true);
    }

    public void RemoveBomb()
    {
        bombTitle.GetComponent<Image>().sprite = bombRemoved;
        bombBar.GetComponent<Image>().sprite = bombBarRemoved;
    }

    #endregion
    
    #region Shoot

    public void DoShoot(float cooldown)
    {
        shootTitle.GetComponent<Image>().sprite = shootUsed;
        shootBar.GetComponent<Image>().sprite = shootBarUsed;
        
        StartCoroutine(_Animate(cooldown, shootBar, shootSprites, ResetShoot));
    }
    
    public void ResetShoot()
    {
        shootBar.GetComponent<Image>().sprite = shootBarFull;
        shootTitle.GetComponent<Image>().sprite = shootFullTitle;
        shootTitle.GetComponent<Animator>().SetBool("play", true);
    }

    public void RemoveShoot()
    {
        shootTitle.GetComponent<Image>().sprite = shootRemoved;
        shootBar.GetComponent<Image>().sprite = shootBarRemoved;
    }

    #endregion
    
    #region Wave

    public void DoWave(float cooldown)
    {
        waveTitle.GetComponent<Image>().sprite = waveUsed;
        waveBar.GetComponent<Image>().sprite = waveBarUsed;
        
        StartCoroutine(_Animate(cooldown, waveBar, waveSprites, ResetWave));
    }
    
    public void ResetWave()
    {
        waveBar.GetComponent<Image>().sprite = waveBarFull;
        waveTitle.GetComponent<Image>().sprite = waveFullTitle;
        waveTitle.GetComponent<Animator>().SetBool("play", true);
    }

    public void RemoveWave()
    {
        waveTitle.GetComponent<Image>().sprite = waveRemoved;
        waveBar.GetComponent<Image>().sprite = waveBarRemoved;
    }

    #endregion
    
    #region Health
    public void AddHealth()
    {
        if (healthCount < maxHealthCount)
        {
            healthCount += 1;
        }
        
        switch (healthCount)
        {
            case 1: 
                heart1.GetComponent<Animator>().SetBool("isEmpty", false);
                break;
            case 2: 
                heart2.GetComponent<Animator>().SetBool("isEmpty", false);
                heart1.GetComponent<Animator>().SetBool("isCritical", false);
                heart2.GetComponent<Animator>().SetBool("isCritical", false);
                heart3.GetComponent<Animator>().SetBool("isCritical", false);
                heart4.GetComponent<Animator>().SetBool("isCritical", false);
                break;
            case 3: 
                heart3.GetComponent<Animator>().SetBool("isEmpty", false);
                break;
            case 4: 
                heart4.GetComponent<Animator>().SetBool("isEmpty", false);
                break;
        }
    }

    public void RemoveHealth()
    {
        if (healthCount > 0)
        {
            healthCount -= 1;
        }

        switch (healthCount)
        {
            case 0: 
                heart1.GetComponent<Animator>().SetBool("isEmpty", true);
                break;
            case 1: 
                heart2.GetComponent<Animator>().SetBool("isEmpty", true);
                heart1.GetComponent<Animator>().SetBool("isCritical", true);
                heart2.GetComponent<Animator>().SetBool("isCritical", true);
                heart3.GetComponent<Animator>().SetBool("isCritical", true);
                heart4.GetComponent<Animator>().SetBool("isCritical", true);
                break;
            case 2: 
                heart3.GetComponent<Animator>().SetBool("isEmpty", true);
                break;
            case 3: 
                heart4.GetComponent<Animator>().SetBool("isEmpty", true);
                break;
        }
    }

    #endregion
    
    IEnumerator _Animate(float cooldown, GameObject bar, Sprite[] sprites, Action resetMethod)
    {
        float step = cooldown / sprites.Length;
        foreach (var dash in sprites)
        {
            yield return new WaitForSeconds(step);
            bar.GetComponent<Image>().sprite = dash;
        }
        
        yield return new WaitForSeconds(step);
        resetMethod();
    }
}
