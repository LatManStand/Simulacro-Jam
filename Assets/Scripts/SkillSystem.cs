using UnityEngine;

public class SkillSystem : MonoBehaviour
{
    public GameObject player;
    public bool isPulseAvailable = true;
    public bool isShootAvailable = true;

    public void RemovePulseSkill()
    {        
        isPulseAvailable = false;
        player.GetComponent<PulseShoot>().enabled = isPulseAvailable;
    }

    public void RemoveShootSkill()
    {
        isShootAvailable = false;
        player.GetComponent<Shoot>().enabled = isShootAvailable;
    }
}
