using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite[] putsprites; //放置所有要顯示的圖片
    public float[] displayTimes; //每個圖片要顯示的時間
    public Image theimage; //遊戲畫面上顯示圖片的Image物件

    private int currentSpriteIndex = 0;
    bool isChanging = false;

    private void Awake()
    {
        
    }

    private void Start()
    {
        theimage = GameObject.Find("開始按鈕").GetComponent<Image>();
        StartCoroutine(SwitchImageCoroutine());
    }

    public void ToggleChange()
    {

        if (currentSpriteIndex == -1)
        {
            isChanging = !isChanging;
            currentSpriteIndex = 0;
        }

        theimage.sprite = putsprites[currentSpriteIndex];
    }

    private IEnumerator SwitchImageCoroutine()
    {
        while (true)
        {

            if (isChanging)
            {             
                currentSpriteIndex = (currentSpriteIndex + 1) % putsprites.Length;
                yield return new WaitForSeconds(displayTimes[currentSpriteIndex]);
                theimage.sprite = putsprites[currentSpriteIndex];
            }
            else
            {
                yield return null;
            }
        }
    }

}
