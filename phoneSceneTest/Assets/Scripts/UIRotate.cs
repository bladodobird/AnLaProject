using DG.Tweening;
using UnityEngine;

public class UIRotate : MonoBehaviour
{
    private int halfSize;
    private GameObject[] gameObjects;
    /// <summary>
    /// 圓半徑
    /// </summary>
    public int r = 200;
    /// <summary>
    /// 相同角度
    /// </summary>
    private int angle;

    private void Start()
    {
        var childCount = transform.childCount;
        halfSize = (childCount - 1) / 2;
        angle = 360 / childCount;
        gameObjects = new GameObject[childCount];
        for (var i = 0; i < childCount; i++)
        {
            gameObjects[i] = transform.GetChild(i).gameObject;
            SetPosition(i);
            SetDeepin(i);
        }
    }

    /// <summary>
    /// 設置物件位置
    /// </summary>
    private void SetPosition(int index)
    {
        float x = 0;
        float z = 0;
        if (index < halfSize)
        {
            int id = halfSize - index;
            x = r * Mathf.Sin(angle * id);
            z = -r * Mathf.Cos(angle * id);
        }
        else if (index > halfSize)
        {
            int id = index - halfSize;
            x = -r * Mathf.Sin(angle * id);
            z = -r * Mathf.Cos(angle * id);
        }
        else
        {
            x = 0;
            z = -r;
        }
        Tweener tweener = gameObjects[index].GetComponent<RectTransform>().DOLocalMove(new Vector3(x, 0, z), 1);
    }

    private void SetDeepin(int index)
    {
        int deepin = 0;
        if (index < halfSize)
        {
            deepin = index;
        }
        else if (index > halfSize)
        {
            deepin = gameObjects.Length - (1 + index);
        }
        else
        {
            deepin = halfSize;
        }
        gameObjects[index].GetComponent<RectTransform>().SetSiblingIndex(deepin);
    }

    /// <summary>
    /// 向後翻頁
    /// </summary>
    public void OnNext()
    {
        var length = gameObjects.Length;
        for (var i = 0; i < length; i++)
        {
            var temp = gameObjects[i];
            gameObjects[i] = gameObjects[length - 1];
            gameObjects[length - 1] = temp;
        }
        for (var i = 0; i < length; i++)
        {
            SetPosition(i);
            SetDeepin(i);
        }
    }
}
