Imports SshNet
Imports System.Security.Cryptography
Imports System.Security
Imports System.Text

'What you can change
'1. Variables configuration (obligatory) : Change values of variables so you can connect to your own server
'2. Decryption method (optional) : Change encryption & decryption method. Default method is Base64
'3. Decryption time (optional) : Change timer at start to give your Synology Diskstation time to decrypt the folder

Public Class Main

    'VARIABLES CONFIGURATION
    '=======================
    'It's the main part you'll have to configure
    'Setup all your password already encrypted (Default method = Base64. Unsecure but fine for intranet use.)
    'Afterward, setup your decryption method if you want to change it within the Decode() Sub

    ReadOnly cserv As String = "" 'Encrypted server IP
    ReadOnly cport As String = "" 'Encrypted server port
    ReadOnly cpass As String = "" 'Encrypted folder passphrase
    ReadOnly cdsPass As String = "" 'Encrypted user password
    ReadOnly csshuser As String = "" 'Encrypted ssh username

    ReadOnly FolderName As String = "" 'Plaintext folder name, the one you will decrypt

    ReadOnly serv As String = Decode(cserv) 'usable server IP
    ReadOnly port As String = Decode(cport) 'usable server port
    ReadOnly pass As String = Decode(cpass) 'usable folder passphrase
    ReadOnly dsPass As String = Decode(cdsPass) 'usable user password
    ReadOnly sshUser As String = Decode(csshuser) 'usable ssh username

    Dim tickCount As Integer

    'Base countdown timer. Change it at will

    Dim ms As Integer = 0
    Dim seconds As Integer = 0
    Dim minutes As Integer = 0
    Dim hours As Integer = 2


    Sub OpenTheGates() Handles Me.Load

        'Launch process. Will decrypt the files and start a time to give some time to the DiskStation to decrypt file.

        LaunchBar.Show()

        Dim coString As New Renci.SshNet.PasswordConnectionInfo(serv, port, sshUser, dsPass)
        Dim sshClient As New Renci.SshNet.SshClient(coString)
        Dim modes As New Dictionary(Of Renci.SshNet.Common.TerminalModes, UInt32)
        Dim commandString As String = "sudo synoshare --enc_mount" & FolderName & " " & pass

        Try
            sshClient.Connect()
            Dim stream = sshClient.CreateShellStream("xterm", 255, 50, 800, 600, 1024, modes)
            Using stream
                LaunchBar.progress.Value = 10
                stream.WriteLine(commandString)
                stream.Expect("Password: ")
                stream.WriteLine(dsPass)
            End Using
            sshClient.Disconnect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Hide()
        launching.Start()

        sshClient.Dispose()

    End Sub


    Function Decode(str As String)

        'DECRYPTION METHOD
        '=================
        'Configure your decryption method to use a safer cipher than Base64
        'Can, of course, be longer than a one liner 

        Dim decoded As String = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(str))
        Return decoded
    End Function

    Private Sub TimeIsTicking()

        'Put the form in front of every other process at 30 minutes, 15 minutes and 5 minutes so the user can extend time if necessary

        If minutes = 30 And hours = 0 And seconds = 0 And ms = 0 Then
            Me.WindowState = WindowState.Normal
        ElseIf minutes = 15 And hours = 0 And seconds = 0 And ms = 0 Then
            Me.WindowState = WindowState.Normal
        ElseIf minutes = 5 And hours = 0 And seconds = 0 And ms = 0 Then
            Me.WindowState = WindowState.Normal
        End If

    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick

        'Countdown process

        TimeIsTicking()

        If ms = 0 Then
            If seconds = 0 Then
                If minutes = 0 Then
                    If hours = 0 Then
                        timer.Stop()
                        CloseGates()
                    Else
                        hours -= 1
                        minutes = 59
                        seconds = 59
                        ms = 59
                    End If

                Else
                    minutes -= 1
                    seconds = 59
                    ms = 59
                End If
            Else
                seconds -= 1
                ms = 59
            End If
        Else
            ms -= 1
        End If

        If hours > 0 Or minutes > 0 Then
            timerCountdown.ForeColor = Color.DarkGreen
        Else
            timerCountdown.ForeColor = Color.Red
        End If

        timerCountdown.Text = TimeToString(hours) & ":" & TimeToString(minutes) & ":" & TimeToString(seconds) & ":" & TimeToString(ms)

    End Sub


    Sub CloseGates() Handles Me.Closing

        'When closed, the app will automatically send a SSH Command to encrypt the files once again

        LaunchBar.Show()

        Dim coString As New Renci.SshNet.PasswordConnectionInfo(serv, port, "Guardian", dsPass)
        Dim sshClient As New Renci.SshNet.SshClient(coString)
        Dim modes As New Dictionary(Of Renci.SshNet.Common.TerminalModes, UInt32)

        Try
            sshClient.Connect()
            Dim stream = sshClient.CreateShellStream("xterm", 255, 50, 800, 600, 1024, modes)
            Using stream
                LaunchBar.progress.Value = 10
                stream.WriteLine("sudo synoshare --enc_unmount " & FolderName)
                stream.Expect("Password: ")
                stream.WriteLine(dsPass)
            End Using
            sshClient.Disconnect()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        LaunchBar.Close()

        sshClient.Dispose()

    End Sub

    Function TimeToString(digit As Integer)

        'Function to get "02:05" instead of "2:5"

        Dim retString As String

        If digit > 9 Then
            retString = Convert.ToString(digit)
        Else
            retString = "0" & Convert.ToString(digit)
        End If

        Return retString
    End Function

    Private Sub BtnShutDown_Click(sender As Object, e As EventArgs) Handles BtnShutDown.Click

        'Yeah so you click on the "Close" button and it closes the exe

        Me.Close()

    End Sub

    Private Sub BtnExtend_Click(sender As Object, e As EventArgs) Handles BtnExtend.Click

        'Extend time remaining by 30 minutes

        minutes += 30
        If minutes > 60 Then
            minutes -= 60
            hours += 1
        End If

        If hours >= 2 Then
            hours = 2
            minutes = 0
            seconds = 0
        End If
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click

        'Button to open the decrypted folder

        Process.Start("\\" & serv & "\" & FolderName)
    End Sub

    Private Sub launching_Tick(sender As Object, e As EventArgs) Handles launching.Tick

        'DECRYPTION TIME
        '===============
        'The time imposed to the user at the start of the executable to leave some time
        'for the DiskStation to decrypt the folder so it will be usable by the user
        'Base time is 20 seconds, each tick is 1 second.

        If tickCount < 20 Then
            Me.Hide()
            LaunchBar.progress.Value = tickCount * 5
            tickCount += 1
        Else
            launching.Stop()
            LaunchBar.Close()
            Me.Show()
            timer.Start()
        End If
    End Sub

End Class
