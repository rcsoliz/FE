<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_Empresa
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtcod_actividad = New System.Windows.Forms.TextBox()
        Me.txtnomb_empresa = New System.Windows.Forms.TextBox()
        Me.txtnomb_actividad = New System.Windows.Forms.TextBox()
        Me.txtciudad = New System.Windows.Forms.TextBox()
        Me.txtPais = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtCodPostal = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtTelefono1 = New System.Windows.Forms.TextBox()
        Me.txtTelefono2 = New System.Windows.Forms.TextBox()
        Me.txtNit = New System.Windows.Forms.TextBox()
        Me.txtCNS = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.dxErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 52)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.53165!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.46836!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(486, 447)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 362)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos empresa"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 102.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label8, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label5, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 1, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.Label10, 1, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 1, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 3, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 1, 10)
        Me.TableLayoutPanel3.Controls.Add(Me.Label14, 1, 11)
        Me.TableLayoutPanel3.Controls.Add(Me.txtcod_actividad, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtnomb_empresa, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtnomb_actividad, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtciudad, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.txtPais, 2, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDireccion, 2, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.txtCodPostal, 2, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.txtEmail, 2, 8)
        Me.TableLayoutPanel3.Controls.Add(Me.txtTelefono1, 2, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.txtTelefono2, 4, 9)
        Me.TableLayoutPanel3.Controls.Add(Me.txtNit, 2, 10)
        Me.TableLayoutPanel3.Controls.Add(Me.txtCNS, 2, 11)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 13
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(474, 341)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(14, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 27)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Código"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(14, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 26)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Ciudad"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(14, 125)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 26)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Pais"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Location = New System.Drawing.Point(14, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 29)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Dirección"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Location = New System.Drawing.Point(14, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 28)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Empresa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(14, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 27)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Actidad "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Location = New System.Drawing.Point(14, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 26)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Código Postal"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Location = New System.Drawing.Point(14, 206)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 27)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Email"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Location = New System.Drawing.Point(14, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 26)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Telefono 1"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Location = New System.Drawing.Point(234, 233)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 26)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Telefono 2"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Location = New System.Drawing.Point(14, 259)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 27)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Nit"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Location = New System.Drawing.Point(14, 286)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(41, 28)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "C.N.S."
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtcod_actividad
        '
        Me.txtcod_actividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtcod_actividad.Location = New System.Drawing.Point(116, 20)
        Me.txtcod_actividad.Name = "txtcod_actividad"
        Me.txtcod_actividad.Size = New System.Drawing.Size(112, 22)
        Me.txtcod_actividad.TabIndex = 12
        '
        'txtnomb_empresa
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtnomb_empresa, 3)
        Me.txtnomb_empresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtnomb_empresa.Location = New System.Drawing.Point(116, 47)
        Me.txtnomb_empresa.Name = "txtnomb_empresa"
        Me.txtnomb_empresa.Size = New System.Drawing.Size(342, 22)
        Me.txtnomb_empresa.TabIndex = 13
        '
        'txtnomb_actividad
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtnomb_actividad, 3)
        Me.txtnomb_actividad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtnomb_actividad.Location = New System.Drawing.Point(116, 75)
        Me.txtnomb_actividad.Name = "txtnomb_actividad"
        Me.txtnomb_actividad.Size = New System.Drawing.Size(342, 22)
        Me.txtnomb_actividad.TabIndex = 14
        '
        'txtciudad
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtciudad, 3)
        Me.txtciudad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtciudad.Location = New System.Drawing.Point(116, 102)
        Me.txtciudad.Name = "txtciudad"
        Me.txtciudad.Size = New System.Drawing.Size(342, 22)
        Me.txtciudad.TabIndex = 15
        '
        'txtPais
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtPais, 3)
        Me.txtPais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPais.Location = New System.Drawing.Point(116, 128)
        Me.txtPais.Name = "txtPais"
        Me.txtPais.Size = New System.Drawing.Size(342, 22)
        Me.txtPais.TabIndex = 16
        '
        'txtDireccion
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtDireccion, 3)
        Me.txtDireccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDireccion.Location = New System.Drawing.Point(116, 154)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(342, 22)
        Me.txtDireccion.TabIndex = 17
        '
        'txtCodPostal
        '
        Me.txtCodPostal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodPostal.Location = New System.Drawing.Point(116, 183)
        Me.txtCodPostal.Name = "txtCodPostal"
        Me.txtCodPostal.Size = New System.Drawing.Size(112, 22)
        Me.txtCodPostal.TabIndex = 18
        '
        'txtEmail
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtEmail, 3)
        Me.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmail.Location = New System.Drawing.Point(116, 209)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(342, 22)
        Me.txtEmail.TabIndex = 19
        '
        'txtTelefono1
        '
        Me.txtTelefono1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTelefono1.Location = New System.Drawing.Point(116, 236)
        Me.txtTelefono1.Name = "txtTelefono1"
        Me.txtTelefono1.Size = New System.Drawing.Size(112, 22)
        Me.txtTelefono1.TabIndex = 20
        '
        'txtTelefono2
        '
        Me.txtTelefono2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTelefono2.Location = New System.Drawing.Point(312, 236)
        Me.txtTelefono2.Name = "txtTelefono2"
        Me.txtTelefono2.Size = New System.Drawing.Size(146, 22)
        Me.txtTelefono2.TabIndex = 21
        '
        'txtNit
        '
        Me.txtNit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNit.Location = New System.Drawing.Point(116, 262)
        Me.txtNit.Name = "txtNit"
        Me.txtNit.Size = New System.Drawing.Size(112, 22)
        Me.txtNit.TabIndex = 22
        '
        'txtCNS
        '
        Me.txtCNS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCNS.Location = New System.Drawing.Point(116, 289)
        Me.txtCNS.Name = "txtCNS"
        Me.txtCNS.Size = New System.Drawing.Size(112, 22)
        Me.txtCNS.TabIndex = 23
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 371)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 73)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Opciones"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnGuardar, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnModificar, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnEliminar, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnSalir, 4, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(474, 52)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'btnGuardar
        '
        Me.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnGuardar.Location = New System.Drawing.Point(23, 11)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(77, 31)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnModificar.Location = New System.Drawing.Point(106, 11)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(77, 31)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "Modiifcar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEliminar.Location = New System.Drawing.Point(189, 11)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(81, 31)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalir.Location = New System.Drawing.Point(276, 11)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(77, 31)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'dxErrorProvider
        '
        Me.dxErrorProvider.ContainerControl = Me
        '
        'UI_Empresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 499)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "UI_Empresa"
        Me.Text = "UI_Empresa"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel2, 0)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.dxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtcod_actividad As System.Windows.Forms.TextBox
    Friend WithEvents txtnomb_empresa As System.Windows.Forms.TextBox
    Friend WithEvents txtnomb_actividad As System.Windows.Forms.TextBox
    Friend WithEvents txtciudad As System.Windows.Forms.TextBox
    Friend WithEvents txtPais As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPostal As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNit As System.Windows.Forms.TextBox
    Friend WithEvents txtCNS As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents dxErrorProvider As System.Windows.Forms.ErrorProvider

End Class
