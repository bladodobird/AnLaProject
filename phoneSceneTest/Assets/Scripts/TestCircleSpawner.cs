using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // ��骺�w�s��

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ���a���U�ƹ�����

            // �N�ƹ��I����m�ഫ���@�ɮy��
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f; // �T�OZ�b��0

            // �b�I����m�ͦ����
            Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
