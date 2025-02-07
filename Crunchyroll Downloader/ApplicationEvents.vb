﻿Option Strict On

Imports System.IO
Imports Gecko
Imports System.Environment
Imports Microsoft.Win32
Namespace My

    ' The following events are available for MyApplication:
    '
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active.
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        'Dim UseFirefoxProfile As Boolean = True
        Protected Overrides Function OnStartup(ByVal eventArgs As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
            'Dim ProfileDirectory As String = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "Mozilla", "Firefox", "Profiles", "CRD")
            'If UseFirefoxProfile = True Then
            '    Dim di As New System.IO.DirectoryInfo(Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "Mozilla", "Firefox", "Profiles"))
            '    Try
            '        For Each fi As System.IO.DirectoryInfo In di.EnumerateDirectories("*.*", System.IO.SearchOption.TopDirectoryOnly)
            '            Dim TempPath As String = Path.Combine(GetFolderPath(SpecialFolder.ApplicationData), "Mozilla", "Firefox", "Profiles", fi.Name)
            '            ProfileDirectory = TempPath
            '        Next
            '    Catch ex As Exception
            '    End Try
            'End If
            'MsgBox(ProfileDirectory)
            'If Not Directory.Exists(ProfileDirectory) Then
            '    Directory.CreateDirectory(ProfileDirectory)
            'End If
            Try


                Dim sUserAgent As String = My.Resources.ffmpeg_user_agend.Replace("User-Agent: ", "").Replace(Chr(34), "") '"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:84.0) Gecko/20100101 Firefox/84.0"
                'sUserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.157 Safari/537.36"
                'Xpcom.ProfileDirectory = ProfileDirectory
                Xpcom.Initialize("Firefox")
                'MsgBox(Xpcom.XulRunnerVersion)

                'Dim File As nsIFile = CType(Xpcom.NewNativeLocalFile("E:\addon\"), nsIFile)
                'File.Append(New nsAString("manifest.json"))
                'Xpcom.ComponentRegistrar.AutoRegister(File)

                'Dim Dir As String =
                GeckoPreferences.User("general.useragent.override") = sUserAgent
                'Xpcom.Initialize("C:\Program Files\Mozilla Firefox")
                GeckoPreferences.Default("browser.cache.disk.enable") = False
                GeckoPreferences.Default("network.cookie.thirdparty.sessionOnly") = False
                GeckoPreferences.Default("Services.sync.prefs.sync.privacy.clearOnShutdown.cookies") = False
                GeckoPreferences.Default("plugin.state.flash") = 0
                GeckoPreferences.Default("zoom.maxPercent") = 100
                GeckoPreferences.Default("zoom.minPercent") = 100
                'GeckoPreferences.Default("layers.geometry.d3d11.enabled") = False
                'GeckoPreferences.Default("security.enterprise_roots.enabled") = True



                Return True
            Catch ex As Exception
                MsgBox("if you see this you should install the x86 version from the Visual C++ redistributable" + vbNewLine + "https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads" + vbNewLine + vbNewLine + ex.ToString)
                Return False
            End Try

        End Function
    End Class
End Namespace
