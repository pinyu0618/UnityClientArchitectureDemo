using UnityEngine;

public class MainToolbarManager : MonoBehaviour, IMainToolbar
{
    [SerializeField] private MainToolbarView m_MainToolbarView;
    [SerializeField] private PopUpView m_PopUpView;

    private bool m_bInit = false;

    public void PopUpConfirm(string _sInfo, DConfirmCallback _dCallback)
    {
        m_PopUpView.SetAndShow(EPopUpType.YES_OR_NO, _sInfo, _dCallback);
    }

    public void PopUpInformation(string _sInfo)
    {
        m_PopUpView.SetAndShow(EPopUpType.ONLY_YES, _sInfo);
    }

    public void Set(EScene _eScene)
    {
        m_MainToolbarView.Set(_eScene);
        Init();
    }

    public void SetBackButton(DCallback _dCallback)
    {
        m_MainToolbarView.SetBackButton(_dCallback);
    }

    public void HideBackButton()
    {
        m_MainToolbarView.HideBackButton();
    }

    public void QuitApp()
    {
        m_MainToolbarView.QuitApp();
    }

    private void Init()
    {
        if (!m_bInit)
        {
            m_MainToolbarView.Show();
            m_bInit = true;
        }
    }
}
