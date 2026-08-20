using UnityEngine;

public abstract class SceneBasic : MonoBehaviour
{
    [SerializeField] private Canvas m_TargetCanvas;

    protected SingletonManager Singleton => SingletonManager.Instance;
    protected ScenesManager ScenesM => Singleton.ScenesMInstance;

    protected abstract void StartScene();

    private void Start()
    {
        Restart();
    }

    private void Restart()
    {
        if (Rule.RESTART)
        {
            ScenesM.Restart();
        }
        else
        {
            DeleteCamera();
            SetCanvas();
            StartScene();
        }
    }

    private void DeleteCamera()
    {
        Camera OriginCamera = m_TargetCanvas.worldCamera;
        if (OriginCamera != null)
        {
            GameObject CameraObj = OriginCamera.gameObject;
            if (CameraObj != null)
            {
                Destroy(CameraObj);
            }
        }
    }

    private void SetCanvas()
    {
        m_TargetCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        m_TargetCanvas.worldCamera = Camera.main;
    }
}