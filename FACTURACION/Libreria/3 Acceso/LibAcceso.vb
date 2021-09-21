Public Class LibAcceso

    Public Shared Function alta(ByVal item As Entidades.tb_Cobusuar) As String
        Return String.Format("insert into cobusuar1 (usrlogin, usrcodig, usrcdneg, usrsbneg, usrcdcat, " &
                                "usrcdsuc, usrempld, usrpassw, usrnombr, usrapell, " &
                                "usrfecha,  usripeqp, usradrrs,  usrobser,  usremail, " &
                                "usrdepen,  usrejefe, usrestad,  usrfecad, login2, " &
                                "passwor2) values (" &
                                "'{0}',  {1},   {2},   {3},  '{4}', " &
                                "'{5}',  {6},  '{7}', '{8}', '{9}', " &
                                "'{10}','{11}','{12}','{13}','{14}', " &
                                "'{15}','{16}','{17}','{18}','{19}', " &
                                "'{20}')", item.usrlogin, item.usrcodig, item.usrcdneg, item.usrsbneg, item.usrcdcat,
                                item.usrcdsuc, item.usrempld, item.usrpassw, item.usrnombr, item.usrapell,
                                item.usrfecha.ToShortDateString, item.usripeqp, item.usradrrs.Replace(",", ".").ToString(), item.usrobser, item.usremail,
                                item.usrdepen, item.usrejefe, item.usrestad, item.usrfecad.ToShortDateString, item.login2,
                                item.passwor2)
    End Function

    Public Shared Function baja(ByVal item As Entidades.tb_Cobusuar) As String
        Return String.Format("update cobusuar1 set usrestad ='i' where usrlogin='{0}'", item.usrlogin)
    End Function

    Public Shared Function actualizar(ByVal item As Entidades.tb_Cobusuar) As String
        Return "update cobusuar1 set " & _
                   "usrcdneg=" & "" & item.usrcdneg & "" & ", " & _
                   "usrsbneg=" & "" & item.usrsbneg & "" & ", " & _
                   "usrcdcat=" & "'" & item.usrcdcat & "'" & ", " & _
                   "usrcdsuc=" & "'" & item.usrcdsuc & "'" & ", " & _
                   "usrempld=" & "" & item.usrempld & "" & ", " & _
                   "usrpassw=" & "'" & item.usrpassw & "'" & ", " & _
                   "usrnombr=" & "'" & item.usrnombr & "'" & ", " & _
                   "usrapell=" & "'" & item.usrapell & "'" & ", " & _
                   "usrfecha=" & "'" & item.usrfecha.ToShortDateString() & "'" & ", " & _
                   "usripeqp=" & "'" & item.usripeqp & "'" & ", " & _
                   "usradrrs=" & "'" & item.usradrrs & "'" & ", " & _
                   "usrobser=" & "'" & item.usrobser & "'" & ", " & _
                   "usremail=" & "'" & item.usremail & "'" & ", " & _
                   "usrdepen=" & "'" & item.usrdepen & "'" & ", " & _
                   "usrejefe=" & "'" & item.usrejefe & "'" & ", " & _
                   "usrestad=" & "'" & item.usrestad & "'" & ", " & _
                   "usrfecad=" & "'" & item.usrfecad.ToShortDateString & "'," & _
                   "usrlogin= '" & item.usrlogin & "', " & _
                   "login2=' " & item.login2 & "', " &
                   "passwor2= '" & item.passwor2 & "' " &
                   " where trim(usrlogin)='" & item.usrlogin & "'"
    End Function

    Public Shared Function getUsuario(ByVal item As Entidades.tb_Cobusuar) As String
        Return "select trim(usrlogin) usrlogin, usrcodig, usrcdneg, usrsbneg, trim(usrcdcat) usrcdcat, " &
               "trim(usrcdsuc) usrcdsuc, usrempld, trim(usrpassw) usrpassw, trim(usrnombr) usrnombr, trim(usrapell) usrapell, " &
               "usrfecha,  trim(usripeqp) usripeqp, trim(usradrrs) usradrrs,  trim(usrobser) usrobser,  trim(usremail) usremail, " &
               "trim(usrdepen) usrdepen,  trim(usrejefe) usrejefe,  trim(usrestad) usrestad,  usrfecad, trim(login2) login2, " &
               "trim(passwor2) passwor2 from cobusuar1 where cobusuar1.usrestad='" & item.usrestad & "' order by usrnombr, usrapell"
    End Function

    Public Shared Function getUnUsuario(ByVal item As Entidades.tb_Cobusuar) As String
        Return "select trim(usrlogin) usrlogin, usrcodig, usrcdneg, usrsbneg, trim(usrcdcat) usrcdcat, " &
               "trim(usrcdsuc) usrcdsuc, usrempld, trim(usrpassw) usrpassw, trim(usrnombr) usrnombr, trim(usrapell) usrapell, " &
               "usrfecha,  trim(usripeqp) usripeqp, trim(usradrrs) usradrrs,  trim(usrobser) usrobser,  trim(usremail) usremail, " &
               "trim(usrdepen) usrdepen,  trim(usrejefe) usrejefe,  trim(usrestad) usrestad,  usrfecad, trim(login2) login2, " &
               "trim(passwor2) passwor2  from cobusuar1 where cobusuar1.usrlogin='" & item.usrlogin & "'"
    End Function

    Public Shared Function getAcceso(ByVal usuar As String) As String
        Return "select * from cobusuar1 where usrlogin='" & usuar & "' "
    End Function

    Public Shared Function getMaxCodigo() As String
        Return "select (nvl(max(usrcodig),0) +1) codigo from cobusuar1"
    End Function
End Class
