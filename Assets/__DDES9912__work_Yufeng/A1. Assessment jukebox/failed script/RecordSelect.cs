using UnityEngine;


public class RecordSelect : MonoBehaviour
{
 
    public Vector3 recordPosition;
   
    public AudioClip recordMusic;

    void Start()
    {
       
        recordPosition = transform.position;
    }


    void OnMouseDown()
    {
     
        JukeboxArm arm = FindObjectOfType<JukeboxArm>();
        if (arm != null)
        {
            arm.targetRecordPos = recordPosition; 
            arm.targetMusic = recordMusic;     
            arm.isSelectRecord = true;           
        }

      
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}