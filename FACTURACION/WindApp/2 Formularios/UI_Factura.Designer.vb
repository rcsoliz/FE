<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_Factura
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtNitEmpresa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCodTipoDocumento = New System.Windows.Forms.TextBox()
        Me.txtDescTipoDocumento = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNroDocumento = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtCodSucrusal = New System.Windows.Forms.TextBox()
        Me.txtDescSucrusal = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtCodCliente = New System.Windows.Forms.TextBox()
        Me.txtDescCliente = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtComplemento = New System.Windows.Forms.TextBox()
        Me.txtNroFactura = New System.Windows.Forms.TextBox()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtCodPago = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDescMetodoPago = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCodMoneda = New System.Windows.Forms.TextBox()
        Me.txtDescMoneda = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtNroTarjeta = New System.Windows.Forms.TextBox()
        Me.txtTipoCambio = New System.Windows.Forms.TextBox()
        Me.txtCuf = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCodSector = New System.Windows.Forms.TextBox()
        Me.txtDescSector = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLiteral = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCodigoControl = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 463.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 52)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 281.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1134, 516)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'GroupBox1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox1, 3)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel5)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1128, 149)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "......"
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 17
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.txtNitEmpresa, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label5, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtEmpresa, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodTipoDocumento, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescTipoDocumento, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label14, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtNroDocumento, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label8, 4, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label15, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodSucrusal, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescSucrusal, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label16, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodCliente, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescCliente, 2, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label17, 4, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label20, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.txtComplemento, 1, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.txtNroFactura, 8, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDireccion, 5, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodPago, 6, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtRazonSocial, 10, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label9, 9, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescMetodoPago, 8, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label18, 9, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodMoneda, 10, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescMoneda, 12, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label22, 14, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtNroTarjeta, 15, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.txtTipoCambio, 15, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCuf, 15, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label19, 14, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label10, 14, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.txtUsuario, 15, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Label21, 14, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Label11, 6, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.dtFechaEmision, 15, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label12, 13, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label23, 4, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtCodSector, 6, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.txtDescSector, 8, 2)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 6
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(1122, 130)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'txtNitEmpresa
        '
        Me.txtNitEmpresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNitEmpresa.Location = New System.Drawing.Point(110, 27)
        Me.txtNitEmpresa.Name = "txtNitEmpresa"
        Me.txtNitEmpresa.Size = New System.Drawing.Size(71, 20)
        Me.txtNitEmpresa.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nit Empresa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmpresa
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtEmpresa, 2)
        Me.txtEmpresa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEmpresa.Location = New System.Drawing.Point(187, 27)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.Size = New System.Drawing.Size(184, 20)
        Me.txtEmpresa.TabIndex = 14
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 24)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Tipo documento"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodTipoDocumento
        '
        Me.txtCodTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodTipoDocumento.Location = New System.Drawing.Point(110, 3)
        Me.txtCodTipoDocumento.Name = "txtCodTipoDocumento"
        Me.txtCodTipoDocumento.Size = New System.Drawing.Size(71, 20)
        Me.txtCodTipoDocumento.TabIndex = 13
        '
        'txtDescTipoDocumento
        '
        Me.txtDescTipoDocumento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescTipoDocumento.Location = New System.Drawing.Point(187, 3)
        Me.txtDescTipoDocumento.Name = "txtDescTipoDocumento"
        Me.txtDescTipoDocumento.Size = New System.Drawing.Size(80, 20)
        Me.txtDescTipoDocumento.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(273, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 24)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Nro Documento"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNroDocumento
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtNroDocumento, 2)
        Me.txtNroDocumento.Location = New System.Drawing.Point(377, 3)
        Me.txtNroDocumento.Name = "txtNroDocumento"
        Me.txtNroDocumento.Size = New System.Drawing.Size(74, 20)
        Me.txtNroDocumento.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label8, 2)
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(377, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 25)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Dirección"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(3, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(92, 25)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Codigo Sucrusal"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodSucrusal
        '
        Me.txtCodSucrusal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodSucrusal.Location = New System.Drawing.Point(110, 52)
        Me.txtCodSucrusal.Name = "txtCodSucrusal"
        Me.txtCodSucrusal.Size = New System.Drawing.Size(71, 20)
        Me.txtCodSucrusal.TabIndex = 19
        '
        'txtDescSucrusal
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtDescSucrusal, 2)
        Me.txtDescSucrusal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescSucrusal.Location = New System.Drawing.Point(187, 52)
        Me.txtDescSucrusal.Name = "txtDescSucrusal"
        Me.txtDescSucrusal.Size = New System.Drawing.Size(184, 20)
        Me.txtDescSucrusal.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 74)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 26)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "Cliente "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodCliente.Location = New System.Drawing.Point(110, 77)
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.Size = New System.Drawing.Size(71, 20)
        Me.txtCodCliente.TabIndex = 22
        '
        'txtDescCliente
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtDescCliente, 2)
        Me.txtDescCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescCliente.Location = New System.Drawing.Point(187, 77)
        Me.txtDescCliente.Name = "txtDescCliente"
        Me.txtDescCliente.Size = New System.Drawing.Size(184, 20)
        Me.txtDescCliente.TabIndex = 23
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label17, 2)
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(377, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 26)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Metodo Pago"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 24)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Complemento"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtComplemento
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtComplemento, 8)
        Me.txtComplemento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtComplemento.Location = New System.Drawing.Point(110, 103)
        Me.txtComplemento.Name = "txtComplemento"
        Me.txtComplemento.Size = New System.Drawing.Size(547, 20)
        Me.txtComplemento.TabIndex = 32
        '
        'txtNroFactura
        '
        Me.txtNroFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNroFactura.Location = New System.Drawing.Point(546, 3)
        Me.txtNroFactura.Name = "txtNroFactura"
        Me.txtNroFactura.Size = New System.Drawing.Size(111, 20)
        Me.txtNroFactura.TabIndex = 9
        '
        'txtDireccion
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtDireccion, 3)
        Me.txtDireccion.Location = New System.Drawing.Point(466, 27)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(191, 20)
        Me.txtDireccion.TabIndex = 2
        '
        'txtCodPago
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtCodPago, 2)
        Me.txtCodPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodPago.Location = New System.Drawing.Point(466, 77)
        Me.txtCodPago.Name = "txtCodPago"
        Me.txtCodPago.Size = New System.Drawing.Size(74, 20)
        Me.txtCodPago.TabIndex = 25
        '
        'txtRazonSocial
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtRazonSocial, 4)
        Me.txtRazonSocial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRazonSocial.Location = New System.Drawing.Point(743, 27)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(165, 20)
        Me.txtRazonSocial.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(663, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 25)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Razón social"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescMetodoPago
        '
        Me.txtDescMetodoPago.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescMetodoPago.Location = New System.Drawing.Point(546, 77)
        Me.txtDescMetodoPago.Name = "txtDescMetodoPago"
        Me.txtDescMetodoPago.Size = New System.Drawing.Size(111, 20)
        Me.txtDescMetodoPago.TabIndex = 35
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(663, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 26)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "Moneda"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodMoneda
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtCodMoneda, 2)
        Me.txtCodMoneda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodMoneda.Location = New System.Drawing.Point(743, 77)
        Me.txtCodMoneda.Name = "txtCodMoneda"
        Me.txtCodMoneda.Size = New System.Drawing.Size(56, 20)
        Me.txtCodMoneda.TabIndex = 27
        '
        'txtDescMoneda
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtDescMoneda, 2)
        Me.txtDescMoneda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescMoneda.Location = New System.Drawing.Point(805, 77)
        Me.txtDescMoneda.Name = "txtDescMoneda"
        Me.txtDescMoneda.Size = New System.Drawing.Size(103, 20)
        Me.txtDescMoneda.TabIndex = 28
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(914, 74)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 26)
        Me.Label22.TabIndex = 36
        Me.Label22.Text = "Nº Tarjeta"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNroTarjeta
        '
        Me.txtNroTarjeta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNroTarjeta.Location = New System.Drawing.Point(991, 77)
        Me.txtNroTarjeta.Name = "txtNroTarjeta"
        Me.txtNroTarjeta.Size = New System.Drawing.Size(114, 20)
        Me.txtNroTarjeta.TabIndex = 37
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTipoCambio.Location = New System.Drawing.Point(991, 52)
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Size = New System.Drawing.Size(114, 20)
        Me.txtTipoCambio.TabIndex = 30
        '
        'txtCuf
        '
        Me.txtCuf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCuf.Location = New System.Drawing.Point(991, 27)
        Me.txtCuf.Name = "txtCuf"
        Me.txtCuf.Size = New System.Drawing.Size(114, 20)
        Me.txtCuf.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(914, 49)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 25)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "T.C."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(914, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 25)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "C.U.F."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsuario
        '
        Me.txtUsuario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtUsuario.Location = New System.Drawing.Point(991, 103)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(114, 20)
        Me.txtUsuario.TabIndex = 34
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(914, 100)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 24)
        Me.Label21.TabIndex = 33
        Me.Label21.Text = "Usuario"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label11, 2)
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(466, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 24)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Nro Factura"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtFechaEmision
        '
        Me.dtFechaEmision.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaEmision.Location = New System.Drawing.Point(991, 3)
        Me.dtFechaEmision.Name = "dtFechaEmision"
        Me.dtFechaEmision.Size = New System.Drawing.Size(114, 20)
        Me.dtFechaEmision.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label12, 2)
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(861, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 24)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Fecha de Emisión"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.TableLayoutPanel5.SetColumnSpan(Me.Label23, 2)
        Me.Label23.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(377, 49)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(43, 25)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "Sector"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodSector
        '
        Me.TableLayoutPanel5.SetColumnSpan(Me.txtCodSector, 2)
        Me.txtCodSector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCodSector.Location = New System.Drawing.Point(466, 52)
        Me.txtCodSector.Name = "txtCodSector"
        Me.txtCodSector.Size = New System.Drawing.Size(74, 20)
        Me.txtCodSector.TabIndex = 39
        '
        'txtDescSector
        '
        Me.txtDescSector.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescSector.Location = New System.Drawing.Point(546, 52)
        Me.txtDescSector.Name = "txtDescSector"
        Me.txtDescSector.Size = New System.Drawing.Size(111, 20)
        Me.txtDescSector.TabIndex = 40
        '
        'GroupBox2
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox2, 3)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 158)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1128, 275)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos Factura..."
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.dgv, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox1, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox2, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label6, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.lblLiteral, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label7, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.lblCodigoControl, 1, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1122, 254)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.BackgroundColor = System.Drawing.Color.White
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TableLayoutPanel3.SetColumnSpan(Me.dgv, 6)
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv.Location = New System.Drawing.Point(3, 3)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(1116, 174)
        Me.dgv.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(829, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Total Con Descuento:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(829, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 19)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(953, 183)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(98, 22)
        Me.TextBox1.TabIndex = 4
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(953, 207)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(98, 22)
        Me.TextBox2.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Location = New System.Drawing.Point(55, 204)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 19)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Literal:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLiteral
        '
        Me.lblLiteral.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.lblLiteral, 2)
        Me.lblLiteral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLiteral.Location = New System.Drawing.Point(106, 204)
        Me.lblLiteral.Name = "lblLiteral"
        Me.lblLiteral.Size = New System.Drawing.Size(717, 19)
        Me.lblLiteral.TabIndex = 8
        Me.lblLiteral.Text = "......"
        Me.lblLiteral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label7.Location = New System.Drawing.Point(39, 223)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 21)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Código de Control:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCodigoControl
        '
        Me.lblCodigoControl.AutoSize = True
        Me.TableLayoutPanel3.SetColumnSpan(Me.lblCodigoControl, 2)
        Me.lblCodigoControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCodigoControl.Location = New System.Drawing.Point(106, 223)
        Me.lblCodigoControl.Name = "lblCodigoControl"
        Me.lblCodigoControl.Size = New System.Drawing.Size(717, 21)
        Me.lblCodigoControl.TabIndex = 10
        Me.lblCodigoControl.Text = "......"
        Me.lblCodigoControl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox3, 3)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(3, 439)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1128, 74)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opiones..."
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 623.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnNuevo, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnAgregar, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnEliminar, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnImprimir, 4, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnSalir, 5, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 18)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(1122, 53)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNuevo.Location = New System.Drawing.Point(18, 11)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(79, 31)
        Me.btnNuevo.TabIndex = 0
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAgregar.Location = New System.Drawing.Point(103, 11)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(69, 31)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEliminar.Location = New System.Drawing.Point(178, 11)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 31)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnImprimir.Location = New System.Drawing.Point(268, 11)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(79, 31)
        Me.btnImprimir.TabIndex = 3
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalir.Location = New System.Drawing.Point(353, 11)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 31)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'UI_Factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 568)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "UI_Factura"
        Me.Text = "UI_Factura"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel2, 0)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLiteral As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblCodigoControl As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNitEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCuf As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCodTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtDescTipoDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNroDocumento As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtCodSucrusal As System.Windows.Forms.TextBox
    Friend WithEvents txtDescSucrusal As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtDescCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtComplemento As System.Windows.Forms.TextBox
    Friend WithEvents txtCodPago As System.Windows.Forms.TextBox
    Friend WithEvents txtDescMetodoPago As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtCodMoneda As System.Windows.Forms.TextBox
    Friend WithEvents txtDescMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtTipoCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtNroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtCodSector As System.Windows.Forms.TextBox
    Friend WithEvents txtDescSector As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
