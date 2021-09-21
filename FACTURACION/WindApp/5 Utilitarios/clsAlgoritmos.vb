Imports System.Security.Cryptography
Imports System.Text.ASCIIEncoding
Imports System.Text
Imports System.Collections.Generic
Imports System
Imports Ionic.Crc
Imports System.Math
Imports Ionic.Zip.ZipFile
Imports Ionic.Zlib.GZipStream
Imports System.IO

Public Class clsAlgoritmos

    Public Shared Function getMD5(ByVal str As String) As String
        Dim md5 As MD5 = MD5CryptoServiceProvider.Create()
        Dim encoding As ASCIIEncoding = New ASCIIEncoding()
        Dim stream() As Byte = Nothing
        Dim sb As StringBuilder = New StringBuilder()
        stream = md5.ComputeHash(encoding.GetBytes(str))
        For i As Integer = 0 To stream.Length - 1 Step 1
            sb.AppendFormat("{0:x2}", stream(i))
        Next
        Return sb.ToString().ToLower()
    End Function

    Public Shared Function getSHA256(ByVal str As String) As String
        Dim Sha256 As SHA256 = SHA256Managed.Create()
        Dim encodig As ASCIIEncoding = New ASCIIEncoding
        Dim stream() As Byte = Nothing
        Dim sb As StringBuilder = New StringBuilder()
        stream = Sha256.ComputeHash(encodig.GetBytes(str))
        For i As Integer = 0 To stream.Length - 1 Step 1
            sb.AppendFormat("{0:x2}", stream(i))
        Next
        Return sb.ToString().ToLower()
    End Function

    'Public Shared Function ChkSumCRC32(ByVal str As String) As String
    '    ' Dim alg As Algorithm = New CngAlgorithm(
    '    'Algorithm("CRC32", New cCRC32)
    '    '  Dim alg As Algorithm = CType(New Algorithm("CRC32", New CRC32()), Algorithm)

    '    Dim oCrc32 As CRC32 = New CRC32()
    '    Dim hash As String = String.Empty
    '    Using fl As FileStream = File.Open(str, FileMode.Open)
    '        'For Each b As Byte In oCrc32.GetHashCo(fl)
    '        '    hash += b.ToString("x2").ToLower()
    '        'Next
    '    End Using
    'End Function

    Public Function obtenerMD5(ByVal url As String)
        Dim vHash As String = getMD5(url)
        Return vHash
    End Function

    Public Function obtenerSHA2(ByVal url As String)
        Dim vHash As String = getSHA256(url)
        Return vHash
    End Function

End Class
