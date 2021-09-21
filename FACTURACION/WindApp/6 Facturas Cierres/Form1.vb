Imports Entidades
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Controls

Public Class Form1

    Private usuario As String
    Private clave As String

    Public Sub New(ByVal usua As String, ByVal clav As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        usuario = usua
        clave = clav
        Call cargar()
    End Sub

    Private Sub cargar()
        Using obcliente As New Negocios.UtilitarioBL(usuario, clave)

            Dim dt As New DataTable
            dt = obcliente.getParametroBL
            GridControl1.DataSource = dt

            Dim dt1 As New DataTable
            dt1 = obcliente.getParametroBL
            GridControl2.DataSource = dt1
        End Using
    End Sub

    Private Sub loadColumnas(ByVal nomColumna As DevExpress.XtraGrid.Columns.GridColumn, ByVal valor As String)
        'For i = 0 To GridView1.RowCount - 1
        '    If GridView1.GetRowCellValue(i, colpavalor2) = 1 Then
        '        GridView1.SetRowCellValue(i, nomColumna, 111)

        '    ElseIf GridView1.GetRowCellValue(i, colpavalor2) = 2 Then
        '        GridView1.SetRowCellValue(i, nomColumna, 222)

        '    Else
        '        GridView1.SetRowCellValue(i, nomColumna, valor)
        '    End If
        'Next


        For i = 0 To GridView1.RowCount - 1
            Dim vgv1 As String = GridView1.GetRowCellValue(i, colpacodigo)

            For j = 0 To GridView2.RowCount - 1

                If vgv1 = GridView1.GetRowCellValue(i, colpacodigo) AndAlso GridView2.GetRowCellValue(j, colpacodigo) = "10002" Then
                    GridView2.SetRowCellValue(j, nomColumna, 9999)
                Else
                    GridView2.SetRowCellValue(j, nomColumna, 100)
                End If

            Next
        Next


        'For i = 0 To GridView2.RowCount - 1
        '    GridView2.SetRowCellValue(i, nomColumna, valor)
        'Next
    End Sub

    Private Sub btnCal1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCal1.Click
        If txtCal1.Text <> String.Empty Then
            Dim valor As String = txtCal1.Text
            loadColumnas(colcal1, valor)
        End If

        If txtCal1.Text <> String.Empty Then
            Dim valor As String = txtCal1.Text
            loadColumnas(GridColumn5, valor)
        End If

    End Sub

    Private Sub btnCal2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCal2.Click
        If txtCal2.Text <> String.Empty Then
            Dim valor As String = txtCal2.Text
            loadColumnas(colcal2, valor)
        End If
    End Sub

    Private Sub btnCal3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCal3.Click
        txtCal3.Text = "0"
        If txtCal1.Text <> String.Empty AndAlso txtCal2.Text <> String.Empty Then
            Dim valor As String = Math.Round(txtCal1.Text / txtCal2.Text, 2)
            loadColumnas(colcal3, valor)
        End If
    End Sub

End Class