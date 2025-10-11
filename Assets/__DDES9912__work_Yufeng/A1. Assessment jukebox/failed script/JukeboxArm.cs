using UnityEngine;
using UnityEngine.Audio;

public class JukeboxArm : MonoBehaviour
{
    
    public Vector3 targetRecordPos; 
    public AudioClip targetMusic;    
    public bool isSelectRecord = false; 

   
    public float moveSpeed = 2f;


    public Transform recordBoxTransform;
    private Vector3 targetBoxPos;

    public AudioSource audioSource;

   
    private enum ArmState { Idle, MoveToRecord, GrabRecord, MoveToBox, PutRecord, PlayMusic }
    private ArmState currentState = ArmState.Idle;

    void Start()
    {
       
        if (recordBoxTransform != null)
        {
            targetBoxPos = recordBoxTransform.position + new Vector3(0, 0.1f, 0);
        }
    }

    void Update()
    {
       
        switch (currentState)
        {
            case ArmState.Idle:
               
                if (isSelectRecord)
                {
                    currentState = ArmState.MoveToRecord;
                    isSelectRecord = false; 
                }
                break;

            case ArmState.MoveToRecord:
               
                transform.position = Vector3.Lerp(transform.position, targetRecordPos, moveSpeed * Time.deltaTime);
              
                if (Vector3.Distance(transform.position, targetRecordPos) < 0.1f)
                {
                    currentState = ArmState.GrabRecord; 
                }
                break;

            case ArmState.GrabRecord:
               
                
                GameObject targetRecord = FindClosestRecord();
                if (targetRecord != null)
                {
                    targetRecord.transform.parent = transform;
                }
                currentState = ArmState.MoveToBox; 
                break;

            case ArmState.MoveToBox:
              
                transform.position = Vector3.Lerp(transform.position, targetBoxPos, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetBoxPos) < 0.1f)
                {
                    currentState = ArmState.PutRecord; 
                break;

            case ArmState.PutRecord:
               
                GameObject grabbedRecord = GetComponentInChildren<RecordSelect>();
                if (grabbedRecord != null)
                {
                    grabbedRecord.transform.parent = null;
                    
                    grabbedRecord.transform.position = targetBoxPos;
                }
                currentState = ArmState.PlayMusic; 
                break;

            case ArmState.PlayMusic:
             
                if (audioSource != null && targetMusic != null)
                {
                    audioSource.Stop();
                    audioSource.clip = targetMusic;
                    audioSource.Play();
                }
               
                currentState = ArmState.Idle;
                break;
        }
    }

   
    private GameObject FindClosestRecord()
    {
        GameObject[] records = GameObject.FindGameObjectsWithTag("Record"); 
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject record in records)
        {
            float distance = Vector3.Distance(transform.position, record.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = record;
            }
        }
        return closest;
    }
}






