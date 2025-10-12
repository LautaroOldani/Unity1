using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    
    public PlayerProgressionData playerData;

    void Awake()
    {
        
        playerData.currentLevel = 1;
        playerData.currentExperience = 0;
        playerData.expToNextLevel = 30;
    }
}