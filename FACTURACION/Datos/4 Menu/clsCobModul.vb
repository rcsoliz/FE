Imports ENTIDADES
Public Class clsCobModul : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub altaCobModul(ByVal item As tb_codmodul)
        Dim consulta As String = String.Empty
        Dim lista As New List(Of tb_codmodul)
        '  lista.ElementAt()
        Try
            consulta = "insert into cobmodul1 (modmodul, moddesc, modinsta, modofici, modsecue) values (" & item.modmodul & ",'" &
                item.moddesc & "','" & item.modinsta & "','" & item.modofici & "'," & item.modsecue & ")"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobModul:: altaCobModul", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobModul(ByVal item As tb_codmodul)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmodul1 set modinsta='{0}' where modmodul={1}", item.modinsta, item.modmodul)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobModul:: bajaCobModul", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificarCobModul(ByVal item As tb_codmodul)
        Dim consulta As String = String.Empty
        Try
            consulta = "update cobmodul1 set moddesc='" & item.moddesc & "', modofici='" & item.modofici & "', modsecue='" & item.modsecue & "', " &
                "modinsta='" & item.modinsta & "' where modmodul=" & item.modmodul & ""
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobModul:: modificarCobModul", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getMaxCobModul() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim maxCodigo As Integer = 1
            Try
                consulta = "select (max(modmodul)+1) modmodul from cobmodul1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("modmodul")) Then
                        maxCodigo = dt.Rows(0).Item("modmodul")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsCobModul:: getMaxCobModul", ex.Message & vbNewLine & consulta)
            End Try
            Return maxCodigo
        End Using
    End Function

    Protected Function getUnCobModul(ByVal item As tb_codmodul) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select modmodul, trim(moddesc) moddesc, trim(modinsta) modinsta, modofici, modsecue from cobmodul1 " &
                    "where modmodul=" & item.modmodul & " order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobModul:: getUnCobModul", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobModulActivo() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select modmodul, trim(moddesc) moddesc, trim(modinsta) modinsta, modofici, modsecue " &
                    "from cobmodul1 where modinsta='SI' order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobModul:: getCobModulActivo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobModulInactivo() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select modmodul, trim(moddesc) moddesc, trim(modinsta) modinsta, modofici, modsecue " &
                    "from cobmodul1 where modinsta='NO'order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobModul:: getCobModulInactivo", ex.Message & vbNewLine & consulta)
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
                set_error("Error clsCobModul:: getCobModulCombo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
