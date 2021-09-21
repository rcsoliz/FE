Public Class LibUtilitarioSIN
    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getCataloFE(ByVal tipo As String)
        Return "select codigo, trim(nombre) nombre from catalogofe WHERE tipo='" & tipo & "' order by 1"
    End Function

    ''' <summary>
    ''' retorna todos los TIPOS CATALOGOS OFICIALES ESPECIFICOS /SFE_FRIGOR
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getCataloFE(ByVal tipo As String, ByVal codigo As String)
        Return "select codigo, trim(nombre) nombre from catalogofe WHERE tipo='" & tipo & "' codigo=" & codigo & " order by 1"
    End Function

    Public Shared Function getAmbinte(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_ambiente where codigo= " & codigo
    End Function

    Public Shared Function getDocuFicales(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_docufiscales where codigo= " & codigo
    End Function

    Public Shared Function getEmision(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_tipoemision where codigo= " & codigo
    End Function

    Public Shared Function getModalidad(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_modalidad where codigo= " & codigo
    End Function

    Public Shared Function getMotivoAnulacion(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_motianulacion where codigo= " & codigo
    End Function

    Public Shared Function getMensSoap(ByVal codigo As String) As String
        Return "select codigo, trim(descripcion) descripcion from tb_menssoap where codigo in (" & codigo & ")"
    End Function

End Class