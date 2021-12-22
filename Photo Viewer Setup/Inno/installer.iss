; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Photo Viewer"
#define MyAppVersion "1.0.4"
#define MyAppPublisher "Zach, Inc."
#define MyAppExeName "Photo Viewer.exe"
#define MyAppAssocName "PNG Image"
#define MyAppAssocExt ".png"
#define MyAppAssocKey StringChange(MyAppAssocName, " ", "") + MyAppAssocExt
#define JpgAssocKey StringChange(MyAppAssocName, " ", "") + ".jpg"
#define GifAssocKey StringChange(MyAppAssocName, " ", "") + ".gif"
#define BmpAssocKey StringChange(MyAppAssocName, " ", "") + ".bmp"
#define RegCapKey StringChange(MyAppName, " ", "")

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{88E7BA21-00C5-4A8F-AEE9-5B64E3DD5407}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppPublisher}\{#MyAppName}
ChangesAssociations=yes
LicenseFile=C:\Users\zacha\Documents\License Agreement.rtf
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\zacha\source\repos\Photo Viewer\Photo Viewer Setup\Inno
OutputBaseFilename=Photo_Viewer_1_0_4_Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
DisableWelcomePage=no
DisableProgramGroupPage=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\zacha\source\repos\Photo Viewer\Photo Viewer\bin\Debug\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Registry]
Root: HKCR; Subkey: "{#MyAppAssocExt}\OpenWithProgids"; ValueType: string; ValueName: "{#MyAppAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCR; Subkey: "{#MyAppAssocKey}"; ValueType: string; ValueName: ""; ValueData: "{#MyAppAssocName}"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#MyAppAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "C:\Windows\System32\shell32.dll,313"
Root: HKCR; Subkey: "{#MyAppAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKCR; Subkey: "Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".png"; ValueData: ""
Root: HKCR; Subkey: ".jpg\OpenWithProgids"; ValueType: string; ValueName: "{#JpgAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCR; Subkey: ".jpeg\OpenWithProgids"; ValueType: string; ValueName: "{#JpgAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCR; Subkey: "{#JpgAssocKey}"; ValueType: string; ValueName: ""; ValueData: "JPEG Image"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#JpgAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "C:\Windows\System32\shell32.dll,313"
Root: HKCR; Subkey: "{#JpgAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKCR; Subkey: "Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".jpg"; ValueData: ""
Root: HKCR; Subkey: "Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".jpeg"; ValueData: ""
Root: HKCR; Subkey: ".bmp\OpenWithProgids"; ValueType: string; ValueName: "{#BmpAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCR; Subkey: "{#BmpAssocKey}"; ValueType: string; ValueName: ""; ValueData: "BMP Image"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#BmpAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "C:\Windows\System32\shell32.dll,313"
Root: HKCR; Subkey: "{#BmpAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKCR; Subkey: "Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".bmp"; ValueData: ""
Root: HKCR; Subkey: ".gif\OpenWithProgids"; ValueType: string; ValueName: "{#GifAssocKey}"; ValueData: ""; Flags: uninsdeletevalue
Root: HKCR; Subkey: "{#GifAssocKey}"; ValueType: string; ValueName: ""; ValueData: "GIF Image"; Flags: uninsdeletekey
Root: HKCR; Subkey: "{#GifAssocKey}\DefaultIcon"; ValueType: string; ValueName: ""; ValueData: "C:\Windows\System32\shell32.dll,313"
Root: HKCR; Subkey: "{#GifAssocKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"" ""%1"""
Root: HKCR; Subkey: "Applications\{#MyAppExeName}\SupportedTypes"; ValueType: string; ValueName: ".gif"; ValueData: ""
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities"; ValueType: string; ValueName: "ApplicationDescription"; ValueData: "A free and open-source photo viewer for Windows."; Flags: uninsdeletekey; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".png"; ValueData: "{#MyAppAssocKey}"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".jpg"; ValueData: "{#JpgAssocKey}"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".jpeg"; ValueData: "{#JpgAssocKey}"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".bmp"; ValueData: "{#BmpAssocKey}"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".gif"; ValueData: "{#GifAssocKey}"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\{#RegCapKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"""; Check: IsWin64
Root: HKLM64; Subkey: "SOFTWARE\RegisteredApplications"; ValueType: string; ValueName: "{#MyAppName}"; ValueData: "SOFTWARE\{#RegCapKey}\Capabilities"; Flags: uninsdeletevalue; Check: IsWin64
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities"; ValueType: string; ValueName: "ApplicationDescription"; ValueData: "A free and open-source photo viewer for Windows."; Flags: uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".png"; ValueData: "{#MyAppAssocKey}"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".jpg"; ValueData: "{#JpgAssocKey}"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".jpeg"; ValueData: "{#JpgAssocKey}"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".bmp"; ValueData: "{#BmpAssocKey}"
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\Capabilities\FileAssociations"; ValueType: string; ValueName: ".gif"; ValueData: "{#GifAssocKey}"; Flags: uninsdeletevalue
Root: HKLM; Subkey: "SOFTWARE\{#RegCapKey}\shell\open\command"; ValueType: string; ValueName: ""; ValueData: """{app}\{#MyAppExeName}"""
Root: HKLM; Subkey: "SOFTWARE\RegisteredApplications"; ValueType: string; ValueName: "{#MyAppName}"; ValueData: "SOFTWARE\{#RegCapKey}\Capabilities"; Flags: uninsdeletevalue

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

