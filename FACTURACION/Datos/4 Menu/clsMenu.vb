Imports Entidades
Public Class clsMenu : Inherits BaseDatos

#Region "[constructor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String)
        MyBase.New()
        Call abrir_coneccion(usuar, clav)
    End Sub

#End Region

#Region "[metodos]"

    Protected Function getModulo(ByVal usuario As String) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "select modmodul, trim(moddesc) moddesc, modsecue from cobmodul1, cobacces1, cobusuar1 " &
                           "where(cobusuar1.usrlogin = cobacces1.prglogin And cobmodul1.modmodul = cobacces1.prgmodul) " &
                           "and cobacces1.prglogin ='" & usuario & "' " &
                           "and modinsta='SI' " &
                           "and cobusuar1.usrestad='a' " &
                           "group by modmodul, moddesc, modsecue " &
                           "order by modsecue"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsMenu:: getModulo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getSubModulo(ByVal usuario As String, ByVal codModulo As Integer) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try

                consulta = "create temp table tmauxi99999 (codmenu1 integer, me1subme  char(30), me1secue smallint, modmodul integer)"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()

                consulta = "insert into tmauxi99999 select codmenu1, trim(me1subme) me1subme, me1secue, " & codModulo & " " &
                            "from cobmenu11, cobmodul1, cobacces1, cobusuar1 " &
                            "where(cobmodul1.modmodul = cobmenu11.me1modul And cobmodul1.modmodul = cobacces1.prgmodul) " &
                            "And cobusuar1.usrlogin =cobacces1.prglogin  " &
                            "and   modinsta ='SI' and me1ofici ='S' and cobusuar1.usrestad='a'  " &
                            "and prglogin ='" & usuario & "' " &
                            "and cobmodul1.modmodul =" & codModulo & " " &
                            "group by codmenu1, me1subme,me1secue  "
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()

                Using dtaux As New DataTable
                    consulta = "select codmenu1, modmodul from tmauxi99999"
                    comando.CommandType = CommandType.Text
                    comando.CommandText = consulta
                    conector.Fill(dtaux)
                    For Each fila As DataRow In dtaux.Rows
                        Using dtVer As New DataTable
                            consulta = "SELECT codevento, me2subme, trim(me2event) me2event, me2secue FROM cobmenu22, cobmenu11, cobmodul1, cobacces1, cobusuar1, cobmopro1  " &
                               "WHERE(cobmenu22.me2modul = cobmenu11.me1modul AND cobmenu22.me2nprog = cobmopro1.idcobpro " &
                               "AND cobmenu22.me2modul= cobmodul1.modmodul) " &
                               "AND cobmodul1.modmodul = cobmenu11.me1modul " &
                               "AND cobmodul1.modmodul = cobacces1.prgmodul " &
                               "AND TRIM(cobusuar1.usrlogin) = TRIM(cobacces1.prglogin) " &
                               "AND cobacces1.prgnprog = cobmopro1.idcobpro  " &
                               "AND TRIM(cobmodul1.modinsta) ='SI' AND TRIM(cobmenu11.me1ofici) ='S' " &
                               "AND TRIM(cobmopro1.mopofici) ='S'  AND TRIM(cobusuar1.usrestad) ='a' " &
                               "AND TRIM(cobacces1.prglogin) ='" & usuario & "' " &
                               "AND cobmodul1.modmodul=" & fila.Item("modmodul") & " " &
                               "AND cobmenu22.me2subme=" & fila.Item("codmenu1") & " " &
                               "GROUP BY codevento, me2subme, me2event, me2secue " &
                               "ORDER BY me2secue"

                            comando.CommandType = CommandType.Text
                            comando.CommandText = consulta
                            conector.Fill(dtVer)
                            If dtVer.Rows.Count > 0 Then

                            Else
                                consulta = String.Format("delete from tmauxi99999 where codmenu1={0} and modmodul={1}", fila.Item("codmenu1"), fila.Item("modmodul"))
                                comando.CommandType = CommandType.Text
                                comando.CommandText = consulta
                                comando.ExecuteNonQuery()
                            End If
                        End Using
                    Next
                End Using
                consulta = "select codmenu1, trim(me1subme) me1subme, me1secue from tmauxi99999 group by codmenu1, me1subme,me1secue  order by me1secue"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)

                consulta = "drop table tmauxi99999"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                comando.ExecuteNonQuery()
                'consulta = "select codmenu1, trim(me1subme) me1subme, me1secue  " &
                '           "from cobmenu11, cobmodul1, cobacces1, cobusuar1 " &
                '           "where(cobmodul1.modmodul = cobmenu11.me1modul And cobmodul1.modmodul = cobacces1.prgmodul) " &
                '           "And cobusuar1.usrlogin =cobacces1.prglogin  " &
                '           "and   modinsta ='SI' and me1ofici ='S' and cobusuar1.usrestad='a'  " &
                '           "and prglogin ='" & usuario & "' " &
                '           "and cobmodul1.modmodul =" & codModulo & " " &
                '           "group by codmenu1, me1subme,me1secue  " &
                '           "order by me1secue "
                'comando.CommandType = CommandType.Text
                'comando.CommandText = consulta
                'conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsMenu:: getSubModulo", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Function getEvento(ByVal usuario As String, ByVal codModulo As Integer, ByVal codEvento As Integer) As DataTable
        Using dt As New DataTable
            Dim consulta As String = String.Empty
            Try
                consulta = "SELECT codevento, me2subme, trim(me2event) me2event, me2secue FROM cobmenu22, cobmenu11, cobmodul1, cobacces1, cobusuar1, cobmopro1  " &
                           "WHERE(cobmenu22.me2modul = cobmenu11.me1modul AND cobmenu22.me2nprog = cobmopro1.idcobpro " &
                           "AND cobmenu22.me2modul= cobmodul1.modmodul) " &
                           "AND cobmodul1.modmodul = cobmenu11.me1modul " &
                           "AND cobmodul1.modmodul = cobacces1.prgmodul " &
                           "AND TRIM(cobusuar1.usrlogin) = TRIM(cobacces1.prglogin) " &
                           "AND cobacces1.prgnprog = cobmopro1.idcobpro  " &
                           "AND TRIM(cobmodul1.modinsta) ='SI' AND TRIM(cobmenu11.me1ofici) ='S' " &
                           "AND TRIM(cobmopro1.mopofici) ='S'  AND TRIM(cobusuar1.usrestad) ='a' " &
                           "AND TRIM(cobacces1.prglogin) ='" & usuario & "' " &
                           "AND cobmodul1.modmodul=" & codModulo & " " &
                           "AND cobmenu22.me2subme=" & codEvento & " " &
                           "GROUP BY codevento, me2subme, me2event, me2secue " &
                           "ORDER BY me2secue"
                comando.CommandType = CommandType.Text
                comando.CommandText = consulta
                conector.Fill(dt)
            Catch ex As Exception
                set_error("Error clsMenu:: getEvento", ex.Message & vbNewLine & consulta)
            End Try
            Return dt
        End Using
    End Function

    Protected Sub grabarlog_db(ByVal idusuario As String, ByVal idwindows As String, ByVal nequipo As String,
                       ByVal ip As String, ByVal fecha As Date, ByVal b As String)

        Dim consulta As String = String.Empty
        Try
            consulta = "insert into logsesionp (id_usuario,id_windos,nequipo,ip,fecha,hora) values ('" & idusuario & "','" & idwindows & "','" & nequipo & "','" & ip & "','" & fecha & "','" & b & "')"
            comando.CommandType = CommandType.Text
            comando.CommandText = consulta
            comando.ExecuteNonQuery()
        Catch ex As Exception
            set_error("Error clsMenu:: getEvento", ex.Message & vbNewLine & consulta)
        End Try
    End Sub

#End Region

End Class