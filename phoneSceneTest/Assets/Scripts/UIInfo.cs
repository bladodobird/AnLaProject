using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemInfo
{
    public string title; //標題
    public string content; //內容
}

public class UIInfo : MonoBehaviour
{
    public ItemInfo[] allInfos; //
    public float gasp; //間隙
    public float reduceSize; //滑動時圖片縮放大小
    public RectTransform prefab; //每一個預置物
    public Transform prefabParent; //
    private List<Transform> allItemPrefab = new List<Transform>(); //
    public Dictionary<int, List<Vector3>> leftPos = new Dictionary<int, List<Vector3>>(); //
    public Dictionary<int, List<Vector3>> rightPos = new Dictionary<int, List<Vector3>>();
    public Button EnterGame;
    private int currentItem; //current是當前的意思但放這我不知道沙小東西
    public int CurrentItem  //
    {
        get => currentItem; //=>移至，但實際上他做了什麼我不清楚
        set
        {
            currentItem = value; //
        }
    }
    void Start()
    {
        InitScreen(); //init初始化
        EnterGame.onClick.AddListener(() =>
            {
                Debug.Log("當前進入的圖片內容:" + allInfos[CurrentItem].title); //
            });
    }
    
    /// <summary>
    /// 往左滑動，
    /// </summary>
    public void Left()
    {
        if (CurrentItem < allInfos.Length-1)
        {
            CurrentItem += 1;
            Slide();
        }
    }
    /// <summary>
    /// 往右滑動，
    /// </summary>>
    public void Right()
    {
        if (CurrentItem > 0)
        {
            CurrentItem -= 1;
            Slide();
        }
    }
    /// <summary>
    /// 滑動過程
    /// </summary>>
    void Slide()
    {
        for (int i = 0; i < allItemPrefab.Count ; i++)
        {
            if (i - CurrentItem <0)
            {
                allItemPrefab[i].DOMove(leftPos[Mathf.Abs(CurrentItem - i)][0], 0.5f);
                allItemPrefab[i].DOScale(leftPos[Mathf.Abs(CurrentItem - i)][1], 0.5f); //
            }
            else 
            {
                allItemPrefab[i].DOMove(rightPos[i - CurrentItem][0], 0.5f);
                allItemPrefab[i].DOScale(rightPos[i - CurrentItem][1], 0.5f);
            }
        }
    }
    /// <summary>
    /// 初始化生成介面元素
    /// </summary>>
    void InitScreen()
    {
        for (int i = 0; i < allInfos.Length; i++)
        {
            //生成UI介面
            RectTransform tempCreat = Instantiate(prefab, prefabParent);
            //UI設正中心位置
            tempCreat.anchorMax = Vector2.one / 2;
            tempCreat.anchorMin = Vector2.one / 2;
            //讓UI逐漸變小
            tempCreat.localScale = Vector3.one * (1 - (i * reduceSize));
            //改變UI生成位置????
            tempCreat.anchoredPosition = new Vector2(i * (prefab.sizeDelta.x + gasp - ((i * reduceSize)) * tempCreat.sizeDelta.x / 2), 0);
            //右邊把所有的UI位置記下來
            rightPos.Add(i, new List<Vector3>() { tempCreat.transform.position, tempCreat.localScale });
            //記錄所有生成的UI元素以便後面需要紀錄左邊UI位置
            allItemPrefab.Add(tempCreat); //????

            //教學說可依需求忽略
            tempCreat.Find("title").GetComponent<Text>().text = allInfos[i].title;
            tempCreat.Find("Content").GetComponent<Text>().text = allInfos[i].content;
        }
        //紀錄所有元素移動到左邊後的位置訊息
        for (int i = 0; i < rightPos.Count; i++)
        {
            leftPos.Add(i, new List<Vector3>() { allItemPrefab[0].position - (allItemPrefab[i].position - allItemPrefab[0].position), rightPos[i][1] });
        }
    }
        
}


