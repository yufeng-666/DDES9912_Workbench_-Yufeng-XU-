using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAController : MonoBehaviour
{
     public GameObject objectA;
    public GameObject objectB;
    public GameObject objectC;
    public GameObject objectD;
    public List<Transform> positionList = new List<Transform>();
    public AudioSource audioSource;
    private bool isRotating = false;
    public Transform CPos;
    public void PlayRecord(int index)
    {
        if (index < 0 || index >= positionList.Count) return;
        objectB = positionList[index].gameObject;
        StartCoroutine(ExecuteFunctionsSequence());
    }
    IEnumerator ExecuteFunctionsSequence()
    {
       
        yield return StartCoroutine(MoveObjectDToBX());
        yield return StartCoroutine(RotateObjectA(90f, Vector3.right));
      
        LinkObjectBToA();     
        yield return StartCoroutine(RotateObjectA(179f, Vector3.left));      
        yield return StartCoroutine(RotateObjectA(-90f, Vector3.up));       
        LinkObjectBToC();       
        StartContinuousRotation();
    }
    IEnumerator MoveObjectDToBX()
    {
        if (positionList.Count == 0)
        {
           
            yield break;
        }      
        Transform targetPosition = objectB.transform;
        Vector3 targetPos = objectD.transform.position;
        targetPos.x = targetPosition.position.x;

        float duration = 2f;
        float elapsedTime = 0f;
        Vector3 startPos = objectD.transform.position;

        while (elapsedTime < duration)
        {
            objectD.transform.position = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectD.transform.position = targetPos;
    }
    IEnumerator RotateObjectA(float angle, Vector3 axis)
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion startRotation = objectA.transform.rotation;
        Quaternion targetRotation = startRotation * Quaternion.AngleAxis(angle, axis);

        while (elapsedTime < duration)
        {
            objectA.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        objectA.transform.rotation = targetRotation;
       
    }
   
    void LinkObjectBToA()
    {    
        objectB.transform.SetParent(objectA.transform);  
    }      
    void LinkObjectBToC()
    {   
        objectB.transform.SetParent(null);
        objectB.transform.SetParent(objectC.transform);
        objectB.transform.localPosition =Vector3.zero + new Vector3(0,1F,0);
    }
    
    void StartContinuousRotation()
    {
        isRotating = true;      
            audioSource.Play();   
    }
    void Update()
    {   
        if (isRotating)
        {
            objectC.transform.Rotate(0,  30 * Time.deltaTime, 0);
        }
    }

 
}