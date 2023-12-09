using UnityEngine;

public class PlaySoundsEffect : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioSource audioSource; // 添加這一行

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>(); // 初始化 audioSource
        //soundEffects = new AudioClip[]
        //{
            //Resources.Load<AudioClip>("SoundEffect1"),
            //Resources.Load<AudioClip>("SoundEffect2"),
            // 加入其他音效
        //};
    }

    public void PlayRandomSoundEffect()
    {
        int randomIndex = UnityEngine.Random.Range(0, soundEffects.Length);
        audioSource.PlayOneShot(soundEffects[randomIndex]);
    }
}
