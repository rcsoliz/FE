Imports Entidades
Public Class libModalidad

    Public Shared Function alta(ByVal item As tb_modalidad) As String
        Return "insert into tb_modalidad(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_modalidad) As String
        Return "update tb_modalidad set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_modalidad) As String
        Return "delete from tb_modalidad where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_modalidad) As String
        Return "select codigo, trim(descripcion) descripcion from tb_modalidad where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_modalidad order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_modalidad"
    End Function

End Class
