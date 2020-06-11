<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.timerCountdown = New System.Windows.Forms.Label()
        Me.BtnExtend = New System.Windows.Forms.Button()
        Me.BtnShutDown = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.timer = New System.Windows.Forms.Timer(Me.components)
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.launching = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'timerCountdown
        '
        Me.timerCountdown.AutoSize = True
        Me.timerCountdown.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timerCountdown.ForeColor = System.Drawing.Color.DarkGreen
        Me.timerCountdown.Location = New System.Drawing.Point(85, 74)
        Me.timerCountdown.Name = "timerCountdown"
        Me.timerCountdown.Size = New System.Drawing.Size(146, 29)
        Me.timerCountdown.TabIndex = 0
        Me.timerCountdown.Text = "02:00:00:00"
        '
        'BtnExtend
        '
        Me.BtnExtend.Location = New System.Drawing.Point(41, 142)
        Me.BtnExtend.Name = "BtnExtend"
        Me.BtnExtend.Size = New System.Drawing.Size(236, 23)
        Me.BtnExtend.TabIndex = 1
        Me.BtnExtend.Text = "Extend time left (30 minutes)"
        Me.BtnExtend.UseVisualStyleBackColor = True
        '
        'BtnShutDown
        '
        Me.BtnShutDown.Location = New System.Drawing.Point(156, 183)
        Me.BtnShutDown.Name = "BtnShutDown"
        Me.BtnShutDown.Size = New System.Drawing.Size(141, 23)
        Me.BtnShutDown.TabIndex = 2
        Me.BtnShutDown.Text = "Close and Encrypt folder"
        Me.BtnShutDown.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(227, 26)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Encrypted folder opened"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(37, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Time left :"
        '
        'timer
        '
        Me.timer.Interval = 10
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(41, 113)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(236, 23)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.Text = "Open folder"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'launching
        '
        Me.launching.Interval = 1000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 216)
        Me.Controls.Add(Me.BtnOpen)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnShutDown)
        Me.Controls.Add(Me.BtnExtend)
        Me.Controls.Add(Me.timerCountdown)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "KeyToVault"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents timerCountdown As Label
    Friend WithEvents BtnExtend As Button
    Friend WithEvents BtnShutDown As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents timer As Timer
    Friend WithEvents BtnOpen As Button
    Friend WithEvents launching As Timer
End Class
