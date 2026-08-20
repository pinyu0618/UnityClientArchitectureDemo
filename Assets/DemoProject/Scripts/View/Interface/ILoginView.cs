
public interface ILoginView : IViewBasic
{
    public string GetInputAccount { get; }
    public string GetInputPassword { get; }

    public void Set(IMainToolbar _IMainToolbar);
    public void SetButtonAction(DCallback _dRunLogin);
    public void SetLoginMemory(string _sAccountMemory, string _sPasswordMemory);
    public void ShowLoginError();
}
