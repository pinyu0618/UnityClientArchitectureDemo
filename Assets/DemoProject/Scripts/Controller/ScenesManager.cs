using UnityEngine.SceneManagement;

public class ScenesManager
{
    private DSceneCallback m_dSetToolbar;

    public void Set(DSceneCallback _dSetToolbar)
    {
        m_dSetToolbar = _dSetToolbar;
    }

    public void Restart()
    {
        SceneManager.LoadScene((int)EScene.INIT);
    }
    
    public void LoadNextScene()
    {
        int iCurrentIndex = GetCurrentSceneIndex();
        int iNextIndex = GetNextSceneIndex(iCurrentIndex);
        bool bSameScene = Equals(iCurrentIndex, iNextIndex);
        if (!bSameScene)
        {
            LoadScene((EScene)iNextIndex);
        }
    }

    public void JumpHomeScene()
    {
        LoadScene(EScene.HOME);
    }

    public void JumpLoginScene()
    {
        LoadScene(EScene.LOGIN);
    }

    private void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        UnityEngine.Application.Quit();
#endif
    }

    private int GetNextSceneIndex(int _iCurrentIndex)
    {
        int iTargetIndex = _iCurrentIndex;
        int iNextIndex = _iCurrentIndex + 1;
        int iMaxIndex = SceneManager.sceneCountInBuildSettings;
        if (iNextIndex < iMaxIndex)
        {
            iTargetIndex = iNextIndex;
        }
        return iTargetIndex;
    }

    private int GetCurrentSceneIndex()
    {
        Scene Scene = SceneManager.GetActiveScene();
        return Scene.buildIndex;
    }

    private void LoadScene(EScene _eScene)
    {
        if (m_dSetToolbar != null)
        {
            m_dSetToolbar.Invoke(_eScene);
        }
        SceneManager.LoadScene((int)_eScene);
    }
}