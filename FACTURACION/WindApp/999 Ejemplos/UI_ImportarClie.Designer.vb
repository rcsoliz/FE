<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UI_ImportarClie
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
        Me.txtCodDoc = New DevExpress.XtraEditors.TextEdit()
        Me.btnListar = New DevExpress.XtraEditors.SimpleButton()
        Me.gcCliente = New DevExpress.XtraGrid.GridControl()
        Me.gvCliente = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtActividad = New DevExpress.XtraEditors.TextEdit()
        Me.btnAlta = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUnidad = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTCliente = New DevExpress.XtraEditors.TextEdit()
        Me.btnExportar = New DevExpress.XtraEditors.SimpleButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gcComp = New DevExpress.XtraGrid.GridControl()
        Me.gvComp = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.txtCodDoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActividad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtUnidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gcComp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvComp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodDoc
        '
        Me.txtCodDoc.EditValue = "99014"
        Me.txtCodDoc.Location = New System.Drawing.Point(13, 39)
        Me.txtCodDoc.Name = "txtCodDoc"
        Me.txtCodDoc.Size = New System.Drawing.Size(100, 20)
        Me.txtCodDoc.TabIndex = 2
        '
        'btnListar
        '
        Me.btnListar.Location = New System.Drawing.Point(552, 37)
        Me.btnListar.Name = "btnListar"
        Me.btnListar.Size = New System.Drawing.Size(75, 23)
        Me.btnListar.TabIndex = 5
        Me.btnListar.Text = "Listar"
        '
        'gcCliente
        '
        Me.gcCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCliente.Location = New System.Drawing.Point(3, 3)
        Me.gcCliente.MainView = Me.gvCliente
        Me.gcCliente.Name = "gcCliente"
        Me.gcCliente.Size = New System.Drawing.Size(876, 328)
        Me.gcCliente.TabIndex = 6
        Me.gcCliente.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCliente})
        '
        'gvCliente
        '
        Me.gvCliente.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn6, Me.GridColumn7})
        Me.gvCliente.GridControl = Me.gcCliente
        Me.gvCliente.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ci_ruc", Nothing, "")})
        Me.gvCliente.Name = "gvCliente"
        Me.gvCliente.OptionsView.ShowAutoFilterRow = True
        Me.gvCliente.OptionsView.ShowFooter = True
        Me.gvCliente.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "C.I."
        Me.GridColumn1.FieldName = "nitci"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ci_ruc", "{0}")})
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nombre"
        Me.GridColumn2.FieldName = "nombre"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 217
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "APELLIDOS"
        Me.GridColumn3.FieldName = "apellido"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 216
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "ACTIVIDAD"
        Me.GridColumn4.FieldName = "cod_actividad"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 86
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "COD. CLI/PROV"
        Me.GridColumn6.FieldName = "codigo"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 80
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "COD. I.N."
        Me.GridColumn7.FieldName = "codigoin"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 93
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(77, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Tipo Movimiento"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(139, 20)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Actividad"
        '
        'txtActividad
        '
        Me.txtActividad.EditValue = "3"
        Me.txtActividad.Location = New System.Drawing.Point(148, 39)
        Me.txtActividad.Name = "txtActividad"
        Me.txtActividad.Size = New System.Drawing.Size(54, 20)
        Me.txtActividad.TabIndex = 4
        '
        'btnAlta
        '
        Me.btnAlta.Location = New System.Drawing.Point(798, 36)
        Me.btnAlta.Name = "btnAlta"
        Me.btnAlta.Size = New System.Drawing.Size(75, 23)
        Me.btnAlta.TabIndex = 9
        Me.btnAlta.Text = "Alta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelControl4)
        Me.GroupBox1.Controls.Add(Me.txtUnidad)
        Me.GroupBox1.Controls.Add(Me.LabelControl3)
        Me.GroupBox1.Controls.Add(Me.txtTCliente)
        Me.GroupBox1.Controls.Add(Me.btnExportar)
        Me.GroupBox1.Controls.Add(Me.txtActividad)
        Me.GroupBox1.Controls.Add(Me.LabelControl2)
        Me.GroupBox1.Controls.Add(Me.btnAlta)
        Me.GroupBox1.Controls.Add(Me.LabelControl1)
        Me.GroupBox1.Controls.Add(Me.txtCodDoc)
        Me.GroupBox1.Controls.Add(Me.btnListar)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(890, 69)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parámetros"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(407, 20)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(106, 13)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "CODIGO UNDAD NEG."
        '
        'txtUnidad
        '
        Me.txtUnidad.EditValue = "2"
        Me.txtUnidad.Location = New System.Drawing.Point(407, 38)
        Me.txtUnidad.Name = "txtUnidad"
        Me.txtUnidad.Size = New System.Drawing.Size(100, 20)
        Me.txtUnidad.TabIndex = 13
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(212, 20)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(183, 13)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "T. CLIENTE 10001 || PROV 10002"
        '
        'txtTCliente
        '
        Me.txtTCliente.EditValue = "10001"
        Me.txtTCliente.Location = New System.Drawing.Point(232, 38)
        Me.txtTCliente.Name = "txtTCliente"
        Me.txtTCliente.Size = New System.Drawing.Size(100, 20)
        Me.txtTCliente.TabIndex = 12
        '
        'btnExportar
        '
        Me.btnExportar.Location = New System.Drawing.Point(798, 7)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(75, 23)
        Me.btnExportar.TabIndex = 10
        Me.btnExportar.Text = "Exportar"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 130)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(890, 362)
        Me.TabControl1.TabIndex = 12
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gcCliente)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(882, 334)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Base Cliente"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gcComp)
        Me.TabPage2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(882, 334)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Datos Complementarios"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gcComp
        '
        Me.gcComp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcComp.Location = New System.Drawing.Point(3, 3)
        Me.gcComp.MainView = Me.gvComp
        Me.gcComp.Name = "gcComp"
        Me.gcComp.Size = New System.Drawing.Size(876, 328)
        Me.gcComp.TabIndex = 0
        Me.gcComp.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvComp})
        '
        'gvComp
        '
        Me.gvComp.GridControl = Me.gcComp
        Me.gvComp.Name = "gvComp"
        Me.gvComp.OptionsView.ShowGroupPanel = False
        '
        'UI_ImportarClie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 498)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "UI_ImportarClie"
        Me.Text = "UI_ImportarClie"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.txtCodDoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActividad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtUnidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gcComp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvComp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtCodDoc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnListar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gcCliente As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCliente As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtActividad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAlta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gcComp As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvComp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTCliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUnidad As DevExpress.XtraEditors.TextEdit
End Class
