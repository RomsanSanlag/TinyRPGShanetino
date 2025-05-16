using UnityEngine;

public class Trappable : MonoBehaviour, ITrappable
{
    public void Trap()
    {
        Debug.Log("Ouch!");
    }
}
