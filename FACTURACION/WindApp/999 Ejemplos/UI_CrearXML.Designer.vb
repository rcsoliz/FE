<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_CrearXML
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
        Me.btnCrearXML = New System.Windows.Forms.Button()
        Me.btnEnviar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCrearXML
        '
        Me.btnCrearXML.Location = New System.Drawing.Point(27, 82)
        Me.btnCrearXML.Name = "btnCrearXML"
        Me.btnCrearXML.Size = New System.Drawing.Size(75, 23)
        Me.btnCrearXML.TabIndex = 9
        Me.btnCrearXML.Text = "&Crear XML"
        Me.btnCrearXML.UseVisualStyleBackColor = True
        '
        'btnEnviar
        '
        Me.btnEnviar.Location = New System.Drawing.Point(27, 136)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(75, 23)
        Me.btnEnviar.TabIndex = 10
        Me.btnEnviar.Text = "&Enviar Siat"
        Me.btnEnviar.UseVisualStyleBackColor = True
        '
        'UI_CrearXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 185)
        Me.Controls.Add(Me.btnEnviar)
        Me.Controls.Add(Me.btnCrearXML)
        Me.Name = "UI_CrearXML"
        Me.Text = "UI_CrearXML"
        Me.Controls.SetChildIndex(Me.btnCrearXML, 0)
        Me.Controls.SetChildIndex(Me.btnEnviar, 0)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCrearXML As System.Windows.Forms.Button
    Friend WithEvents btnEnviar As System.Windows.Forms.Button
End Class
