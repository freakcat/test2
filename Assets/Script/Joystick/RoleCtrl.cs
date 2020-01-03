using UnityEngine;

public class RoleCtrl : MonoBehaviour {

    /// <summary>
    /// 摇杆
    /// </summary>
    public JoyStickBar m_Joy;

    /// <summary>
    /// 当前人物触发器
    /// </summary>
    public CharacterController m_char;

    /// <summary>
    /// 动画状态机
    /// </summary>
    public RoleFSMMgr m_fsm;

    /// <summary>
    /// 动画控制器
    /// </summary>
    public Animator m_anim;

    private void Start()
    {
        m_Joy.m_ctrl = this;
        m_char = GetComponent<CharacterController>();
        m_anim = GetComponent<Animator>();
        m_fsm = new RoleFSMMgr(this);
        m_fsm.ChangeState(RoleState.Idle);
    }

    // Update is called once per frame
    void Update () {

        if (!m_char) return;

        if (!m_Joy) return;

        if (m_fsm == null) return;

        ///非落地情况 使其快速落地
        if (!m_char.isGrounded)
        {
            m_char.Move(new Vector3 (0,-100,0));
        }

        m_fsm.OnUpdate();

    }
}
