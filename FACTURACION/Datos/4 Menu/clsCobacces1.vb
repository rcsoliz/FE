Imports Entidades
Public Class clsCobacces1 : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[eventos]"

    Protected Sub altaCobAcces1(ByVal lista As List(Of tb_cobacces))
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_cobacces In lista
                Dim existeRegistro As Boolean = False

                Using dt As New DataTable
                    consulta = "select trim(prglogin) prglogin, prgmodul , prgnprog from cobacces1 where prglogin='" & item.prglogin & "' and " &
                        "prgmodul=" & item.prgmodul & " and prgnprog=" & item.prgnprog
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dt)
                    If dt.Rows.Count > 0 Then
                        If Not IsDBNull(dt.Rows(0).Item("prglogin")) Then
                            existeRegistro = True
                        End If
                    End If
                End Using

                If Not existeRegistro Then
                    consulta = String.Format("insert into cobacces1 (prglogin, prgmodul , prgnprog, prggraba, prgborra, prgmodif, prgconsu, prgimpri, prgexcel, prgexpdf, prgcopip, prgofici) values ('{0}',{1},{2},'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", item.prglogin, item.prgmodul,
                                             item.prgnprog, item.prggraba, item.prgborra, item.prgmodif, item.prgconsu,
                                             item.prgimpri, item.prgexcel, item.prgexpdf, item.prgcopip, item.prgofici)
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    comando.ExecuteNonQuery()
                End If

            Next
        Catch ex As Exception
            set_error("Error clsCobacces1:: altaCobAcces1", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobAcces1(ByVal item As tb_cobacces)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("delete from cobacces1 where prglogin='{0}' and prgmodul={1} and prgnprog={2}", item.prglogin, item.prgmodul, item.prgnprog)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobacces1:: bajaCobAcces1", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobAcces1(ByVal lista As List(Of tb_cobacces))
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_cobacces In lista
                consulta = String.Format("delete from cobacces1 where prglogin='{0}' and prgmodul={1} and prgnprog={2}", item.prglogin, item.prgmodul, item.prgnprog)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Error clsCobacces1:: bajaCobAcces1", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificarCobAcces1(ByVal lista As List(Of tb_cobacces))
        Dim consulta As String = String.Empty
        Try
            For Each item As tb_cobacces In lista
                consulta = String.Format("update cobacces1 set prggraba='{0}', prgborra='{1}', prgmodif='{2}', prgconsu='{3}', " &
                                         "prgimpri='{4}', prgexcel='{5}', prgexpdf='{6}', prgcopip='{7}', prgofici='{8}' where prglogin='{9}' and prgmodul={10} and prgnprog={11}",
                                         item.prggraba, item.prgborra, item.prgmodif, item.prgconsu,
                                         item.prgimpri, item.prgexcel, item.prgexpdf, item.prgcopip, item.prgofici,
                                         item.prglogin, item.prgmodul, item.prgnprog)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Error clsCobacces1:: modificarCobAcces1", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getCobModulCombo() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select modmodul, trim(moddesc) moddesc from cobmodul1 order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobModulCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMopro1(ByVal item As tb_cobacces) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = String.Format("select idcobpro, trim(mopnprog) mopnprog, trim(mopdescr) mopdescr, mopmodul from cobmopro1 where mopmodul={0} order by mopdescr", item.prgmodul)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getCobacces1XModuloYUsuario", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobacces1XModuloYUsuario(ByVal item As tb_cobacces) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = String.Format("select trim(prglogin) prglogin, prgmodul, (select trim(mo.moddesc) from cobmodul1 mo where mo.modmodul=cobacces1.prgmodul) modulo, prgnprog, (select trim(mopdescr) mopdescr from cobmopro1 pr where pr.idcobpro=cobacces1.prgnprog) programa, trim(prggraba) prggraba, trim(prgborra) prgborra, trim(prgmodif) prgmodif, trim(prgconsu) prgconsu, trim(prgimpri) prgimpri, trim(prgexcel) prgexcel, trim(prgexpdf) prgexpdf, trim(prgcopip) prgcopip, trim(prgofici) prgofici from cobacces1 where prglogin='{0}' and prgmodul={1} order by 1", item.prglogin, item.prgmodul)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getCobacces1XModuloYUsuario", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobacces1XModulo(ByVal item As tb_cobacces) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select trim(prglogin) prglogin, prgmodul, (select trim(mo.moddesc) from cobmodul1 mo where mo.modmodul=cobacces1.prgmodul) modulo, " &
                    "prgnprog, (select trim(mopdescr) mopdescr from cobmopro1 pr where pr.idcobpro=cobacces1.prgnprog) programa, " &
                    "trim(prggraba) prggraba, trim(prgborra) prgborra, trim(prgmodif) prgmodif, " &
                    "trim(prgconsu) prgconsu, trim(prgimpri) prgimpri, trim(prgexcel) prgexcel, trim(prgexpdf) prgexpdf, trim(prgcopip) prgcopip, " &
                    "trim(prgofici) prgofici " &
                    "from cobacces1 " &
                    "where prgmodul='" & item.prgmodul & "' order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getCobacces1XModuloYUsuario", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
