Imports System.Web.Mvc

Namespace Controllers
    Public Class PersonasController
        Inherits Controller

        ' GET: Personas
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace