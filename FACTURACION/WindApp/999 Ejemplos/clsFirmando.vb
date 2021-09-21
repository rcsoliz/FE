Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Xml
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports Ionic.Zip
Imports System.IO.Compression

Public Class clsFirmando

    'Public Shared Function SignXmlDocument(ByVal xmlFilePath As String, ByVal certificate As X509Certificate2) As XmlDocument
    '    Dim xmlDocument As XmlDocument = New XmlDocument With {.PreserveWhitespace = True}
    '    xmlDocument.Load(xmlFilePath)

    '    Dim signedXml As SignedXml = New SignedXml(xmlDocument) With {.SigningKey = certificate.PrivateKey}

    '    Dim reference As Reference = New Reference With {.Uri = ""}

    '    Dim env As XmlDsigEnvelopedSignatureTransform = New XmlDsigEnvelopedSignatureTransform()
    '    reference.AddTransform(env)

    '    signedXml.AddReference(reference)

    '    Dim keyInfo As KeyInfo = New KeyInfo()
    '    Dim keyInfoX509Data As KeyInfoX509Data = New KeyInfoX509Data(certificate, X509IncludeOption.ExcludeRoot)

    '    keyInfo.AddClause(keyInfoX509Data)
    '    signedXml.KeyInfo = keyInfo
    '    signedXml.ComputeSignature()

    '    Dim xmldsigXmlElement As XmlElement = signedXml.GetXml()
    '    xmlDocument.DocumentElement.PrependChild(xmlDocument.ImportNode(xmldsigXmlElement, True))

    '    Return xmlDocument
    'End Function

    'Public Sub firmar1()
    '    Dim l_xml As String = "C:\Users\Romain\Desktop\SUNAT\test csharp\20381235051-01-FF11-01.xml"
    '    Dim l_certificado As String = "C:\Users\Romain\Desktop\SUNAT\test csharp\aG9CcVpHVndCWTd3WlVOVw==.p12"
    '    Dim l_pwd As String = "5861642"
    '    Dim l_xpath As String

    '    Dim l_cert As X509Certificate2 = New X509Certificate2(l_certificado, l_pwd)

    '    Dim xmlDoc As XmlDocument = New XmlDocument()
    '    xmlDoc.PreserveWhitespace = True
    '    xmlDoc.Load(l_xml)

    '    Dim signedXml As SignedXml = New SignedXml(xmlDoc)

    '    signedXml.SigningKey = l_cert.PrivateKey
    '    Dim KeyInfo As KeyInfo = New KeyInfo()

    '    Dim Reference As Reference = New Reference()
    '    Reference.Uri = ""

    '    Reference.AddTransform(New XmlDsigEnvelopedSignatureTransform())
    '    signedXml.AddReference(Reference)

    '    Dim X509Chain As X509Chain = New X509Chain()
    '    X509Chain.Build(l_cert)

    '    Dim local_element As X509ChainElement = X509Chain.ChainElements(0)
    '    Dim x509Data As KeyInfoX509Data = New KeyInfoX509Data(local_element.Certificate)
    '    Dim subjectName As String = local_element.Certificate.Subject

    '    x509Data.AddSubjectName(subjectName)
    '    KeyInfo.AddClause(x509Data)

    '    signedXml.KeyInfo = KeyInfo
    '    signedXml.ComputeSignature()

    '    Dim Signature As XmlElement = signedXml.GetXml()
    '    Signature.Prefix = "ds"
    '    signedXml.ComputeSignature()

    '    For Each loop_node As XmlNode In Signature.SelectNodes("descendant-or-self::*[namespace-uri()='http://www.w3.org/2000/09/xmldsig#']")
    '        If (loop_node.LocalName = "Signature") Then
    '            Dim newAttribute As XmlAttribute = xmlDoc.CreateAttribute("Id")
    '            newAttribute.Value = "SignatureSP"
    '            loop_node.Attributes.Append(newAttribute)
    '        End If
    '    Next
    'End Sub

    Public Sub Firmar()
        Dim archivoFirma As String = "D:\Facturacion\FACTURACION\WindApp\frigorCertificado.pfx"
        Dim cert As X509Certificate2 = New X509Certificate2(archivoFirma, "123", X509KeyStorageFlags.Exportable)
        Dim xmlDoc As XmlDocument = New XmlDocument()
        xmlDoc.PreserveWhitespace = True
        xmlDoc.Load("D:\Facturacion\FACTURACION\WindApp\1_190730092233.xml")
        SignXml(xmlDoc, cert)
        xmlDoc.Save("D:\Facturacion\FACTURACION\WindApp\FA076Firmado13.xml")
    End Sub

    Public Function Firmar(ByVal rutaCertificado As String, ByVal passCertificado As String, ByVal rutaXML As String,
                           ByVal rutaXMLFirmado As String, ByRef menError As String) As Boolean
        Dim esFirmado As Boolean = False
        Try
            Dim certificado As X509Certificate2 = New X509Certificate2(rutaCertificado, passCertificado, X509KeyStorageFlags.Exportable)
            Dim xmlDoc As XmlDocument = New XmlDocument()
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load(rutaXML)
            SignXml(xmlDoc, certificado)
            xmlDoc.Save(rutaXMLFirmado)
            esFirmado = True
        Catch ex As Exception
            menError = ex.Message
            esFirmado = False
        End Try
        Return esFirmado
    End Function

    Public Sub SignXml(ByVal xmlDoc As XmlDocument, ByVal cert As X509Certificate2)
        If xmlDoc Is Nothing Then Throw New ArgumentException("xmlDoc")
        If cert Is Nothing Then Throw New ArgumentException("Cert")

        Dim exportedKeyMaterial = cert.PrivateKey.ToXmlString(True)
        Dim key = New RSACryptoServiceProvider(New CspParameters(24))
        key.PersistKeyInCsp = False
        key.FromXmlString(exportedKeyMaterial)

        '________________ XMLSignature

        Dim signedXml As SignedXml = New SignedXml(xmlDoc)
        signedXml.SigningKey = key
        signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256"

        Dim signatureMethod As String = "http://www.w3.org/2001/04/xmlenc#sha256"

        Dim reference As Reference = New Reference()
        reference.AddTransform(New XmlDsigEnvelopedSignatureTransform())
        reference.AddTransform(New XmlDsigC14NWithCommentsTransform())

        reference.DigestMethod = signatureMethod

        '____________________________________xml-exc-c14n#
        reference.Uri = ""
        'Dim ddd As New SignedXml
        'ddd.

        signedXml.AddReference(reference)
        Dim keyInfo As KeyInfo = New KeyInfo()
        keyInfo.AddClause(New KeyInfoX509Data(cert))
        signedXml.KeyInfo = keyInfo
        signedXml.ComputeSignature()

        'Dim xmlDigitalSignature As XmlElement = signedXml.GetXml()
        'xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, True))

        xmlDoc.DocumentElement.AppendChild(signedXml.GetXml())
    End Sub


    Public Function getBase64(ByVal urlXmlFirmado As String, ByRef tramaZip As String, ByRef menBase64 As String) As Boolean
        Dim bandera As Boolean = False
        Try
            If Not String.IsNullOrEmpty(urlXmlFirmado) Then
                If System.IO.File.Exists(urlXmlFirmado) Then
                    Dim archivoBytes As Byte() = System.IO.File.ReadAllBytes(urlXmlFirmado)
                    Dim tramaFirmado As String = Convert.ToBase64String(archivoBytes)

                    Dim nombreArchivo As String = "firmado01.text"

                    Using fs = File.Create(("{nombreArchivo}.xml"))
                        Dim byteFirmado = Convert.FromBase64String(tramaFirmado)
                        fs.Write(byteFirmado, 0, byteFirmado.Length)
                    End Using

                    tramaZip = GenerarZip(tramaFirmado, nombreArchivo)
                    If tramaZip <> String.Empty Then
                        bandera = True
                    End If
                Else
                    menBase64 = "Clase:clsFirmando -> Metodo: getBase64() " & vbNewLine & "MEnsaje: No existe archivo generado para continuar "
                End If
            Else
                menBase64 = "Url de Archivo esta Vacia no se puede continuar"
            End If
        Catch ex As Exception
            menBase64 = ex.Message
        End Try
        Return bandera
    End Function

    Public Function GenerarZip(ByVal tramaXml As String, ByVal nombreArchivo As String) As String
        Dim memOrigen = New MemoryStream(Convert.FromBase64String(tramaXml))
        'Dim memOrigen = New MemoryStream(tramaXml)
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

    Public Shared Function GenerarZipDos(ByVal urlSin As String, ByRef resultado As String, ByVal menError As String) As Boolean
        Try
            Dim buffer As Byte() = System.IO.File.ReadAllBytes(urlSin)
            Dim tramaFirmado = Convert.ToBase64String(buffer)

            Dim nombreArchivo = "C:\Facturacion\frigor\Archivos\2019910\nuevo.text"

            'Using fs = File.Create(nombreArchivo & ".xml")
            '    Dim byteFirmado = Convert.FromBase64String(tramaFirmado)
            '    fs.Write(byteFirmado, 0, byteFirmado.Length)
            'End Using
            '____________________ GENERAR ZIP
            Dim memOrigen = New MemoryStream(Convert.FromBase64String(tramaFirmado))
            Dim memDestino = New MemoryStream()
            Using fileZip = New ZipFile(nombreArchivo & ".gz")
                fileZip.AddEntry(nombreArchivo & ".xml", memOrigen)
                fileZip.Save(memDestino)
                resultado = Convert.ToBase64String(memDestino.ToArray())
            End Using

            memOrigen.Close()
            memDestino.Close()
            Return True
        Catch ex As Exception
            menError = ex.Message
        End Try
        Return False
    End Function

    Public Shared Function Compacta1(ByVal text As String, ByRef tramaZip As String, ByRef menError As String) As Boolean
        Try
            Dim buffer As Byte() = System.IO.File.ReadAllBytes(text)
            Dim inputStr = Convert.ToBase64String(buffer)
            Dim inputBytes As Byte() = Convert.FromBase64String(inputStr)

            ' Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(inputStr)

            Using outputStream = New MemoryStream()

                Using gZipStream = New GZipStream(outputStream, CompressionMode.Compress)
                    gZipStream.Write(inputBytes, 0, inputBytes.Length)
                End Using

                Dim outputBytes = outputStream.ToArray()
                Dim outputbase64 = Convert.ToBase64String(outputBytes)

                tramaZip = outputbase64
                Return True
            End Using
        Catch ex As Exception

        End Try
        Return False
    End Function


    Public Shared Function Compacta2(ByVal text As String, ByRef tramaZip As String, ByRef menError As String) As Boolean
        Try
            Dim buffer As Byte() = System.IO.File.ReadAllBytes(text)
            Dim base64String As String = Convert.ToBase64String(buffer, 0, buffer.Length)
            Dim arregloBytes As Byte() = Convert.FromBase64String(base64String)

            Using ms As MemoryStream = New MemoryStream()
                Using zip As GZipStream = New GZipStream(ms, CompressionMode.Compress, True)
                    zip.Write(arregloBytes, 0, arregloBytes.Length)
                End Using
                ms.Position = 0
                Dim outStream As MemoryStream = New MemoryStream()
                Dim compressed As Byte() = New Byte(ms.Length - 1) {}
                ms.Read(compressed, 0, compressed.Length)
                Dim gzBuffer As Byte() = New Byte(compressed.Length + 4 - 1) {}
                System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length)
                System.Buffer.BlockCopy(BitConverter.GetBytes(arregloBytes.Length), 0, gzBuffer, 0, 4)
                tramaZip = Convert.ToBase64String(gzBuffer)

                Return True
            End Using

          
        Catch ex As Exception
            menError = ex.Message
        End Try
        Return False
    End Function


    Public Shared Function Compacta(ByVal text As String, ByRef tramaZip As String, ByRef menError As String) As String
        Try
            Dim buffer As Byte() = System.IO.File.ReadAllBytes(text)
            Dim tramaFirmado = Convert.ToBase64String(buffer)

            'Dim aux As Byte() = Convert.FromBase64String(buffer)
            'Dim aux As Byte() = New Byte(buffer.Length - 1) {}


            Dim ms As MemoryStream = New MemoryStream()

            Using zip As GZipStream = New GZipStream(ms, CompressionMode.Compress, True)
                zip.Write(buffer, 0, buffer.Length)
            End Using

            ms.Position = 0
            Dim outStream As MemoryStream = New MemoryStream()
            Dim compressed As Byte() = New Byte(ms.Length - 1) {}
            ms.Read(compressed, 0, compressed.Length)
            Dim gzBuffer As Byte() = New Byte(compressed.Length + 4 - 1) {}
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length)
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4)
            tramaZip = Convert.ToBase64String(gzBuffer)
            Return tramaZip
        Catch ex As Exception
            tramaZip = String.Empty
            menError = ex.Message
        End Try
        Return String.Empty
    End Function



    Public Function getSHA256(ByVal str As String) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim encoding As ASCIIEncoding = New ASCIIEncoding()
        Dim stream As Byte() = Nothing
        Dim sb As StringBuilder = New StringBuilder()
        stream = sha256.ComputeHash(encoding.GetBytes(str))

        For i As Integer = 0 To stream.Length - 1
            sb.AppendFormat("{0:x2}", stream(i))
        Next

        Return sb.ToString().ToLower()
    End Function

End Class
