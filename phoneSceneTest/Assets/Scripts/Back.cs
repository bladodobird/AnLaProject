using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    public Button backMain;

    private void Awake()
    {
        backMain = GameObject.Find("backbtn").GetComponent<Button>();

        backMain.onClick.AddListener(LoadPreviousScene);
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene("Main");
    }
}
