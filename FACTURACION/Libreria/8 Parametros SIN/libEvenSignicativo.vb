Imports Entidades
Public Class libEvenSignicativo

    Public Shared Function alta(ByVal item As tb_evenSignicativo) As String
        Return "insert into (codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_evenSignicativo) As String
        Return "update tb_evensignicativo set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_evenSignicativo) As String
        Return "delete from tb_evensignicativo where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_evenSignicativo) As String
        Return "select codigo, trim(descripcion) descripcion from tb_evensignicativo where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_evensignicativo order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_evensignicativo"
    End Function

End Class