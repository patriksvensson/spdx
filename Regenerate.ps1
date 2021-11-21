Push-Location "src/Spdx.Generator"
dotnet run -- --output "../Spdx"
if ($LASTEXITCODE -ne 0) {
    throw "An error occured while generating SPDX licenses"
}
Pop-Location