
public interface IUserInfoView : IViewBasic
{
    public void Show(string _sUserName);

    public void Set();
    public void SetButtonAction(DCallback _dLogoutCallback);
}
