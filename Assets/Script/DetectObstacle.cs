using Unity.Behavior;
using Unity.VisualScripting;
using UnityEngine;

public class DetectObstacle : MonoBehaviour
{
    
    public GameObject UpdateCollider()
    {
        GameObject obj = null;
        
        void OnTriggerEnter(Collider other)
        {
            obj = other.gameObject;
        }
        
        return obj;
    }
}
