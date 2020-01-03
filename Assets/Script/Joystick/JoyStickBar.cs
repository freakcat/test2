using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickBar : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {

    /// <summary>
    /// 角色控制器
    /// </summary>
    public RoleCtrl m_ctrl;

    /// <summary>
    /// 最大半径
    /// </summary>
    public float maxRadius;

    /// <summary>
    /// 计算中的半径
    /// </summary>
    public float radius;

    /// <summary>
    /// 原始位置
    /// </summary>
    private Vector2 originalPos;

    /// <summary>
    /// 遥杆中心位置
    /// </summary>
    public RectTransform joystickradius;

    /// <summary>
    /// 箭头指针方向
    /// </summary>
    public Transform joystickpointer;

    #region 方向控制访问器

    /// <summary>
    /// 水平方向
    /// </summary>
    private float horizontal = 0;

    /// <summary>
    /// 垂直方向
    /// </summary>
    private float vertical = 0;

    /// <summary>
    /// 水平方向属性访问器
    /// </summary>
    public float Horizontal
    {
        get { return horizontal; }
    }

    /// <summary>
    /// 垂直方向属性访问器
    /// </summary>
    public float Vertical
    {
        get { return vertical; }
    }
    
    #endregion

    private void Start()
    {
        if (!joystickradius) return;
        originalPos = transform.position;
        maxRadius = - joystickradius.anchoredPosition.x;
//        Debug.LogError(maxRadius);
        ShowPointer(false);
    }

    #region 方向受力

    /// <summary>
    /// 各个方向上的受力
    /// </summary>
    private void DirPotency()
    {
        //horizontal = transform.localPosition.x;
        //vertical = transform.localPosition.y;
        horizontal = GetComponent<RectTransform>().anchoredPosition.x;
        vertical = GetComponent<RectTransform>().anchoredPosition.y;
    }

    #endregion

    #region 继承接口事件逻辑处理

    /// <summary>
    /// 开始拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        ShowPointer(true);
    }

    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
        //偏移量
        Vector2 dir = eventData.position - originalPos;
        //Vector2 dir = new Vector2 (Input.mousePosition.x, Input.mousePosition.y) - originalPos;

        //获取向量长度
        float distance = Vector3.Magnitude(dir);

        //获取当前
        radius = Mathf.Clamp(distance,0,maxRadius);

        //状态切换
        m_ctrl.m_fsm.ChangeState(RoleState.Run);

        //位置赋值
        transform.position = dir.normalized * radius + originalPos;

        //方向受力度量
        DirPotency();

        //角度转换
        CalculateAngle(dir.normalized);

    }

    /// <summary>
    /// 结束拖拽
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPos;

        //当前半径
        radius = 0;

        //方向受力度量
        DirPotency();

        ShowPointer(false);

        //m_ctrl.m_fsm.ChangeState(RoleState.Idle);

        m_ctrl.m_fsm.ChangeState(RoleState.RunToIdle);
    }

    #endregion

    #region 指针逻辑
    
    /// <summary>
    /// 角度转换
    /// </summary>
    public void CalculateAngle(Vector2 dir)
    {
        if (!joystickpointer) return;
        float angle = Vector2.Angle(Vector2.up,dir);
        joystickpointer.rotation = Quaternion.Euler(new Vector3(0, 0, -(dir.x>0?angle:-angle)));
    }

    /// <summary>
    /// 显示隐藏指针
    /// </summary>
    /// <param name="isshow"></param>
    public void ShowPointer(bool isshow)
    {
        joystickpointer.gameObject.SetActive(isshow);
    }

    #endregion

}
