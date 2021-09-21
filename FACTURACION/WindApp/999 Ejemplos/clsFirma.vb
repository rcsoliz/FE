Imports System.Xml
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.IO.Compression
Imports Ionic.Zip

Imports System.IO.Compression.GZipStream
Imports System.Runtime.InteropServices

Public Class clsFirma

    Public Sub firmar(ByVal rutaXml As String)
        Try
            'Crear un nuevo objeto CspParameters para especificar
            'Un contenedor de llaves.
            Dim cspParams As New CspParameters()
            cspParams.KeyContainerName = "XML_DSIG_RSA_KEY"

            'Cree una nueva clave de firma RSA y guárdela en el contenedor.
            Dim rsaKey As New RSACryptoServiceProvider(cspParams)
            Dim xmlDoc As New XmlDocument()


            'Cargar un archivo XML en el objeto XmlDocument.
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load(rutaXml)


            'Firma el documento XML.
            SignXml(xmlDoc, rsaKey)

            MessageBox.Show("Archivo XML firmado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Console.WriteLine("Archivo XML firmado")

            'Guardar el documento.
            Dim nomdoc() As String = rutaXml.Split(".")
            Dim nueDoc As String = nomdoc.GetValue(0) & "f" & ".xml"
            xmlDoc.Save(nueDoc)  '"test.xml"



            'Generar archivo SHA2 de XML de la Factura (cabeza detalle)

            Dim hash2 As String = clsAlgoritmos.getSHA256(nueDoc)
            Dim aux As String = hash2

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    'Firmar un archivo XML.
    'Este documento no puede ser verificado a menos que la verificación
    'código tiene la clave con la que fue firmado.
    Sub SignXml(ByVal xmlDoc As XmlDocument, ByVal rsaKey As RSA)

        'Compruebe los argumentos.
        If xmlDoc Is Nothing Then
            Throw New ArgumentException("Documento xml es null")
        End If
        If rsaKey Is Nothing Then
            Throw New ArgumentException("Documento RSA es null")
        End If

        'Crear un objeto SignedXml.
        Dim signedXml As New SignedXml(xmlDoc)


        'Agregue la clave al documento SignedXml.
        signedXml.SigningKey = rsaKey

        'Crear una referencia para ser firmada.
        Dim reference As New Reference()
        reference.Uri = ""

        'Añadir una transformación envuelta a la referencia.
        Dim env As New XmlDsigEnvelopedSignatureTransform()
        reference.AddTransform(env)

        'Agregar la referencia al objeto SignedXml.
        signedXml.AddReference(reference)


        'Calcular la firma.
        signedXml.ComputeSignature()

        'Obtener la representación XML de la firma y guardar
        'a un objeto XmlElement.
        Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()

        'Añadir el elemento al documento XML.

        xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))

    End Sub

    Public Function comprimirGZip(ByVal pathDirectio As String, ByRef mensajeGZip As String) As Boolean
        'Dim ruta As String = "C:\comprimido\" & pathDirectio

        Dim fileName As String = pathDirectio
        Dim archivoBytes() As Byte = System.IO.File.ReadAllBytes(fileName)
        Dim tramaFirmado As String = Convert.ToBase64String(archivoBytes)

        Dim nombreArchivo As String = "firmado01.text"
        Using fs = File.Create(("{nombreArchivo}.xml"))
            Dim byteFirmado = Convert.FromBase64String(tramaFirmado)
            fs.Write(byteFirmado, 0, byteFirmado.Length)
        End Using


        Dim fileToBeGZipped As FileInfo = New FileInfo(nombreArchivo)
        Dim gzipFileName As FileInfo = New FileInfo(String.Concat(fileToBeGZipped.FullName, ".gz"))

        Using fileToBeZippedAsStream As FileStream = fileToBeGZipped.OpenRead()
            Using gzipTargetAsStream As FileStream = gzipFileName.Create()
                Using gzipStream As GZipStream = New GZipStream(gzipTargetAsStream, CompressionMode.Compress)
                    Try
                        fileToBeZippedAsStream.CopyTo(gzipStream)
                        Return True
                    Catch ex As Exception
                        mensajeGZip = ex.Message
                        Return False
                    End Try
                End Using
            End Using
        End Using
    End Function

    Public Function desComprimirGZip(ByVal pathDirectorio As String, ByRef mensajeGzip As String) As Boolean
        Dim fileToBeGZipped As FileInfo = New FileInfo(pathDirectorio)
        Dim gzipFileName As FileInfo = New FileInfo(String.Concat(fileToBeGZipped.FullName, ".gz"))

        Using fileToDecompressAsStream As FileStream = gzipFileName.OpenRead()
            Dim decompressedFileName As String = "c:\gzip\decompressed.txt" '..........?

            Using decompressedStream As FileStream = File.Create(decompressedFileName)

                Using decompressionStream As GZipStream = New GZipStream(fileToDecompressAsStream, CompressionMode.Decompress)

                    Try
                        decompressionStream.CopyTo(decompressedStream)
                        Return True
                    Catch ex As Exception
                        mensajeGzip = ex.Message
                        Return False
                    End Try
                End Using
            End Using
        End Using
    End Function



    Public Sub GetCRC32(ByVal data As String())
        Dim oCRC32 As New Ionic.Crc.CRC32()

        Dim cs As String() = New String() {"utf8"} ', "cp1252", "cp866" */}
        Dim array As Byte()
        Dim d As Byte

        'For i = 0 To cs.Length
        '    array = data.getBytes(CharSet. .forName(cs(i)))

        'Next
    End Sub

End Class
