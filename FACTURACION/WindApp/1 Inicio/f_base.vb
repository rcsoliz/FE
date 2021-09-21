Public Class f_base

#Region "[atrubutosGlobales]"

    Private Property SystemColors As Object

    Dim titulo1 As String, titulo2 As String, imagen1 As String
    Dim users As String
    Dim clav As String
    Private qrBackColor As Integer = Color.FromArgb(255, 255, 255, 255).ToArgb
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private qrForeColor As Integer = Color.FromArgb(255, 0, 0, 0).ToArgb

    Public directorioRaiz As String = "D:\Ejecutables_Otros_Sistemas\Facturacion_Impuestos\"
    Public directorio As String = "D:\Ejecutables_Otros_Sistemas\Facturacion_Impuestos\Facturas_Emitidas\"


#End Region

#Region "[constructor]"

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal Usuario As String, ByVal Contra As String, ByVal Titulo As String, ByVal Sub_Titulo As String)
        MyBase.New()
        InitializeComponent()
        lblTituloBase.Text = Titulo
        lblSubTituloBase.Text = Sub_Titulo
    End Sub

    Public Sub New(ByVal titulo As String)
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal titulo As String, ByVal subtitulo As String)
        MyBase.New()
        InitializeComponent()
        lblTituloBase.Text = titulo
        lblSubTituloBase.Text = subtitulo
    End Sub

    Public Sub New(ByVal usuario As String, ByVal clave As String, ByVal titul1 As String, ByVal titul2 As String, ByVal imag1 As String)
        MyBase.New()

        titulo1 = titul1
        titulo2 = titul2
        imagen1 = imag1
        InitializeComponent()
        Me.lblTituloBase.Text = titulo1 + " : " & titulo2
        Me.lblSubTituloBase.Text = titul2
        users = usuario
        clav = clave
    End Sub

#End Region

End Class