Imports Entidades
Public Class libPais

    Public Shared Function alta(ByVal item As tb_pais) As String
        Return "insert into tb_pais(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_pais) As String
        Return "update tb_pais set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_pais) As String
        Return "delete from tb_pais where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_pais) As String
        Return "select codigo, trim(descripcion) descripcion from tb_pais where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_pais order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_pais"
    End Function

End Class