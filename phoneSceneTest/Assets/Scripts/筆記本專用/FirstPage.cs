using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FirstPage : MonoBehaviour
{
    public GameObject scene1Objects; // 第一個場景的物件
    public GameObject scene2Objects; // 第二個場景的物件

    public Button textbutton; // 那個按鈕

    public TextMeshProUGUI fillText; //那個要放字的文字物件

    public void Start()
    {
        textbutton = GetComponent<Button>();
    }

    public void SetText1()
    {
        fillText.text = "氣爛";
    }

    public void SetText2()
    {
        fillText.text = "超級EMO";
    }

    public void SetText3()
    {
        fillText.text = "今天做了件大事!";
    }

    public void SetText4()
    {
        fillText.text = "自行填入";
    }

    public void SwitchToScene2()
    {
        scene1Objects.SetActive(false); // 隱藏第一個場景的物件
        scene2Objects.SetActive(true);  // 顯示第二個場景的物件
    }


}
