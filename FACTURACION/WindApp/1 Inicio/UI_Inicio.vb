Option Explicit On
Imports Entidades

Imports DevExpress.XtraBars
Imports System.Collections.Generic
Imports System.Data
Imports System.Threading
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Windows.Forms
Public Class UI_Inicio

#Region "[atributosGlobales]"

    Private skinMask As String = "Estilo: "
    Private usuario As String
    Private clave As String
    Private codActividad As String
    Private dir_raiz As String = ""

#End Region

#Region "[contrutor]"

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal actividad As String)
        MyBase.New()
        InitializeComponent()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style"
        codActividad = Trim(actividad)
        usuario = usuar
        clave = clav
    End Sub

    Public Sub New(ByVal usuar As String, ByVal clav As String, ByVal actividad As String, ByVal vers As String)
        MyBase.New()
        InitializeComponent()
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style"
        codActividad = Trim(actividad)
        usuario = usuar
        clave = clav
        buttonUsuar.Caption = "Usuario: " & usuar
        btVersion.Caption = vers
    End Sub

#End Region

#Region "[metodos]"


    Private Sub OnSkinClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        Dim skinName As String = e.Item.Caption.Replace(skinMask, "")
        Me.DefaultLookAndFeel1.LookAndFeel.SkinName = skinName
        BarManager1.GetController().PaintStyleName = "Skin"
    End Sub

    Private Sub generarNuevoMenuDB(ByVal idusuario As String)
        Using obMenu As New Negocios.MenuBL(usuario, clave)
            Dim barManager As BarManager = New BarManager()
            barManager.Form = Me
            barManager.BeginUpdate()

            Dim bar1 As Bar = New Bar(barManager, "My MainMenu") ' creo la barrra de menu
            bar1.DockStyle = BarDockStyle.Top ' coloco en parte superior
            bar1.DockRow = 0 ' lo coloco en la posicion 0
            barManager.MainMenu = bar1

            Dim listaMenu As New List(Of entMenu)()
            Dim dtMenu As New DataTable
            dtMenu = obMenu.getModuloBL(idusuario)

            For Each fila As DataRow In dtMenu.Rows
                Dim subMenuInicio As BarSubItem = New BarSubItem(barManager, fila.Item("moddesc"))
                subMenuInicio.Appearance.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                Dim itemMenu1 As New entMenu With {.codigo = fila.Item("modmodul"), .menu = subMenuInicio}
                listaMenu.Add(itemMenu1)
            Next

            Dim listaSubMenu As New List(Of entSubMenu)()
            For Each iModulo As entMenu In listaMenu
                Dim dtSubMenu As New DataTable
                dtSubMenu = obMenu.getSubModuloBL(idusuario, iModulo.codigo)
                For Each fila As DataRow In dtSubMenu.Rows  ' codmenu1, trim(me1subme) me1subme, me1secue 
                    Dim subMenuAdm As BarSubItem = New BarSubItem(barManager, fila.Item("me1subme"))
                    subMenuAdm.Appearance.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    Dim itemSubMenu1 As New entSubMenu With {.subCodigo = fila.Item("codmenu1"), .menu = subMenuAdm, .codMenu = iModulo.codigo}
                    listaSubMenu.Add(itemSubMenu1)
                Next
            Next

            Dim listaEvento As New List(Of entEvento)()
            For Each iModulo As entMenu In listaMenu

                For Each iSubModulo As entSubMenu In listaSubMenu
                    If iSubModulo.codMenu = iModulo.codigo Then
                        Dim dtEvento As New DataTable
                        dtEvento = obMenu.getEventoBL(idusuario, iModulo.codigo, iSubModulo.subCodigo)
                        For Each fila As DataRow In dtEvento.Rows
                            Dim buttonOpen As BarButtonItem = New BarButtonItem(barManager, fila.Item("me2event"))
                            buttonOpen.Appearance.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            Dim itemEvento1 As New entEvento With {.codEvento = fila.Item("codevento"), .menu = buttonOpen, .codSubMenu = iSubModulo.subCodigo}
                            listaEvento.Add(itemEvento1)
                        Next
                    End If
                Next
            Next

            'neo menu rcsoliz......................
            Dim subMenuInicio1 As BarSubItem = New BarSubItem(barManager, "Estilos de ventanas")
            subMenuInicio1.Appearance.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Dim itemMenu2 As New entMenu With {.codigo = 999, .menu = subMenuInicio1}
            listaMenu.Add(itemMenu2)
            'end menu rcsoliz......................

            'neo sub-menu rcsoliz..............
            Dim subMenuAdm11 As BarSubItem = New BarSubItem(barManager, "Skin")
            subMenuAdm11.Appearance.Font = New System.Drawing.Font("Calibri", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Dim itemSubMenu11 As New entSubMenu With {.subCodigo = 9991, .menu = subMenuAdm11, .codMenu = 999}
            listaSubMenu.Add(itemSubMenu11)
            'end sub-menu rcsoliz..............

            'neo evento rcsoliz..................


            For Each cnt As DevExpress.Skins.SkinContainer In DevExpress.Skins.SkinManager.[Default].Skins
                Dim item As BarButtonItem = New BarButtonItem(BarManager1, skinMask + cnt.SkinName)
                item.Name = "bi" + cnt.SkinName
                item.Id = BarManager1.GetNewItemId()
                BarManager1.Items.Add(item)
                subMenuAdm11.AddItem(item)
                AddHandler item.ItemClick, AddressOf OnSkinClick
            Next
            'end evento rcsoliz...................

            For Each item As entMenu In listaMenu
                bar1.AddItems(New BarItem() {item.menu})
                For Each itemSub As entSubMenu In listaSubMenu
                    If itemSub.codMenu = item.codigo Then
                        item.menu.AddItems(New BarSubItem() {itemSub.menu})
                        For Each itemEvento As entEvento In listaEvento
                            If itemEvento.codSubMenu = itemSub.subCodigo Then
                                itemSub.menu.AddItems(New BarItem() {itemEvento.menu})
                            End If
                        Next
                    End If
                Next
            Next

            AddHandler barManager.ItemClick, AddressOf barManager_ItemClick
            barManager.EndUpdate()
            obMenu.finalizar()
        End Using
    End Sub

#End Region

#Region "[eventos]"

    Private Sub barManager_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        If sender.GetType() Is GetType(BarManager) Then

            Dim subMenu As BarSubItem = TryCast(e.Item, BarSubItem)
            If Not subMenu Is Nothing Then Return
            Select Case e.Item.Caption

                Case "Usuarios"
                    Dim recepcion2 As New UB_USUARIO(usuario, clave) With {.MdiParent = Me}
                    recepcion2.Show()

                Case "Modulos"
                    Dim recepcion2 As New UI_BModulos(usuario, clave) With {.MdiParent = Me}
                    recepcion2.Show()
                Case "Menús"
                    Dim recepcion2 As New UI_BCobMenu11(usuario, clave) With {.MdiParent = Me}
                    recepcion2.Show()

                Case "Formulario llegadas a porteria"

                Case "Asignación de consignatarios a lotes"

                Case "Planificación de llegadas de ganado"


                Case "Requerimiento de ganado"

                Case "Formulario recepción de ganado"


                Case "Informe de visitas"


                Case "Informe de fecha salida"


                Case "Administrador de menús"

                Case "Control de Ingreso a Sistema"

            End Select
        End If
    End Sub

    Private Sub UI_Inicio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call generarNuevoMenuDB(usuario)
    End Sub

#End Region


   
End Class