Imports Entidades
Public Class libDocuFiscales

    Public Shared Function alta(ByVal item As tb_docuFiscales) As String
        Return "insert into tb_docufiscales(codigo, descripcion) values (" & item.codigo & ",'" & item.descripcion & "')"
    End Function

    Public Shared Function modificar(ByVal item As tb_docuFiscales) As String
        Return "update tb_docufiscales set descripcion='" & item.descripcion & "' where codigo=" & item.codigo & ""
    End Function

    Public Shared Function eliminar(ByVal item As tb_docuFiscales) As String
        Return "delete from tb_docufiscales where codigo=" & item.codigo
    End Function

    Public Shared Function listar(ByVal item As tb_docuFiscales) As String
        Return "select codigo, trim(descripcion) descripcion from tb_docufiscales where codigo=" & item.codigo & ""
    End Function

    Public Shared Function listar() As String
        Return "select codigo, trim(descripcion) descripcion from tb_docufiscales order by 1"
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (max(codigo)+1) codigo from tb_docufiscales"
    End Function

End Class
