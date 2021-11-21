namespace Spdx.Tests;

public sealed class SpdxLicenseTests
{
    [Fact]
    public void Should_Get_All_Licenses()
    {
        // Given, When
        var licenses = SpdxLicense.All.ToArray();

        // Then
        licenses.Length.ShouldBe(479);
    }

    [Fact]
    public void Should_Populate_MIT_License_With_Expected_Data()
    {
        // Given, When
        var license = SpdxLicense.Lookup["MIT"];

        // Then
        license.ShouldNotBeNull();
        license.Id.ShouldBe("MIT");
        license.Name.ShouldBe("MIT License");
        license.Url.ShouldBe("https://spdx.org/licenses/MIT.html");
        license.JsonUrl.ShouldBe("https://spdx.org/licenses/MIT.json");
        license.IsOsiApproved.ShouldBeTrue();
        license.IsFsfLibre.ShouldBeTrue();
        license.IsDeprecated.ShouldBeFalse();
    }
}