using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(100)]
public class randomcard : MonoBehaviour
{
    public static randomcard instance;

    [SerializeField, Header("所有日記")]
    public Sprite[] picture; //sprite是因為圖片類型

    [SerializeField, Header("是否拿到日記")]
    public bool[] picturestate; //state是狀態的意思

    private Image imgpicture; //Canvas顯示sprite可使用image


    private void Awake()
    {
        instance = this;

        GetCardIsGetInformation();

        imgpicture = GameObject.Find("圖片").GetComponent<Image>();

        GetRandompicture();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < picturestate.Length; i++)
            {
                PlayerPrefs.SetString("圖片" + i, "未拿到");
            }

            GetCardIsGetInformation(); //也要確認都有再刪"是否"紀錄
        }
    }

    //自訂義外面按??可以確認
    [ContextMenu("確認所有卡片已獲得")]
    public void GetCardIsGetInformation()
    {
        //picture 陣列相對應的 bool 陣列，
        //new是因為前面的宣告是沒有分配到記憶體空間，單純是宣告(?)
        picturestate = new bool[picture.Length];

        //設定初始值(從0開始)、判斷式(0~9)、行為(+1)
        //用來檢查是否有打勾的紀錄的迴圈，避免重複取得
        //("圖片" + i)是字串鍵，在(後面的設定)後設定成已拿到的在這裡如果偵測到已拿到
        //就會是true，否則false
        for (int i = 0; i < picturestate.Length; i++)
        {
            picturestate[i] = PlayerPrefs.GetString("圖片" + i) == "已拿到";
        }
    }

    private void GetRandompicture()
    {
        //挑最小值到最大值中 隨機一個整數(變數名稱indexRandom)
        int indexRandom = Random.Range(0, picture.Length);
        //where用來篩選資料，找出還沒被打勾的有哪些
        var pictureStateFalse = picturestate.Where(x => x == false);
        //全true的話系統文字顯示"全部拿過了"
        if (pictureStateFalse.Count() == 0)
        {
            print("全部拿過了");
            return; //對下方行為結束迴圈的提前告知
        }

        //用while迴圈確認這個拿到的變數是不是已經拿過
        while (PlayerPrefs.GetString("圖片" + indexRandom) == "已拿到")
        {
            indexRandom = Random.Range(0, picture.Length);
        }

        imgpicture.sprite = picture[indexRandom];
        imgpicture.color = Color.white;

        PlayerPrefs.SetString("圖片" + indexRandom, "已拿到");//設定圖片已拿
    }


}
