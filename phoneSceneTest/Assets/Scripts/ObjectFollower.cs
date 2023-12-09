using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform[] waypoints; //儲存A物件位置(三個圍圈)
    public float speed = 2f;
    private int currentWaypointIndex = 0; //當前要前往的路徑
    private Transform target; // B物件要跟隨的A物件


    private void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        target = waypoints[currentWaypointIndex];

    }

    private void Update()
    {
        #region 版本一，無隨機，成功
        // 獲取物件要前往的路徑(跟隨順序)出隱形的線
        //Transform targetWaypoint = waypoints[currentWaypointIndex];

        // 讓要跟隨的物件往目標A物件移動，一秒跑一次
        //transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // 檢查是否達目標位置
        //if (transform.position == targetWaypoint.position)
        //{
        //    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        //}
        #endregion

        #region 版本二，但2D物件用3D的邏輯在運作
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //if (Vector3.Distance(transform.position, target.position) < 0.1f)
        //{
        //    int randomIndex = Random.Range(0, waypoints.Length);

        // 確保下一個目標不是當前的目標
        //    while (randomIndex == currentWaypointIndex)
        //    {
        //        randomIndex = Random.Range(0, waypoints.Length);
        //    }

        //    target = waypoints[randomIndex];
        //    currentWaypointIndex = randomIndex;
        //}

        //transform.LookAt(target);
        //transform.Translate(Vector3.forward * Time.deltaTime);
        #endregion

        #region 版本三
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            // 選擇下一個 A 物件，並更新目前的索引
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            target = waypoints[currentWaypointIndex];
        }
        #endregion
    }

}