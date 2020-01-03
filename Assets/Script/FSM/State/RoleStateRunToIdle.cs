
using UnityEngine;

public class RoleStateRunToIdle : RoleStateAbstract
{

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleFSMMgr">有限状态机管理器</param>
    public RoleStateRunToIdle(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        time = CurrRoleFSMMgr.CurrRoleCtrl.m_anim.GetFloat(RoleState.Run.ToString());
        CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetFloat(RoleState.Run.ToString(), time);
    }

    float time;

    float speed = 0;

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnStay()
    {
        base.OnStay();
        if (time >= 0)
        {
            time -= Time.deltaTime;
            speed = 3 * time;
            CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetFloat(RoleState.Run.ToString(), time);
        }

        CurrRoleFSMMgr.CurrRoleCtrl.m_char.Move(CurrRoleFSMMgr.CurrRoleCtrl.transform.forward * Time.deltaTime * speed);
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        //CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetFloat(RoleState.Run.ToString(), 0f);
    }
}
