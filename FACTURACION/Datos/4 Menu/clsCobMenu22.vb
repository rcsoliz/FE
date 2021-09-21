Imports Entidades
Public Class clsCobMenu22 : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[eventos]"

    Protected Sub altaCobMenu22(ByVal item As tb_cobmenu22)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("insert into cobmenu22 (codevento, me2event, me2modul, me2subme, me2nprog, me2ofici, me2secue) values ({0},'{1}',{2},{3},{4},'{5}',{6})", item.codevento, item.me2event, item.me2modul, item.me2subme, item.me2nprog, item.me2ofici, item.me2secue)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobMenu22:: altaCobMenu22", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobMenu22(ByVal item As tb_cobmenu22)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmenu22 set me2ofici='{0}' where codevento={1}", item.me2ofici,
                                      item.codevento)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobMenu22:: bajaCobMenu22", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificarCobMenu22(ByVal item As tb_cobmenu22)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmenu22 set me2event='{0}', me2modul={1}, me2subme='{2}', " &
                                     "me2nprog={3} , me2ofici='{4}', me2secue={5} where codevento={6}",
                                     item.me2event, item.me2modul, item.me2subme,
                                     item.me2nprog, item.me2ofici, item.me2secue, item.codevento)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobMenu22:: modificarCobMenu22", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getMaxCobMenu22() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim maxCodigo As Integer = 1
            Try
                consulta = "select (max(codevento)+1) codevento from cobmenu22"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codevento")) Then
                        maxCodigo = dt.Rows(0).Item("codevento")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getMaxCobMenu22", ex.Message & vbNewLine & consulta)
            End Try
            Return maxCodigo
        End Using
    End Function

    Protected Function getUnCobMenu22(ByVal item As tb_cobmenu22) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try 
                consulta = "select codevento, trim(me2event) me2event, me2modul, me2subme, me2nprog, trim(me2ofici) me2ofici, me2secue from cobmenu22 " &
                    "where codevento=" & item.codevento & " order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getUnCobMenu22", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu22XModulo(ByVal item As tb_cobmenu22) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codevento, trim(me2event) me2event, me2modul, me2subme, me2nprog, trim(me2ofici) me2ofici, me2secue " &
                    "from cobmenu22 where me2modul=" & item.me2modul & " and me2subme=" & item.me2subme & " order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMenu11XModulo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu22() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codevento, trim(me2event) me2event, me2modul, me2subme, me2nprog, trim(me2ofici) me2ofici, me2secue " &
                    "from cobmenu22 order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMenu22", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

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

    Protected Function getCobModulCombo(ByVal item As tb_cobmenu22) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = String.Format("select modmodul, trim(moddesc) moddesc from cobmodul1 where modmodul={0} order by 1", item.me2modul)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobModulCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMopro1Combo(ByVal item As tb_cobmenu22) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = String.Format("select idcobpro, trim(mopdescr) mopdescr from cobmopro1 where mopmodul={0} order by mopdescr", item.me2modul)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMoproCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMopro1Combo() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select idcobpro, trim(mopdescr) mopdescr from cobmopro1 order by mopdescr"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMoproCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu11(ByVal item As tb_cobmenu22) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = String.Format("select codmenu1, trim(me1subme) me1subme from cobmenu11 where me1modul={0} and codmenu1={1} order by 2", item.me2modul,
                                         item.me2subme)
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMenu11", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu11() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codmenu1, trim(me1subme) me1subme from cobmenu11 order by 2"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobMenu22:: getCobMenu11", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
