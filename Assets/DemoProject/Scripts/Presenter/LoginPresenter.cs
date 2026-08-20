
public class LoginPresenter
{
    private LoginModel m_LoginModel;
    private ILoginView m_LoginView;

    private DCallback m_dLoadNextScene;

    private bool m_bInit = false;

    public LoginPresenter(LoginModel _LoginModel, ILoginView _LoginView)
    {
        m_LoginModel = _LoginModel;
        m_LoginView = _LoginView;
    }

    public void SetLoadScene(DCallback _dLoadNextScene)
    {
        m_dLoadNextScene = _dLoadNextScene;
    }

    public void Set()
    {
        Init();

        m_LoginView.SetLoginMemory(m_LoginModel.GetAccountMemory, m_LoginModel.GetPasswordMemory);
    }

    private void Init()
    {
        if (!m_bInit)
        {
            m_LoginView.SetButtonAction(RunLogin);
            m_LoginView.Show();

            m_bInit = true;
        }
    }

    private async void RunLogin()
    {
        string sAccount = m_LoginView.GetInputAccount;
        string sPassword = m_LoginView.GetInputPassword;

        bool bResult = await m_LoginModel.LoginAccountAsync(sAccount, sPassword);
        if (bResult)
        {
            LoadNextScene();
        }
        else
        {
            m_LoginView.ShowLoginError();
        }
    }

    private void LoadNextScene()
    {
        if (m_dLoadNextScene != null)
        {
            m_dLoadNextScene.Invoke();
        }
    }
}
