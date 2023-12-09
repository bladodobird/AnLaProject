using System.Collections;
using TMPro;
using UnityEngine;

public class Clicko : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 放文字物件
    private float timer; // 開始秒數

    private bool isTimerRunning = false;

    void Start()
    {
        timerText = GameObject.Find("計時器").GetComponent<TextMeshProUGUI>();
        timer = 0f; // 設定計時器開始秒數為 0

        isTimerRunning = false;

        StartCoroutine(TimerCoroutine());
    }

    private void ToggleTimer()
    {
        isTimerRunning = !isTimerRunning;
    }


    IEnumerator TimerCoroutine()
    {
        while (true)
        {
            if (isTimerRunning)
            {

                timer += Time.deltaTime;

                // 將計時器數據轉換為 "mm:ss" 格式
                int minutes = Mathf.FloorToInt(timer / 60f);
                int seconds = Mathf.FloorToInt(timer % 60f);
                string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);

                // 更新 Text 物件的內容
                timerText.text = timeText;
            }
            yield return null;
        }
    }

    // 在 Unity 中將此方法與On Click關聯
    public void OnClickToggleButton()
    {
        ToggleTimer();
    }
}
