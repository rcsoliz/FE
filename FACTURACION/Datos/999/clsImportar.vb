Imports Entidades
Imports Libreria
Public Class clsImportar : Inherits BaseDatos


#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

    Protected Sub New(ByVal dtConexio As DataTable)
        MyBase.New()
        Call abrir_coneccion(dtConexio)
    End Sub

#End Region

#Region "[metodos]"

    Protected Function getClientesFactura(ByVal codTipo As String) As DataTable
        Dim consulta As String = String.Empty
        Using dtBase As New DataTable
            Try
                'consulta = Libreria.LibImportar.getDatos93012(codTipo)

                consulta = Libreria.LibImportar.getDatosFatura(codTipo)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtBase)
            Catch ex As Exception
                set_error("Fallo en clsImportar:: getClientesFactura " & consulta, ex.Message)
            End Try
            Return dtBase
        End Using
    End Function

    Protected Function listarProveedor(ByRef dtFactura As DataTable, ByRef correlativo As Integer) As List(Of Entidades.tb_cabimport)
        Dim lista As List(Of Entidades.tb_cabimport) = New List(Of Entidades.tb_cabimport)
        Dim consulta As String = String.Empty
        Try
            For Each fila As DataRow In dtFactura.Rows

                Dim dtlipro As New DataTable
                consulta = "select unique lqtipliq, lqnroliq, lqcodpro from afliqpro where lqtipliq='" & fila.Item("tipomov") & "' " &
                           "AND lqnroliq=" & fila.Item("nummov")
                comando.CommandText = consulta
                conector.Fill(dtlipro)
                If dtlipro.Rows.Count > 0 Then
                    If Not IsDBNull(dtlipro.Rows(0).Item("lqcodpro")) Then
                        Dim dtProveeNIT As New DataTable
                        consulta = "SELECT trim(prnombre) prnombre, trim(prapelli) prapelli,  trim(prdirecc) prdirecc, trim(ruc_prove.ruc) ruc, " &
                                   "trim(prdirecc) direccion, trim(prtelefo) telefono FROM afprovee, ruc_prove " &
                                   "WHERE afprovee.prcodigo = ruc_prove.codigo AND prcodigo=" & dtlipro.Rows(0).Item("lqcodpro")
                        comando.CommandType = CommandType.Text
                        comando.CommandText = consulta
                        conector.Fill(dtProveeNIT)
                        If dtProveeNIT.Rows.Count > 0 Then
                            Dim item As New Entidades.tb_cabimport With {.codigoin = correlativo,
                                                                         .nombre = dtProveeNIT.Rows(0).Item("prnombre"),
                                                                         .apellido = dtProveeNIT.Rows(0).Item("prapelli"),
                                                                         .nitci = dtProveeNIT.Rows(0).Item("ruc"),
                                                                         .codigo = dtlipro.Rows(0).Item("lqcodpro")}
                            If lista.Count > 0 Then
                                If Not lista.Any(Function(x) x.codigo = item.codigo) Then
                                    lista.Add(item)
                                    correlativo = correlativo + 1
                                End If

                            Else
                                lista.Add(item)
                                correlativo = correlativo + 1
                            End If
                        End If
                    End If

                End If
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: listarClienteProveedor " & consulta, ex.Message)
        End Try
        Return lista
    End Function

    Protected Function listarCliente(ByRef dtFactura As DataTable, ByRef correlativo As Integer, ByVal esMenudo As Boolean, ByVal ciclo As Integer) As List(Of Entidades.tb_cabimport)
        Dim lista As List(Of Entidades.tb_cabimport) = New List(Of Entidades.tb_cabimport)
        Dim consulta As String = String.Empty

        Try
            For Each fila As DataRow In dtFactura.Rows

                Dim dtlipro As New DataTable
                If esMenudo AndAlso ciclo = 1 Then

                    consulta = "select unique fmtipfac, fmnrofac, fmcodcli FROM  affacmen WHERE fmtipfac='" & fila.Item("tipomov") & "' " &
                               "AND fmnrofac=" & fila.Item("nummov")
                ElseIf Not esMenudo AndAlso ciclo = 1 Then

                    consulta = "select unique fptipfac, fpnrofac, fpcodcli FROM affacsub WHERE fptipfac='" & fila.Item("tipomov") & "' " &
                               "AND fpnrofac=" & fila.Item("nummov")

                ElseIf Not esMenudo AndAlso ciclo = 2 Then
                    consulta = "select trim(tipoc) tdoc, (nro_dc) nrodoc, trim(codcam) codcliente from expcarne@ol_suse:dembqdti " &
                               "where tipoc='" & fila.Item("tipomov") & "' " &
                               "AND nro_dc=" & fila.Item("nummov")
                Else

                End If

                comando.CommandText = consulta
                conector.Fill(dtlipro)

                If dtlipro.Rows.Count > 0 Then
                    Dim codCliente As String = String.Empty

                    If esMenudo AndAlso ciclo = 1 Then
                        codCliente = If(IsDBNull(dtlipro.Rows(0).Item("fmcodcli")), Nothing, dtlipro.Rows(0).Item("fmcodcli"))

                    ElseIf Not esMenudo AndAlso ciclo = 1 Then
                        codCliente = If(IsDBNull(dtlipro.Rows(0).Item("fpcodcli")), Nothing, dtlipro.Rows(0).Item("fpcodcli"))

                    ElseIf Not esMenudo AndAlso ciclo = 2 Then
                        codCliente = If(IsDBNull(dtlipro.Rows(0).Item("codcliente")), Nothing, dtlipro.Rows(0).Item("codcliente"))
                    End If

                    If codCliente <> String.Empty Then
                        Dim dtClienteNIT As New DataTable  ''' ACA ESTOY.......................................................................

                        If Not esMenudo AndAlso ciclo = 1 Then
                            consulta = "SELECT TRIM(clnombre) clnombre, TRIM(clapelli) clapelli, TRIM(ruc_cliente.ruc) ruc, " &
                                       "TRIM(cldirecc) direccion, TRIM(cltelcli) telefono FROM afclient, ruc_cliente " &
                                       "WHERE clcodcli=codigo AND clcodcli= " & codCliente

                        ElseIf Not esMenudo AndAlso ciclo = 2 Then
                            consulta = "SELECT TRIM(cl.clnombre) clnombre, TRIM(cl.clapelli) clapelli, TRIM(df.nit_ci) ruc, " &
                                       "TRIM(cl.cldirecc) direccion, TRIM(cl.cltelcli) telefono FROM expcarne@ol_suse:afclient cl, expcarne@ol_suse:datos_factura df " &
                                       "WHERE cl.clcodcli=df.codigocli AND cl.clcodcli= " & codCliente
                        End If
                   
                        comando.CommandType = CommandType.Text
                        comando.CommandText = consulta
                        conector.Fill(dtClienteNIT)

                        If dtClienteNIT.Rows.Count > 0 Then
                            Dim item As New Entidades.tb_cabimport With {.codigoin = correlativo,
                                                     .nombre = If(IsDBNull(dtClienteNIT.Rows(0).Item("clnombre")), Nothing, dtClienteNIT.Rows(0).Item("clnombre")),
                                                     .apellido = If(IsDBNull(dtClienteNIT.Rows(0).Item("clapelli")), Nothing, dtClienteNIT.Rows(0).Item("clapelli")),
                                                     .nitci = If(IsDBNull(dtClienteNIT.Rows(0).Item("ruc")), Nothing, dtClienteNIT.Rows(0).Item("ruc")),
                                                     .codigo = codCliente}
                            If String.IsNullOrEmpty(item.nitci) Then
                                Dim sinNit As String = item.nitci
                            End If

                            If lista.Count > 0 Then
                                If Not lista.Any(Function(x) x.codigo = item.codigo) Then
                                    lista.Add(item)
                                    correlativo = correlativo + 1
                                End If

                            Else
                                lista.Add(item)
                                correlativo = correlativo + 1
                            End If
                        End If
                    End If

                End If
            Next

            Dim cont As Integer
            cont = lista.Count


        Catch ex As Exception
            set_error("Fallo en clsImportar:: listarClienteProveedor " & consulta, ex.Message)
        End Try
        Return lista
    End Function





    Protected Function verificarProveedor(ByRef lista As List(Of Entidades.tb_cabimport), ByVal tcliente As String) As List(Of Entidades.tb_cabimport)
        Dim consulta As String = String.Empty
        'Dim listaProve As New List(Of tb_cabimport)
        Try
            For Each item As tb_cabimport In lista
                Dim existe As Boolean = False
                Using dt As New DataTable
                    consulta = "select nitci, cl.codigoin codigoin  from clientein cl, clientenegocio ng " &
                        "WHERE ng.codigoin=cl.codigoin AND cl.nitci= " & item.nitci & " " &
                        "AND tipocliente='" & tcliente & "'"
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0).Item("nitci")) Then
                            existe = True
                            lista.RemoveAll(Function(x) x.nitci = item.nitci)
                        End If
                    End If
                End Using
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: verificarProveedor " & consulta, ex.Message)
        End Try
        Return lista
    End Function

    Protected Function verificarCliente(ByVal lista As List(Of Entidades.tb_cabimport), ByVal tcliente As String, ByVal unidad As Integer) As List(Of Entidades.tb_cabimport)
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_cabimport In lista
                Dim existe As Boolean = False
                Using dt As New DataTable
                    consulta = "select nitci, cl.codigoin codigoin  from clientein cl, clientenegocio ng " &
                        "WHERE ng.codigoin=cl.codigoin AND cl.nitci= " & item.nitci & " " &
                        "AND tipocliente='" & tcliente & "' " &
                        "AND codunidad= " & unidad
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0).Item("nitci")) Then
                            existe = True
                            lista.RemoveAll(Function(x) x.nitci = item.nitci)
                        End If
                    End If
                End Using
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: verificarCliente " & consulta, ex.Message)
        End Try
        Return lista
    End Function

    Protected Function listarCuerpoProveedor(ByRef listProveedor As List(Of Entidades.tb_cabimport), ByVal unidad As Integer,
                                             ByVal tcliente As String) As List(Of Entidades.tb_cueimport)
        Dim listaCuerpo As New List(Of Entidades.tb_cueimport)
        Dim consulta As String = String.Empty
        Try

            For Each item As Entidades.tb_cabimport In listProveedor
                Using dt As New DataTable
                    consulta = "SELECT trim(prdirecc) direccion, trim(prtelefo) telefono FROM afprovee " &
                               "WHERE prcodigo=" & item.codigo
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim itemCuep As New tb_cueimport With {.codigoin = item.codigoin,
                                                               .codigosistema = item.codigo,
                                                               .codunidad = unidad,
                                                               .tipocliente = tcliente,
                                                               .telefono = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono")),
                                                               .celular = String.Empty,
                                                               .direccion = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion")),
                                                               .email = String.Empty,
                                                               .fregistro = Date.Now.ToShortDateString,
                                                               .estado = "a"}
                        listaCuerpo.Add(itemCuep)

                    End If
                End Using
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: listarCuerpoProveedor " & consulta, ex.Message)
        End Try

        Return listaCuerpo
    End Function
    Protected Function listarCuerpoCliente(ByRef listProveedor As List(Of Entidades.tb_cabimport), ByVal unidad As Integer, ByVal tcliente As String) As List(Of Entidades.tb_cueimport)
        Dim listaCuerpo As New List(Of Entidades.tb_cueimport)
        Dim consulta As String = String.Empty
        Try

            For Each item As Entidades.tb_cabimport In listProveedor
                Using dt As New DataTable
                    If unidad = 1 Then
                        consulta = "SELECT trim(cldirecc) direccion, trim(cltelcli) telefono FROM afclient " &
                                   "WHERE clcodcli=" & item.codigo
                    ElseIf unidad = 2 Then
                        consulta = "SELECT trim(cldirecc) direccion, trim(cltelcli) telefono FROM expcarne@ol_suse:afclient " &
                                   "WHERE clcodcli=" & item.codigo
                    End If
                    
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        Dim itemCuep As New tb_cueimport With {.codigoin = item.codigoin,
                                                               .codigosistema = item.codigo,
                                                               .codunidad = unidad,
                                                               .tipocliente = tcliente,
                                                               .telefono = If(IsDBNull(dt.Rows(0).Item("telefono")), Nothing, dt.Rows(0).Item("telefono")),
                                                               .celular = String.Empty,
                                                               .direccion = If(IsDBNull(dt.Rows(0).Item("direccion")), Nothing, dt.Rows(0).Item("direccion")),
                                                               .email = String.Empty,
                                                               .fregistro = Date.Now.ToShortDateString,
                                                               .estado = "a"}
                        listaCuerpo.Add(itemCuep)

                    End If
                End Using
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: listarCuerpoCliente " & consulta, ex.Message)
        End Try

        Return listaCuerpo
    End Function



    Protected Function getCorrelativo() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty : Dim varCorrelativo As Integer = 1
            Try
                consulta = LibClienteIn.getCorrelativo()
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("valor")) Then
                        varCorrelativo = dt.Rows(0).Item("valor")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsImportar:: getCorrelativo", ex.Message & vbNewLine & consulta)
            End Try
            Return varCorrelativo
        End Using
    End Function

    Protected Function altaPorBloque(ByRef listaCab As List(Of Entidades.tb_cabimport), ByRef listaCuep As List(Of Entidades.tb_cueimport), ByVal correlativo As Integer, ByVal tCliente As String)
        Dim vOk As Boolean = False
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_cabimport In listaCab

                Using dtVer As New DataTable
                    Dim existe As Boolean = False
                    If Not String.IsNullOrEmpty(item.nitci) Then
                        consulta = "select nitci from clientein where nitci= " & item.nitci
                        comando.CommandType = CommandType.Text
                        comando.CommandText = consulta
                        conector.Fill(dtVer)
                        If dtVer.Rows.Count > 0 Then
                            If Not IsDBNull(dtVer.Rows(0).Item("nitci")) Then
                                existe = True
                            End If
                        End If
                        If Not existe Then
                            consulta = "insert into clientein(codigoin, nombre, apellido, nitci) values(" & item.codigoin & ",'" & item.nombre & "','" & item.apellido & "','" & item.nitci & "')"
                            comando.CommandType = CommandType.Text
                            comando.CommandText = consulta
                            comando.ExecuteNonQuery()
                        End If
                    End If
                End Using
            Next

            For Each item As tb_cueimport In listaCuep
                consulta = "insert into clientenegocio(codigoin, codigosistema, codunidad, tipocliente, telefono, celular, direccion, email, fregistro, estado) values(" &
                            item.codigoin & "," & item.codigosistema & "," & item.codunidad & ",'" &
                            tCliente & "','" & item.telefono & "','" & item.celular & "','" &
                            item.direccion & "','" & item.email & "','" & item.fregistro.ToShortDateString & "', 'a' )"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next

            consulta = "UPDATE afparame SET pavalor1=" & correlativo & " WHERE pacodigo='5001'"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()

            vOk = True
        Catch ex As Exception
            set_error("Error clsImportar:: altaPorBloque", ex.Message & vbNewLine & consulta)
        End Try
        Return vOk
    End Function


    Protected Sub updateCorrelativo(ByVal correlativo As Integer)
        Dim consulta As String = String.Empty
        Try '"select (pavalor1+1)  valor from afparame where pacodigo='5001'
            consulta = "UPDATE afparame SET pavalor1=" & correlativo & " WHERE pacodigo='5001'"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsImportar:: actualizarCorrelativo", ex.Message & vbNewLine & consulta)
        End Try
    End Sub



    Protected Function getClientesFactura93012(ByVal codTipo As String) As List(Of Entidades.tb_impcliente)
        Dim consulta As String = String.Empty
        Dim lista As New List(Of Entidades.tb_impcliente)
        Using dtBase As New DataTable
            Try
                consulta = Libreria.LibImportar.getDatos93012(codTipo)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dtBase)
                For Each fila As DataRow In dtBase.Rows
                    If lista.Count > 0 Then
                        Dim item As New tb_impcliente With
                            {.nombre = fila.Item("nombre"),
                             .apellido = fila.Item("apellido"),
                             .ruc_ci = fila.Item("ci_ruc"),
                             .nromov = fila.Item("nummov")}
                        If Not lista.Any(Function(x) x.ruc_ci = item.ruc_ci) Then
                            lista.Add(item)
                        End If
                    Else
                        Dim item As New tb_impcliente With
                             {.nombre = fila.Item("nombre"),
                             .apellido = fila.Item("apellido"),
                             .ruc_ci = fila.Item("ci_ruc"),
                             .nromov = fila.Item("nummov")}
                        lista.Add(item)
                    End If
                Next
            Catch ex As Exception
                set_error("Fallo en clsImportar:: getClientesFactura93012", ex.Message)
            End Try
            Return lista
        End Using
    End Function

    Protected Function getClienteBase(ByRef listBase As List(Of tb_impcliente), ByVal codMov As String) As List(Of Entidades.tb_clienteIn)
        Dim lista As New List(Of Entidades.tb_clienteIn)
        Dim consulta As String = String.Empty
        Try
            For Each itemBase As tb_impcliente In listBase
                Using dtTransaccion As New DataTable
                    consulta = Libreria.LibImportar.getDatosCuerpoProv(codMov, itemBase.nromov)
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dtTransaccion)
                    If dtTransaccion.Rows.Count > 0 Then
                        If Not IsDBNull(dtTransaccion.Rows(0).Item("lqnroliq")) Then
                            If lista.Count > 0 Then

                                Dim item As New tb_clienteIn With
                                    {.nombre = dtTransaccion.Rows(0).Item("prnombre"),
                                     .apellido = dtTransaccion.Rows(0).Item("prapelli"),
                                     .nitci = dtTransaccion.Rows(0).Item("ruc"),
                                     .direccion = dtTransaccion.Rows(0).Item("prdirecc"),
                                     .telefono = dtTransaccion.Rows(0).Item("telefono"),
                                     .celular = Decimal.Zero,
                                     .tipocliente = "0"
                                    }

                                If Not lista.Any(Function(x) x.nitci = item.nitci) Then
                                    lista.Add(item)
                                End If


                            Else
                                Dim item As New tb_clienteIn With
                                    {.nombre = dtTransaccion.Rows(0).Item("prnombre"),
                                     .apellido = dtTransaccion.Rows(0).Item("prapelli"),
                                     .nitci = dtTransaccion.Rows(0).Item("ruc"),
                                     .direccion = dtTransaccion.Rows(0).Item("prdirecc"),
                                     .telefono = dtTransaccion.Rows(0).Item("telefono"),
                                     .celular = Decimal.Zero,
                                     .tipocliente = "0"}
                                lista.Add(item)
                            End If
                        End If
                    End If
                End Using
            Next
        Catch ex As Exception
            set_error("Fallo en clsImportar:: getClienteBase " & consulta, ex.Message)
        End Try
        Return lista
    End Function

    Protected Sub alta(ByVal lista As List(Of tb_impcliente))
        Dim consulta As String = String.Empty
        Try
            Dim varCorrelativo As Integer = 1
            Dim dt As New DataTable
            consulta = LibClienteIn.getCorrelativo()
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            conector.Fill(dt)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item("valor")) Then
                    varCorrelativo = dt.Rows(0).Item("valor")
                End If
            End If

            For Each item As tb_impcliente In lista
                consulta = Libreria.LibImportar.alta(item)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next

        Catch ex As Exception
            set_error("Fallo en clsImportar:: alta  " & consulta, ex.Message)
        End Try
    End Sub



    Public Function getPrueba() As DataTable
        Using dt As New DataTable
            Dim consulta As String = "select  apcodmov, apmonuni, apimport  from aptransa where apgesmes='31/03/2010'"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            conector.Fill(dt)
            Return dt
        End Using
    End Function


#End Region

End Class
