using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    #region 改色
    public GameObject circle1;
    public GameObject frame;
    public GameObject background;
    private Color originalcircleColor;
    private Color originalFrameColor;
    private Color originalBackgroundColor;
    #endregion

    #region 換位
    public Transform circle;
    private Vector3 circleStartPosition;
    #endregion
    
    private bool isLightOn = true;


    private void Start()
    {
        circleStartPosition = circle.position;

        // 儲存初始的顏色
        originalcircleColor = circle1.GetComponent<Image>().color;
        originalFrameColor = frame.GetComponent<Image>().color;
        originalBackgroundColor = background.GetComponent<SpriteRenderer>().color;
    }

    public void ToggleLight()
    {
        isLightOn = !isLightOn;

        if (isLightOn)
        {
            // 開燈
            MoveCircle(circleStartPosition);
            ChangeColor(circle1, Color.black);
            ChangeColor(frame, Color.black);
            ChangeColor(background, Color.white);
        }
        else
        {
            // 關燈
            MoveCircle(circleStartPosition + new Vector3(0f, -125f, 0f));
            ChangeColor(circle1, Color.white);
            ChangeColor(frame, Color.white);
            ChangeColor(background, Color.black);
        }
    }

    private void MoveCircle(Vector3 targetPosition)
    {
        // 移動圓圈到目標位置
        circle.position = targetPosition;
    }

    private void ChangeColor(GameObject targetObject, Color targetColor)
    {
        // 變更目標物件的顏色
        if (targetObject.GetComponent<Image>() != null)
        {
            targetObject.GetComponent<Image>().color = targetColor;
        }
        else if (targetObject.GetComponent<SpriteRenderer>() != null)
        {
            targetObject.GetComponent<SpriteRenderer>().color = targetColor;
        }
    }
}


