using UnityEngine;
using UnityEngine.UI;

public class TimerAndChangeImage : MonoBehaviour
{
    public Image image; // 連結到你的顯示圖片的UI元素
    public Sprite[] images; // 放置你的四張圖片
    private int currentImageIndex = 0;
    private bool isPlaying = false;

    // 計時器
    private float timer = 0f;

    // 每張圖片的顯示時間（秒）
    private float[] imageDisplayTimes = { 4f, 2f, 6f, 4f };

    void Update()
    {
        if (isPlaying)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // 切換到下一張圖片
                currentImageIndex = (currentImageIndex + 1) % images.Length;
                image.sprite = images[currentImageIndex];

                // 設置下一張圖片的顯示時間
                timer = imageDisplayTimes[currentImageIndex];
            }
        }
    }

    public void OnButtonClick()
    {
        if (!isPlaying)
        {
            // 開始播放，從第一張待機圖片開始
            isPlaying = true;
            //currentImageIndex = 0;  // 初始化為 0，即第一張待機圖片
            image.sprite = images[currentImageIndex];
            timer = imageDisplayTimes[currentImageIndex];
        }
        else
        {
            // 暫停播放
            isPlaying = false;
        }
    }
}

