Imports Entidades
Public Class libUnidMedida

    Public Shared Function alta(ByVal item As tb_unidMedida) As String
        Return "insert into tb_unidmedida(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_unidMedida) As String
        Return "update tb_unidmedida set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_unidMedida) As String
        Return "delete from tb_unidmedida where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_unidMedida) As String
        Return "select codigo, trim(descripcion) descripcion from tb_unidmedida where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_unidmedida order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_unidmedida"
    End Function

End Class