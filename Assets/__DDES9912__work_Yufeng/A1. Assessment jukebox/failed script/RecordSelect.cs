using UnityEngine;
public class RecordSelect : MonoBehaviour
{
    void OnMouseDown()
    {

        Debug.Log("尝试点击唱片！");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log("命中了：" + hit.collider.gameObject.name);
        }
        else
        {
            Debug.Log("没命中任何物体！");
        }
        // 原逻辑...
    }
}