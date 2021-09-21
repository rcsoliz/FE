Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml
Imports System.Xml.Serialization
Imports Ionic.Zip
Imports System.Security.Cryptography.Xml

Public Class clsSerializador

    Private Const CommonExtensionComponents As String = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2"
    Public Property RutaCertificadoDigital As String
    Public Property PasswordCertificado As String
    Public Property DigestValue As String
    Public Property TipoDocumento As Integer

    Public Sub New()
        TipoDocumento = 1
    End Sub

    Public Function GenerarXmlFisico(Of T)(ByVal request As T, ByVal nombreArchivo As String) As String
        Dim serializer = New XmlSerializer(GetType(T))
        Dim filename = Directory.GetCurrentDirectory() & "\{nombreArchivo}.xml"

        Using writer = New StreamWriter(filename)
            serializer.Serialize(writer, request)
        End Using

        Return filename
    End Function

    Public Function GenerarXml(Of T)(ByVal objectToSerialize As T) As String
        Dim serializer = New XmlSerializer(GetType(T))
        Dim resultado As String

        Using memStr = New MemoryStream()

            Using stream = New StreamWriter(memStr, Encoding.GetEncoding("ISO-8859-1"))
                serializer.Serialize(stream, objectToSerialize)
            End Using

            resultado = FirmarXml(Convert.ToBase64String(memStr.ToArray()))
        End Using

        Return resultado
    End Function

    Public Function GenerarZip(ByVal tramaXml As String, ByVal nombreArchivo As String) As String
        Dim memOrigen = New MemoryStream(Convert.FromBase64String(tramaXml))
        Dim memDestino = New MemoryStream()
        Dim resultado As String

        Using fileZip = New ZipFile(nombreArchivo & ".zip")
            fileZip.AddEntry(nombreArchivo & ".xml", memOrigen)
            fileZip.Save(memDestino)
            resultado = Convert.ToBase64String(memDestino.ToArray())
        End Using

        memOrigen.Close()
        memDestino.Close()
        Return resultado
    End Function



    Public Function FirmarXml(ByVal tramaXml As String) As String
        Dim certificate = New X509Certificate2()
        certificate.Import(Convert.FromBase64String(RutaCertificadoDigital), PasswordCertificado, X509KeyStorageFlags.MachineKeySet)

        Dim xmlDoc = New XmlDocument()
        Dim resultado As String

        Using documento = New MemoryStream(Convert.FromBase64String(tramaXml))
            xmlDoc.PreserveWhitespace = True
            xmlDoc.Load(documento)
            Dim tipo As Integer

            If TipoDocumento = 1 OrElse TipoDocumento = 2 OrElse TipoDocumento = 3 OrElse TipoDocumento = 4 Then
                tipo = 1
            Else
                tipo = 0
            End If

            'Dim nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent", CommonExtensionComponents).Item(tipo)
            'Dim nodoExtension = xmlDoc.GetElementsByTagName("ExtensionContent").Item(tipo)
            'If nodoExtension Is Nothing Then Throw New InvalidOperationException("No se pudo encontrar el nodo ExtensionContent en el XML")
            'nodoExtension.RemoveAll()

            Dim signedXml = New SignedXml(xmlDoc) With {.SigningKey = CType(certificate.PrivateKey, RSA)}

            signedXml.SigningKey = certificate.PrivateKey
            Dim xmlSignature = signedXml.Signature
            Dim env = New XmlDsigEnvelopedSignatureTransform()
            Dim reference = New Reference(String.Empty)
            reference.AddTransform(env)
            xmlSignature.SignedInfo.AddReference(reference)
            Dim keyInfo = New KeyInfo()
            Dim x509Data = New KeyInfoX509Data(certificate)
            x509Data.AddSubjectName(certificate.Subject)
            keyInfo.AddClause(x509Data)
            xmlSignature.KeyInfo = keyInfo
            xmlSignature.Id = "SignatureErickOrlando"
            signedXml.ComputeSignature()
            If reference.DigestValue IsNot Nothing Then DigestValue = Convert.ToBase64String(reference.DigestValue)
            '        nodoExtension.AppendChild(signedXml.GetXml())
            Dim settings = New XmlWriterSettings() With {
                .Encoding = Encoding.GetEncoding("ISO-8859-1")
            }

            Using memDoc = New MemoryStream()

                Using writer = XmlWriter.Create(memDoc, settings)
                    xmlDoc.WriteTo(writer)
                End Using

                resultado = Convert.ToBase64String(memDoc.ToArray())
            End Using
        End Using

        Return resultado
    End Function
End Class
