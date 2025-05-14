using System;
using UnityEditor;
using UnityEngine;

public class TrapPlacer : MonoBehaviour
{
    [SerializeField] TrapPoolManager trapPool;
    bool _actionTriggered;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) _actionTriggered = true;
        if (_actionTriggered) PlaceTrap();
        _actionTriggered = false;
    }

    private void PlaceTrap()
    {
        bool success = trapPool.GetObject(transform.position, transform.rotation);
        if (success == false) Debug.Log("No Traps left in the pool");
    }
}
