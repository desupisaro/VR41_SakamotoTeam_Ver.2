using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> posList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();

    private List<GameObject> activeObjects = new List<GameObject>();

    void Start()
    {
        int numberOfObjectsToSpawn = Mathf.Min(posList.Count, objectList.Count);

        List<GameObject> shuffledObjects = new List<GameObject>(objectList);
        Shuffle(shuffledObjects);

        // 特別なオブジェクトをランダムに選ぶためのインデックス
        int specialObjectIndex = Random.Range(0, numberOfObjectsToSpawn);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 spawnPos = posList[i].transform.position;
            Quaternion spawnRot = posList[i].transform.rotation;

            GameObject prefabToInstantiate = shuffledObjects[i];

            GameObject instantiatedObject = Instantiate(prefabToInstantiate, spawnPos, spawnRot);
            activeObjects.Add(instantiatedObject);

            // ランダムに選ばれたオブジェクトに特別なタグを付ける
            if (i == specialObjectIndex)
            {
                // ここでオブジェクトに「Target」のようなタグを付ける
                instantiatedObject.tag = "Target";
                Debug.Log($"Target is {instantiatedObject.name}");
            }
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}