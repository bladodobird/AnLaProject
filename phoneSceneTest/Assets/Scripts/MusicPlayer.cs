using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public GameObject playBtm, pauseBtm; //播放,暫停
    public TextMeshProUGUI nowtime; //已撥放時長
    public TextMeshProUGUI alltime; //總時長
    public Slider progressSlider; //時間條

    private int CurrentMinute, CurrentSecond;
    private int ClipMinute, ClipSecond;

    public AudioSource audioSource;
    public static MusicPlayer instance;

    private void Start()
    {
        pauseBtm.SetActive(false);
        nowtime = GameObject.Find("nowtime").GetComponent<TextMeshProUGUI>();
        alltime = GameObject.Find("alltime").GetComponent<TextMeshProUGUI>();
        //audioSource.clip = Resources.Load<AudioClip>("YourMusicClipName"); ;
    }

    public void TogglePlayback()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            playBtm.SetActive(true);
            pauseBtm.SetActive(false);
        }
        else
        {
            audioSource.Play();
            playBtm.SetActive(false);
            pauseBtm.SetActive(true);

            // 如果音樂播放結束，將時間點重置並重新播放
            if (audioSource.time == audioSource.clip.length)
            {
                audioSource.time = 0;
                audioSource.Play();
            }
        }
    }

    private void Update()
    {
        UpdateCurrentTime();
        UpdateProgressSlider();
    }

    private void UpdateCurrentTime()
    {
        CurrentMinute = (int)audioSource.time / 60;
        CurrentSecond = (int)audioSource.time % 60;
        nowtime.text = string.Format("{0:00}:{1:00}", CurrentMinute, CurrentSecond);//還沒有研究原理
    }

    private void UpdateProgressSlider()
    {
        float progress = audioSource.time / audioSource.clip.length;
        progressSlider.value = progress;
    }

    public void OnSliderValueChanged(float value)
    {
        // 根據拖曳條的值來計算對應的時間點
        float targetTime = value * audioSource.clip.length;

        // 設置音樂撥放器的時間點
        audioSource.time = targetTime;
    }

    public void Musicloop()
    {
        if (audioSource.clip == null)
        {
            Debug.LogError("No music clip assigned.");
            return;
        }
        audioSource.loop = true;
    }
}
