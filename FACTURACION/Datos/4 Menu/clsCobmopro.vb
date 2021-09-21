Imports ENTIDADES
Public Class clsCobmopro : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub altaCobMopro(ByVal item As tb_cobmopro)
        Dim consulta As String = String.Empty
        Try
            consulta = "insert into cobmopro1 (idcobpro, mopnprog, mopmodul, mopdescr, mopofici) values (" & item.idcobpro & ",'" &
                item.mopnprog & "'," & item.mopmodul & ",'" & item.mopdescr & "','" & item.mopofici & "')"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmpro:: altaCobMopro", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub bajaCobMopro(ByVal item As tb_cobmopro)
        Dim consulta As String = String.Empty
        Try
            consulta = String.Format("update cobmopro1 set mopofici='{0}' where idcobpro={1}", item.mopofici, item.idcobpro)
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmpro:: bajaCobMopro", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificarCobMopro(ByVal item As tb_cobmopro)
        Dim consulta As String = String.Empty
        Try
            consulta = "update cobmopro1 set mopnprog='" & item.mopnprog & "', mopmodul='" & item.mopmodul &
                "', mopdescr='" & item.mopdescr & "' " &
                ", mopofici='" & item.mopofici & "' " &
                "where idcobpro=" & item.idcobpro & ""
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsCobmopro:: modificarCobMopro", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function getMaxCobMopro() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Dim maxCodigo As Integer = 1
            Try
                consulta = "select (max(idcobpro)+1) idcobpro from cobmopro1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0).Item("idcobpro")) Then
                        maxCodigo = dt.Rows(0).Item("idcobpro")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsCobmopro:: getMaxCobMopro", ex.Message & vbNewLine & consulta)
            End Try
            Return maxCodigo
        End Using
    End Function

    Protected Function getUnCobMopro(ByVal item As tb_cobmopro) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select idcobpro, trim(mopnprog) mopnprog, mopmodul, trim(mopdescr) mopdescr, trim(mopofici) mopofici " &
                    "from cobmopro1 where idcobpro=" & item.idcobpro & " order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmopro:: getUnCobMopro", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getSubModulo(ByVal item As tb_cobmopro) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select mp.idcobpro, trim(mp.mopnprog) programa, mp.mopmodul, " &
                           "(select trim(mo.moddesc) from cobmodul1 mo where mo.modmodul=mp.mopmodul)  " &
                           "modulo, trim(mopdescr) descripcion, trim(mopofici) mopofici " &
                           "from  cobmopro1 mp where mopmodul=" & item.mopmodul & " order by mopdescr"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmopro:: getSubModulo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCobModpro() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select idcobpro, trim(mopnprog) mopnprog, mopmodul, trim(mopdescr) mopdescr, trim(mopofici) mopofici from cobmopro1 order by 1"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsCobmopro:: getCobModpro", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class