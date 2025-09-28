using UnityEngine;
using UnityEngine.Events;

public class ProgressionManager : MonoBehaviour
{
    public static ProgressionManager Instance { get; private set; }

    // Referencia al ScriptableObject que almacena los datos
    public PlayerProgressionData playerData;

    // Eventos para notificar al HUD cuando la experiencia o el nivel cambian
    public UnityEvent<float, float> OnExpGanada;
    public UnityEvent<int> OnSubirNivel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void AddExperience(float amount)
    {
        playerData.currentExperience += amount;

        OnExpGanada.Invoke(playerData.currentExperience, playerData.expToNextLevel);

        // La revisión ahora es un bucle
        if (playerData.currentExperience >= playerData.expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        // Usa un bucle para asegurar que se suba de nivel por cada 
        // cantidad de experiencia requerida.
        while (playerData.currentExperience >= playerData.expToNextLevel)
        {
            playerData.currentExperience -= playerData.expToNextLevel;
            playerData.currentLevel++;
            playerData.expToNextLevel *= 1.5f;

            OnSubirNivel.Invoke(playerData.currentLevel);
        }

        // Esta línea asegura que la barra de experiencia se actualice después de subir de nivel.
        OnExpGanada.Invoke(playerData.currentExperience, playerData.expToNextLevel);
    }
}