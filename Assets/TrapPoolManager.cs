using Unity.VisualScripting;
using UnityEngine;


public interface IStorableInPool
{
    void reset();
}

public class TrapPoolManager : MonoBehaviour
{
    /* create the objects in the pool
     * enable the object (at a place/rotation)
     * disable the object (reset it while you are at it)
     */

    [SerializeField] GameObject _gameObject;
    [SerializeField] static int _poolSize = 5;

    GameObject[] _objectsInPool = new GameObject[_poolSize];

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            _objectsInPool[i] = Instantiate(_gameObject, transform.position, transform.rotation);
            _objectsInPool[i].SetActive(false);
        }
    }

    public bool GetObject(Vector3 position, Quaternion rotation)
    {
        int index = GetNextFreeObjectIndex();
        if (index == -1) return false;

        _objectsInPool[index].transform.position = position;
        _objectsInPool[index].transform.rotation = rotation;
        _objectsInPool[index].SetActive(true);
        return true;
    }

    public void ReturnObject(GameObject obj) 
    {
        obj.SetActive(false);
        //obj.GetComponent<IStorableInPool>().reset();
    }

    int GetNextFreeObjectIndex()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (_objectsInPool[i].activeSelf == false) return i;
        }
        return -1;
    }
}
