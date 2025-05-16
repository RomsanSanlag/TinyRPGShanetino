using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public interface IStorableInPool
{
    void ResetObject();
    void ForceReturnToPool();
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
    List<IStorableInPool> _spawnedObjects = new List<IStorableInPool> ();

    private void Start()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            _objectsInPool[i] = Instantiate(_gameObject, transform.position, transform.rotation);
            _objectsInPool[i].SetActive(false);
        }
    }

    public GameObject GetObject(Vector3 position, Quaternion rotation)
    {
        int index = GetNextFreeObjectIndex();
        if (index == -1)
        {
            ForceReturnOldestObject();
            index = 0;
        }

        _objectsInPool[index].transform.position = position;
        _objectsInPool[index].transform.rotation = rotation;
        _objectsInPool[index].SetActive(true);
        _spawnedObjects.Add(gameObject.GetComponent<IStorableInPool>());
        return _objectsInPool[index];
    }

    public void ReturnObject(GameObject obj) 
    {
        _spawnedObjects.Remove(obj.GetComponent<IStorableInPool>());
        obj.SetActive(false);
        obj.GetComponent<IStorableInPool>().ResetObject();
    }

    int GetNextFreeObjectIndex()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (_objectsInPool[i].activeSelf == false) return i;
        }
        return -1;
    }

    private void ForceReturnOldestObject()
    {
        _spawnedObjects[0].ForceReturnToPool(); 
    }
}
