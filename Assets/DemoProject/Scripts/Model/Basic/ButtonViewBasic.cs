using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ButtonViewBasic : ViewBasic
{
    public override void Show()
    {
        SetButton();
        base.Show();
    }

    public override void ShowOff()
    {
        base.ShowOff();
    }

    protected abstract void SetButton();

    protected void AddListener(Button _btn, UnityAction _action)
    {
        _btn.onClick.AddListener(_action);
    }

    protected void RemoveListener(Button _btn)
    {
        _btn.onClick.RemoveAllListeners();
    }
}
