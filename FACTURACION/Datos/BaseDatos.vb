Imports System.IO
Public MustInherit Class BaseDatos : Implements IDisposable

#Region "[atributosGlobales]"

    Protected coneccion As System.Data.Odbc.OdbcConnection
    Protected conector As System.Data.Odbc.OdbcDataAdapter
    Protected comando As System.Data.Odbc.OdbcCommand
    Protected transaccion As Odbc.OdbcTransaction
    Protected hostip As String = "97.0.0.103"
    Protected servidor As String = "ol_suse"
    Protected puerto As String = "1526"
    Protected basedato As String = "sfe_frigor" ' "fact_virtual  sfe_frigor
    Protected usuario As String
    Protected password As String
    Protected hayerror As Boolean
    Protected mensajeerror As String

    Protected hayerror2 As Boolean
    Protected mensajeerror2 As String

    Protected mensajeerrorusuario As String

#End Region

#Region "[constructor]"

    Protected Sub New()
        coneccion = New System.Data.Odbc.OdbcConnection
        conector = New System.Data.Odbc.OdbcDataAdapter
        comando = New System.Data.Odbc.OdbcCommand
        hayerror = False
        mensajeerror = String.Empty
        mensajeerrorusuario = String.Empty
    End Sub

#End Region

#Region "[metodos]"

    Protected Sub abrir_transaccion()
        transaccion = coneccion.BeginTransaction()
        comando.Transaction = transaccion
    End Sub

    Protected Sub aceptar_transaccion()
        transaccion.Commit()
    End Sub

    Protected Sub rechazar_transaccion()
        transaccion.Rollback()
    End Sub

    Protected Function get_error() As Boolean
        Return hayerror
    End Function

    Protected Function get_error2() As Boolean
        Return hayerror2
    End Function

    Protected Function get_mensaje_error() As String
        Return mensajeerror
    End Function

    'Protected Function get_mensaje_error_sistema() As String
    '    Return mensajeerror
    'End Function

    Protected Function get_mensaje_error2() As String
        Return mensajeerror2
    End Function

    Protected Sub set_error(ByVal mensaje As String)
        hayerror = True
        mensajeerror = mensaje
        ' Set a variable to the My Documents path.
        Dim mydocpath As String = "D:\Ejecutables_Otros_Sistemas\Facturacion_Impuestos\WriteLines.txt"
        Using outputFile As New StreamWriter(mydocpath, True)
            outputFile.WriteLine(mensajeerror)
        End Using
    End Sub

    Protected Sub set_error(ByVal mensajeusuario As String, ByVal mensaje_sistema As String)
        hayerror = True
        mensajeerror = mensaje_sistema
        mensajeerrorusuario = mensajeusuario
        mensajeerror2 = mensajeusuario

        Dim mydocpath As String = "D:\Ejecutables_Otros_Sistemas\Facturacion_Impuestos\WriteLines.txt"
        Using outputFile As New StreamWriter(mydocpath, True)
            outputFile.WriteLine(mensajeerror)
        End Using
    End Sub

    Protected Sub set_error2(ByVal mensaje As String)
        hayerror2 = True
        mensajeerror2 = mensaje
    End Sub

    Protected Sub limpiar_error()
        hayerror = False
        mensajeerror = ""
    End Sub
    Protected Sub limpiar_error2()
        hayerror2 = False
        mensajeerror2 = ""
    End Sub

    Protected Sub cerrar_coneccion()
        coneccion.Close()
    End Sub

    Protected Sub abrir_coneccion(ByVal usuario_ As String, ByVal password_ As String)
        coneccion.Close()

        coneccion.ConnectionString = "OPTOFC=0;CLOC=es_ES.819;VMB=0;RKC=0;ODTYP=0;RCWC=0;ICUR=0;CURB" & _
   "=0;DDFP=0;DRIVER={IBM INFORMIX ODBC DRIVER};SCUR=0;PRO=onsoctcp;DNL=0;OPT" & _
   "=;OAC=1;DLOC=es_ES.819" & _
   ";DATABASE=" & basedato & _
   ";HOST=" & hostip & _
   ";SRVR=" & servidor & _
   ";SERV=" & puerto & _
   ";PWD=" & password_ & _
   ";UID=" & usuario_

        Try
            coneccion.ConnectionTimeout = 5000
            comando.CommandTimeout = 5000
            coneccion.Open()

        Catch ex As Exception
            hayerror = True
            mensajeerror = "Error en Base_datos::sin coneccion: " & ex.Message
        End Try
        If coneccion.State = ConnectionState.Open Then
            comando.Connection = coneccion
            conector.SelectCommand = comando
        Else
            hayerror = True
            mensajeerror = "Error en Base_datos::abrir_coneccion "
        End If
    End Sub

    Public Sub abrir_coneccion(ByVal datos_tabla As DataTable)
        coneccion.Close() 'yes
        coneccion.ConnectionString = "OPTOFC=0;CLOC=es_ES.819;VMB=0;RKC=0;ODTYP=0;RCWC=0;ICUR=0;CURB" & _
           "=0;DDFP=0;DRIVER={IBM INFORMIX ODBC DRIVER};SCUR=0;PRO=onsoctcp;DNL=0;OPT" & _
           "=;OAC=1;DLOC=es_ES.819" & _
           ";DATABASE=" & Trim(datos_tabla.Rows(0).Item("basedato")) & _
           ";HOST=" & Trim(datos_tabla.Rows(0).Item("hostip")) & _
           ";SRVR=" & Trim(datos_tabla.Rows(0).Item("servidor")) & _
           ";SERV=" & Trim(datos_tabla.Rows(0).Item("puerto")) & _
           ";PWD=" & Trim(datos_tabla.Rows(0).Item("clave")) & _
           ";UID=" & Trim(datos_tabla.Rows(0).Item("usuario"))


        Try
            coneccion.ConnectionTimeout = 5000
            comando.CommandTimeout = 5000
            coneccion.Open()

        Catch ex As Exception
            hayerror = True
            mensajeerror = "Error en Base_datos::sin coneccion: " & ex.Message
        End Try
        If coneccion.State = ConnectionState.Open Then
            comando.Connection = coneccion
            conector.SelectCommand = comando
        Else
            hayerror = True
            mensajeerror = "Error en Base_datos::abrir_coneccion "
        End If
    End Sub


    Protected Sub selecciona_datos_consulta(ByRef objeto As System.Data.DataTable, ByVal cadena As String)
        Dim strsql As String
        strsql = Trim(cadena)
        Dim datos_tabla As New System.Data.DataTable
        Try
            comando.CommandText = strsql
            conector.Fill(datos_tabla)
            objeto = datos_tabla
        Catch ex As Exception
            hayerror = True
            mensajeerror = "Error en Base_datos::selecciona_datos_consulta: " & ex.Message
        End Try
    End Sub

    Protected Function dar_dato_tabla_posicion(ByVal objeto As System.Data.DataTable, ByVal posicion As Integer) As String
        Dim encontrado As System.Data.DataRow
        Dim valor As String = ""
        For Each encontrado In objeto.Rows
            valor = encontrado.Item(0)
        Next
        Return valor
    End Function

    Protected Function dar_dato_tabla_nombre_columna(ByVal objeto As System.Data.DataTable, ByVal nombre As String) As String
        Dim encontrado As System.Data.DataRow
        Dim valor As String = ""
        For Each encontrado In objeto.Rows
            If IsDBNull(encontrado.Item(nombre)) Then
                valor = 0
            Else
                valor = encontrado.Item(nombre)
            End If
        Next
        Return valor
    End Function

    Protected Function Obtener_Datos_Coneccion(ByVal codgrupo As String, ByVal codact As String) As DataTable
        Dim consulta As String = Trim("select * from datos_coneccion where codgrupo='" & Trim(codgrupo) & "' and actividad='" & Trim(codact) & "'")
        Try
            Dim datos_tabla As New DataTable()
            selecciona_datos_consulta(datos_tabla, consulta)
            Return datos_tabla
        Catch ex As Exception
            set_error("Error en Datos_logerror_db:: Obtener_contra_base datos ")
        End Try
        Return Nothing
    End Function

    Protected Function Obtener_Datos_Coneccion(ByVal codact As String) As DataTable
        Dim consulta As String = Trim("select * from datos_coneccion where actividad='" & Trim(codact) & "'")
        Try
            Dim datos_tabla As New DataTable()
            selecciona_datos_consulta(datos_tabla, consulta)
            Return datos_tabla
        Catch ex As Exception
            set_error("Error en Datos_logerror_db:: Obtener_contra_base datos ")
        End Try
        Return Nothing
    End Function

#End Region

#Region "IDisposable Support"
    Private disposedValue As Boolean ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: eliminar estado administrado (objetos administrados).
            End If

            ' TODO: liberar recursos no administrados (objetos no administrados) e invalidar Finalize() below.
            ' TODO: Establecer campos grandes como Null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: invalidar Finalize() sólo si la instrucción Dispose(ByVal disposing As Boolean) anterior tiene código para liberar recursos no administrados.
    'Protected Overrides Sub Finalize()
    '    ' No cambie este código. Ponga el código de limpieza en la instrucción Dispose(ByVal disposing As Boolean) anterior.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class