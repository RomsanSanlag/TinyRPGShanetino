using System;
using System.Threading.Tasks;
using UnityEngine;

public class TrapController : MonoBehaviour, IStorableInPool 
{
    [SerializeField] GameObject _spikes;

    public event Action<GameObject> OnTrapDespawn;

    public void ForceReturnToPool()
    {
        Debug.Log("ForceReturn called");
        OnTrapDespawn?.Invoke(this.gameObject);
    }

    public void ResetObject()
    {
        _spikes.SetActive(false);
    }

    private async void OnTriggerEnter(Collider other)
    {
        ITrappable trappable = other.gameObject.GetComponent<ITrappable>();
        if (trappable == null) return;

        _spikes.SetActive(true);
        trappable.Trap();

        await Task.Delay(1000);

        OnTrapDespawn?.Invoke(this.gameObject);
    }
}

internal interface ITrappable
{
    void Trap();
}
