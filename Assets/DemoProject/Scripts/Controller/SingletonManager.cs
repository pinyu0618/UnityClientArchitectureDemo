public class SingletonManager
{
    private static SingletonManager m_Instance;
    public static SingletonManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new SingletonManager();
            }
            return m_Instance;
        }
    }

    public ScenesManager ScenesMInstance { get; private set; }
    public UpdateManager UpdateMInstance { get; private set; }
    public MainToolbarManager MainToolbarMInstance { get; private set; }
    public DataManager DataMInstance { get; private set; }

    public void SetMain(SMain _MainStruct)
    {
        UpdateMInstance = _MainStruct.g_UpdateManager;
        MainToolbarMInstance = _MainStruct.g_MainToolbarManager;

        DataMInstance = new DataManager();

        ScenesMInstance.Set(MainToolbarMInstance.Set);
    }

    public void CloseMain()
    {
        
    }

    private SingletonManager()
    {
        ScenesMInstance = new ScenesManager();
    }
     
}