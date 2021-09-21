<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_Pruebas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnSerializar = New System.Windows.Forms.Button()
        Me.btnDeserializar = New System.Windows.Forms.Button()
        Me.dgvFactura = New System.Windows.Forms.DataGridView()
        Me.btnFormato = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.txtFormatoCuf = New System.Windows.Forms.TextBox()
        Me.txtFormFactura = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnValidarXML = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDirectorioXML = New System.Windows.Forms.TextBox()
        Me.btnExpXML = New System.Windows.Forms.Button()
        Me.btnFirmarXML = New System.Windows.Forms.Button()
        Me.btnExplorarCertificado = New System.Windows.Forms.Button()
        Me.txtDirectorioCetificado = New System.Windows.Forms.TextBox()
        Me.btnComprir = New System.Windows.Forms.Button()
        Me.btnFirmar = New System.Windows.Forms.Button()
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 58)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(333, 441)
        Me.RichTextBox1.TabIndex = 9
        Me.RichTextBox1.Text = "PASOS GENERAR FACTURA ELECTRONICA:" & Global.Microsoft.VisualBasic.ChrW(10) & "1.- Pasar de .xsd a clases en vb.net" & Global.Microsoft.VisualBasic.ChrW(10) & "xsd /clas" & _
            "ses /language:vb direcctoriYnombreArchivo.xsd" & Global.Microsoft.VisualBasic.ChrW(10) & "2.- Serializar el documomento " & Global.Microsoft.VisualBasic.ChrW(10) & "gen" & _
            "eramos un documento .xml"
        '
        'btnSerializar
        '
        Me.btnSerializar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSerializar.Location = New System.Drawing.Point(351, 98)
        Me.btnSerializar.Name = "btnSerializar"
        Me.btnSerializar.Size = New System.Drawing.Size(90, 30)
        Me.btnSerializar.TabIndex = 10
        Me.btnSerializar.Text = "2. Serializar"
        Me.btnSerializar.UseVisualStyleBackColor = True
        '
        'btnDeserializar
        '
        Me.btnDeserializar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeserializar.Location = New System.Drawing.Point(466, 98)
        Me.btnDeserializar.Name = "btnDeserializar"
        Me.btnDeserializar.Size = New System.Drawing.Size(104, 30)
        Me.btnDeserializar.TabIndex = 11
        Me.btnDeserializar.Text = "2.1. Deserializar"
        Me.btnDeserializar.UseVisualStyleBackColor = True
        '
        'dgvFactura
        '
        Me.dgvFactura.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFactura.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFactura.Location = New System.Drawing.Point(576, 58)
        Me.dgvFactura.Name = "dgvFactura"
        Me.dgvFactura.Size = New System.Drawing.Size(561, 70)
        Me.dgvFactura.TabIndex = 12
        '
        'btnFormato
        '
        Me.btnFormato.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFormato.Location = New System.Drawing.Point(351, 145)
        Me.btnFormato.Name = "btnFormato"
        Me.btnFormato.Size = New System.Drawing.Size(121, 30)
        Me.btnFormato.TabIndex = 13
        Me.btnFormato.Text = "2.2. Formato fecha"
        Me.btnFormato.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(478, 148)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 14
        '
        'txtFormatoCuf
        '
        Me.txtFormatoCuf.Location = New System.Drawing.Point(706, 148)
        Me.txtFormatoCuf.Name = "txtFormatoCuf"
        Me.txtFormatoCuf.Size = New System.Drawing.Size(431, 20)
        Me.txtFormatoCuf.TabIndex = 15
        Me.txtFormatoCuf.Text = "0000123456789201901131637212310000111010000000100003"
        '
        'txtFormFactura
        '
        Me.txtFormFactura.Location = New System.Drawing.Point(706, 174)
        Me.txtFormFactura.Name = "txtFormFactura"
        Me.txtFormFactura.Size = New System.Drawing.Size(431, 20)
        Me.txtFormFactura.TabIndex = 16
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(706, 229)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(431, 20)
        Me.TextBox1.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(351, 219)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 30)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Prueba Funcion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFirmar)
        Me.GroupBox1.Controls.Add(Me.btnValidarXML)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtDirectorioXML)
        Me.GroupBox1.Controls.Add(Me.btnExpXML)
        Me.GroupBox1.Controls.Add(Me.btnFirmarXML)
        Me.GroupBox1.Controls.Add(Me.btnExplorarCertificado)
        Me.GroupBox1.Controls.Add(Me.txtDirectorioCetificado)
        Me.GroupBox1.Location = New System.Drawing.Point(351, 296)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 203)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos XML"
        '
        'btnValidarXML
        '
        Me.btnValidarXML.Location = New System.Drawing.Point(176, 113)
        Me.btnValidarXML.Name = "btnValidarXML"
        Me.btnValidarXML.Size = New System.Drawing.Size(75, 23)
        Me.btnValidarXML.TabIndex = 7
        Me.btnValidarXML.Text = "Validar XML"
        Me.btnValidarXML.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "3 Realizar la validación del XML"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(108, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "2"
        '
        'txtDirectorioXML
        '
        Me.txtDirectorioXML.Location = New System.Drawing.Point(138, 48)
        Me.txtDirectorioXML.Name = "txtDirectorioXML"
        Me.txtDirectorioXML.Size = New System.Drawing.Size(470, 20)
        Me.txtDirectorioXML.TabIndex = 4
        '
        'btnExpXML
        '
        Me.btnExpXML.Location = New System.Drawing.Point(15, 48)
        Me.btnExpXML.Name = "btnExpXML"
        Me.btnExpXML.Size = New System.Drawing.Size(106, 23)
        Me.btnExpXML.TabIndex = 3
        Me.btnExpXML.Text = "Exp Xml"
        Me.btnExpXML.UseVisualStyleBackColor = True
        '
        'btnFirmarXML
        '
        Me.btnFirmarXML.Location = New System.Drawing.Point(15, 77)
        Me.btnFirmarXML.Name = "btnFirmarXML"
        Me.btnFirmarXML.Size = New System.Drawing.Size(75, 23)
        Me.btnFirmarXML.TabIndex = 2
        Me.btnFirmarXML.Text = "Firmar XML"
        Me.btnFirmarXML.UseVisualStyleBackColor = True
        '
        'btnExplorarCertificado
        '
        Me.btnExplorarCertificado.Location = New System.Drawing.Point(15, 19)
        Me.btnExplorarCertificado.Name = "btnExplorarCertificado"
        Me.btnExplorarCertificado.Size = New System.Drawing.Size(106, 23)
        Me.btnExplorarCertificado.TabIndex = 1
        Me.btnExplorarCertificado.Text = "Exp Certificado"
        Me.btnExplorarCertificado.UseVisualStyleBackColor = True
        '
        'txtDirectorioCetificado
        '
        Me.txtDirectorioCetificado.Location = New System.Drawing.Point(138, 21)
        Me.txtDirectorioCetificado.Name = "txtDirectorioCetificado"
        Me.txtDirectorioCetificado.Size = New System.Drawing.Size(470, 20)
        Me.txtDirectorioCetificado.TabIndex = 0
        '
        'btnComprir
        '
        Me.btnComprir.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComprir.Location = New System.Drawing.Point(706, 255)
        Me.btnComprir.Name = "btnComprir"
        Me.btnComprir.Size = New System.Drawing.Size(142, 30)
        Me.btnComprir.TabIndex = 20
        Me.btnComprir.Text = "Coprimir"
        Me.btnComprir.UseVisualStyleBackColor = True
        '
        'btnFirmar
        '
        Me.btnFirmar.Location = New System.Drawing.Point(509, 87)
        Me.btnFirmar.Name = "btnFirmar"
        Me.btnFirmar.Size = New System.Drawing.Size(108, 44)
        Me.btnFirmar.TabIndex = 8
        Me.btnFirmar.Text = "FIRMAR"
        Me.btnFirmar.UseVisualStyleBackColor = True
        '
        'UI_Pruebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1155, 511)
        Me.Controls.Add(Me.btnComprir)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.txtFormFactura)
        Me.Controls.Add(Me.txtFormatoCuf)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.btnFormato)
        Me.Controls.Add(Me.dgvFactura)
        Me.Controls.Add(Me.btnDeserializar)
        Me.Controls.Add(Me.btnSerializar)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Name = "UI_Pruebas"
        Me.Text = "UI_Pruebas"
        Me.Controls.SetChildIndex(Me.RichTextBox1, 0)
        Me.Controls.SetChildIndex(Me.btnSerializar, 0)
        Me.Controls.SetChildIndex(Me.btnDeserializar, 0)
        Me.Controls.SetChildIndex(Me.dgvFactura, 0)
        Me.Controls.SetChildIndex(Me.btnFormato, 0)
        Me.Controls.SetChildIndex(Me.DateTimePicker1, 0)
        Me.Controls.SetChildIndex(Me.txtFormatoCuf, 0)
        Me.Controls.SetChildIndex(Me.txtFormFactura, 0)
        Me.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnComprir, 0)
        CType(Me.dgvFactura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnSerializar As System.Windows.Forms.Button
    Friend WithEvents btnDeserializar As System.Windows.Forms.Button
    Friend WithEvents dgvFactura As System.Windows.Forms.DataGridView
    Friend WithEvents btnFormato As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFormatoCuf As System.Windows.Forms.TextBox
    Friend WithEvents txtFormFactura As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExplorarCertificado As System.Windows.Forms.Button
    Friend WithEvents txtDirectorioCetificado As System.Windows.Forms.TextBox
    Friend WithEvents btnFirmarXML As System.Windows.Forms.Button
    Friend WithEvents txtDirectorioXML As System.Windows.Forms.TextBox
    Friend WithEvents btnExpXML As System.Windows.Forms.Button
    Friend WithEvents btnValidarXML As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnComprir As System.Windows.Forms.Button
    Friend WithEvents btnFirmar As System.Windows.Forms.Button
End Class
