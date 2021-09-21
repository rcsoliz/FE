Public Class MenuDinamicoLib
    Public Shared Function darMenu(ByVal idUsuario As String) As String
        Return String.Format("SELECT me.id_menu codmenu, me.id_menupadre codbase, TRIM(substr(UPPER (me.descripcionmenu), 1, 1)||substr(LOWER(me.descripcionmenu),2,255)) menu, Me.posicionmenu posicion FROM tb_menu me, tb_perfilespermisos pe WHERE Me.id_menu = pe.id_menu and pe.id_usuario='{0}' and me.nivel='M'  and me.habilitadomenu=1 ORDER BY me.posicionmenu, me.id_menu, me.id_menupadre", idUsuario)
    End Function

    Public Shared Function darSubMenu(ByVal idUsuario As String) As String
        Return String.Format("SELECT me.id_menu codmenu, me.id_menupadre codbase, TRIM(substr(UPPER (me.descripcionmenu), 1, 1)||substr(LOWER(me.descripcionmenu),2,255)) menu, Me.posicionmenu posicion FROM tb_menu me, tb_perfilespermisos pe WHERE Me.id_menu = pe.id_menu AND pe.id_usuario='{0}' and me.nivel='S' AND me.habilitadomenu=1 ORDER BY me.posicionmenu, me.id_menu, me.id_menupadre", idUsuario)
    End Function

    Public Shared Function darEvento(ByVal idUsuario As String) As String
        Return String.Format("SELECT me.id_menu codmenu, me.id_menupadre codbase, TRIM(substr(UPPER (me.descripcionmenu), 1, 1)||substr(LOWER(me.descripcionmenu),2,255)) menu, Me.posicionmenu posicion FROM tb_menu me, tb_perfilespermisos pe WHERE Me.id_menu = pe.id_menu AND pe.id_usuario='{0}' and me.nivel='E' AND me.habilitadomenu=1 ORDER BY me.posicionmenu, me.id_menu, me.id_menupadre", idUsuario)
    End Function
End Class
