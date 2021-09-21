Imports Entidades
Public Class libMetoPago

    Public Shared Function alta(ByVal item As tb_metoPago) As String
        Return "insert into tb_metopago(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_metoPago) As String
        Return "update tb_metopago set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_metoPago) As String
        Return "delete from tb_metopago where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_metoPago) As String
        Return "select codigo, trim(descripcion) descripcion from tb_metopago where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_metopago order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_metopago"
    End Function

End Class