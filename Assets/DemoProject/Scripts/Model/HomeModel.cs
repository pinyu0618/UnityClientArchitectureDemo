
public class HomeModel
{
    private IDataHome m_IData;

    private SHomeData m_SHomeData;

    public string GetUserName => m_SHomeData.g_sUserName;

    public HomeModel(IDataHome _IData)
    {
        m_IData = _IData;

        m_SHomeData = m_IData.LoadHomeData();
    }

    public void LogoutAccount()
    {
        m_IData.LogoutAccount();
    }
}
