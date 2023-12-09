using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThirdPage : MonoBehaviour
{
    public GameObject scene3Objects; // 第3個場景的物件
    public GameObject scene4Objects; // 第4個場景的物件

    public TMP_Text textA;
    public TMP_Text textB;
    public TMP_Text textC;

    // 用來儲存文字和輸入的內容的變數
    private string contentA;
    private string contentB;
    private string contentC;

    // 方法用來設定文字和輸入的內容
    public void SetData(string textAContent, string inputAContent, string inputBContent)
    {
        contentA = textAContent;
        contentB = inputAContent;
        contentC = inputBContent;

        // 更新顯示文字
        textA.text = contentA;
        textB.text = contentB;
        textC.text = contentC;
    }

    public void SwitchToScene4()
    {
        scene3Objects.SetActive(false); // 隱藏第二個場景的物件
        scene4Objects.SetActive(true);  // 顯示第三個場景的物件
    }

    public void SwitchToScene3()
    {
        scene4Objects.SetActive(false); 
        scene3Objects.SetActive(true);  
    }
}
