using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> posList = new List<GameObject>();
    [SerializeField]
    private List<GameObject> objectList = new List<GameObject>();

    // �^�[�Q�b�g�ɓK�p�������}�e���A�����C���X�y�N�^�[����ݒ�ł���悤�ɂ���
    [SerializeField]
    private Material targetMaterial;

    private List<GameObject> activeObjects = new List<GameObject>();

    void Start()
    {
        int numberOfObjectsToSpawn = Mathf.Min(posList.Count, objectList.Count);

        List<GameObject> shuffledObjects = new List<GameObject>(objectList);
        Shuffle(shuffledObjects);

        int specialObjectIndex = Random.Range(0, numberOfObjectsToSpawn);

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 spawnPos = posList[i].transform.position;
            Quaternion spawnRot = posList[i].transform.rotation;

            GameObject prefabToInstantiate = shuffledObjects[i];

            GameObject instantiatedObject = Instantiate(prefabToInstantiate, spawnPos, spawnRot);
            activeObjects.Add(instantiatedObject);

            if (i == specialObjectIndex)
            {
                instantiatedObject.tag = "Target";
                Debug.Log($"Target is {instantiatedObject.name}");

                // �^�[�Q�b�g�I�u�W�F�N�g�ɓ��ʂȃ}�e���A����K�p
                ApplyTargetMaterial(instantiatedObject);
            }
        }
    }

    // �^�[�Q�b�g�I�u�W�F�N�g�Ƀ}�e���A����K�p����w���p�[�֐�
    void ApplyTargetMaterial(GameObject obj)
    {
        // �}�e���A�����ݒ肳��Ă��邩�m�F
        if (targetMaterial != null)
        {
            // MeshRenderer�R���|�[�l���g���擾
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.material = targetMaterial; // �}�e���A����K�p
            }
            else
            {
                Debug.LogWarning($"Target object {obj.name} has no MeshRenderer component to apply material.");
            }
        }
        else
        {
            Debug.LogWarning("Target Material is not assigned in the Inspector.");
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