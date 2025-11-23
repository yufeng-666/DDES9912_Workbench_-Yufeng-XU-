using UnityEngine;

public class ButtonPoker : MonoBehaviour 

{
    public InteractableGeneral subject;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        subject = other.GetComponent<InteractableGeneral>();

        if (subject != null)
        {
            subject.onPrimaryInteract.Invoke();


        }


}
}

