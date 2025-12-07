using UnityEngine;
using System;
using System.Collections.Generic;

public class GenericPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _objectPrefab;

    private int _spawningObjectIndex;

    private Queue<T> _pool = new Queue<T>();
    private List<T> _activeObjects = new List<T>();

    public event Action<T> ObjectSpawned;
    public event Action<T> ObjectRemoved;

    public T GetObject()
    {
        if(_pool.Count > 0)
        {
            T oldObj = _pool.Dequeue();

            oldObj.gameObject.SetActive(true);

            ObjectSpawned?.Invoke(oldObj);

            _activeObjects.Add(oldObj);

            return oldObj;
        }

        T obj = Instantiate(_objectPrefab);

        ObjectSpawned?.Invoke(obj);

        _activeObjects.Add(obj);

        return obj;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);

        ObjectRemoved?.Invoke(obj);

        _pool.Enqueue(obj);

        _activeObjects.Remove(obj);
    }

    public void ResetAllObjects()
    {
        List<T> newActiveObjects = new List<T>(_activeObjects);

        for(int i = 0; i < newActiveObjects.Count; i++)
            ReturnObject(newActiveObjects[i]);
    }
}
