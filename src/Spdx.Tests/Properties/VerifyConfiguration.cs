namespace Spdx.Tests;

public static class VerifyConfiguration
{
    [ModuleInitializer]
    public static void Init()
    {
        DerivePathInfo(Expectations.Initialize);
    }
}
