Imports Entidades
Public Class clsCobmenu11 : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub altaCobMenu11(ByVal item As tb_cobmenu11)
        Dim consulta As String = String.Empty
        Try
            consulta = "insert into cobmenu11 (codmenu1, me1subme, me1modul, me1ofici, me1secue) values (" & item.codmenu1 & ",'" & item.me1subme & "','" & item.me1modul & "','" &
                item.me1ofici & "'," & item.me1secue & ")"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmenu11:: altaCobMenu11", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobMenu11(ByVal item As tb_cobmenu11)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmenu11 set me1ofici='{0}' where codmenu1={1}", item.me1ofici,
                                      item.codmenu1)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmenu11:: bajaCobMenu11", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificarCobMenu11(ByVal item As tb_cobmenu11)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmenu11 set me1subme='{0}', me1modul='{1}', me1ofici='{2}', " &
                                     "me1secue={3} where codmenu1={4}", item.me1subme, item.me1modul, item.me1ofici,
                                     item.me1secue, item.codmenu1)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmenu11:: modificarCobMenu11", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getMaxCobMenu11() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim maxCodigo As Integer = 1
            Try
                consulta = "select (max(codmenu1)+1) codmenu1 from cobmenu11"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("codmenu1")) Then
                        maxCodigo = dt.Rows(0).Item("codmenu1")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getMaxCobMenu11", ex.Message & vbNewLine & consulta)
            End Try
            Return maxCodigo
        End Using
    End Function

    Protected Function getUnCobMenu11(ByVal item As tb_cobmenu11) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try 'codmenu1 As Integer me1subme As String , me1modul As Integer, me1ofici As String, me1secue As Int16
                consulta = "select codmenu1, trim(me1subme) me1subme, me1modul, trim(me1ofici) me1ofici, me1secue from cobmenu11 " &
                    "where codmenu1=" & item.codmenu1 & " order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getUnCobMenu11", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu11XModulo(ByVal item As tb_cobmenu11) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codmenu1, trim(me1subme) me1subme, me1modul, trim(me1ofici) me1ofici, me1secue " &
                    "from cobmenu11 where me1modul=" & item.me1modul & "order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getCobMenu11XModulo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobMenu11() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codmenu1, trim(me1subme) me1subme, me1modul, trim(me1ofici) me1ofici, me1secue " &
                    "from cobmenu11 order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmenu11:: getCobMenu11", ex.Message & vbNewLine & consulta)
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
                set_error("Error clsCobmenu11:: getCobModulCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
