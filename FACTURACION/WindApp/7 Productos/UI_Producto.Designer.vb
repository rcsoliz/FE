<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_Producto
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
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtCodigoProd = New System.Windows.Forms.TextBox()
        Me.txtDescProd = New System.Windows.Forms.TextBox()
        Me.txtEmbaseProd = New System.Windows.Forms.TextBox()
        Me.txtDescEmbase = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnInicio = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnFin = New System.Windows.Forms.Button()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.txtDescActEconomicaSIN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtActEconomicaSIN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCodigoSIN = New System.Windows.Forms.TextBox()
        Me.txtCodAndinaSIN = New System.Windows.Forms.TextBox()
        Me.txtUniMedidaSIN = New System.Windows.Forms.TextBox()
        Me.txtDescCodigoSIN = New System.Windows.Forms.TextBox()
        Me.txtDescCodAndinaSIN = New System.Windows.Forms.TextBox()
        Me.txtDescUniMedidaSIN = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 377.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.GroupBox2, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 52)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(643, 416)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'GroupBox1
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox1, 3)
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Productos"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 99.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TxtCodigoProd, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDescProd, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.txtEmbaseProd, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.txtDescEmbase, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 1, 3)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 5
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(631, 106)
        Me.TableLayoutPanel3.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtCodigoProd
        '
        Me.TxtCodigoProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TxtCodigoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TxtCodigoProd.Location = New System.Drawing.Point(111, 18)
        Me.TxtCodigoProd.Name = "TxtCodigoProd"
        Me.TxtCodigoProd.Size = New System.Drawing.Size(74, 20)
        Me.TxtCodigoProd.TabIndex = 3
        '
        'txtDescProd
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtDescProd, 4)
        Me.txtDescProd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescProd.Location = New System.Drawing.Point(111, 45)
        Me.txtDescProd.Name = "txtDescProd"
        Me.txtDescProd.Size = New System.Drawing.Size(508, 20)
        Me.txtDescProd.TabIndex = 4
        '
        'txtEmbaseProd
        '
        Me.txtEmbaseProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmbaseProd.Location = New System.Drawing.Point(111, 72)
        Me.txtEmbaseProd.Name = "txtEmbaseProd"
        Me.txtEmbaseProd.Size = New System.Drawing.Size(74, 20)
        Me.txtEmbaseProd.TabIndex = 8
        '
        'txtDescEmbase
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.txtDescEmbase, 2)
        Me.txtDescEmbase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescEmbase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescEmbase.Location = New System.Drawing.Point(191, 72)
        Me.txtDescEmbase.Name = "txtDescEmbase"
        Me.txtDescEmbase.Size = New System.Drawing.Size(302, 20)
        Me.txtDescEmbase.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Embase"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox3, 3)
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 340)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(637, 73)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 8
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 396.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnAgregar, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnModificar, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnEliminar, 3, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnSalir, 4, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(631, 53)
        Me.TableLayoutPanel4.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAgregar.Location = New System.Drawing.Point(23, 11)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(83, 31)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "&Guardar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnModificar.Location = New System.Drawing.Point(112, 11)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(82, 31)
        Me.btnModificar.TabIndex = 1
        Me.btnModificar.Text = "Modiifcar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnEliminar.Location = New System.Drawing.Point(200, 11)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(77, 31)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSalir.Location = New System.Drawing.Point(283, 11)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(74, 31)
        Me.btnSalir.TabIndex = 4
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 7
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.btnInicio, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnAnterior, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnSiguiente, 4, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnFin, 5, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblRegistros, 6, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(129, 284)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 3
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(371, 50)
        Me.TableLayoutPanel5.TabIndex = 0
        '
        'btnInicio
        '
        Me.btnInicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicio.Location = New System.Drawing.Point(49, 11)
        Me.btnInicio.Name = "btnInicio"
        Me.btnInicio.Size = New System.Drawing.Size(46, 28)
        Me.btnInicio.TabIndex = 0
        Me.btnInicio.Text = "<<"
        Me.btnInicio.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAnterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAnterior.Location = New System.Drawing.Point(101, 11)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(44, 28)
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.Text = "<"
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.Location = New System.Drawing.Point(151, 11)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(42, 28)
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = ">"
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnFin
        '
        Me.btnFin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFin.Location = New System.Drawing.Point(199, 11)
        Me.btnFin.Name = "btnFin"
        Me.btnFin.Size = New System.Drawing.Size(46, 28)
        Me.btnFin.TabIndex = 3
        Me.btnFin.Text = ">>"
        Me.btnFin.UseVisualStyleBackColor = True
        '
        'lblRegistros
        '
        Me.lblRegistros.AutoSize = True
        Me.lblRegistros.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblRegistros.Location = New System.Drawing.Point(251, 8)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(51, 34)
        Me.lblRegistros.TabIndex = 4
        Me.lblRegistros.Text = "Registros"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.GroupBox2, 3)
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel6)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 143)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Parámetros S.I.N."
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 6
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.txtDescActEconomicaSIN, 3, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label3, 1, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.txtActEconomicaSIN, 2, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 1, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.Label6, 1, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.Label7, 1, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.txtCodigoSIN, 2, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtCodAndinaSIN, 2, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.txtUniMedidaSIN, 2, 4)
        Me.TableLayoutPanel6.Controls.Add(Me.txtDescCodigoSIN, 3, 2)
        Me.TableLayoutPanel6.Controls.Add(Me.txtDescCodAndinaSIN, 3, 3)
        Me.TableLayoutPanel6.Controls.Add(Me.txtDescUniMedidaSIN, 3, 4)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 17)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 6
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(631, 123)
        Me.TableLayoutPanel6.TabIndex = 0
        '
        'txtDescActEconomicaSIN
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.txtDescActEconomicaSIN, 2)
        Me.txtDescActEconomicaSIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescActEconomicaSIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescActEconomicaSIN.Location = New System.Drawing.Point(212, 14)
        Me.txtDescActEconomicaSIN.Name = "txtDescActEconomicaSIN"
        Me.txtDescActEconomicaSIN.Size = New System.Drawing.Size(284, 20)
        Me.txtDescActEconomicaSIN.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(11, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Actividad Economica"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtActEconomicaSIN
        '
        Me.txtActEconomicaSIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActEconomicaSIN.Location = New System.Drawing.Point(142, 14)
        Me.txtActEconomicaSIN.Name = "txtActEconomicaSIN"
        Me.txtActEconomicaSIN.Size = New System.Drawing.Size(64, 20)
        Me.txtActEconomicaSIN.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Location = New System.Drawing.Point(11, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 26)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Codigo S.I.N."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(11, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 25)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Codigo Andina"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(11, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 25)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Unidad de Medida"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCodigoSIN
        '
        Me.txtCodigoSIN.Location = New System.Drawing.Point(142, 39)
        Me.txtCodigoSIN.Name = "txtCodigoSIN"
        Me.txtCodigoSIN.Size = New System.Drawing.Size(64, 21)
        Me.txtCodigoSIN.TabIndex = 10
        '
        'txtCodAndinaSIN
        '
        Me.txtCodAndinaSIN.Location = New System.Drawing.Point(142, 65)
        Me.txtCodAndinaSIN.Name = "txtCodAndinaSIN"
        Me.txtCodAndinaSIN.Size = New System.Drawing.Size(64, 21)
        Me.txtCodAndinaSIN.TabIndex = 11
        '
        'txtUniMedidaSIN
        '
        Me.txtUniMedidaSIN.Location = New System.Drawing.Point(142, 90)
        Me.txtUniMedidaSIN.Name = "txtUniMedidaSIN"
        Me.txtUniMedidaSIN.Size = New System.Drawing.Size(64, 21)
        Me.txtUniMedidaSIN.TabIndex = 12
        '
        'txtDescCodigoSIN
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.txtDescCodigoSIN, 2)
        Me.txtDescCodigoSIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescCodigoSIN.Location = New System.Drawing.Point(212, 39)
        Me.txtDescCodigoSIN.Name = "txtDescCodigoSIN"
        Me.txtDescCodigoSIN.Size = New System.Drawing.Size(284, 21)
        Me.txtDescCodigoSIN.TabIndex = 13
        '
        'txtDescCodAndinaSIN
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.txtDescCodAndinaSIN, 2)
        Me.txtDescCodAndinaSIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescCodAndinaSIN.Location = New System.Drawing.Point(212, 65)
        Me.txtDescCodAndinaSIN.Name = "txtDescCodAndinaSIN"
        Me.txtDescCodAndinaSIN.Size = New System.Drawing.Size(284, 21)
        Me.txtDescCodAndinaSIN.TabIndex = 14
        '
        'txtDescUniMedidaSIN
        '
        Me.TableLayoutPanel6.SetColumnSpan(Me.txtDescUniMedidaSIN, 2)
        Me.txtDescUniMedidaSIN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescUniMedidaSIN.Location = New System.Drawing.Point(212, 90)
        Me.txtDescUniMedidaSIN.Name = "txtDescUniMedidaSIN"
        Me.txtDescUniMedidaSIN.Size = New System.Drawing.Size(284, 21)
        Me.txtDescUniMedidaSIN.TabIndex = 15
        '
        'UI_Producto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(643, 468)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "UI_Producto"
        Me.Text = "UI_Productos"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel2, 0)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodigoProd As System.Windows.Forms.TextBox
    Friend WithEvents txtDescProd As System.Windows.Forms.TextBox
    Friend WithEvents txtActEconomicaSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtDescActEconomicaSIN As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmbaseProd As System.Windows.Forms.TextBox
    Friend WithEvents txtDescEmbase As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnInicio As System.Windows.Forms.Button
    Friend WithEvents btnAnterior As System.Windows.Forms.Button
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnFin As System.Windows.Forms.Button
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAndinaSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtUniMedidaSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtDescCodigoSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtDescCodAndinaSIN As System.Windows.Forms.TextBox
    Friend WithEvents txtDescUniMedidaSIN As System.Windows.Forms.TextBox
End Class
