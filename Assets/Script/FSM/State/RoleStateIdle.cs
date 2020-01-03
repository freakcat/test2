
/// <summary>
/// 待机状态
/// </summary>
public class RoleStateIdle : RoleStateAbstract
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="roleFSMMgr">有限状态机管理器</param>
    public RoleStateIdle(RoleFSMMgr roleFSMMgr) : base(roleFSMMgr)
    {

    }

    /// <summary>
    /// 实现基类 进入状态
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();
        CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetBool(RoleState.Idle.ToString(), true);
    }

    /// <summary>
    /// 实现基类 执行状态
    /// </summary>
    public override void OnStay()
    {
        base.OnStay();

        //CurrRoleAnimatorStateInfo = CurrRoleFSMMgr.CurrRoleCtrl.m_anim.GetCurrentAnimatorStateInfo(0);
    }

    /// <summary>
    /// 实现基类 离开状态
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
        CurrRoleFSMMgr.CurrRoleCtrl.m_anim.SetBool(RoleState.Idle.ToString(), false);
    }
}