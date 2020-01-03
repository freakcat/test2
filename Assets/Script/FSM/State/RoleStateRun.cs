using UnityEngine;

/// <summary>
/// 跑状态
/// </summary>
public class RoleStateRun : RoleStateAbstract
{

    /// <summary>
    /// 旋转速度
    /// </summary>
    public float m_rotateSpeed = 3f;

    /// <summary>
    /// 移动速度
    /// </summary>
    public float m_moveSpeed = 3f;

    /// <summary>
    /// 移动速度
    /// </summary>
    private float m_MoveRatio = 0f;

    /// <summary>
    /// 转身的目标方向
    /// </summary>
    private Quaternion m_TargetQuaternion;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleFSMMgr">有限状态机管理器</param>
    public RoleStateRun(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        time = CurrRoleFSMMgr.CurrRoleCtrl.m_anim.GetFloat(RoleState.Run.ToString());
    }

    /// <summary>
    /// 缓冲计时
    /// </summary>
    float time = 0;

    /// <summary>
    /// 缓冲速度
    /// </summary>
    float speed = 0;

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnStay()
    {
        base.OnStay();

        #region 移动方案一  根据方向按键拖动的距离来增加移动速度

        ////获取方向键拖动比例
        //float radius = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.radius;
        //float maxradius = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.maxRadius;
        //m_MoveRatio = radius / maxradius;

        //CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetFloat(RoleState.Run.ToString(), m_MoveRatio);

        //float hor = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.Horizontal;
        //float ver = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.Vertical;

        //Vector3 dir = new Vector3(hor, 0, ver);

        //if (dir != Vector3.zero)
        //{
        //    CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation = Quaternion.Lerp(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * m_rotateSpeed);
        //    CurrRoleFSMMgr.CurrRoleCtrl.m_char.Move(CurrRoleFSMMgr.CurrRoleCtrl.transform.forward * Time.deltaTime * m_moveSpeed * m_MoveRatio);
        //}

        #endregion

        #region 方案二  拖动按钮有加速度

        if (time <= 1)
        {
            time += Time.deltaTime;
            speed = m_moveSpeed * time;
            CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetFloat(RoleState.Run.ToString(), time);
        }

        float hor = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.Horizontal;
        float ver = CurrRoleFSMMgr.CurrRoleCtrl.m_Joy.Vertical;
        Vector3 dir = new Vector3(hor, 0, ver);

        if (dir != Vector3.zero)
        {
            CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation = Quaternion.Lerp(CurrRoleFSMMgr.CurrRoleCtrl.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * m_rotateSpeed);
            CurrRoleFSMMgr.CurrRoleCtrl.m_char.Move(CurrRoleFSMMgr.CurrRoleCtrl.transform.forward * Time.deltaTime * speed);
        }

        #endregion
        //CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.m_anim.GetCurrentAnimatorStateInfo(0);
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }
}