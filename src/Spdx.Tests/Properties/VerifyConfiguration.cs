namespace Spdx.Tests;

public static class VerifyConfiguration
{
    [ModuleInitializer]
    public static void Init()
    {
        VerifierSettings.DerivePathInfo(Expectations.Initialize);
    }
}
