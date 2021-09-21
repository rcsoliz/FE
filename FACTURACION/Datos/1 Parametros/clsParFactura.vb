Public Class clsParFactura : Inherits BaseDatos

#Region "[atributosGlobales]"

#End Region

#Region "[contrutor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Public Sub alta(ByVal item As Entidades.tb_ParFatura)
        Dim consulta As String = String.Empty
        Try
            consulta = "insert into parfactura (codparame ,descripcion, valor1, valor2, valor3) values (" & item.codparame & ",'" & item.descripcion & "'," &
                item.valor1 & "," & item.valor2 & "," & item.valor3 & ")"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsParFactura:: alta", ex.Message)
        End Try
    End Sub

    Public Sub alta(ByVal lista As List(Of Entidades.tb_ParFatura))
        Dim consulta As String = String.Empty
        Try
            For Each item As Entidades.tb_ParFatura In lista
                consulta = "insert into parfactura (codparame ,descripcion, valor1, valor2, valor3) values (" & item.codparame & ",'" & item.descripcion & "'," &
                    item.valor1 & "," & item.valor2 & "," & item.valor3 & ")"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
            Next
        Catch ex As Exception
            set_error("Fallo en clsParFactura:: alta", ex.Message)
        End Try
    End Sub

    Public Sub actualizar(ByVal item As Entidades.tb_ParFatura)
        Dim consulta As String = String.Empty
        Try
            consulta = "update parfactura set descripcion='" & item.descripcion & "', valor1=" & item.valor1 & "," &
                "valor2=" & item.valor2 & ", valor3=" & item.valor3 & " where codparame=" & item.codparame & ""
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsParFactura:: actualizar", ex.Message)
        End Try
    End Sub

    Public Sub baja(ByVal item As Entidades.tb_ParFatura)
        Dim consulta As String = String.Empty
        Try
            consulta = "delete from parfactura where codparame=" & item.codparame & ""
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Fallo en clsParFactura:: baja", ex.Message)
        End Try
    End Sub

    Public Function getParametro() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select codparame , trim(descripcion) descripcion, valor1, valor2, valor3 from parfactura order by 1,3"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsParFactura:: getParametro", ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Public Function getParametro(ByVal item As Entidades.tb_ParFatura) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = " select codparame, trim(descripcion) descripcion, valor1, valor2, valor3 from parfactura where codparame=" & item.codparame & ""
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsParFactura:: getParametro", ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class
