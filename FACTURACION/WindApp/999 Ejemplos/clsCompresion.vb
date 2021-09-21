Imports System.IO
Imports Ionic.Zip
Imports System.Security.Cryptography
Imports System.Text

Public Class clsCompresion

    Public Function getTramaGz(ByVal url As String) As String
        Dim archivoBytes() As Byte = System.IO.File.ReadAllBytes(url)
        Dim tramaFirmado As String = Convert.ToBase64String(archivoBytes)

        Dim nombreArchivo As String = "firmado01.text"

        Using fs = File.Create(("{nombreArchivo}.xml"))
            Dim byteFirmado = Convert.FromBase64String(tramaFirmado)
            fs.Write(byteFirmado, 0, byteFirmado.Length)
        End Using

        ' Ahora lo empaquetamos en un ZIP.
        Dim tramaZip As String = GenerarZip(tramaFirmado, nombreArchivo)
        Return tramaZip
    End Function

    Public Function GenerarZip(ByVal tramaXml As String, ByVal nombreArchivo As String) As String
        Dim memOrigen = New MemoryStream(Convert.FromBase64String(tramaXml))
        Dim memDestino = New MemoryStream()
        Dim resultado As String

        Using fileZip = New ZipFile("{nombreArchivo}.gz")
            fileZip.AddEntry("{nombreArchivo}.xml", memOrigen)
            fileZip.Save(memDestino)
            resultado = Convert.ToBase64String(memDestino.ToArray())
        End Using

        memOrigen.Close()
        memDestino.Close()
        Return resultado
    End Function

    Public Function GetSHA256(ByVal str As String) As String
        Dim sha256 As Security.Cryptography.SHA256 = SHA256Managed.Create()
        Dim encoding As ASCIIEncoding = New ASCIIEncoding()
        Dim stream As Byte() = Nothing
        Dim sb As StringBuilder = New StringBuilder()
        stream = sha256.ComputeHash(encoding.GetBytes(str))

        For i As Integer = 0 To stream.Length - 1
            sb.AppendFormat("{0:x2}", stream(i))
        Next

        Return sb.ToString()
    End Function


End Class
