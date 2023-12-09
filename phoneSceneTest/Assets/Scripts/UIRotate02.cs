using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRotate02 : MonoBehaviour
{
    public Scrollbar bar;
    public GameObject[] itemlist;
    private float distance = 0;

    public int selectindex = 0;
    public int lastSelectindex = 0;
    private float time = 0;
    private float target = 0;

    private void Start()
    {
        Info();
    }

    public void Info()
    {
        distance = 1.0f / ((float)itemlist.Length - 1);
        for (int i = 0; i < itemlist.Length; i++)
        {
            itemlist[i].GetComponent<Item>().x = distance * i;
        }

        int value = (int)(bar.value / distance + 0.5f);
        for (int i = 0; i < itemlist.Length; i++)
        {
            if (i > value)
                itemlist[i].transform.SetSiblingIndex(itemlist.Length - 1 - i + value);
            else if (i< value)
                itemlist[i].transform.SetSiblingIndex(itemlist.Length - 1);
        }
    }

    public void PointUp()
    {
        int valse = (int)(bar.value / distance + 0.5f);

        selectindex = valse;
        target = distance * valse;
        itemlist[selectindex].transform.SetSiblingIndex(itemlist.Length - 1);

        time = 0;
        lastSelectindex = selectindex;
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            PointUp();
        }

        if (Input.GetMouseButton(0))
        {
            int value = (int)(bar.value / distance + 0.5f);

            for (int i = 0; i < itemlist.Length; i++)
            {
                if (i > value)
                    itemlist[i].transform.SetSiblingIndex(itemlist.Length - 1 - i + value);
                else if (i < value)
                    itemlist[i].transform.SetSiblingIndex(i);
                else if (i == value)
                    itemlist[i].transform.SetSiblingIndex(itemlist.Length - 1);
            }
            time += Time.deltaTime;
            return;
        }
        if (target != bar.value)
        {
            if (bar.value < target)
                bar.value += Time.deltaTime / 5;
            if (bar.value >= target)
                bar.value -= Time.deltaTime / 5;

            if (Mathf.Abs(bar.value - target) < 0.01f)
            {
                bar.value = target;
            }
        }
    }

    public GameObject Max;
    public Image max_image;

    public void PointClick()
    {
        if (time < 0.5f && selectindex == lastSelectindex)
        {
            Max.SetActive(true);
            Debug.Log("selectIndex" + selectindex);
            max_image.sprite = itemlist[selectindex].GetComponent<Image>().sprite;

        }
    }

    public void OnClick_MaxCloseCloseEvent()
    {
        Max.SetActive(false);
    }
}
