Imports Entidades
Public Class libMensSoap

    Public Shared Function alta(ByVal item As tb_mensSoap) As String
        Return "insert into tb_menssoap(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_mensSoap) As String
        Return "update tb_menssoap set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_mensSoap) As String
        Return "delete from tb_menssoap where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_mensSoap) As String
        Return "select codigo, trim(descripcion) descripcion from tb_menssoap where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_menssoap order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_menssoap"
    End Function

End Class