Imports System.Numerics
Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Public Class UI_PruebaGrid : Inherits f_base

#Region "[atributosGlobales]"

    Private usuario As String
    Private clave As String

#End Region

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New("Prueba de Generacion CUF por Bloque", "Realice la opereación deseada")
        InitializeComponent()
        usuario = usuar : clave = clav
    End Sub

#End Region

#Region "metodos"

    Private Sub getBase16()
        If dgv.RowCount > 0 Then
            For Each fila As DataGridViewRow In dgv.Rows
                If Not fila.Cells(0).Value Is Nothing AndAlso Trim(fila.Cells(0).Value) <> String.Empty Then
                    Dim objUtilitario As New libreriaCUF() ' 1, 9, False

                    'Get Nit Formateado
                    fila.Cells(10).Value = objUtilitario.getNitFormato(fila.Cells(1).Value)
                    'Gete fecha Formateado
                    fila.Cells(11).Value = fila.Cells(2).Value
                    'Get Sucrusal
                    fila.Cells(12).Value = objUtilitario.getSucrusalFormat(fila.Cells(3).Value)
                    'Get Modalidad
                    fila.Cells(13).Value = fila.Cells(4).Value
                    'Get Tipo Emision
                    fila.Cells(14).Value = fila.Cells(5).Value
                    'Get Documento Fiscal
                    fila.Cells(15).Value = fila.Cells(6).Value
                    'Get Tipo Documento Sector
                    fila.Cells(16).Value = objUtilitario.getTipoDocumentoSectorFormat(fila.Cells(7).Value)
                    'Get Nro de Factura
                    fila.Cells(17).Value = objUtilitario.getNroFacturaFormat(fila.Cells(8).Value)
                    'Get Nro de Factura
                    fila.Cells(18).Value = objUtilitario.getPuntoVentaFormat(fila.Cells(9).Value)

                    'Get concatenamos los campos
                    fila.Cells(19).Value = fila.Cells(10).Value & fila.Cells(11).Value & fila.Cells(12).Value & fila.Cells(13).Value & fila.Cells(14).Value & fila.Cells(15).Value & fila.Cells(16).Value & fila.Cells(17).Value & fila.Cells(18).Value
                    'Get modulo 11
                    fila.Cells(20).Value = objUtilitario.calculaDigitoModulo11(fila.Cells(19).Value, 1, 9, False)
                    'Concateno valor original con valor modulo 11 
                    fila.Cells(21).Value = fila.Cells(19).Value & fila.Cells(20).Value

                    'asigo el valor del modulo 11 y concateno 
                    'fila.Cells(2).Value = fila.Cells(0).Value & fila.Cells(21).Value

                    'asigo el valor en base 16
                    Dim vBase16 As BigInteger = System.Numerics.BigInteger.Parse(fila.Cells(21).Value.ToString)
                    fila.Cells(22).Value = objUtilitario.getHexadecimal(vBase16)

                End If
            Next
        End If
    End Sub

    Private Sub exportarExcel()
        Dim app As Microsoft.Office.Interop.Excel._Application = New Microsoft.Office.Interop.Excel.Application()
        Dim workbook As Microsoft.Office.Interop.Excel._Workbook = app.Workbooks.Add(Type.Missing)
        Dim worksheet As Microsoft.Office.Interop.Excel._Worksheet = Nothing
        worksheet = workbook.Sheets("Hoja1")
        worksheet = workbook.ActiveSheet
        'Aca se agregan las cabeceras de nuestro datagrid.

        For i As Integer = 1 To Me.dgv.Columns.Count
            worksheet.Cells(1, i) = Me.dgv.Columns(i - 1).HeaderText
        Next

        'Aca se ingresa el detalle recorrera la tabla celda por celda
        For i As Integer = 0 To Me.dgv.Rows.Count - 1
            For j As Integer = 0 To Me.dgv.Columns.Count - 1
                If dgv.Rows(i).Cells(j).Value <> String.Empty Then
                    worksheet.Cells(i + 2, j + 1) = Me.dgv.Rows(i).Cells(j).Value.ToString()
                End If
            Next
        Next

        'Aca le damos el formato a nuestro excel

        worksheet.Rows.Item(1).Font.Bold = 1
        worksheet.Rows.Item(1).HorizontalAlignment = 3
        worksheet.Columns.AutoFit()
        worksheet.Columns.HorizontalAlignment = 2

        app.Visible = True
        app = Nothing
        workbook = Nothing
        worksheet = Nothing
        FileClose(1)
        GC.Collect()
    End Sub


    Public Sub ExportarDatosExcel(ByVal DataGridView1 As DataGridView, ByVal titulo As String)
        Dim m_Excel As New Excel.Application
        m_Excel.Cursor = Excel.XlMousePointer.xlWait
        m_Excel.Visible = True
        Dim objLibroExcel As Excel.Workbook = m_Excel.Workbooks.Add
        Dim objHojaExcel As Excel.Worksheet = objLibroExcel.Worksheets(1)
        With objHojaExcel
            .Visible = Excel.XlSheetVisibility.xlSheetVisible
            .Activate()
            'Encabezado  
            .Range("A1:L1").Merge()
            .Range("A1:L1").Value = "INSTITUTO ARGENCAF"
            .Range("A1:L1").Font.Bold = True
            .Range("A1:L1").Font.Size = 15
            'Copete  
            .Range("A2:L2").Merge()
            .Range("A2:L2").Value = titulo
            .Range("A2:L2").Font.Bold = True
            .Range("A2:L2").Font.Size = 12

            Const primeraLetra As Char = "A"
            Const primerNumero As Short = 3
            Dim Letra As Char, UltimaLetra As Char
            Dim Numero As Integer, UltimoNumero As Integer
            Dim cod_letra As Byte = Asc(primeraLetra) - 1
            Dim sepDec As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
            Dim sepMil As String = Application.CurrentCulture.NumberFormat.NumberGroupSeparator
            'Establecer formatos de las columnas de la hija de cálculo  
            Dim strColumna As String = ""
            Dim LetraIzq As String = ""
            Dim cod_LetraIzq As Byte = Asc(primeraLetra) - 1
            Letra = primeraLetra
            Numero = primerNumero
            Dim objCelda As Excel.Range
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        cod_LetraIzq += 1
                        LetraIzq = Chr(cod_LetraIzq)
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                    strColumna = LetraIzq + Letra + Numero.ToString
                    objCelda = .Range(strColumna, Type.Missing)
                    objCelda.Value = c.HeaderText
                    objCelda.EntireColumn.Font.Size = 8
                    'objCelda.EntireColumn.NumberFormat = c.DefaultCellStyle.Format  
                    If c.ValueType Is GetType(Decimal) OrElse c.ValueType Is GetType(Double) Then
                        objCelda.EntireColumn.NumberFormat = "#" + sepMil + "0" + sepDec + "00"
                    End If
                End If
            Next

            Dim objRangoEncab As Excel.Range = .Range(primeraLetra + Numero.ToString, LetraIzq + Letra + Numero.ToString)
            objRangoEncab.BorderAround(1, Excel.XlBorderWeight.xlMedium)
            UltimaLetra = Letra
            Dim UltimaLetraIzq As String = LetraIzq

            'CARGA DE DATOS  
            Dim i As Integer = Numero + 1

            For Each reg As DataGridViewRow In DataGridView1.Rows
                LetraIzq = ""
                cod_LetraIzq = Asc(primeraLetra) - 1
                Letra = primeraLetra
                cod_letra = Asc(primeraLetra) - 1
                For Each c As DataGridViewColumn In DataGridView1.Columns
                    If c.Visible Then
                        If Letra = "Z" Then
                            Letra = primeraLetra
                            cod_letra = Asc(primeraLetra)
                            cod_LetraIzq += 1
                            LetraIzq = Chr(cod_LetraIzq)
                        Else
                            cod_letra += 1
                            Letra = Chr(cod_letra)
                        End If
                        strColumna = LetraIzq + Letra
                        ' acá debería realizarse la carga  
                        .Cells(i, strColumna) = IIf(IsDBNull(reg.ToString), "", reg.Cells(c.Index).Value)
                        '.Cells(i, strColumna) = IIf(IsDBNull(reg.(c.DataPropertyName)), c.DefaultCellStyle.NullValue, reg(c.DataPropertyName))  
                        '.Range(strColumna + i, strColumna + i).In()  

                    End If
                Next
                Dim objRangoReg As Excel.Range = .Range(primeraLetra + i.ToString, strColumna + i.ToString)
                objRangoReg.Rows.BorderAround()
                objRangoReg.Select()
                i += 1
            Next
            UltimoNumero = i

            'Dibujar las líneas de las columnas  
            LetraIzq = ""
            cod_LetraIzq = Asc("A")
            cod_letra = Asc(primeraLetra)
            Letra = primeraLetra
            For Each c As DataGridViewColumn In DataGridView1.Columns
                If c.Visible Then
                    objCelda = .Range(LetraIzq + Letra + primerNumero.ToString, LetraIzq + Letra + (UltimoNumero - 1).ToString)
                    objCelda.BorderAround()
                    If Letra = "Z" Then
                        Letra = primeraLetra
                        cod_letra = Asc(primeraLetra)
                        LetraIzq = Chr(cod_LetraIzq)
                        cod_LetraIzq += 1
                    Else
                        cod_letra += 1
                        Letra = Chr(cod_letra)
                    End If
                End If
            Next

            'Dibujar el border exterior grueso  
            Dim objRango As Excel.Range = .Range(primeraLetra + primerNumero.ToString, UltimaLetraIzq + UltimaLetra + (UltimoNumero - 1).ToString)
            objRango.Select()
            objRango.Columns.AutoFit()
            objRango.Columns.BorderAround(1, Excel.XlBorderWeight.xlMedium)
        End With

        m_Excel.Cursor = Excel.XlMousePointer.xlDefault
    End Sub

#End Region

#Region "[eventos]"

    Private Sub btnModulo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModulo.Click
        Call getBase16()
    End Sub

    Private Sub dgv_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Try
                For Each line As String In Clipboard.GetText.Split(vbNewLine)
                    Dim item() As String = line.Trim.Split(vbTab)
                    If item.Length = Me.dgv.ColumnCount Then
                        dgv.Rows.Add(item)
                    Else
                        dgv.Rows.Add(item)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ExportarListaListaDeFacturasPorCobrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarListaListaDeFacturasPorCobrarToolStripMenuItem.Click
        'call exportarExcel()
        Call ExportarDatosExcel(dgv, "")
    End Sub

#End Region

End Class