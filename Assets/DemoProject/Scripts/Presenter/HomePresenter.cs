
public class HomePresenter
{
    private HomeModel m_HomeModel;
    private IHomeView m_HomeView;
    private IUserInfoView m_UserInfoView;

    private DCallback m_dJumpLoginScene;

    private bool m_bInit = false;

    public HomePresenter(HomeModel _HomeModel, IHomeView _HomeView, IUserInfoView _UserInfoView)
    {
        m_HomeModel = _HomeModel;
        m_HomeView = _HomeView;
        m_UserInfoView = _UserInfoView;
    }

    public void SetLoadScene(DCallback _dJumpLoginScene)
    {
        m_dJumpLoginScene = _dJumpLoginScene;
    }

    public void Set()
    {
        Init();
    }

    private void Init()
    {
        if (!m_bInit)
        {
            m_HomeView.SetUserName(m_HomeModel.GetUserName);
            m_HomeView.SetButtonAction(ShowUserInfoView);
            m_UserInfoView.SetButtonAction(Logout);

            m_HomeView.Show();

            m_bInit = true;
        }
    }

    private void ShowUserInfoView()
    {
        m_UserInfoView.Show(m_HomeModel.GetUserName);
    }

    private void Logout()
    {
        m_HomeModel.LogoutAccount();
        m_dJumpLoginScene.Invoke();
    }
}
