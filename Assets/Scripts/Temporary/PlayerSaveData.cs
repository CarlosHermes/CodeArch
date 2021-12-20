using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSaveData", menuName = "ScriptableObjects/PlayerSaveData", order = 1)]
public class PlayerSaveData : ScriptableObject
{
    public IntVariable ingots;
    public IntVariable coins; 
    public IntVariable level; 
    public SkillItem firearrow;
    public SkillItem frozenarrow; 
    public SkillItem poisonarrow;

    public void LoadPlayerData(UserData data) 
    { 
        ingots.Value = data.ingots;
        coins.Value = data.coins;
        level.Value = data.level;
        firearrow.Locked = !data.skillsData.fireArrow;
        frozenarrow.Locked = !data.skillsData.frozenArrow; 
        poisonarrow.Locked = !data.skillsData.poisonArrow;
    }
}