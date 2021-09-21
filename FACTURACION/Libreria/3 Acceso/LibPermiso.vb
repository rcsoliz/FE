Public Class LibPermiso

    Public Shared Function allowAccesAlta(ByVal columna As String, ByVal login As String) As String
        Return "select " & columna & "  from cobacces1 where prglogin='" & login & "'"
    End Function

    Public Shared Function allowAccesAlta(ByVal columna As String, ByVal login As String,
                                          ByVal modulo As Integer, ByVal programa As Integer) As String
        Return "select " & columna & "  from cobacces1 where prglogin='" & login & "' and prgmodul=" & modulo & " and " &
                                                            "prgnprog=" & programa & ""
    End Function

End Class
