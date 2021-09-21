<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_Cliente
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnComplemento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.gcComplementario = New DevExpress.XtraGrid.GridControl()
        Me.DsCliente1 = New WindApp.DSCliente()
        Me.gvComplementario = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colcodigoin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcodigosistema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcodUnidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkNegocio = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.coltipocliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkTipoCliente = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.coltelefono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcelular = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldireccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfregistro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colestado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCINit = New DevExpress.XtraEditors.TextEdit()
        Me.txtApellidos = New DevExpress.XtraEditors.TextEdit()
        Me.txtNombre = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodigoIN = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dxErrorProvider = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcComplementario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCliente1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvComplementario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCINit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApellidos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnComplemento)
        Me.LayoutControl1.Controls.Add(Me.btnSalir)
        Me.LayoutControl1.Controls.Add(Me.btnEliminar)
        Me.LayoutControl1.Controls.Add(Me.btnModificar)
        Me.LayoutControl1.Controls.Add(Me.btnAgregar)
        Me.LayoutControl1.Controls.Add(Me.gcComplementario)
        Me.LayoutControl1.Controls.Add(Me.txtCINit)
        Me.LayoutControl1.Controls.Add(Me.txtApellidos)
        Me.LayoutControl1.Controls.Add(Me.txtNombre)
        Me.LayoutControl1.Controls.Add(Me.txtCodigoIN)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(491, 397, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(857, 398)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnComplemento
        '
        Me.btnComplemento.Location = New System.Drawing.Point(424, 114)
        Me.btnComplemento.Name = "btnComplemento"
        Me.btnComplemento.Size = New System.Drawing.Size(102, 22)
        Me.btnComplemento.StyleController = Me.LayoutControl1
        Me.btnComplemento.TabIndex = 8
        Me.btnComplemento.Text = "Ir a complentos >>"
        '
        'btnSalir
        '
        Me.btnSalir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Appearance.Options.UseFont = True
        Me.btnSalir.Location = New System.Drawing.Point(351, 352)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(111, 22)
        Me.btnSalir.StyleController = Me.LayoutControl1
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        '
        'btnEliminar
        '
        Me.btnEliminar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Appearance.Options.UseFont = True
        Me.btnEliminar.Location = New System.Drawing.Point(248, 352)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(99, 22)
        Me.btnEliminar.StyleController = Me.LayoutControl1
        Me.btnEliminar.TabIndex = 6
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnModificar
        '
        Me.btnModificar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Appearance.Options.UseFont = True
        Me.btnModificar.Location = New System.Drawing.Point(136, 352)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(108, 22)
        Me.btnModificar.StyleController = Me.LayoutControl1
        Me.btnModificar.TabIndex = 5
        Me.btnModificar.Text = "Modificar"
        '
        'btnAgregar
        '
        Me.btnAgregar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Appearance.Options.UseFont = True
        Me.btnAgregar.Location = New System.Drawing.Point(24, 352)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(108, 22)
        Me.btnAgregar.StyleController = Me.LayoutControl1
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar"
        '
        'gcComplementario
        '
        Me.gcComplementario.DataMember = "tb_clientenegocio"
        Me.gcComplementario.DataSource = Me.DsCliente1
        Me.gcComplementario.Location = New System.Drawing.Point(24, 192)
        Me.gcComplementario.MainView = Me.gvComplementario
        Me.gcComplementario.Name = "gcComplementario"
        Me.gcComplementario.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkNegocio, Me.lkTipoCliente})
        Me.gcComplementario.Size = New System.Drawing.Size(809, 114)
        Me.gcComplementario.TabIndex = 9
        Me.gcComplementario.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvComplementario})
        '
        'DsCliente1
        '
        Me.DsCliente1.DataSetName = "DSCliente"
        Me.DsCliente1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gvComplementario
        '
        Me.gvComplementario.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colcodigoin, Me.colcodigosistema, Me.colcodUnidad, Me.coltipocliente, Me.coltelefono, Me.colcelular, Me.coldireccion, Me.colfregistro, Me.colestado})
        Me.gvComplementario.GridControl = Me.gcComplementario
        Me.gvComplementario.Name = "gvComplementario"
        Me.gvComplementario.OptionsView.ShowGroupPanel = False
        '
        'colcodigoin
        '
        Me.colcodigoin.Caption = "CODIGO I.N."
        Me.colcodigoin.FieldName = "codigoin"
        Me.colcodigoin.Name = "colcodigoin"
        Me.colcodigoin.Width = 76
        '
        'colcodigosistema
        '
        Me.colcodigosistema.Caption = "CODIGO SIS."
        Me.colcodigosistema.FieldName = "codigosistema"
        Me.colcodigosistema.Name = "colcodigosistema"
        Me.colcodigosistema.Visible = True
        Me.colcodigosistema.VisibleIndex = 0
        Me.colcodigosistema.Width = 73
        '
        'colcodUnidad
        '
        Me.colcodUnidad.Caption = "CICLO"
        Me.colcodUnidad.ColumnEdit = Me.lkNegocio
        Me.colcodUnidad.FieldName = "codunidad"
        Me.colcodUnidad.Name = "colcodUnidad"
        Me.colcodUnidad.Visible = True
        Me.colcodUnidad.VisibleIndex = 1
        Me.colcodUnidad.Width = 155
        '
        'lkNegocio
        '
        Me.lkNegocio.AutoHeight = False
        Me.lkNegocio.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkNegocio.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("coduneg", "Codigo", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("unidad", "Unidad")})
        Me.lkNegocio.Name = "lkNegocio"
        Me.lkNegocio.NullText = ""
        '
        'coltipocliente
        '
        Me.coltipocliente.Caption = "TIPO CLIENTE"
        Me.coltipocliente.ColumnEdit = Me.lkTipoCliente
        Me.coltipocliente.FieldName = "tipocliente"
        Me.coltipocliente.Name = "coltipocliente"
        Me.coltipocliente.Visible = True
        Me.coltipocliente.VisibleIndex = 2
        Me.coltipocliente.Width = 108
        '
        'lkTipoCliente
        '
        Me.lkTipoCliente.AutoHeight = False
        Me.lkTipoCliente.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkTipoCliente.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Codigo", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("descripcion", "Descripcion")})
        Me.lkTipoCliente.Name = "lkTipoCliente"
        Me.lkTipoCliente.NullText = ""
        '
        'coltelefono
        '
        Me.coltelefono.Caption = "TELEFONO"
        Me.coltelefono.FieldName = "telefono"
        Me.coltelefono.Name = "coltelefono"
        Me.coltelefono.Visible = True
        Me.coltelefono.VisibleIndex = 3
        Me.coltelefono.Width = 108
        '
        'colcelular
        '
        Me.colcelular.Caption = "CELULAR"
        Me.colcelular.FieldName = "celular"
        Me.colcelular.Name = "colcelular"
        Me.colcelular.Visible = True
        Me.colcelular.VisibleIndex = 4
        Me.colcelular.Width = 108
        '
        'coldireccion
        '
        Me.coldireccion.Caption = "DIRECCION"
        Me.coldireccion.FieldName = "direccion"
        Me.coldireccion.Name = "coldireccion"
        Me.coldireccion.Visible = True
        Me.coldireccion.VisibleIndex = 5
        Me.coldireccion.Width = 148
        '
        'colfregistro
        '
        Me.colfregistro.Caption = "F. REGISTRO"
        Me.colfregistro.FieldName = "fregistro"
        Me.colfregistro.Name = "colfregistro"
        '
        'colestado
        '
        Me.colestado.Caption = "ESTADO"
        Me.colestado.FieldName = "estado"
        Me.colestado.Name = "colestado"
        Me.colestado.Visible = True
        Me.colestado.VisibleIndex = 6
        Me.colestado.Width = 91
        '
        'txtCINit
        '
        Me.txtCINit.EditValue = ""
        Me.txtCINit.Location = New System.Drawing.Point(69, 114)
        Me.txtCINit.Name = "txtCINit"
        Me.txtCINit.Properties.Mask.EditMask = "d"
        Me.txtCINit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCINit.Size = New System.Drawing.Size(245, 20)
        Me.txtCINit.StyleController = Me.LayoutControl1
        Me.txtCINit.TabIndex = 3
        '
        'txtApellidos
        '
        Me.txtApellidos.Location = New System.Drawing.Point(69, 90)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellidos.Size = New System.Drawing.Size(452, 20)
        Me.txtApellidos.StyleController = Me.LayoutControl1
        Me.txtApellidos.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(69, 66)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Size = New System.Drawing.Size(452, 20)
        Me.txtNombre.StyleController = Me.LayoutControl1
        Me.txtNombre.TabIndex = 1
        '
        'txtCodigoIN
        '
        Me.txtCodigoIN.Location = New System.Drawing.Point(69, 42)
        Me.txtCodigoIN.Name = "txtCodigoIN"
        Me.txtCodigoIN.Properties.Mask.EditMask = "d"
        Me.txtCodigoIN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCodigoIN.Size = New System.Drawing.Size(87, 20)
        Me.txtCodigoIN.StyleController = Me.LayoutControl1
        Me.txtCodigoIN.TabIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3, Me.LayoutControlGroup4})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(857, 398)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem1, Me.EmptySpaceItem3, Me.LayoutControlItem2, Me.EmptySpaceItem4, Me.LayoutControlItem3, Me.EmptySpaceItem5, Me.LayoutControlItem4, Me.EmptySpaceItem6, Me.LayoutControlItem7, Me.EmptySpaceItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(837, 150)
        Me.LayoutControlGroup2.Text = "Datos Clientes"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 98)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(813, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCodigoIN
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(136, 24)
        Me.LayoutControlItem1.Text = "Codigo"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(42, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(136, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(677, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtNombre
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(501, 24)
        Me.LayoutControlItem2.Text = "Nombre"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(42, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(501, 24)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(312, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtApellidos
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(501, 24)
        Me.LayoutControlItem3.Text = "Apellidos"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(42, 13)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(501, 48)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(312, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtCINit
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(294, 26)
        Me.LayoutControlItem4.Text = "CI/NIT"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(42, 13)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(294, 72)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(106, 26)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnComplemento
        Me.LayoutControlItem7.Location = New System.Drawing.Point(400, 72)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(106, 26)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(506, 72)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(307, 26)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 150)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(837, 160)
        Me.LayoutControlGroup3.Text = "Datos Complementarios"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.gcComplementario
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(813, 118)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem7, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 310)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(837, 68)
        Me.LayoutControlGroup4.Text = "Opciones"
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(442, 0)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(371, 26)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnSalir
        Me.LayoutControlItem6.Location = New System.Drawing.Point(327, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(115, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnEliminar
        Me.LayoutControlItem8.Location = New System.Drawing.Point(224, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(103, 26)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnModificar
        Me.LayoutControlItem9.Location = New System.Drawing.Point(112, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnAgregar
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(112, 26)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'dxErrorProvider
        '
        Me.dxErrorProvider.ContainerControl = Me
        '
        'UI_Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 450)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "UI_Cliente"
        Me.Text = "UI_Cliente"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcComplementario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCliente1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvComplementario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCINit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApellidos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtCINit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtApellidos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodigoIN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents gcComplementario As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvComplementario As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dxErrorProvider As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents DsCliente1 As WindApp.DSCliente
    Friend WithEvents colcodigoin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcodigosistema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcodUnidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltipocliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltelefono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcelular As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldireccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfregistro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colestado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkNegocio As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents lkTipoCliente As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents btnComplemento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
