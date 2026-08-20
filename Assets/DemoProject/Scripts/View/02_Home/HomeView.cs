using UnityEngine;
using UnityEngine.UI;

public class HomeView : ButtonViewBasic, IHomeView
{
    [SerializeField] private Button m_btnUserInfo;
    [SerializeField] private Text m_txtUserName;

    private IMainToolbar m_IMainToolbar;

    private DCallback m_dLoadUserInfo = null;
    
    public void Set(IMainToolbar _IMainToolbar)
    {
        m_IMainToolbar = _IMainToolbar;
    }

    public void SetButtonAction(DCallback _dLoadUserInfo)
    {
        m_dLoadUserInfo = _dLoadUserInfo;
    }

    public void SetUserName(string _sUserName)
    {
        m_txtUserName.text = _sUserName;
    }

    protected override void SetButton()
    {
        AddListener(m_btnUserInfo, m_dLoadUserInfo.Invoke);
    }
}
