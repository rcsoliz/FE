<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UB_CarteraClientes
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnSalir = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExportar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnModificar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.gcClienteCom = New DevExpress.XtraGrid.GridControl()
        Me.DsCliente1 = New WindApp.DSCliente()
        Me.gvClienteCom = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colcodigoin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcodigosistema = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colnitci = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcodUnidad = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkNegocio = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.coltipocliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lkTipoCliente = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.coltelefono = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcelular = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.coldireccion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colfregistro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colestado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcClienteCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCliente1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvClienteCom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lkTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnSalir)
        Me.LayoutControl1.Controls.Add(Me.btnExportar)
        Me.LayoutControl1.Controls.Add(Me.btnEliminar)
        Me.LayoutControl1.Controls.Add(Me.btnModificar)
        Me.LayoutControl1.Controls.Add(Me.btnAgregar)
        Me.LayoutControl1.Controls.Add(Me.gcClienteCom)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(487, 90, 650, 400)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1053, 437)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnSalir
        '
        Me.btnSalir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Appearance.Options.UseFont = True
        Me.btnSalir.Location = New System.Drawing.Point(377, 391)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 22)
        Me.btnSalir.StyleController = Me.LayoutControl1
        Me.btnSalir.TabIndex = 22
        Me.btnSalir.Text = "Salir"
        '
        'btnExportar
        '
        Me.btnExportar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Appearance.Options.UseFont = True
        Me.btnExportar.Location = New System.Drawing.Point(282, 391)
        Me.btnExportar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(91, 22)
        Me.btnExportar.StyleController = Me.LayoutControl1
        Me.btnExportar.TabIndex = 21
        Me.btnExportar.Text = "Exportar"
        '
        'btnEliminar
        '
        Me.btnEliminar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Appearance.Options.UseFont = True
        Me.btnEliminar.Location = New System.Drawing.Point(194, 391)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(84, 22)
        Me.btnEliminar.StyleController = Me.LayoutControl1
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.Text = "Eliminar"
        '
        'btnModificar
        '
        Me.btnModificar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Appearance.Options.UseFont = True
        Me.btnModificar.Location = New System.Drawing.Point(112, 391)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(78, 22)
        Me.btnModificar.StyleController = Me.LayoutControl1
        Me.btnModificar.TabIndex = 19
        Me.btnModificar.Text = "Modificar"
        '
        'btnAgregar
        '
        Me.btnAgregar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Appearance.Options.UseFont = True
        Me.btnAgregar.Location = New System.Drawing.Point(24, 391)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(84, 22)
        Me.btnAgregar.StyleController = Me.LayoutControl1
        Me.btnAgregar.TabIndex = 18
        Me.btnAgregar.Text = "Agregar"
        '
        'gcClienteCom
        '
        Me.gcClienteCom.DataMember = "tb_clientenegocio"
        Me.gcClienteCom.DataSource = Me.DsCliente1
        Me.gcClienteCom.Location = New System.Drawing.Point(24, 43)
        Me.gcClienteCom.MainView = Me.gvClienteCom
        Me.gcClienteCom.Name = "gcClienteCom"
        Me.gcClienteCom.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.lkNegocio, Me.lkTipoCliente})
        Me.gcClienteCom.Size = New System.Drawing.Size(1005, 301)
        Me.gcClienteCom.TabIndex = 4
        Me.gcClienteCom.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvClienteCom})
        '
        'DsCliente1
        '
        Me.DsCliente1.DataSetName = "DSCliente"
        Me.DsCliente1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gvClienteCom
        '
        Me.gvClienteCom.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colcodigoin, Me.colcodigosistema, Me.colnombre, Me.colnitci, Me.colcodUnidad, Me.coltipocliente, Me.coltelefono, Me.colcelular, Me.coldireccion, Me.colfregistro, Me.colestado})
        Me.gvClienteCom.GridControl = Me.gcClienteCom
        Me.gvClienteCom.Name = "gvClienteCom"
        Me.gvClienteCom.OptionsFind.AlwaysVisible = True
        Me.gvClienteCom.OptionsFind.ShowClearButton = False
        Me.gvClienteCom.OptionsFind.ShowCloseButton = False
        Me.gvClienteCom.OptionsFind.ShowFindButton = False
        Me.gvClienteCom.OptionsView.ShowAutoFilterRow = True
        '
        'colcodigoin
        '
        Me.colcodigoin.Caption = "Codigo I.N."
        Me.colcodigoin.FieldName = "codigoin"
        Me.colcodigoin.Name = "colcodigoin"
        '
        'colcodigosistema
        '
        Me.colcodigosistema.Caption = "Codigo Sist."
        Me.colcodigosistema.FieldName = "codigosistema"
        Me.colcodigosistema.Name = "colcodigosistema"
        Me.colcodigosistema.Visible = True
        Me.colcodigosistema.VisibleIndex = 0
        Me.colcodigosistema.Width = 69
        '
        'colnombre
        '
        Me.colnombre.Caption = "Nombre"
        Me.colnombre.FieldName = "nombre"
        Me.colnombre.Name = "colnombre"
        Me.colnombre.Visible = True
        Me.colnombre.VisibleIndex = 1
        Me.colnombre.Width = 198
        '
        'colnitci
        '
        Me.colnitci.Caption = "Nit./C.I."
        Me.colnitci.FieldName = "nitci"
        Me.colnitci.Name = "colnitci"
        Me.colnitci.Visible = True
        Me.colnitci.VisibleIndex = 2
        Me.colnitci.Width = 138
        '
        'colcodUnidad
        '
        Me.colcodUnidad.Caption = "Unidad de Negocio"
        Me.colcodUnidad.ColumnEdit = Me.lkNegocio
        Me.colcodUnidad.FieldName = "codunidad"
        Me.colcodUnidad.Name = "colcodUnidad"
        Me.colcodUnidad.Visible = True
        Me.colcodUnidad.VisibleIndex = 3
        Me.colcodUnidad.Width = 177
        '
        'lkNegocio
        '
        Me.lkNegocio.AutoHeight = False
        Me.lkNegocio.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkNegocio.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("coduneg", "Codigo", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("unidad", "Unidad de Negocio")})
        Me.lkNegocio.Name = "lkNegocio"
        Me.lkNegocio.NullText = ""
        '
        'coltipocliente
        '
        Me.coltipocliente.Caption = "Tipo Cliente"
        Me.coltipocliente.ColumnEdit = Me.lkTipoCliente
        Me.coltipocliente.FieldName = "tipocliente"
        Me.coltipocliente.Name = "coltipocliente"
        Me.coltipocliente.Visible = True
        Me.coltipocliente.VisibleIndex = 4
        Me.coltipocliente.Width = 128
        '
        'lkTipoCliente
        '
        Me.lkTipoCliente.AutoHeight = False
        Me.lkTipoCliente.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.lkTipoCliente.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("codigo", "Codigo", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("descripcion", "Tipo Cliente")})
        Me.lkTipoCliente.Name = "lkTipoCliente"
        Me.lkTipoCliente.NullText = ""
        '
        'coltelefono
        '
        Me.coltelefono.Caption = "Telefono"
        Me.coltelefono.FieldName = "telefono"
        Me.coltelefono.Name = "coltelefono"
        Me.coltelefono.Visible = True
        Me.coltelefono.VisibleIndex = 5
        Me.coltelefono.Width = 73
        '
        'colcelular
        '
        Me.colcelular.Caption = "Celular"
        Me.colcelular.FieldName = "celular"
        Me.colcelular.Name = "colcelular"
        Me.colcelular.Visible = True
        Me.colcelular.VisibleIndex = 6
        Me.colcelular.Width = 56
        '
        'coldireccion
        '
        Me.coldireccion.Caption = "Dirección"
        Me.coldireccion.FieldName = "direccion"
        Me.coldireccion.Name = "coldireccion"
        Me.coldireccion.Visible = True
        Me.coldireccion.VisibleIndex = 7
        Me.coldireccion.Width = 82
        '
        'colfregistro
        '
        Me.colfregistro.Caption = "F. Registro"
        Me.colfregistro.FieldName = "fregistro"
        Me.colfregistro.Name = "colfregistro"
        '
        'colestado
        '
        Me.colestado.Caption = "Estado"
        Me.colestado.FieldName = "estado"
        Me.colestado.Name = "colestado"
        Me.colestado.Visible = True
        Me.colestado.VisibleIndex = 8
        Me.colestado.Width = 66
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1053, 437)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup2.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup2.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1033, 348)
        Me.LayoutControlGroup2.Text = "Datos Clientes"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.gcClienteCom
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1009, 305)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.AppearanceGroup.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup3.AppearanceItemCaption.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup3.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem3, Me.LayoutControlItem2})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 348)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1033, 69)
        Me.LayoutControlGroup3.Text = "Opciones"
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(442, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(567, 26)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnAgregar
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(88, 26)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.btnModificar
        Me.LayoutControlItem5.Location = New System.Drawing.Point(88, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(82, 26)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnEliminar
        Me.LayoutControlItem4.Location = New System.Drawing.Point(170, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(88, 26)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnExportar
        Me.LayoutControlItem3.Location = New System.Drawing.Point(258, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(95, 26)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnSalir
        Me.LayoutControlItem2.Location = New System.Drawing.Point(353, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(89, 26)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'UB_CarteraClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 489)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "UB_CarteraClientes"
        Me.Text = "UI_Cartera de Clientes"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcClienteCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCliente1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvClienteCom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lkTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents gcClienteCom As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvClienteCom As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DsCliente1 As WindApp.DSCliente
    Friend WithEvents colcodigoin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcodigosistema As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colnitci As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcodUnidad As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltipocliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coltelefono As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcelular As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents coldireccion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colfregistro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colestado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lkTipoCliente As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Private WithEvents lkNegocio As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnSalir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExportar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnModificar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
