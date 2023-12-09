using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SecondPage : MonoBehaviour
{
    #region 畫面物件
    public GameObject scene1Objects; // 第一個場景的物件
    public GameObject scene2Objects; // 第二個場景的物件
    public GameObject scene3Objects; // 第三個場景的物件
    #endregion

    #region 文字物件
    public TMP_Text textA;//情緒文字(畫面2)
    public TMP_InputField inputA;//輸入時間(畫面2)
    public TMP_InputField inputB;//輸入文字(畫面2)
    public TMP_Text textB;//接收輸入的時間(畫面3)
    public TMP_Text textC;//接收2上的情緒文字(畫面4)
    public TMP_Text textD;//接收inputB顯示(畫面4)
    #endregion

    #region 預置物
    public GameObject recordPrefab; // 預置物
    public Transform notesContainer; // 紀錄紙的容器，用於存放生成的紀錄紙物件
    #endregion

    public Button finishButton; // 完成按鈕


    public void RecordTextA()
    {
        string textAContent = textA.text;
        textC.text = textAContent;
    }

    public void RecordInputA()
    {
        string inputAContent = inputA.text;
        textB.text = inputAContent;
    }

    public void RecordInputB()
    {
        string inputBContent = inputB.text;
        textD.text = inputBContent;
    }

    public void CreateRecordObject()
    {
        // 創建包含資料的預置物
        GameObject recordObject = Instantiate(recordPrefab, Vector3.zero, Quaternion.identity);
        // 取得 YourRecordScript 腳本的實例
        ThirdPage recordScript = recordObject.GetComponent<ThirdPage>();

    }

    // 監聽手機上的返回按鈕事件
    void Update()
    {
        // 按下手機上的返回按鈕
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scene1Objects.SetActive(true); // 隱藏第一個場景的物件
            scene2Objects.SetActive(false);  // 顯示第二個場景的物件
        }
    }

    public void SwitchToScene3()
    {
        scene2Objects.SetActive(false); // 隱藏第二個場景的物件
        scene3Objects.SetActive(true);  // 顯示第三個場景的物件
    }

}
