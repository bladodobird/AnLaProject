using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBMButEaser : MonoBehaviour
{
    public GameObject noteButtonPrefab;  // ���O���s�w�s��
    public Transform buttonsParent;  // ���O���s��������

    public List<GameObject> noteButtons = new List<GameObject>();  // �s�x���O���s���C��
    public Vector2 buttonOffset = new Vector2(0f, -100f); // �C���ͦ����s����m�����q
    private Vector2 nextButtonPosition; // �U�@�ӫ��s����m

    void Start()
    {
        nextButtonPosition = buttonsParent.transform.position; // �]�w�U�@�ӫ��s����l��m
    }

    public void CreateNote()
    {
        // �b buttonsParent �U�ͦ��@�ӷs�����O���s����
        GameObject newNoteButton = Instantiate(noteButtonPrefab, nextButtonPosition, Quaternion.identity, buttonsParent);
        nextButtonPosition += buttonOffset; // �վ�U�@�ӫ��s����m

        // �N�s�ͦ������O���s����K�[�쵧�O���s�C��
        noteButtons.Add(newNoteButton);
    }

}
