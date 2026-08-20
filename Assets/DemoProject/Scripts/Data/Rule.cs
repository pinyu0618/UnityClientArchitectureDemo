
public delegate void DCallback();

public delegate void DConfirmCallback(bool _bConfirm);
public delegate void DSceneCallback(EScene _eScene);

public enum EScene
{
    INIT = 0,
    LOGIN = 1,
    HOME = 2
}

public class Rule
{
#if (UNITY_EDITOR)
    public const bool TEST = true;
#else
    public const bool TEST = false;
#endif

#if (UNITY_EDITOR)
    public static bool RESTART = true;
#else
    public static bool RESTART = false;
#endif
}