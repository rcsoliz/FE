﻿Imports Entidades
Imports Libreria
Public Class clsMonedaSin : Inherits BaseDatos

#Region "[constructor]"

    Protected Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub alta(ByVal item As tb_moneda)
        Dim consulta As String = String.Empty
        Try
            consulta = libMoneda.alta(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsMonedaSin:: alta", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub baja(ByVal item As tb_moneda)
        Dim consulta As String = String.Empty
        Try
            consulta = libMoneda.eliminar(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsMonedaSin:: baja", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Sub modificar(ByVal item As tb_moneda)
        Dim consulta As String = String.Empty
        Try
            consulta = libMoneda.modificar(item)
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsMonedaSin:: modificar", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

    Protected Function listar(ByVal item As tb_moneda) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = libMoneda.listar(item)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsMonedaSin:: listar", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function listar() As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = libMoneda.listar()
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsMonedaSin:: listar", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getCorrelativo() As Integer
        Using dt As New DataTable
            Dim consulta As String = String.Empty : Dim correlativo As Integer = 1
            Try
                consulta = libMoneda.getCorrelativo()
                comando.CommandText = consulta
                conector.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0).Item("codigo")) Then
                        correlativo = dt.Rows(0).Item("codigo")
                    End If
                End If
            Catch ex As Exception
                set_error("Error clsMonedaSin:: getCorrelativo", ex.Message & vbNewLine & consulta)
            End Try
            Return correlativo
        End Using
    End Function

#End Region

End Class
