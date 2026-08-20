using UnityEngine;

public class HomeController : SceneBasic
{
    [SerializeField] private HomeView m_HomeView;
    [SerializeField] private UserInfoView m_UserInfoView;

    private HomePresenter m_HomePresenter;
    private HomeModel m_HomeModel;

    private IMainToolbar IMainToolbar => Singleton.MainToolbarMInstance;
    private IDataHome IData => Singleton.DataMInstance;

    protected override void StartScene()
    {
        Set();
        m_HomeView.Show();
    }

    private void Set()
    {
        m_HomeView.Set(IMainToolbar);

        m_HomeModel = new HomeModel(IData);

        m_HomePresenter = new HomePresenter(m_HomeModel, m_HomeView, m_UserInfoView);
        m_HomePresenter.SetLoadScene(ScenesM.JumpLoginScene);

        m_HomePresenter.Set();
    }

    private void Logout()
    {
        IData.LogoutAccount();
        ScenesM.JumpLoginScene();
    }
}
