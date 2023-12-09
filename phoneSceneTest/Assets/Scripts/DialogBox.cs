using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{
    #region 對話框內容本體的設定
    public Image box;
    public TextMeshProUGUI textObject;
    public List<string> dialogues;

    public List<Sprite> characterSprites;
    public List<string> characterSpriteNames;
    private SpriteRenderer characterImage; //要使用到image裡的sprite

    private int currentIndex = -1;
    //private int currentIndex = 0;       // 目前顯示的文字內容索引
    #endregion



    private void Start()
    {
        #region 對話框本體設定
        box = GameObject.Find("對話框").GetComponent<Image>();
        textObject = GameObject.Find("內容").GetComponent<TextMeshProUGUI>();

        int randomIndex = Random.Range(0, dialogues.Count);
        textObject.text = dialogues[randomIndex];  // 顯示第一個文字內容

        // 獲取角色的Image組件
        characterImage = GameObject.Find("CharImage").GetComponent<SpriteRenderer>();

        // 根據第一個文字內容來顯示對應的表情圖片
        SetCharacterImage(randomIndex);
        #endregion

    }

    public void SwitchDialogue()
    {
        #region 對話框本體設定
        //currentIndex++;      // 切換到下一個文字內容
        //if (currentIndex >= dialogues.Count) currentIndex = 0;  // 超過最後一個文字內容時回到第一個
        //textObject.text = dialogues[currentIndex];  // 顯示目前文字內容

        int index = Random.Range(0, dialogues.Count);
        while (index == currentIndex)  // 確保新的 index 不等於目前的 index
        {
            index = Random.Range(0, dialogues.Count);
        }
        currentIndex = index;
        textObject.text = dialogues[index];

        // 根據新的文字內容來顯示對應的表情圖片
        SetCharacterImage(index);
        #endregion
    }

    public void SetCharacterImage(int index)
    {
        #region 對話框本體設定
        string spriteName = characterSpriteNames[index];
        Sprite sprite = characterSprites.Find(s => s.name == spriteName);
        characterImage.sprite = sprite;

        Debug.Log(sprite);
        #endregion
    }
}

