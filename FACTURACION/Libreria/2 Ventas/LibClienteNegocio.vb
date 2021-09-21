Imports Entidades
Public Class LibClienteNegocio

    'Public Property codigoin As Integer
    'Public Property codigosistema As String
    'Public Property codUnidad As Integer
    'Public Property tipocliente As Integer
    'Public Property telefono As String
    'Public Property celular As String
    'Public Property direccion As String
    'Public Property fregistro As Date
    'Public Property estado As String
    Public Shared Function alta(ByVal item As tb_clienteNegocio) As String
        Return "insert into clientenegocio(codigoin, codigosistema, codunidad, tipocliente, telefono, celular, direccion, email, fregistro, estado) values(" &
            item.codigoin & "," & item.codigosistema & "," & item.codUnidad & ",'" &
            item.tipocliente & "','" & item.telefono & "','" & item.celular & "','" &
            item.direccion & "','" & item.email & "','" & item.fregistro.ToShortDateString & "', 'a' )"
    End Function

    Public Shared Function actualizar(ByVal item As tb_clienteNegocio) As String
        Return "update clientenegocio set tipocliente='" & item.tipocliente & "', telefono='" & item.telefono & "' , celular='" & item.celular &
               "direccion='" & item.direccion & "' , email='" & item.email & "' where codigoin=" & item.codigoin & " and codigosistema=" & item.codigosistema & " and codUnidad=" & item.codUnidad
    End Function

    Public Shared Function bajaLogica(ByVal item As tb_clienteNegocio) As String
        Return "update clientenegocio set estado='i' where codigoin=" & item.codigoin & " and codigosistema=" & item.codigosistema & " and codUnidad=" & item.codUnidad
    End Function

    Public Shared Function baja(ByVal item As tb_clienteNegocio) As String
        Return "delete from clientenegocio where codigoin=" & item.codigoin & " and codigosistema=" & item.codigosistema & " and codUnidad=" & item.codUnidad & ""
    End Function

    Public Shared Function getClienteNegocio() As String
        Return "select cb.codigoin, cb.codigosistema, cb.codunidad, (trim(cl.nombre)||' '||trim(cl.apellido)) nombre, cl.nitci, " &
            " trim(tipocliente) tipocliente, trim(telefono) telefono, trim(celular) celular,  trim(direccion) direccion," &
"trim(cb.email) email, cb.fregistro fregistro, trim(cb.estado) estado from clientenegocio cb, clientein cl where cl.codigoin=cb.codigoin " &
"order by 4,1,2"
    End Function

    Public Shared Function getClienteNegocio(ByVal item As tb_clienteNegocio) As String

        Return "select codigoin, codigosistema, codunidad, trim(tipocliente) tipocliente, trim(telefono) telefono, trim(celular) celular,  trim(direccion) direccion, " &
    "trim(email) email, fregistro, trim(estado) estado from clientenegocio where codigoin=" & item.codigoin

        'Return "select codigoin, codigosistema, codunidad, trim(tipocliente) tipocliente, trim(telefono) telefono, trim(celular) celular,  trim(direccion) direccion, " &
        '    "trim(email) email, fregistro, trim(estado) estado from clientenegocio where codigoin=" & item.codigoin & " and codigosistema=" & item.codigosistema & " and codUnidad=" & item.codUnidad
    End Function

    Public Shared Function getCliente(ByVal item As tb_clienteNegocio) As String
        Return "select trim(nombre)||' '||trim(apellido) nombre,  nitci from clientein where codigoin=" & item.codigoin
    End Function

End Class
