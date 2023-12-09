using UnityEngine;
using UnityEngine.UI;

public class TimerAndChangeImage : MonoBehaviour
{
    public Image image; // �s����A����ܹϤ���UI����
    public Sprite[] images; // ��m�A���|�i�Ϥ�
    private int currentImageIndex = 0;
    private bool isPlaying = false;

    // �p�ɾ�
    private float timer = 0f;

    // �C�i�Ϥ�����ܮɶ��]��^
    private float[] imageDisplayTimes = { 4f, 2f, 6f, 4f };

    void Update()
    {
        if (isPlaying)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // ������U�@�i�Ϥ�
                currentImageIndex = (currentImageIndex + 1) % images.Length;
                image.sprite = images[currentImageIndex];

                // �]�m�U�@�i�Ϥ�����ܮɶ�
                timer = imageDisplayTimes[currentImageIndex];
            }
        }
    }

    public void OnButtonClick()
    {
        if (!isPlaying)
        {
            // �}�l����A�q�Ĥ@�i�ݾ��Ϥ��}�l
            isPlaying = true;
            //currentImageIndex = 0;  // ��l�Ƭ� 0�A�Y�Ĥ@�i�ݾ��Ϥ�
            image.sprite = images[currentImageIndex];
            timer = imageDisplayTimes[currentImageIndex];
        }
        else
        {
            // �Ȱ�����
            isPlaying = false;
        }
    }
}

