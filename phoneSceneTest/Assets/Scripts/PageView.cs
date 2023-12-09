using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class PageView : ScrollRect
{
    public class OnObChangeEvent : UnityEvent<int>
    { }

    public int CurrentObjIndex = 0;
    private Tweener tweenerMove = null;

    /// <summary>
    /// 焦點物件改變的事件
    /// </summary>
    public OnObChangeEvent OnObjChance = new OnObChangeEvent();
    //Content上的Grid格狀元件
    private GridLayoutGroup grid = null;
    //玩家手放開選單最終停下X座標
    private float finalPosX = 0;

    protected override void Start()
    {
        base.Start();
        grid = content.GetComponent<GridLayoutGroup>();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        if (tweenerMove != null)
        {
            //tweenerMove.Kill();
            tweenerMove = null;
        }
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);

        int index = ProcessCurrentObjIndex();
        if (CurrentObjIndex != index)
        {
            CurrentObjIndex = index;
            OnObjChance.Invoke(CurrentObjIndex);
        }
    }



    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        float cellSizeX = grid.cellSize.x;
        CurrentObjIndex = ProcessCurrentObjIndex();
        finalPosX = cellSizeX / 2 + CurrentObjIndex * cellSizeX;

        //content.localPosition = new Vector2(-finalPosX, content.localPosition.y);
        tweenerMove = content.DOLocalMoveX(-finalPosX, 0.3f);
    }

    /// <summary>
    /// 計算可是區域物件index
    /// </summary>
    /// <returns></returns>
    private int ProcessCurrentObjIndex()
    {
        int contentChildCount = content.childCount;

        float contentEndPosX = content.localPosition.x;
        float cellSizeX = cellSizeX = grid.cellSize.x;

        int resultIndex = Mathf.Abs((int)((contentEndPosX) / (cellSizeX)));

        if (resultIndex < 0) resultIndex = 0;
        if (resultIndex > contentChildCount - 1) resultIndex = contentChildCount - 1;

        return resultIndex;
    }


}
