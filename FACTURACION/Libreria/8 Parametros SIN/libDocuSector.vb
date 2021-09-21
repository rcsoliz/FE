Imports Entidades
Public Class libDocuSector

    Public Shared Function alta(ByVal item As tb_docuSector) As String
        Return "insert into tb_docusector(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_docuSector) As String
        Return "update tb_docusector set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_docuSector) As String
        Return "delete from tb_docusector where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_docuSector) As String
        Return "select codigo, trim(descripcion) descripcion from tb_docusector where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_docusector order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_docusector"
    End Function

End Class