using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettextController : MonoBehaviour
{
    public TextMeshProUGUI user_tex;
    public TMP_InputField user_inputField;

    public void setText()
    {
        user_tex.text = user_inputField.text;


    }
}
