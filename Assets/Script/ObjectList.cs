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

        // ���ʂȃI�u�W�F�N�g�������_���ɑI�Ԃ��߂̃C���f�b�N�X
        int specialObjectIndex = Random.Range(0, numberOfObjectsToSpawn);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 spawnPos = posList[i].transform.position;
            Quaternion spawnRot = posList[i].transform.rotation;

            GameObject prefabToInstantiate = shuffledObjects[i];

            GameObject instantiatedObject = Instantiate(prefabToInstantiate, spawnPos, spawnRot);
            activeObjects.Add(instantiatedObject);

            // �����_���ɑI�΂ꂽ�I�u�W�F�N�g�ɓ��ʂȃ^�O��t����
            if (i == specialObjectIndex)
            {
                // �����ŃI�u�W�F�N�g�ɁuTarget�v�̂悤�ȃ^�O��t����
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