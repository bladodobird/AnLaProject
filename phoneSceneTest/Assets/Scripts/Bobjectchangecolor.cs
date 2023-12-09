using UnityEngine;

public class Bobjectchangecolor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Color[] colors;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color currentColor = spriteRenderer.color;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("A"))
        {
            // 生成隨機顏色
            Color randomColor = new Color(Random.value, Random.value, Random.value);

            // 設定 B 物件的顏色
            spriteRenderer.color = randomColor;
        }
    }
}