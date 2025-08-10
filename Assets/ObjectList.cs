using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class ObjectList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> posList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>(); 

    private List<GameObject> selectedObject = new List<GameObject>();

    private GameObject instantiateObject;

    private GameObject randomObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < posList.Count; i++)
        {
            Vector3 spawnPos = posList[i].transform.position;
            Quaternion spawnRot = posList[i].transform.rotation;

            randomObject = objectList[Random.Range(0,objectList.Count)];

            instantiateObject = Instantiate(randomObject,spawnPos,spawnRot);

            posList[i] = instantiateObject;

            objectList.Remove(randomObject);
            selectedObject.Add(instantiateObject);
        } 
        Debug.Log(instantiateObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
