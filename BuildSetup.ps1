$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $MyInvocation.MyCommand.Path
$project = Join-Path $root "src\SquadHub\SquadHub.csproj"
$publish = Join-Path $root "publish"
$installer = Join-Path $root "installer\SquadHub.iss"
Write-Host "Publishing self-contained Windows app..."
dotnet publish $project -c Release -r win-x64 --self-contained true -o $publish
if ($LASTEXITCODE -ne 0) { throw "dotnet publish failed" }
$iscc = "$env:ProgramFiles(x86)\Inno Setup 6\ISCC.exe"
if (!(Test-Path $iscc)) { $iscc = "$env:ProgramFiles\Inno Setup 6\ISCC.exe" }
if (!(Test-Path $iscc)) { throw "Inno Setup 6 missing. Install it and rerun." }
& $iscc $installer
if ($LASTEXITCODE -ne 0) { throw "Inno Setup compilation failed" }
Write-Host "Setup created in dist\SquadHub_Setup.exe"
