Namespace Syncfusion.Windows.Forms
    Friend Class Grid
        Friend Class GridControl
            Public Sub New()
            End Sub

            Friend Function Location() As Point
                Throw New NotImplementedException()
            End Function

            Friend Function ThemeStyle() As Object
                Throw New NotImplementedException()
            End Function
        End Class

        Friend Class GridCellClickEventArgs
        End Class

        Friend Class GridBaseStyle
            Friend Function Name() As String
                Throw New NotImplementedException()
            End Function

            Friend Function StyleInfo() As Object
                Throw New NotImplementedException()
            End Function
        End Class

        Friend Class GridCellInfo
        End Class

        Friend Class GridBorder
            Private none As Object

            Public Sub New(none As Object)
                Me.none = none
            End Sub
        End Class

        Friend Shared Function GridVerticalAlignment() As Object
            Throw New NotImplementedException()
        End Function

        Friend Shared Function GridHorizontalAlignment() As Object
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
