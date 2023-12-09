using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThirdPage : MonoBehaviour
{
    public GameObject scene3Objects; // ��3�ӳ���������
    public GameObject scene4Objects; // ��4�ӳ���������

    public TMP_Text textA;
    public TMP_Text textB;
    public TMP_Text textC;

    // �Ψ��x�s��r�M��J�����e���ܼ�
    private string contentA;
    private string contentB;
    private string contentC;

    // ��k�Ψӳ]�w��r�M��J�����e
    public void SetData(string textAContent, string inputAContent, string inputBContent)
    {
        contentA = textAContent;
        contentB = inputAContent;
        contentC = inputBContent;

        // ��s��ܤ�r
        textA.text = contentA;
        textB.text = contentB;
        textC.text = contentC;
    }

    public void SwitchToScene4()
    {
        scene3Objects.SetActive(false); // ���òĤG�ӳ���������
        scene4Objects.SetActive(true);  // ��ܲĤT�ӳ���������
    }

    public void SwitchToScene3()
    {
        scene4Objects.SetActive(false); 
        scene3Objects.SetActive(true);  
    }
}
