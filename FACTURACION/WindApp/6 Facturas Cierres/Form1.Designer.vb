<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.DsParametro1 = New WindApp.DSParametro()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colpacodigo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpadescri = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpavalor1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colpavalor2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcal1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcal2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcal3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnCal1 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCal1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtCal2 = New DevExpress.XtraEditors.TextEdit()
        Me.btnCal2 = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCal3 = New DevExpress.XtraEditors.TextEdit()
        Me.btnCal3 = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsParametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCal1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCal2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCal3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.DataMember = "tbparametro"
        Me.GridControl1.DataSource = Me.DsParametro1
        Me.GridControl1.Location = New System.Drawing.Point(12, 125)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(552, 324)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'DsParametro1
        '
        Me.DsParametro1.DataSetName = "DSParametro"
        Me.DsParametro1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colpacodigo, Me.colpadescri, Me.colpavalor1, Me.colpavalor2, Me.colcal1, Me.colcal2, Me.colcal3})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'colpacodigo
        '
        Me.colpacodigo.FieldName = "pacodigo"
        Me.colpacodigo.Name = "colpacodigo"
        Me.colpacodigo.Visible = True
        Me.colpacodigo.VisibleIndex = 0
        '
        'colpadescri
        '
        Me.colpadescri.FieldName = "padescri"
        Me.colpadescri.Name = "colpadescri"
        Me.colpadescri.Visible = True
        Me.colpadescri.VisibleIndex = 1
        '
        'colpavalor1
        '
        Me.colpavalor1.FieldName = "pavalor1"
        Me.colpavalor1.Name = "colpavalor1"
        Me.colpavalor1.Visible = True
        Me.colpavalor1.VisibleIndex = 2
        '
        'colpavalor2
        '
        Me.colpavalor2.FieldName = "pavalor2"
        Me.colpavalor2.Name = "colpavalor2"
        Me.colpavalor2.Visible = True
        Me.colpavalor2.VisibleIndex = 3
        '
        'colcal1
        '
        Me.colcal1.FieldName = "cal1"
        Me.colcal1.Name = "colcal1"
        Me.colcal1.Visible = True
        Me.colcal1.VisibleIndex = 4
        '
        'colcal2
        '
        Me.colcal2.FieldName = "cal2"
        Me.colcal2.Name = "colcal2"
        Me.colcal2.Visible = True
        Me.colcal2.VisibleIndex = 5
        '
        'colcal3
        '
        Me.colcal3.FieldName = "cal3"
        Me.colcal3.Name = "colcal3"
        Me.colcal3.Visible = True
        Me.colcal3.VisibleIndex = 6
        '
        'btnCal1
        '
        Me.btnCal1.Location = New System.Drawing.Point(146, 32)
        Me.btnCal1.Name = "btnCal1"
        Me.btnCal1.Size = New System.Drawing.Size(75, 23)
        Me.btnCal1.TabIndex = 1
        Me.btnCal1.Text = "Opcion 1"
        '
        'txtCal1
        '
        Me.txtCal1.EditValue = "15"
        Me.txtCal1.Location = New System.Drawing.Point(27, 34)
        Me.txtCal1.Name = "txtCal1"
        Me.txtCal1.Size = New System.Drawing.Size(100, 20)
        Me.txtCal1.TabIndex = 2
        '
        'txtCal2
        '
        Me.txtCal2.Location = New System.Drawing.Point(27, 63)
        Me.txtCal2.Name = "txtCal2"
        Me.txtCal2.Size = New System.Drawing.Size(100, 20)
        Me.txtCal2.TabIndex = 4
        '
        'btnCal2
        '
        Me.btnCal2.Location = New System.Drawing.Point(146, 61)
        Me.btnCal2.Name = "btnCal2"
        Me.btnCal2.Size = New System.Drawing.Size(75, 23)
        Me.btnCal2.TabIndex = 3
        Me.btnCal2.Text = "Opcion 2"
        '
        'txtCal3
        '
        Me.txtCal3.Location = New System.Drawing.Point(27, 94)
        Me.txtCal3.Name = "txtCal3"
        Me.txtCal3.Size = New System.Drawing.Size(100, 20)
        Me.txtCal3.TabIndex = 6
        '
        'btnCal3
        '
        Me.btnCal3.Location = New System.Drawing.Point(146, 92)
        Me.btnCal3.Name = "btnCal3"
        Me.btnCal3.Size = New System.Drawing.Size(75, 23)
        Me.btnCal3.TabIndex = 5
        Me.btnCal3.Text = "Opcion 3"
        '
        'GridControl2
        '
        Me.GridControl2.Location = New System.Drawing.Point(594, 125)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(650, 324)
        Me.GridControl2.TabIndex = 7
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "pacodigo"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "GridColumn2"
        Me.GridColumn2.FieldName = "padescri"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "GridColumn3"
        Me.GridColumn3.FieldName = "pavalor1"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn4"
        Me.GridColumn4.FieldName = "pavalor2"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "GridColumn5"
        Me.GridColumn5.FieldName = "cal1"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "GridColumn6"
        Me.GridColumn6.FieldName = "cal2"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "GridColumn7"
        Me.GridColumn7.FieldName = "cal3"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1280, 461)
        Me.Controls.Add(Me.GridControl2)
        Me.Controls.Add(Me.txtCal3)
        Me.Controls.Add(Me.btnCal3)
        Me.Controls.Add(Me.txtCal2)
        Me.Controls.Add(Me.btnCal2)
        Me.Controls.Add(Me.txtCal1)
        Me.Controls.Add(Me.btnCal1)
        Me.Controls.Add(Me.GridControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsParametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCal1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCal2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCal3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DsParametro1 As WindApp.DSParametro
    Friend WithEvents colpacodigo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpadescri As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpavalor1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colpavalor2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcal1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcal2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcal3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnCal1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCal1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCal2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCal2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCal3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCal3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
End Class
