using UnityEngine;

public class RecordData : MonoBehaviour
{
    public AudioClip song;
    public Vector3 originalposition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalposition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
