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
        GameObject trap = trapPool.GetObject(transform.position, transform.rotation);
        if (trap == null)
        {
            Debug.Log("No Traps left in the pool");
            return;
        }

        trap.GetComponent<TrapController>().OnTrapDespawn += ReturnTrap;
    }

    private void ReturnTrap(GameObject trap)
    {
        trap.GetComponent<TrapController>().OnTrapDespawn -= ReturnTrap;
        trapPool.ReturnObject(trap);
    }
}
