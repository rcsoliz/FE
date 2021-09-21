Imports System.IO
Public Class clDirectorio

#Region "[metodos]"

    Public Shared Function crearDirectorio(ByVal usuario As String) As Boolean
        Dim resultado As Boolean = False
        Dim fecha As Date = Date.Now
        Try
            Dim Array_Dir() As Object
            Dim rutaHoy() As String = {String.Format("C:\Facturacion\{0}\Archivos\Directorio\Sfe\", usuario),
                                       String.Format("C:\Facturacion\{0}\Archivos\{1}{2}{3}\Directorio", usuario, fecha.Year, fecha.Month, fecha.Day)}

            For Each ruta As String In rutaHoy
                If ruta = vbNullString Then
                    resultado = False
                    Exit For
                Else
                    Dim str As String = ""
                    Array_Dir = Split(ruta, "\")
                    For Each carpeta In Array_Dir
                        If carpeta <> Nothing Or carpeta <> String.Empty Or carpeta <> "" Then
                            str &= carpeta & "\"
                            If Directory.Exists(str) = False Then
                                Directory.CreateDirectory(str)
                            End If
                            resultado = True
                        End If
                    Next
                End If
            Next

            'If Directory.Exists("C:\Facturacion\" & usuario & "\Archivos") Then
            '    Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
            '    crearAccesoDirecto(String.Format("C:\Facturacion\{0}\Archivos\Directorio\", usuario), s, "Directorio de Trabajo")
            'End If

            If Directory.Exists("C:\Facturacion\" & usuario & "\Archivos\Directorio\Sfe") Then
                Dim s As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                crearAccesoDirecto(String.Format("C:\Facturacion\{0}\Archivos\Directorio\Sfe", usuario), s, "SFE")
            End If

        Catch ex As Exception

        End Try
        Return resultado
    End Function

    Private Shared Function crearAccesoDirecto(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Boolean
        Dim oShell As Object
        Dim oLink As Object
        'you don’t need to import anything in the project reference to create the Shell Object
        Dim resultado As Boolean = False
        Try

            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()
            resultado = True
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function



    Public Function verificarDirectorio(ByVal ruta As String)
        Dim resultado As Boolean = False
        Try
            If Directory.Exists(ruta) Then
                resultado = True
            End If
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function

    Public Function verificarArchivo(ByVal rutaArchivo As String)
        Dim resultado As Boolean = False
        Try
            If File.Exists(rutaArchivo) Then
                resultado = True
            End If
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function

    Public Function verificarArchivo(ByVal rutaArchivo() As String)
        Dim resultado As Boolean = False
        Try
            For Each archivo As String In rutaArchivo
                If File.Exists(archivo) Then
                    resultado = True
                Else
                    resultado = False
                    Exit For
                End If
            Next
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function

    Public Function nombreArchivo(ByVal rutaArchivo As String)
        Dim resultado As String
        Try
            Dim info As New FileInfo(rutaArchivo)
            resultado = info.Name
        Catch ex As Exception
            resultado = ""
        End Try
        Return resultado
    End Function

    Public Function extensionArchivo(ByVal rutaArchivo As String)
        Dim resultado As String
        Try
            Dim info As New FileInfo(rutaArchivo)
            resultado = info.Extension
        Catch ex As Exception
            resultado = ""
        End Try
        Return resultado
    End Function

    Public Function rutaArchivo(ByVal archivo As String)
        Dim resultado As String
        Try
            Dim info As New FileInfo(archivo)
            resultado = info.DirectoryName
        Catch ex As Exception
            resultado = ""
        End Try
        Return resultado
    End Function

    Public Sub copiarArchivo(ByVal rutaArchivo_() As String, ByVal rutaCopia_ As String)
        For Each file_ As String In rutaArchivo_
            If verificarArchivo(rutaArchivo_) Then
                If verificarArchivo(String.Format("{0}{1}", rutaCopia_, nombreArchivo(file_))) = False Then
                    My.Computer.FileSystem.CopyFile(file_, String.Format("{0}{1}", rutaCopia_, nombreArchivo(file_)), False)
                End If
            End If
        Next
    End Sub

    Public Sub copiarArchivo(ByVal rutaArchivo_ As String, ByVal rutaCopia_ As String)
        If verificarArchivo(rutaArchivo_) Then
            If verificarArchivo(String.Format("{0}{1}", rutaCopia_, nombreArchivo(rutaArchivo_))) = False Then
                My.Computer.FileSystem.CopyFile(rutaArchivo_, String.Format("{0}{1}", rutaCopia_, nombreArchivo(rutaArchivo_)), False)
            End If
        End If
    End Sub

    Public Function contarCarpeta(ByVal directorio_ As String)
        Dim resultado As Boolean = False
        Try
            Dim contadorDeArchivos As System.Collections.ObjectModel.ReadOnlyCollection(Of String)
            contadorDeArchivos = My.Computer.FileSystem.GetFiles(directorio_)
            If contadorDeArchivos.Count > 0 Then
                resultado = False
            Else
                resultado = True
            End If
        Catch ex As Exception
            resultado = False
        End Try
        Return resultado
    End Function

#End Region

End Class
