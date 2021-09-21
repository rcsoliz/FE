Imports Entidades
Public Class LibClienteIn

    'Public Property codigoin As Integer
    'Public Property nombre As String
    'Public Property apellido As String
    'Public Property nitci As String

    Public Shared Function alta(ByVal item As tb_clienteIn) As String
        Return "insert into clientein(codigoin, nombre, apellido, nitci) values(" & item.codigoin & ",'" & item.nombre & "','" & item.apellido & "','" & item.nitci & "')"
    End Function

    Public Shared Function actualizar(ByVal item As tb_clienteIn) As String
        Return "update clientein set nombre='" & item.nombre & "', apellido='" & item.apellido & "' , nitci='" & item.nitci & "' where codigoin=" & item.codigoin
    End Function

    Public Shared Function baja(ByVal item As tb_clienteIn) As String
        Return "delete from clientein where codigoin=" & item.codigoin
    End Function

    Public Shared Function getClienteSin() As String
        Return "select codigoin, trim(nombre) nombre, trim(apellido) apellido, nitci from clientein order by 1, 2,3"
    End Function

    Public Shared Function getClienteSin(ByVal item As tb_clienteIn) As String
        Return "select codigoin, trim(nombre) nombre, trim(apellido) apellido, nitci from clientein where codigoin=" & item.codigoin
    End Function

    Public Shared Function getCorrelativo() As String
        Return "select (pavalor1+1)  valor from afparame where pacodigo='5001' "
    End Function

    Public Shared Function actualizarCorrelativo() As String
        Return "update afparame set pavalor1=pavalor1+1 where pacodigo='5001'"
    End Function

    Public Shared Function getClienteAfclient() As String
        Return "select clcodcli codigo, trim(clnombre) nombre, trim(clapelli) apellidos, trim(cldirecc) direccion, trim(cltelcli) telefono from afclient order by  clnombre, clapelli, 1"
    End Function

    Public Shared Function getClienteAfprovee() As String
        Return "select prcodigo codigo, trim(prnombre) nombre, trim(prapelli) apellidos , trim(prdirecc) direccion, trim(prtelefo) telefono from afprovee order by prnombre, prapelli, 1"
    End Function

End Class
