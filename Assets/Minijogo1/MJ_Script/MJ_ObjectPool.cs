using System.Collections.Generic;
using UnityEngine;

public class MJ_ObjectPool : MonoBehaviour
{
    //public static ObjectPool SharedInstance;
    [SerializeField] protected MJ_GameControl _gameControl;
    [SerializeField] protected List<GameObject> pooledObjects;
    [SerializeField] protected GameObject objectToPool;
    [SerializeField] protected int amountToPool;

    public virtual void Awake()
    {
        _gameControl = GameObject.FindWithTag("GameController").GetComponent<MJ_GameControl>();
        //SharedInstance = this;
    }

    public virtual void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    public virtual GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
