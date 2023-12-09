using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class toBlack : MonoBehaviour
{
    private Button btnEnter04;

    private void Awake()
    {
        btnEnter04 = GameObject.Find("Button04").GetComponent<Button>();
        btnEnter04.onClick.AddListener(EnterFuc04);
    }

    private void EnterFuc04()
    {
        SceneManager.LoadScene("MainbBlack");
    }
}
