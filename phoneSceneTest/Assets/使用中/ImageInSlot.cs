using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(200)]
public class ImageInSlot : MonoBehaviour
{
    [SerializeField, Header("卡片")]
    private Image[] imgCard; // 圖片列表
       
    private void Awake()
    {
        randomcard.instance.GetCardIsGetInformation(); // 确保数据已准备好

        Show();
    }

    private void Show()
    {
        for(int i = 0; i < imgCard.Length; i++)
        {
            bool isGet = randomcard.instance.picturestate[i];
            imgCard[i].sprite = isGet ? randomcard.instance.picture[i] : null;
        }
    }
}