Imports Entidades
Public Class libTipoEmision
    Public Shared Function alta(ByVal item As tb_tipoemision) As String
        Return "insert into tb_tipoemision(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_tipoemision) As String
        Return "update tb_tipoemision set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_tipoemision) As String
        Return "delete from tb_tipoemision where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_tipoemision) As String
        Return "select codigo, trim(descripcion) descripcion from tb_tipoemision where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_tipoemision order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_tipoemision"
    End Function

End Class
