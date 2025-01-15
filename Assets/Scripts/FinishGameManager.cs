using TMPro;
using UnityEngine;

public class WinGameManager : MonoBehaviour
{
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;
    
    void Start()
    {
        skill1.SetActive(false);
        skill2.SetActive(false);
        skill3.SetActive(false);
        skill4.SetActive(false);

        var skills = UISystemManager.instance.skillRemovedOrder;

        if (skills.Count == 1)
        {
            SetSkill1(skills[0]);
        }
        
        if (skills.Count == 2)
        {
            SetSkill1(skills[0]);
            SetSkill2(skills[1]);
        }
        
        if (skills.Count == 3)
        {
            SetSkill1(skills[0]);
            SetSkill2(skills[1]);
            SetSkill3(skills[2]);
        }
        
        if (skills.Count == 4)
        {
            SetSkill1(skills[0]);
            SetSkill2(skills[1]);
            SetSkill3(skills[2]);
            SetSkill4(skills[3]);
        }
    }

    void SetSkill1(string skillName)
    {
        skill1.SetActive(true);
        skill1.GetComponent<TextMeshProUGUI>().text = skillName;
    }
    
    void SetSkill2(string skillName)
    {
        skill2.SetActive(true);
        skill2.GetComponent<TextMeshProUGUI>().text = skillName;
    }
    
    void SetSkill3(string skillName)
    {
        skill3.SetActive(true);
        skill3.GetComponent<TextMeshProUGUI>().text = skillName;
    }
    
    void SetSkill4(string skillName)
    {
        skill4.SetActive(true);
        skill4.GetComponent<TextMeshProUGUI>().text = skillName;
    }
}
