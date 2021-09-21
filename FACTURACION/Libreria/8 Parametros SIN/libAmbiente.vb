Imports Entidades
Public Class libAmbiente

    Public Shared Function alta(ByVal item As tb_ambiente) As String
        Return "insert into tb_ambiente(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_ambiente) As String
        Return "update tb_ambiente set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_ambiente) As String
        Return "delete from tb_ambiente where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_ambiente) As String
        Return "select codigo, trim(descripcion) descripcion from tb_ambiente where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_ambiente order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_ambiente"
    End Function

End Class