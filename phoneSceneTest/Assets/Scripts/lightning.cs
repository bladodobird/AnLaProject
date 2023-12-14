using UnityEngine;
using UnityEngine.UI;

public class lightning : MonoBehaviour
{
    private bool isToggled = false;
    private GameObject lightii;

    private void Awake()
    {
        lightii = GameObject.Find("lightButton");
        ToggleButton();
    }

    public void OnButtonClick()
    {
        isToggled = !isToggled;
        ToggleButton();
    }

    private void ToggleButton()
    {
        lightii.SetActive(isToggled);
        Debug.Log("lightButton active status: " + isToggled);
    }
}
