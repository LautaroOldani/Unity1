using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "Progression/Player Data")]
public class PlayerProgressionData : ScriptableObject
{
    public int currentLevel = 0;
    public float currentExperience = 0;
    public float expToNextLevel = 30;
}