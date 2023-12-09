using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteTb : MonoBehaviour
{
    public GameObject notebookItem; // 要連接到的記事本物件

    public void ShowNoteContent(GameObject note)
    {
        // 顯示筆記物件
        note.SetActive(true);
    }

}
