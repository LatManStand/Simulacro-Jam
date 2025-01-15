using UnityEngine;

public class SkillSystem: MonoBehaviour
{
    public void RemoveWaveSkill()
    {        
        GetComponent<PulseShoot>().enabled = false;
    }

    public void RemoveShootSkill()
    {
        GetComponent<Shoot>().enabled = false;
    }
    
    public void RemoveDashSkill()
    {
        GetComponent<Dash>().enabled = false;
    }
    
    public void RemoveBombSkill()
    {
        GetComponent<Bomb>().enabled = false;
    }
}
