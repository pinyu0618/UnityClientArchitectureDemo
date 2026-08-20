using UnityEngine;
using UnityEngine.UI;

public class MainToolbarView : ButtonViewBasic
{
    [SerializeField] private Button m_btnBack;
    [SerializeField] private Button m_btnQuit;

    private DCallback m_dBackButtonCallback;

    public void Set(EScene _eScene)
    {
        SetSceneButton(_eScene);
    }

    public void SetBackButton(DCallback _dCallback)
    {
        m_dBackButtonCallback = _dCallback;
        ShowObj(m_btnBack);
    }

    public void HideBackButton()
    {
        ShowObjOff(m_btnBack);
    }

    public void QuitApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    protected override void SetButton()
    {
        AddListener(m_btnBack, ClickBack);
        AddListener(m_btnQuit, QuitApp);
    }

    private void SetSceneButton(EScene _eScene)
    {
        switch (_eScene)
        {
            case EScene.LOGIN:
            case EScene.HOME:
                ShowObj(m_btnQuit);
                break;

            default:
                ShowObj(m_btnQuit);
                break;
        }

        HideBackButton();
    }

    private void ClickBack()
    {
        if (m_dBackButtonCallback != null)
        {
            m_dBackButtonCallback.Invoke();
            ShowObjOff(m_btnBack);
        }
    }
}
