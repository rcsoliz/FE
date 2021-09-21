Imports Entidades
Public Class LibCatalogoFe

    Public Shared Function alta(ByVal item As Entidades.tb_CatalogoFe) As String
        Return "insert into catalogofe (tipo, codigo, nombre) values ('" & item.tipo & "'," & item.codigo & "'," & item.nombre & "')"
    End Function

    Public Shared Function baja(ByVal item As Entidades.tb_CatalogoFe) As String
        Return "delete from catalogofe where tipo='" & item.tipo & "' and codigo=" & item.codigo
    End Function

    Public Shared Function update(ByVal item As Entidades.tb_CatalogoFe) As String
        Return "update catalogofe set nombre='" & item.nombre & "' where tipo='" & item.tipo & "' and codigo=" & item.codigo
    End Function

    Public Shared Function getCatalogo() As String
        Return "select trim(tipo) tipo, codigo, trim(nombre) nombre from catalogofe order by 1,2"
    End Function

    Public Shared Function getCatalogoGrupo(ByVal item As Entidades.tb_CatalogoFe) As String
        Return "select trim(tipo) tipo, codigo, trim(nombre) nombre from catalogofe where tipo='" & item.tipo & "' order by 1,2"
    End Function

    Public Shared Function getCatalogo(ByVal item As Entidades.tb_CatalogoFe) As String
        Return "select trim(tipo) tipo, codigo, trim(nombre) nombre from catalogofe where tipo='" & item.tipo & "' and codigo=" & item.codigo
    End Function

    Public Shared Function getCatalogo(ByVal tipo As String, ByVal codError As String) As String
        Return "SELECT 'tipo'||': '||trim(tipo) ||'   '||'codigo: '||codigo||'   '||'Desc: '||trim(nombre) nombre FROM catalogofe WHERE tipo='" & tipo & "' AND codigo IN (" & codError & ")"
    End Function

End Class