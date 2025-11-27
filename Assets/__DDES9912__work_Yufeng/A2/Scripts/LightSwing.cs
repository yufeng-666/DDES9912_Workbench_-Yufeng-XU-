using UnityEngine;

public class LightSwing : MonoBehaviour
{
    public Light leftLight;   
    public Light rightLight;  
    public AudioSource audioSource;  

    private float swingSpeed = 1.5f;   
    private float maxAngle = 50f;

    private Quaternion initialRotation;

    void Start()
    {    
        initialRotation = Quaternion.Euler(90f, 0f, 0f);       
        leftLight.transform.rotation = initialRotation;
        rightLight.transform.rotation = initialRotation;
    }

    void Update()
    {
        
        if (audioSource.isPlaying)
        {
            
            float swingValue = Mathf.Sin(Time.time * swingSpeed);
            float currentSwingAngle = swingValue * maxAngle;        
            Quaternion swingRotation = Quaternion.Euler(0f, currentSwingAngle, 0f);

           
            leftLight.transform.rotation = initialRotation * swingRotation;           
            rightLight.transform.rotation = initialRotation * Quaternion.Euler(0f, -currentSwingAngle, 0f);
        }
        else
        {
            
            leftLight.transform.rotation = initialRotation;
            rightLight.transform.rotation = initialRotation;
        }
    }
}