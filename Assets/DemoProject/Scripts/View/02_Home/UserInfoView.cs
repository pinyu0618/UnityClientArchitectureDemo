using UnityEngine;
using UnityEngine.UI;

public class UserInfoView : ButtonViewBasic, IUserInfoView
{
    [SerializeField] private RectTransform m_rtUserInfoPanel;
    [SerializeField] private Button m_btnClose;
    [SerializeField] private Button m_btnLogout;
    [SerializeField] private Text m_txtInfo;

    private const float USER_PANEL_PANEL_HEIGHT_SCALE = 0.45f;

    private string m_sInfoFormat => "Åwªï {0}";

    private bool m_bInit = false;

    private DCallback m_dLogoutCallback = null;

    public void Set()
    {
        Init();
    }

    public void SetButtonAction(DCallback _dLogoutCallback)
    {
        m_dLogoutCallback = _dLogoutCallback;
    }

    public void Show(string _sUserName)
    {
        SetInfo(_sUserName);
        Show();
    }

    protected override void SetButton()
    {
        AddListener(m_btnClose, ShowOff);
        AddListener(m_btnLogout, Logout);
    }

    private void Init()
    {
        if (!m_bInit)
        {
            SetPanelHeight(m_rtUserInfoPanel, USER_PANEL_PANEL_HEIGHT_SCALE);
            m_bInit = true;
        }
    }

    private void SetInfo(string _sUserName)
    {
        string sDisplayName = _sUserName;

        string sInfo = string.Format(m_sInfoFormat, sDisplayName);
        m_txtInfo.text = sInfo;
    }

    private void Logout()
    {
        m_dLogoutCallback?.Invoke();
    }
}
