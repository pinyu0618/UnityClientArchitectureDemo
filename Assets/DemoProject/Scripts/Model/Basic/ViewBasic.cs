using UnityEngine;

public class ViewBasic : MonoBehaviour
{
    protected void SetPanelHeight(RectTransform _rtPanel, float _fHeightScale)
    {
        float fPanelSizeX = _rtPanel.sizeDelta.x;
        float fPanelSizeY = Screen.height * _fHeightScale;
        _rtPanel.sizeDelta = new Vector2(fPanelSizeX, fPanelSizeY);
    }

    protected void SetPanelSize(RectTransform _rtPanel, float _fWidthScale, float _fHeightScale)
    {
        float fPanelSizeX = Screen.width * _fWidthScale;
        float fPanelSizeY = Screen.height * _fHeightScale;
        _rtPanel.sizeDelta = new Vector2(fPanelSizeX, fPanelSizeY);
    }

    public virtual void Show()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void ShowOff()
    {
        this .gameObject.SetActive(false);
    }

    public void ShowObj(GameObject _obj)
    {
        _obj.SetActive(true);
    }

    public void ShowObj(Component _cp)
    {
        _cp.gameObject.SetActive(true);
    }

    public void ShowObjOff(GameObject _obj)
    {
        _obj.SetActive(false);
    }

    public void ShowObjOff(Component _cp)
    {
        _cp.gameObject.SetActive(false);
    }
}
