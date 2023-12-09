using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TbManager : MonoBehaviour
{
    public GameObject noteButtonPrefab;  // 筆記按鈕預製體
    public GameObject notePrefab;  // 筆記預製體
    public Transform buttonsParent;  // 筆記按鈕的父物件
    public Transform notesParent;  // 筆記的父物件
    public List<GameObject> noteButtons = new List<GameObject>();  // 存儲筆記按鈕的列表
    public List<GameObject> notes = new List<GameObject>();  // 存儲筆記的列表

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

        // 在 notesParent 下生成一個新的筆記物件
        GameObject newNote = Instantiate(notePrefab, notesParent);

        // 將新生成的筆記按鈕物件與筆記物件建立對應關係
        int index = noteButtons.Count + 1;
        newNoteButton.name = "A" + index.ToString();
        newNote.name = "a" + index.ToString();

        // 將新生成的筆記按鈕物件添加到筆記按鈕列表中
        noteButtons.Add(newNoteButton);

        // 將新生成的筆記物件添加到筆記列表中
        notes.Add(newNote);

        // 添加按鈕的點擊事件
        Button buttonComponent = newNoteButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => ShowNoteContent(noteButtons.IndexOf(newNoteButton)));
    }

    public void ShowNoteContent(int index)
    {
        // 根據索引找到對應的筆記物件並顯示
        if (index >= 0 && index < notes.Count)
        {
            GameObject note = notes[index];
            note.SetActive(true);
        }
    }

    public void DeleteNoteButton(GameObject note)
    {
        //檢查被刪除筆記下方是否有其他筆記需要上移
        int index = notes.IndexOf(note);
        if (index < notes.Count)
        {
            for (int i = index; i < notes.Count; i++)
            {
                Vector2 newPosition = notes[i].transform.position;
                newPosition.y += buttonOffset.y;
                notes[i].transform.position = newPosition;
            }
        }
    }

}
