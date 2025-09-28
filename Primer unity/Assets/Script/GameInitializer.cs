using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Esta variable contendr� tu ScriptableObject
    public PlayerProgressionData playerData;

    void Awake()
    {
        // Resetea los datos del jugador a sus valores iniciales
        playerData.currentLevel = 1;
        playerData.currentExperience = 0;
        playerData.expToNextLevel = 30;
    }
}