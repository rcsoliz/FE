Imports Entidades
Public Class libDocuIdentidad

    Public Shared Function alta(ByVal item As tb_docuIdentidad) As String
        Return "insert into tb_docuidentidad(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_docuIdentidad) As String
        Return "update tb_docuidentidad set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_docuIdentidad) As String
        Return "delete from tb_docuidentidad where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_docuIdentidad) As String
        Return "select codigo, trim(descripcion) descripcion from tb_docuidentidad where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_docuidentidad order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_docuidentidad"
    End Function

End Class