using UnityEngine;
using UnityEngine.UI;


public class StartClick : MonoBehaviour
{
    //public Clicko bScript;
    //public ImageSwitcher cScript;
    //private bool isBehaviorActive = false;
    public Image buttonImage; // 需要切換的按鈕圖片
    public Sprite imageA; // 圖片 A
    public Sprite imageB; // 圖片 B


    public void ToggleButtonImage()
    {
        // 根據當前圖片切換至另一圖片
        buttonImage.sprite = (buttonImage.sprite == imageA) ? imageB : imageA;
    }

}

