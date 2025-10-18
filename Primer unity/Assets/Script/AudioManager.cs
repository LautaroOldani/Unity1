using UnityEngine;

public class AudioManager : MonoBehaviour
{
  
    public static AudioManager Instance;

    [Header("Componentes de Audio")]
    private AudioSource audioSource;

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
       
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

  

    [Header("Clips del Juego")]
    public AudioClip golpeEnemigo; 
    public AudioClip saltoJugador;   

    
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            
            audioSource.PlayOneShot(clip);
        }
    }
}