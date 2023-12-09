using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class justStartScenToMaim : MonoBehaviour
{
    public Button enterMain;

    private void Awake()
    {
        enterMain = GameObject.Find("enterMain").GetComponent<Button>();
        enterMain.onClick.AddListener(EnterMain);
    }

    private void EnterMain()
    {
        SceneManager.LoadScene("Main");
    }
}
