using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBMButEaser : MonoBehaviour
{
    public GameObject noteButtonPrefab;  // 筆記按鈕預製體
    public Transform buttonsParent;  // 筆記按鈕的父物件

    public List<GameObject> noteButtons = new List<GameObject>();  // 存儲筆記按鈕的列表
    public Vector2 buttonOffset = new Vector2(0f, -100f); // 每次生成按鈕的位置偏移量
    private Vector2 nextButtonPosition; // 下一個按鈕的位置

    void Start()
    {
        nextButtonPosition = buttonsParent.transform.position; // 設定下一個按鈕的初始位置
    }

    public void CreateNote()
    {
        // 在 buttonsParent 下生成一個新的筆記按鈕物件
        GameObject newNoteButton = Instantiate(noteButtonPrefab, nextButtonPosition, Quaternion.identity, buttonsParent);
        nextButtonPosition += buttonOffset; // 調整下一個按鈕的位置

        // 將新生成的筆記按鈕物件添加到筆記按鈕列表中
        noteButtons.Add(newNoteButton);
    }

}
