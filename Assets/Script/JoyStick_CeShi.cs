using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick_CeShi : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    /// <summary>
    /// 最大距离
    /// </summary>
    public float MaxDis = 128f;

    /// <summary>
    /// 初始坐标
    /// </summary>
    private Vector2 originalPos;

    /// <summary>
    /// 底板
    /// </summary>
    public GameObject BG;

    /// <summary>
    /// 控制的物体
    /// </summary>
    public Transform m_Ctrl;

    /// <summary>
    /// 当前半径
    /// </summary>
    private float radius;

    void Start()
    {
        originalPos = transform.position;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        BG.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - originalPos;

        float distance = Vector3.Magnitude(dir);

        radius = Mathf.Clamp(distance,0,MaxDis);

        transform.position = dir.normalized * radius + originalPos;

        Vector3 ctrlDir = new Vector3(dir.x,0,dir.y);

        Debug.DrawLine(Vector3.zero,ctrlDir,Color.red);

        m_Ctrl.rotation = Quaternion.Lerp(m_Ctrl.rotation,Quaternion.LookRotation(ctrlDir),Time.deltaTime * 10f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = originalPos;
        BG.gameObject.SetActive(false); 
    }
}
