using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Scrollbar bar;
    public float x;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.localPosition = new Vector3(-(bar.value - x) * 500, 0, 0);
        float scale = 1 - Mathf.Abs(bar.value - x) * 0.5f;
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
