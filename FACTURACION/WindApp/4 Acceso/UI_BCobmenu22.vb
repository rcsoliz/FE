Imports ENTIDADES
Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraGrid
Public Class UI_BCobmenu22 : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String
    Private itemCobmenu11 As tb_cobmenu11

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal iCobMenu11 As tb_cobmenu11)
        MyBase.New("DATOS EVENTOS", "Realice la operación requerida...")
        InitializeComponent()

        usuario = usuar
        clave = clav
        itemCobmenu11 = iCobMenu11

        Call getCobModulo1()
        Call getCobmenu11()
        Call getCobmopro1()
    End Sub

#End Region

#Region "[metodos]"

    Private Sub getCobModulo1()
        Using objMenu11 As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objMenu11.getCobModulComboBL()
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorSistema, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkModulo.DataSource = dt
                lkModulo.ValueMember = "modmodul"
                lkModulo.DisplayMember = "moddesc"
            End If
        End Using
    End Sub

    Private Sub getCobmenu11()
        Using objMenu11 As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objMenu11.getCobMenu11BL()
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorSistema, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkSubMenu.DataSource = dt
                lkSubMenu.ValueMember = "codmenu1"
                lkSubMenu.DisplayMember = "me1subme"
            End If
        End Using
    End Sub

    Private Sub getCobmopro1()
        Using objMenu11 As New Negocios.CobMenu22BL(usuario, clave)
            Dim dt As New DataTable
            dt = objMenu11.getCobMopro1ComboBL()
            If objMenu11.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objMenu11.mensajeErrorSistema, objMenu11.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                lkPrograma.DataSource = dt
                lkPrograma.ValueMember = "idcobpro"
                lkPrograma.DisplayMember = "mopdescr"
            End If
        End Using
    End Sub

    Private Sub getCobmenu22()
        Using objCobmenu22 As New Negocios.CobMenu22BL(usuario, clave)
            Dim item As New tb_cobmenu22 With {.me2modul = itemCobmenu11.me1modul, .me2subme = itemCobmenu11.codmenu1}
            Dim dt As New DataTable 'codevento, me2event, me2modul, me2subme, me2nprog, me2ofici, me2secue
            dt = objCobmenu22.getCobMenu22XModuloBL(item)
            If objCobmenu22.existeError Then
                DevExpress.XtraEditors.XtraMessageBox.Show(String.Format("{0} {1}", objCobmenu22.mensajeErrorSistema, objCobmenu22.mensajeErrorUsuarios),
                                                 "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                gcEventos.DataSource = dt
            End If
        End Using
    End Sub

    Private Sub imprimirGrid(ByVal gc As GridControl)
        If Not gc.IsPrintingAvailable Then
            MessageBox.Show("La libreria para poder imprir ...")
            Return
        End If
        gc.ShowRibbonPrintPreview()
    End Sub

    Private Function getListaEvento() As List(Of ENTIDADES.tb_cobmenu22)
        Dim lista As New List(Of ENTIDADES.tb_cobmenu22)()
        If gvEventos.RowCount > 0 Then

            Dim filaDatos As DataRow
            Dim arrayFilaSel() As Integer = gvEventos.GetSelectedRows()
            For i = 0 To arrayFilaSel.Length - 1 Step 1
                filaDatos = gvEventos.GetDataRow(arrayFilaSel(i))
                Dim item As New ENTIDADES.tb_cobmenu22 With {.codevento = filaDatos.Item(0), .me2event = filaDatos.Item(1),
                                                            .me2modul = filaDatos.Item(2), .me2subme = filaDatos.Item(3),
                                                            .me2nprog = filaDatos.Item(4), .me2ofici = filaDatos.Item(5),
                                                            .me2secue = filaDatos.Item(6)}
                lista.Add(item)
            Next
        End If

        Return lista
    End Function



#End Region

#Region "[eventos]"

    Private Sub UI_BCobmenu22_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Call getCobmenu22()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim item As New tb_cobmenu22 With {.me2modul = itemCobmenu11.me1modul, .me2subme = itemCobmenu11.codmenu1}
        Dim objForm As New UI_Cobmenu22(usuario, clave, item, 1) With {.MdiParent = MdiParent}
        objForm.Show()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmenu22)()
        lista = getListaEvento()
        If lista.Count > 0 Then
            Dim item As New tb_cobmenu22 With {.me2modul = itemCobmenu11.me1modul, .me2subme = itemCobmenu11.codmenu1}
            Dim objFormModulo As New UI_Cobmenu22(usuario, clave, lista, item, 2) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim lista As New List(Of ENTIDADES.tb_cobmenu22)()
        lista = getListaEvento()
        If lista.Count > 0 Then
            Dim item As New tb_cobmenu22 With {.me2modul = itemCobmenu11.me1modul, .me2subme = itemCobmenu11.codmenu1}
            Dim objFormModulo As New UI_Cobmenu22(usuario, clave, lista, item, 3) With {.MdiParent = MdiParent}
            objFormModulo.Show()
        Else
            DevExpress.XtraEditors.XtraMessageBox.Show("Primero debe seleccionar las fila(s) a actualizar", "Información",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Call imprimirGrid(gcEventos)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Call Close()
    End Sub

#End Region

End Class