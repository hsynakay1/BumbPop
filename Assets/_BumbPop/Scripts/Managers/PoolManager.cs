using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [Serializable] public struct Pool
    {
        public Queue<Ball> PooledObjects;
        public Ball objectPrefab;
        public int poolSize;
    }
    [SerializeField] public Pool[] pools = null;

    public static PoolManager Instance;
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i].PooledObjects = new Queue<Ball>();
            
            for(int j = 0; j < pools[i].poolSize; j++)
            {
                Ball obj = Instantiate(pools[i].objectPrefab);
                obj.gameObject.SetActive(false);
                pools[i].PooledObjects.Enqueue(obj);
            }
        }
    }
    public Ball GetPoolObject(int objectType)
    {
        if (objectType >= pools.Length) return null;
        
        if (pools[objectType].PooledObjects.Count == 0)
            AddSizePool(5f, objectType);
        
        Ball obj = pools[objectType].PooledObjects.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void SetPoolObject(Ball pooledObject, int objectType)
    {
        if(objectType >= pools.Length) return;
        pools[objectType].PooledObjects.Enqueue(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
    public void AddSizePool(float amount, int objectType)
    {
        for (int i = 0; i < amount; i++)
        {
            Ball obj = Instantiate(pools[objectType].objectPrefab);
            obj.gameObject.SetActive(false);
            pools[objectType].PooledObjects.Enqueue(obj);
        }
    }
}
