Imports Entidades
Public Class libMoneda

    Public Shared Function alta(ByVal item As tb_moneda) As String
        Return "insert into tb_moneda(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_moneda) As String
        Return "update tb_moneda set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_moneda) As String
        Return "delete from tb_moneda where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_moneda) As String
        Return "select codigo, trim(descripcion) descripcion from tb_moneda where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_moneda order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_moneda"
    End Function

End Class