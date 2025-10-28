using UnityEngine;

public class ArmController : MonoBehaviour
{
    public Transform basePosition;
    public Transform armPiece1;
    public Transform armPiece2;
    public Transform claw;
    public Transform idlePosition;
    public Transform turntablePosition;
    public Transform[] discs;

    private Transform currentTarget;
    private bool isMoving = false;
    private bool isGrabbing = false;
    private Transform heldDisc = null;

    public float moveSpeed = 2.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && currentTarget != null) ;
        {
            MoveArm();

        }
}
    void MoveArm()
    {
        if(!isGrabbing )
        {
            if (Mathf.Abs(armPiece1.position.y - currentTarget.position.y) > 0.1f)
            {
                armPiece1.position = Vector3.MoveTowards(armPiece1.position, currentTarget.position, moveSpeed * Time.deltaTime);
            }
            else
            {
               
                if (Mathf.Abs(armPiece2.position.x - currentTarget.position.x) > 0.1f)
                {
                    armPiece2.position = Vector3.MoveTowards(armPiece2.position, currentTarget.position, moveSpeed * Time.deltaTime);
                }
                else
                {
                    
                    if (!isGrabbing)
                    {
                        if (heldDisc == null && currentTarget.CompareTag("Disc"))
                        {
                            GrabDisc(currentTarget);
                        }
                        else if (heldDisc != null && currentTarget == turntablePosition)
                        {
                            DropDisc();
                        }
                    }
                }
            }
        }
    }

    
    public void MoveToTarget(Transform target)
    {
        currentTarget = target;
        isMoving = true;
    }

    
    void GrabDisc(Transform disc)
    {
        heldDisc = disc;
        disc.SetParent(claw); 
        claw.position = disc.position; 
        isGrabbing = true;
    }

    
    void DropDisc()
    {
        heldDisc.SetParent(null);  
        heldDisc.position = turntablePosition.position;  
        heldDisc = null;
        isGrabbing = false; 

        
        MoveToTarget(idlePosition);
    }
}