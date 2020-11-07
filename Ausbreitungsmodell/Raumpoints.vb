Public Class Raumpoints
    Inherits List(Of Raumpoint)

    Public DBG As Boolean

    Public Function getcolor(x As Integer, y As Integer) As Color

        If Me.DBG = True Then Debug.Print("getColor-1:" + Me.Count.ToString)

        For i = 0 To Me.Count - 1

            'If Me.DBG = True Then Debug.Print("getColor-2:" + Me(i).valCol.ToString)

            If x = Me(i).valx And y = Me(i).valy Then
                getcolor = Me(i).valCol
                If Me.DBG = True Then Debug.Print("getColor-3:" + i.ToString)
                If Me.DBG = True Then Debug.Print("getColor-4:" + Me(i).valCol.ToString)
                If Me.DBG = True Then Debug.Print("getColor-5:" + Me(i).valX.ToString)
                Exit For
            End If
        Next

        If Me.DBG = True Then Debug.Print("getColor-6:" + getcolor.ToString)

    End Function

    Public Function drawPoints(IMG As Image) As Image
        Dim x, y As Integer
        Dim col As Color
        'Dim IMG As Image

        'Dim img2 As Bitmap = New Bitmap(IMG)

        Dim img2 As Bitmap = CType(IMG, Bitmap)

        For i = 0 To Me.Count - 1
            x = Me(i).valX
            y = Me(i).valY
            col = Me(i).valCol

            img2.SetPixel(x, y, col)
            'Form7.picOut.Image = img2

            'img.Invalidate()

            '            If Me.DBG = True Then Debug.Print(Me(i).valX.ToString)
            '            If Me.DBG = True Then Debug.Print(Me(i).valY.ToString)
            '           If Me.DBG = True Then Debug.Print(Me(i).valCol.ToString)
        Next

        drawPoints = img2

    End Function

    Public Sub getPoints(IMG As Image)

        ' alle Pixel einlesen

        Dim Picture As Bitmap = New Bitmap(IMG)
        Dim col As Color
        Dim W = IMG.Width
        Dim H = IMG.Height
        Dim x As Integer
        Dim y As Integer
        Dim clr As String

        'form6b.picOut.Image = New Bitmap(form6b.picOut.Width, form6b.picOut.Height)
        'Dim img2 As Bitmap = CType(form6b.picOut.Image.Clone, Bitmap)

        'Using g = Graphics.FromImage(form6b.picOut.Image), Brush = New SolidBrush(Color.Gray)

        'PointListe.Clear()

        'DBG = Not DBG

        If DBG = True Then Debug.Print(Now().ToString)
        Me.Clear()

        For x = 0 To W - 1
            For y = 0 To H - 1
                col = Picture.GetPixel(x, y)
                clr = col.R & col.G & col.B

                'If DBG = True Then Debug.Print("getPoints Color :" + clr)

                If clr <> "255255255" Then
                    If DBG = True Then Debug.Print("getPoints Color :" + clr)
                    'PointListe.Add(New Raumpoint(x, y, col))
                    Me.Add(New Raumpoint(x, y, col))
                    '                    Debug.Print(x.ToString)
                    '                    Debug.Print(y.ToString)
                    '                    Debug.Print(clr)
                    '                    Debug.Print(col.Name.ToString)
                End If

                '                    img2.SetPixel(x, y, col)
                '                    form6b.picOut.Image = img2

            Next
            Application.DoEvents()
        Next

        If DBG = True Then Debug.Print(Now().ToString)

        If DBG = True Then Debug.Print(Me.Count.ToString)

        'DBG = Not DBG

    End Sub

End Class


