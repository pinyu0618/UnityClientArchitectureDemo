using System.Threading.Tasks;

public interface IDataLogin
{
    SLoginData LoadLoginData();
    Task<bool> LoginAccountAsync(string _sEmail, string _sPassword);
}
