using System;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : ButtonViewBasic, ILoginView
{
    [SerializeField] private InputField m_inputAccount;
    [SerializeField] private InputField m_inputPassword;
    [SerializeField] private Button m_btnLogin;

    private IMainToolbar m_IMainToolbar;

    private DCallback m_dRunLogin = null;

    private string m_sLoginErrorText => "登入失敗";

    public string GetInputAccount => m_inputAccount.text;
    public string GetInputPassword => m_inputPassword.text;

    public void Set(IMainToolbar _IMainToolbar)
    {
        m_IMainToolbar = _IMainToolbar;
    }

    public void SetButtonAction(DCallback _dRunLogin)
    {
        m_dRunLogin = _dRunLogin;
    }

    public void SetLoginMemory(string _sAccountMemory, string _sPasswordMemory)
    {
        m_inputAccount.text = _sAccountMemory;
        m_inputPassword.text = _sPasswordMemory;
    }

    public void ShowLoginError()
    {
        m_IMainToolbar.PopUpInformation(m_sLoginErrorText);
    }

    protected override void SetButton()
    {
        AddListener(m_btnLogin, m_dRunLogin.Invoke);
    }
}
