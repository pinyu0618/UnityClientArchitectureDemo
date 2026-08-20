
public interface IUpdate
{
    public void RegisterTimer(UpdateTimer _dTimer);
    public void RegisterUpdate(DUpdate _dUpdate);
    public void RegisterFixedUpdate(DUpdate _dUpdate);
    public void UnRegisterTimer(UpdateTimer _dTimer);
    public void UnRegisterUpdate(DUpdate _dUpdate);
    public void UnRegisterFixedUpdate(DUpdate _dUpdate);
}
