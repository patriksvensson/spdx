Push-Location "src/Spdx.Generator"
dotnet run -- --output "../Spdx/SpdxLicense.Generated.cs"
if ($LASTEXITCODE -ne 0) {
    throw "An error occured while generating SPDX licenses"
}
Pop-Location