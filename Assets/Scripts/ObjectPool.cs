using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour
{
   
    [SerializeField]
    private GameObject[] objectPrefabs;

    
    public GameObject GetObject(string type)
    {
        //If the pool didn't contain the object, that we needed then we need to create a new one
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            //If we have a prefab for creating the object
            if (objectPrefabs[i].name == type)
            {
                //We instantiate the prefab of the correct type
                GameObject newObject = Instantiate(objectPrefabs[i]);
                newObject.name = type;
                return newObject;
            }
        }

        return null;
    }

}
