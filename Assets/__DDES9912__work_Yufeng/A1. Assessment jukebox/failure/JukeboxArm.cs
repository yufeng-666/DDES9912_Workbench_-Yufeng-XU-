using UnityEngine;
public class JukeboxArm : MonoBehaviour
{
    public Vector3 targetPos; 
    public bool shouldMove = false; 
    public float moveSpeed = 3f; 

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                shouldMove = false;
            }
        }
    }
}