using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public GameObject playBtm, pauseBtm; //����,�Ȱ�
    public TextMeshProUGUI nowtime; //�w����ɪ�
    public TextMeshProUGUI alltime; //�`�ɪ�
    public Slider progressSlider; //�ɶ���

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

            // �p�G���ּ��񵲧��A�N�ɶ��I���m�í��s����
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
        nowtime.text = string.Format("{0:00}:{1:00}", CurrentMinute, CurrentSecond);//�٨S����s��z
    }

    private void UpdateProgressSlider()
    {
        float progress = audioSource.time / audioSource.clip.length;
        progressSlider.value = progress;
    }

    public void OnSliderValueChanged(float value)
    {
        // �ھک즲�����Ȩӭp��������ɶ��I
        float targetTime = value * audioSource.clip.length;

        // �]�m���ּ��񾹪��ɶ��I
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
