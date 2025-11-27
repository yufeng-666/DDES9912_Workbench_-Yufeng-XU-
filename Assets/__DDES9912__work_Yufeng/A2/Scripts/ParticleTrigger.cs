using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particleSystem; 
    public AudioSource audioSource;       

    private bool isPlaying = false; 

    void Update()
    {
        
        if (audioSource.isPlaying && !isPlaying)
        {
            particleSystem.Play();
            isPlaying = true;     
        }
       
        else if (!audioSource.isPlaying && isPlaying)
        {
            particleSystem.Stop();  
            isPlaying = false;     
        }
    }
}