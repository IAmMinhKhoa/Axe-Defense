using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PoolObjectInfo> ObjectPools =new List<PoolObjectInfo> ();

    private GameObject _objectPoolEmptyHoder;

    private static GameObject _particleSystemsEmpty;
    private static GameObject _gameObjectsEmpty;

    public enum Pooltyle
    {
        ParticleSystem,
        Gameobject,
        None
    }
    public static Pooltyle PoolingType;


    private void Awake()
    {
        SetUpEmpties();
    }
    private void SetUpEmpties()
    {
        _objectPoolEmptyHoder = new GameObject("Pooled Objects");

        _particleSystemsEmpty = new GameObject("Particle Effects");
        _particleSystemsEmpty.transform.SetParent(_objectPoolEmptyHoder.transform);

        _gameObjectsEmpty = new GameObject("GameObjects");
        _gameObjectsEmpty.transform.SetParent(_objectPoolEmptyHoder.transform);
    }


    public static GameObject SpawnOject(GameObject objectToSpam,Vector3 spawnPosition,quaternion spawnRotation,Pooltyle pooltyle=Pooltyle.None)
    {
        PoolObjectInfo pool = ObjectPools.Find(p => p.LookupString == objectToSpam.name);


        //if the pool doesn't exist, creat it
        if(pool == null)
        {
            pool = new PoolObjectInfo() { LookupString = objectToSpam.name };
            ObjectPools.Add(pool);
        }

        //check if there are any iactive objects in the pool
        GameObject spawnableObj = pool.InactiveObjects.FirstOrDefault();

        /* GameObject spawnableObj = null;
         foreach (GameObject obj in pool.InactiveObjects)
         {
             if (obj != null)
             {
                 spawnableObj = obj;
                 break;
             }
         }*/

        if (spawnableObj == null)
        {
            //find the parent of the empty object
            GameObject parentObject = SetParentObject(pooltyle);

            //if there are no inactivate objects, creat a new one
            spawnableObj=Instantiate(objectToSpam,spawnPosition,spawnRotation);

            if (parentObject != null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            //if there is an inactive object, reactive it
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnOjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);//by taking off 7 ,removing  the (clone)

        PoolObjectInfo pool = ObjectPools.Find(p=>p.LookupString== goName);    

        if(pool == null)
        {
            Debug.LogWarning(goName+"trying to release an object tha is not pooled : " + obj.name);

        }
        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }

    private static GameObject SetParentObject(Pooltyle pooltyle)
    {
        switch (pooltyle)
        {   
            case Pooltyle.ParticleSystem:
                return _particleSystemsEmpty;
            case Pooltyle.Gameobject:
                return _gameObjectsEmpty;
            case Pooltyle.None:
                return null;
            default:
                return null;
        }
    }
}


public class PoolObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects =new List<GameObject> ();
}
