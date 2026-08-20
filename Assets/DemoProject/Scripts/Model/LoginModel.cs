
using System.Threading.Tasks;

public class LoginModel
{
    private IDataLogin m_IData;

    private SLoginData m_SLoginData;

    public string GetAccountMemory => m_SLoginData.g_sAccountMemory;
    public string GetPasswordMemory => m_SLoginData.g_sPasswordMemory;

    public LoginModel(IDataLogin _IData)
    {
        m_IData = _IData;

        m_SLoginData = m_IData.LoadLoginData();
    }

    public async Task<bool> LoginAccountAsync(string _sAccount, string _sPassword)
    {
        return await m_IData.LoginAccountAsync(_sAccount, _sPassword);
    }
}
