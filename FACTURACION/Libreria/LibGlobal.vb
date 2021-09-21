Public Class LibGlobal

    Public Shared Function getCotizacion(ByVal fecha As Date) As String
        Return "select cocotiza fecha from afcotdol where cofechap='" & fecha.ToShortDateString & "'"
    End Function

    Public Shared Function getCategoriaDeUsuario() As String
        Return "select pacodigo, trim(padescri) padescri from afparame where (pacodigo > 201) And (pacodigo < 211) order by padescri"
    End Function

    Public Shared Function getUsuariosXSucrusal() As String
        Return "select pacodigo, trim(padescri) padescri from afparame where (pacodigo > 300) AND (pacodigo < 320) order by padescri"
    End Function

    Public Shared Function getParametro(ByVal codigo As String) As String
        Return "select trim(pacodigo) pacodigo, trim(padescri) padescri, pavalor1, pavalor2 from afparame where pacodigo='" & codigo & "' "
    End Function

    Public Shared Function getNegocio() As String
        Return "select coduneg, trim(cabnomb) unidad from cabungocio where coduneg<>0 order by 1 "
    End Function

    Public Shared Function getNegocio(ByVal unidad As Integer) As String
        Return "select coduneg, trim(cabnomb) unidad from cabungocio where coduneg=" & unidad
    End Function

    Public Shared Function getTipoCliente() As String
        Return "select trim(pacodigo) codigo, trim(padescri) descripcion " &
               "from afparame where trim(pacodigo) between '10001' and '10010' " &
               "order by 1"
    End Function

End Class
