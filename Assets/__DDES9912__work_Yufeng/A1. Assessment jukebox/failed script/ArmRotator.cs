using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    public float rotateSpeed = 45f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target!= null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }

}
    public void SetTarget(Transform t) => target = t;
}
