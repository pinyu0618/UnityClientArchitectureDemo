
public interface IHomeView : IViewBasic
{
    public void Set(IMainToolbar _IMainToolbar);
    public void SetButtonAction(DCallback _dLoadUserInfo);
    public void SetUserName(string _sUserName);
}
