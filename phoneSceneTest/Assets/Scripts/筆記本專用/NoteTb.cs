using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteTb : MonoBehaviour
{
    public GameObject notebookItem; // �n�s���쪺�O�ƥ�����

    public void ShowNoteContent(GameObject note)
    {
        // ��ܵ��O����
        note.SetActive(true);
    }

}
