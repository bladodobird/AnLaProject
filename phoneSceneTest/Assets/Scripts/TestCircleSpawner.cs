using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCircleSpawner : MonoBehaviour
{
    public GameObject circlePrefab; // 圓圈的預製體

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 玩家按下滑鼠左鍵

            // 將滑鼠點擊位置轉換為世界座標
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f; // 確保Z軸為0

            // 在點擊位置生成圓圈
            Instantiate(circlePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
