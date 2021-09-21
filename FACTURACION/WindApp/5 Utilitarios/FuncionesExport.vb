Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Public Class FuncionesExport
    Dim fila As Integer

    Public Sub DataTableToExcel_estandar(ByVal pDataTable As DataTable, ByVal titulo As String)

        Dim vFileName As String = Path.GetTempFileName()

        FileOpen(1, vFileName, OpenMode.Output)

        Dim sb As String
        Dim dc As DataColumn
        ' copia cabecera de excel 

        For Each dc In pDataTable.Columns
            sb &= Trim(dc.Caption.ToUpper) & Microsoft.VisualBasic.ControlChars.Tab
        Next

        PrintLine(1, Trim(titulo) & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, sb)

        Dim i As Integer = 0
        Dim dr As DataRow

        fila = 0
        For Each dr In pDataTable.Rows
            fila = fila + 1
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    '  sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    'If i = 1 Then
                    'sb &= "=" & Microsoft.VisualBasic.ControlChars.Quote & Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Quote & Microsoft.VisualBasic.ControlChars.Tab
                    '      sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    ' Else
                    sb &= Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Tab
                    ' End If
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next
            PrintLine(1, sb)
        Next
        i = 0 : sb = ""
        For Each dc In pDataTable.Columns
            If Not IsDBNull(dr(i)) Then
                '  sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                Select Case i
                    Case 0
                        sb &= "TOTAL" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 2
                        '  sb &= "=" & "SUMA(C3:C" & fila + 2 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 4
                        '  sb &= "=" & "SUMA(E3:E" & fila + 2 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 6
                        '  sb &= "=" & "SUMA(G3:G" & fila + 2 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 7
                        '  sb &= "=" & "SUMA(H3:H" & fila + 2 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 8
                        '  sb &= "=" & "SUMA(I3:I" & fila + 2 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case Else
                        sb &= Microsoft.VisualBasic.ControlChars.Tab
                End Select
            Else
                sb &= Microsoft.VisualBasic.ControlChars.Tab
            End If
            i += 1
        Next
        PrintLine(1, sb)

        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "-----------------------------                                                       -----------------------------                                             -----------------------------------                              -----------------------------------" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "ELABORADO POR                                                             CONTADOR                                                             GERENTE ADM.FIN.                                      RECIBIDO POR" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        '  PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)

        Dim dia As Date
        dia = Date.Now
        PrintLine(1, "Santa Cruz " & dia.Day & " de " & dar_mes_literal(dia.Month) & " del " & dia.Year & Microsoft.VisualBasic.ControlChars.Tab)


        FileClose(1)
        TextToExcel_estandar(vFileName)

    End Sub

    Public Sub TextToExcel_estandar(ByVal pFileName As String)

        Dim vFormato As Excel.XlRangeAutoFormat

        Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES")

        Dim Exc As Excel.Application = New Excel.Application
        Exc.Workbooks.OpenText(pFileName, , , , Excel.XlTextQualifier.xlTextQualifierNone, , True)

        Dim Wb As Excel.Workbook = Exc.ActiveWorkbook
        Dim Ws As Excel.Worksheet = Wb.ActiveSheet


        'Se le indica el formato al que queremos exportarlo
        Dim valor As Integer = 4
        If valor > -1 Then
            Select Case valor
                Case 0 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatNone
                Case 1 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple
                Case 2 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1
                Case 3 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2
                Case 4 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic3
                Case 5 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1
                Case 6 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting2
                Case 7 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting3
                Case 8 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting4
                Case 9 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor1
                Case 10 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2
                Case 11 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor3
                Case 12 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList1
                Case 13 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList2
                Case 14 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList3
                Case 15 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1
                Case 16 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects2
            End Select
            ' copia final lineas 1
            Ws.PageSetup.Zoom = 67
            Ws.PageSetup.TopMargin = 1
            Ws.PageSetup.RightMargin = 0
            Ws.PageSetup.LeftMargin = 0

            Ws.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperLegal
            Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count - 1, Ws.UsedRange.Columns.Count)).AutoFormat(vFormato)
            Ws.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape



            Ws.Range("A" & fila + 3 & ":K" & fila + 3).Columns.Font.Bold = True
            Ws.Range("A2:B2").Columns.Columns.Font.Size = 10
            Ws.Range("A2:L2").HorizontalAlignment = 1
            Ws.Range("M2:M2").HorizontalAlignment = 1

            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)
            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)

        End If
        Exc.Quit()

        Ws = Nothing
        Wb = Nothing
        Exc = Nothing

        GC.Collect()

        If valor > -1 Then
            Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
            p.EnableRaisingEvents = False
            p.Start("Excel.exe", pFileName)
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = vCultura
    End Sub


    Public Sub DataTableToExcel_estandar_dos(ByVal pDataTable As DataTable, ByVal titulo As String)

        Dim vFileName As String = Path.GetTempFileName()

        FileOpen(1, vFileName, OpenMode.Output)

        Dim sb As String
        Dim dc As DataColumn
        ' copia cabecera de excel 

        For Each dc In pDataTable.Columns
            sb &= Trim(dc.Caption.ToUpper) & Microsoft.VisualBasic.ControlChars.Tab
        Next
        PrintLine(1, Trim("ENRIQUE ESCUDERO CAMPOS") & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, Trim("NIT: 1025453025") & Microsoft.VisualBasic.ControlChars.Tab)

        PrintLine(1, Trim(titulo) & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, sb)

        Dim i As Integer = 0
        Dim dr As DataRow

        fila = 0
        For Each dr In pDataTable.Rows
            fila = fila + 1
            i = 0 : sb = ""
            For Each dc In pDataTable.Columns
                If Not IsDBNull(dr(i)) Then
                    '  sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    'If i = 1 Then
                    'sb &= "=" & Microsoft.VisualBasic.ControlChars.Quote & Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Quote & Microsoft.VisualBasic.ControlChars.Tab
                    '      sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    ' Else
                    sb &= Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Tab
                    ' End If
                Else
                    sb &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next
            PrintLine(1, sb)
        Next
        i = 0 : sb = ""
        For Each dc In pDataTable.Columns
            If Not IsDBNull(dr(i)) Then
                '  sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                Select Case i
                    Case 0
                        sb &= "TOTAL" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 1
                        sb &= "=" & "SUMA(B5:B" & fila + 4 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case 2
                        sb &= "=" & "SUMA(C5:C" & fila + 4 & ")" & Microsoft.VisualBasic.ControlChars.Tab
                    Case Else
                        sb &= Microsoft.VisualBasic.ControlChars.Tab
                End Select
            Else
                sb &= Microsoft.VisualBasic.ControlChars.Tab
            End If
            i += 1
        Next
        PrintLine(1, sb)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "-------------------------           ---------------------        --------------------------             -------------------------" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "ELABORADO POR           CONTADOR           GERENTE ADM.FIN.          RECIBIDO POR" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, "" & Microsoft.VisualBasic.ControlChars.Tab)
        Dim dia As Date
        dia = Date.Now
        PrintLine(1, "Santa Cruz " & dia.Day & " de " & dar_mes_literal(dia.Month) & " del " & dia.Year & Microsoft.VisualBasic.ControlChars.Tab)
        FileClose(1)
        TextToExcel_estandar_dos(vFileName)

    End Sub

    Public Sub TextToExcel_estandar_dos(ByVal pFileName As String)

        Dim vFormato As Excel.XlRangeAutoFormat

        Dim vCultura As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES")

        Dim Exc As Excel.Application = New Excel.Application
        Exc.Workbooks.OpenText(pFileName, , , , Excel.XlTextQualifier.xlTextQualifierNone, , True)

        Dim Wb As Excel.Workbook = Exc.ActiveWorkbook
        Dim Ws As Excel.Worksheet = Wb.ActiveSheet


        'Se le indica el formato al que queremos exportarlo
        Dim valor As Integer = 4
        If valor > -1 Then
            Select Case valor
                Case 0 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatNone
                Case 1 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatSimple
                Case 2 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic1
                Case 3 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2
                Case 4 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic3
                Case 5 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting1
                Case 6 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting2
                Case 7 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting3
                Case 8 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatAccounting4
                Case 9 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor1
                Case 10 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor2
                Case 11 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatColor3
                Case 12 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList1
                Case 13 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList2
                Case 14 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormatList3
                Case 15 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects1
                Case 16 : vFormato = Excel.XlRangeAutoFormat.xlRangeAutoFormat3DEffects2
            End Select
            ' copia final lineas 1
            'Ws.PageSetup.Zoom = 100

            Ws.Range(Ws.Cells(1, 1), Ws.Cells(Ws.UsedRange.Rows.Count - 9, Ws.UsedRange.Columns.Count)).AutoFormat(vFormato)
            'Ws.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape

            '  Ws.Range("B3:B" & Ws.UsedRange.Rows.Count - 9).Columns.AutoFit()
            Ws.Range("A" & fila + 5 & ":D" & fila + 5).Columns.Font.Bold = True
            Ws.Range("A4:A4").Columns.Columns.Font.Size = 10
            Ws.Range("B5:C" & fila + 5).Columns.Columns.NumberFormat = "##.##0,00"



            pFileName = Path.GetTempFileName.Replace("tmp", "xls")
            File.Delete(pFileName)
            Exc.ActiveWorkbook.SaveAs(pFileName, Excel.XlTextQualifier.xlTextQualifierNone - 1)

        End If
        Exc.Quit()

        Ws = Nothing
        Wb = Nothing
        Exc = Nothing

        GC.Collect()

        If valor > -1 Then
            Dim p As System.Diagnostics.Process = New System.Diagnostics.Process
            p.EnableRaisingEvents = False
            p.Start("Excel.exe", pFileName)
        End If
        System.Threading.Thread.CurrentThread.CurrentCulture = vCultura
    End Sub



    Public Function dar_mes_literal(ByVal valor As Integer) As String
        Select Case valor
            Case 1
                Return "Enero"
            Case 2
                Return "Febrero"
            Case 3
                Return "Marzo"
            Case 4
                Return "Abril"
            Case 5
                Return "Mayo"
            Case 6
                Return "Junio"
            Case 7
                Return "Julio"
            Case 8
                Return "Agosto"
            Case 9
                Return "Septiembre"
            Case 10
                Return "Octubre"
            Case 11
                Return "Noviembre"
            Case 12
                Return "Diciembre"
            Case Else
                Return "Nada"
        End Select
    End Function

    Public Sub De_DataTable_a_Excel(ByVal tablaDeDatos As DataTable, ByVal titulo As String)
        Dim Linea_de_texto As String
        Dim Columna As DataColumn
        Dim ArchivoTemp As String = Path.GetTempFileName()

        FileOpen(1, ArchivoTemp, OpenMode.Output)
        ' copia cabecera de excel 

        For Each Columna In tablaDeDatos.Columns
            Linea_de_texto &= Columna.Caption & Microsoft.VisualBasic.ControlChars.Tab
        Next
        PrintLine(1, Trim(titulo) & Microsoft.VisualBasic.ControlChars.Tab)
        PrintLine(1, Linea_de_texto)
        Dim i As Integer = 0
        Dim dr As DataRow
        For Each dr In tablaDeDatos.Rows
            i = 0 : Linea_de_texto = ""
            For Each Columna In tablaDeDatos.Columns
                If Not IsDBNull(dr(i)) Then
                    '  sb &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab
                    Select Case i
                        Case 0, 3, 5, 14
                            Linea_de_texto &= "=" & Microsoft.VisualBasic.ControlChars.Quote & Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Quote & Microsoft.VisualBasic.ControlChars.Tab
                        Case 6, 7, 8, 9, 10, 11, 12, 13
                            Linea_de_texto &= "=" & Trim(Format(dr(i), "0.00").ToString) & Microsoft.VisualBasic.ControlChars.Tab
                        Case Else
                            Linea_de_texto &= "=" & Trim(CStr(dr(i))) & Microsoft.VisualBasic.ControlChars.Tab
                    End Select
                    ' Else

                    ' Linea_de_texto &= CStr(dr(i)) & Microsoft.VisualBasic.ControlChars.Tab

                Else
                    Linea_de_texto &= Microsoft.VisualBasic.ControlChars.Tab
                End If
                i += 1
            Next
            PrintLine(1, Linea_de_texto)
        Next
        FileClose(1)
        TextToExcel_estandar(ArchivoTemp)

    End Sub

End Class
