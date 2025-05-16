using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class DetectTrap : MonoBehaviour, ITrappable
{
    [SerializeField] GameObject _parentToKill;
    
    public void Trap()
    {
        Destroy(_parentToKill);
    }
}
