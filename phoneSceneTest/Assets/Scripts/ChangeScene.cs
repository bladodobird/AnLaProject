using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    private Button btnEnter01;
    private Button btnEnter02;
    private Button btnEnter03;

    private Button btnEnter05;
    private Button btnEnter06;

    private void Awake()
    {
        btnEnter01 = GameObject.Find("Button01").GetComponent<Button>();
        btnEnter02 = GameObject.Find("Button02").GetComponent<Button>();
        btnEnter03 = GameObject.Find("Button03").GetComponent<Button>();
        btnEnter06 = GameObject.Find("Button06").GetComponent<Button>();

        btnEnter01.onClick.AddListener(EnterFuc01);
        btnEnter02.onClick.AddListener(EnterFuc02);
        btnEnter03.onClick.AddListener(EnterFuc03);
        btnEnter06.onClick.AddListener(EnterFuc06);
    }

    private void EnterFuc01()
    {
        SceneManager.LoadScene("fuc01");
    }

    private void EnterFuc02()
    {
        SceneManager.LoadScene("fuc02");
    }

    private void EnterFuc03()
    {
        SceneManager.LoadScene("fuc03");
    }


    private void EnterFuc06()
    {
        SceneManager.LoadScene("fuc06");
    }
}
