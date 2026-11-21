#define AppName "SquadHub"
#define AppVersion "0.2.0"
#define AppExe "SquadHub.exe"
#define PublishDir "..\\publish"
[Setup]
AppId={{7B2A8B43-53A9-4F10-9E6D-7D28F02C0011}
AppName={#AppName}
AppVersion={#AppVersion}
DefaultDirName={autopf}\\SquadHub
DefaultGroupName=SquadHub
OutputDir=..\\dist
OutputBaseFilename=SquadHub_Setup
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin
UninstallDisplayIcon={app}\\{#AppExe}
[Files]
Source: "{#PublishDir}\\*"; DestDir: "{app}"; Flags: recursesubdirs ignoreversion
[Icons]
Name: "{autoprograms}\\SquadHub"; Filename: "{app}\\{#AppExe}"
Name: "{autodesktop}\\SquadHub"; Filename: "{app}\\{#AppExe}"; Tasks: desktopicon
[Tasks]
Name: "desktopicon"; Description: "Создать ярлык на рабочем столе"; GroupDescription: "Дополнительные ярлыки:"
[Run]
Filename: "{app}\\{#AppExe}"; Description: "Запустить SquadHub"; Flags: postinstall nowait skipifsilent
