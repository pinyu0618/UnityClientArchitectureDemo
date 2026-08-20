
public static class JsonFactory
{
    public static Type Clone<Type>(Type _Class)
    {
        string sJson = GetJson(_Class);
        return GetClass<Type>(sJson);
    }

    public static Type GetClass<Type>(string _sJson)
    {
        return Newtonsoft.Json.JsonConvert.DeserializeObject<Type>(_sJson);
    }

    public static string GetJson<Type>(Type _Class)
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(_Class);
    }

}
