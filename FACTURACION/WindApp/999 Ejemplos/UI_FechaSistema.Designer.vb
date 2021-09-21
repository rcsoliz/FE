<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_FechaSistema
    Inherits WindApp.f_base

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnFechaHora = New System.Windows.Forms.Button()
        Me.txtFechaHora = New System.Windows.Forms.TextBox()
        Me.txtCuis = New System.Windows.Forms.TextBox()
        Me.btnCuis = New System.Windows.Forms.Button()
        Me.btnExplorar = New System.Windows.Forms.Button()
        Me.txtExplorar = New System.Windows.Forms.TextBox()
        Me.txtSH256 = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSh256 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnFechaHora
        '
        Me.btnFechaHora.Location = New System.Drawing.Point(41, 141)
        Me.btnFechaHora.Name = "btnFechaHora"
        Me.btnFechaHora.Size = New System.Drawing.Size(104, 30)
        Me.btnFechaHora.TabIndex = 9
        Me.btnFechaHora.Text = "Fecha Hora S.I.N."
        Me.btnFechaHora.UseVisualStyleBackColor = True
        '
        'txtFechaHora
        '
        Me.txtFechaHora.Location = New System.Drawing.Point(167, 147)
        Me.txtFechaHora.Name = "txtFechaHora"
        Me.txtFechaHora.Size = New System.Drawing.Size(333, 20)
        Me.txtFechaHora.TabIndex = 10
        '
        'txtCuis
        '
        Me.txtCuis.Location = New System.Drawing.Point(167, 95)
        Me.txtCuis.Name = "txtCuis"
        Me.txtCuis.Size = New System.Drawing.Size(333, 20)
        Me.txtCuis.TabIndex = 12
        '
        'btnCuis
        '
        Me.btnCuis.Location = New System.Drawing.Point(41, 89)
        Me.btnCuis.Name = "btnCuis"
        Me.btnCuis.Size = New System.Drawing.Size(104, 30)
        Me.btnCuis.TabIndex = 11
        Me.btnCuis.Text = "CUIS"
        Me.btnCuis.UseVisualStyleBackColor = True
        '
        'btnExplorar
        '
        Me.btnExplorar.Location = New System.Drawing.Point(434, 192)
        Me.btnExplorar.Name = "btnExplorar"
        Me.btnExplorar.Size = New System.Drawing.Size(75, 23)
        Me.btnExplorar.TabIndex = 13
        Me.btnExplorar.Text = "Explorar"
        Me.btnExplorar.UseVisualStyleBackColor = True
        '
        'txtExplorar
        '
        Me.txtExplorar.Location = New System.Drawing.Point(41, 194)
        Me.txtExplorar.Name = "txtExplorar"
        Me.txtExplorar.Size = New System.Drawing.Size(387, 20)
        Me.txtExplorar.TabIndex = 14
        Me.txtExplorar.Text = "......."
        '
        'txtSH256
        '
        Me.txtSH256.Location = New System.Drawing.Point(41, 230)
        Me.txtSH256.Multiline = True
        Me.txtSH256.Name = "txtSH256"
        Me.txtSH256.Size = New System.Drawing.Size(387, 82)
        Me.txtSH256.TabIndex = 15
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSh256
        '
        Me.btnSh256.Location = New System.Drawing.Point(434, 230)
        Me.btnSh256.Name = "btnSh256"
        Me.btnSh256.Size = New System.Drawing.Size(75, 23)
        Me.btnSh256.TabIndex = 16
        Me.btnSh256.Text = "SH256"
        Me.btnSh256.UseVisualStyleBackColor = True
        '
        'UI_FechaSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 449)
        Me.Controls.Add(Me.btnSh256)
        Me.Controls.Add(Me.txtSH256)
        Me.Controls.Add(Me.txtExplorar)
        Me.Controls.Add(Me.btnExplorar)
        Me.Controls.Add(Me.txtCuis)
        Me.Controls.Add(Me.btnCuis)
        Me.Controls.Add(Me.txtFechaHora)
        Me.Controls.Add(Me.btnFechaHora)
        Me.Name = "UI_FechaSistema"
        Me.Text = "UI_FechaSistema"
        Me.Controls.SetChildIndex(Me.btnFechaHora, 0)
        Me.Controls.SetChildIndex(Me.txtFechaHora, 0)
        Me.Controls.SetChildIndex(Me.btnCuis, 0)
        Me.Controls.SetChildIndex(Me.txtCuis, 0)
        Me.Controls.SetChildIndex(Me.btnExplorar, 0)
        Me.Controls.SetChildIndex(Me.txtExplorar, 0)
        Me.Controls.SetChildIndex(Me.txtSH256, 0)
        Me.Controls.SetChildIndex(Me.btnSh256, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFechaHora As System.Windows.Forms.Button
    Friend WithEvents txtFechaHora As System.Windows.Forms.TextBox
    Friend WithEvents txtCuis As System.Windows.Forms.TextBox
    Friend WithEvents btnCuis As System.Windows.Forms.Button
    Friend WithEvents btnExplorar As System.Windows.Forms.Button
    Friend WithEvents txtExplorar As System.Windows.Forms.TextBox
    Friend WithEvents txtSH256 As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSh256 As System.Windows.Forms.Button
End Class
