using System.Threading.Tasks;

public class DataManager : IDataLogin, IDataHome
{
    private string m_sTestAccount = "test_account";
    private string m_sTestPassword = "test_password";

    public SLoginData LoadLoginData()
    {
        return new()
        { 
            g_sAccountMemory = m_sTestAccount,
            g_sPasswordMemory = m_sTestPassword
        };
    }

    public SHomeData LoadHomeData()
    {
        return new()
        {
            g_sUserName = "test_user"
        };
    }

    public async Task<bool> LoginAccountAsync(string _sAccount, string _sPassword)
    {
        bool bResult = (_sAccount == m_sTestAccount) &&¡@(_sPassword == m_sTestPassword);

        await Task.Delay(1500);
        return bResult;
    }

    public void LogoutAccount()
    {

    }
}
