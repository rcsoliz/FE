Imports Entidades
Public Class libMotiAnulacion

    Public Shared Function alta(ByVal item As tb_motiAnulacion) As String
        Return "insert into tb_motianulacion(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_motiAnulacion) As String
        Return "update tb_motianulacion set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_motiAnulacion) As String
        Return "delete from tb_motianulacion where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_motiAnulacion) As String
        Return "select codigo, trim(descripcion) descripcion from tb_motianulacion where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_motianulacion order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_motianulacion"
    End Function

End Class
