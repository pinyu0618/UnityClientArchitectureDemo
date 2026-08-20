using UnityEngine;

public class LoginController : SceneBasic
{
    [SerializeField] private LoginView m_LoginView;

    private LoginPresenter m_LoginPresenter;
    private LoginModel m_LoginModel;
    
    private IMainToolbar IMainToolbar => Singleton.MainToolbarMInstance;
    private IDataLogin IData => Singleton.DataMInstance;

    protected override void StartScene()
    {
        Set();
    }

    private void Set()
    {
        m_LoginView.Set(IMainToolbar);

        m_LoginModel = new LoginModel(IData);

        m_LoginPresenter = new LoginPresenter(m_LoginModel, m_LoginView);
        m_LoginPresenter.SetLoadScene(ScenesM.LoadNextScene);

        m_LoginPresenter.Set();
    }
}
