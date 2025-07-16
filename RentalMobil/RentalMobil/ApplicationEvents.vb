Imports Microsoft.VisualBasic.ApplicationServices
Namespace My
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(ByVal e As ApplicationServices.StartupEventArgs) As Boolean
            ' Set main form tanpa .Show()
            Me.MainForm = New Form1()
            Return MyBase.OnStartup(e)
        End Function
    End Class
End Namespace