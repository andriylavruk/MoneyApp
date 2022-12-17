namespace MoneyApp.Client.Static;

public class APIEndpoints
{
#if DEBUG
    internal const string ServerBaseUrl = "https://localhost:7071";
#endif
    internal readonly static string s_register = $"{ServerBaseUrl}/api/user/register";
    internal readonly static string s_signIn = $"{ServerBaseUrl}/api/user/signin";
}
