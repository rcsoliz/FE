Imports Libreria
Public Class clsUtilitarioSIN : Inherits BaseDatos

#Region "[constructor]"

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

    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function getCataloFE(ByVal tipo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibUtilitarioSIN.getCataloFE(tipo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getCataloFE" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function


    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES ESPECIFICOS /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function getCataloFE(ByVal tipo As String, ByVal codigo As Integer) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = Libreria.LibUtilitarioSIN.getCataloFE(tipo, codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getCataloFE" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    '_________________________________
    Protected Function getAmbiente(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getAmbinte(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getAmbiente" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getDocuFicales(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getDocuFicales(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getDocuFicales" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getEmision(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getEmision(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getEmision" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getModalidad(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getModalidad(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getModalidad" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getMotivoAnulacion(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getMotivoAnulacion(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getMotivoAnulacion" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getMensSoap(ByVal codigo As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = LibUtilitarioSIN.getMensSoap(codigo)
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Fallo en clsUtilitarioSIN:: getMensSoap" & vbNewLine & consulta, ex.Message)
            End Try
            Return dt
        End Using
    End Function

#End Region

End Class