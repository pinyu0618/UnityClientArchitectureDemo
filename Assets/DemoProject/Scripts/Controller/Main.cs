using UnityEngine;
public class Main : MonoBehaviour
{
    [SerializeField] private SMain m_MainStruct;
    private SingletonManager Singleton => SingletonManager.Instance;
    private ScenesManager ScenesM => Singleton.ScenesMInstance;

    private void Start()
    {
        InitSingleton();
        InitMainToolbar();
        LoadNextScene();
    }

    private void InitSingleton()
    {
        Singleton.SetMain(m_MainStruct);
    }

    private void InitMainToolbar()
    {
        m_MainStruct.g_MainToolbarManager.Set(EScene.INIT);
    }

    private void LoadNextScene()
    {
        Rule.RESTART = false;
        ScenesM.LoadNextScene();
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDestroy()
    {
        Singleton.CloseMain();

#if (UNITY_EDITOR)
        Rule.RESTART = true;
#endif
    }
}
