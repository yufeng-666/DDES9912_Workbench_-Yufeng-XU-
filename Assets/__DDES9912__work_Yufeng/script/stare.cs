using UnityEngine;

public class stare : MonoBehaviour
{
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target); using UnityEngine;

public class CarouselController : MonoBehaviour
    {
        public float moveSpeed = 2f;       // 移动速度
        public Vector3 moveDirection;      // 移动方向
        public float rotateSpeed = 30f;    // 旋转速度（度/秒）

        void Update()
        {
            // 平移移动
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

            // 旋转自己
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.Self);
        }
    }

}
}
