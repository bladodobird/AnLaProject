using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class toWhite : MonoBehaviour
{
    private Button btnEnter041;

    private void Awake()
    {
        btnEnter041 = GameObject.Find("Button041").GetComponent<Button>();
        btnEnter041.onClick.AddListener(EnterFuc041);
    }

    private void EnterFuc041()
    {
        SceneManager.LoadScene("Main");
    }
}
