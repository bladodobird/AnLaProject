using UnityEngine;

public class PlaySoundsEffect : MonoBehaviour
{
    public AudioClip[] soundEffects;
    public AudioSource audioSource; // �K�[�o�@��

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>(); // ��l�� audioSource
        //soundEffects = new AudioClip[]
        //{
            //Resources.Load<AudioClip>("SoundEffect1"),
            //Resources.Load<AudioClip>("SoundEffect2"),
            // �[�J��L����
        //};
    }

    public void PlayRandomSoundEffect()
    {
        int randomIndex = UnityEngine.Random.Range(0, soundEffects.Length);
        audioSource.PlayOneShot(soundEffects[randomIndex]);
    }
}
