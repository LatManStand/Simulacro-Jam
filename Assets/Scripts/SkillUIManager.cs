using UnityEngine;

public class SkillUIManager : MonoBehaviour
{
    public GameObject LevelSystem;

    public void RemoveSkill(int skill)
    {
        Debug.Log($"Remove {skill}");
        
        LevelSystem.GetComponent<LevelSystem>().LoadNextLevel();
    }
}
