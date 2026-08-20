
public interface IMainToolbar
{
    public void PopUpConfirm(string _sInfo, DConfirmCallback _dCallback);
    public void PopUpInformation(string _sInfo);
    public void SetBackButton(DCallback _dCallback);
    public void HideBackButton();
}
