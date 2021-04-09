using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAndom : MonoBehaviour
{

    public GameObject[] myObjects;
   void update ()
    {
        int randomIndex = Random.Range(0, myObjects.Length);

        GameObject instantiatedObject = Instantiate(myObjects[randomIndex], transform.position , Quaternion.identity) as GameObject;
    }

    
}
