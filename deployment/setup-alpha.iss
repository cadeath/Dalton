; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Dalton Pawnshop"
#define MyAppVersion "a1.3"
#define MyAppPublisher "Perfecto Group of Companies"
#define MyAppExeName "pawnshop.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AED4E4D4-55AF-48DD-ABC8-813B9A3CB464}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\cdt-S0ft\Dalton Pawnshop
DefaultGroupName=cdt-S0ft\Dalton Pawnshop
OutputDir=D:\cadeath\Documents\DevInstaller\Pawnshop
OutputBaseFilename=pawnshop-a13
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\cadeath\Documents\GitHub\Dalton\Pawnshop\Pawnshop\bin\Debug\pawnshop.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\cadeath\Documents\GitHub\Dalton\Pawnshop\Pawnshop\bin\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

