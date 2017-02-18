; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Mobile Number Extractor"
#define MyAppVersion "1.0.0.4"
#define MyAppPublisher "PGC"
#define MyAppExeName "frmMNextractor.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{A0B9820D-C27D-4C89-9FF2-B8CFB946F15E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\MISGWAPOHON\Desktop\fsdf
OutputBaseFilename=Mobile Number Extractor
SetupIconFile=C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\RAW\Trayse101-Photoshop-Filetypes-Extract.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\Pawnshop\frmMNextractor\bin\Debug\frmMNextractor.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\Pawnshop\frmMNextractor\bin\Debug\frmMNextractor.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\Pawnshop\frmMNextractor\bin\Debug\frmMNextractor.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\Pawnshop\frmMNextractor\bin\Debug\frmMNextractor.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\MISGWAPOHON\Documents\DALTON\Dalton\Pawnshop\frmMNextractor\bin\Debug\frmMNextractor.xml"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
