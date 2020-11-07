Public Class subject
    Public x As Integer
    Public y As Integer
    Public Radius As Integer
    Public Farbe As Color
    Public PB As PictureBox
    Public Schritte As Integer
    Public RD As Integer
    Public DBG As Boolean
    Public genesungsZeit As Integer
    Public Wartezeit As Integer
    Public Tod As Boolean
    'Public TodMatch As Integer
    Public Kollisionen As Integer
    Public AGS As Boolean
    Public BackColor As Color
    Public Imun As Boolean
    Public id As Integer
    Public Vorschau As Boolean

    'Public PL As List(Of Raumpoint)

    Public Event Kollision(ByRef sender As Object, ByRef e As subject, ByRef c As Color)
    Public Event KollisionWithRed(ByRef sender As Object, ByRef e As subject)

    Private Sub myKollision(ByRef sender As Object, ByRef e As subject, ByRef c As Color) Handles Me.Kollision

        If c = Color.Red Then Debug.Print("CL Subject Kollision ID: " + e.id.ToString + " " + e.BackColor.ToString + " " + c.ToString)

        'MsgBox("CL1 Kollision :  " + e.id.ToString)
        'e.Kollisionen = e.Kollisionen + 1
        'e.Farbe = Color.Red

    End Sub

    Private Sub myKollisionWithRed(ByRef sender As Object, ByRef e As subject) Handles Me.KollisionWithRed

        Debug.Print("CLSubject Kollision with Red ID: " + e.id.ToString + " " + e.BackColor.ToString)
        'MsgBox("CL1 Kollision :  " + e.id.ToString)
        e.Kollisionen = e.Kollisionen + 1

        If e.Farbe = Color.Green Then e.Farbe = Color.Red
        If e.Farbe = Color.Blue Then e.Farbe = Color.Yellow

    End Sub

    Sub New(ByVal id As Integer, ByVal x As Integer, ByVal y As Integer, ByVal Radius As Integer, ByRef drawColor As Color, Picturebox As PictureBox, Schritte As Integer, DBG As Boolean, AGS As Boolean, BackColor As Color, pl As List(Of Raumpoint), Vorschau As Boolean)

        'Me.PL = pl

        Me.id = id
        Me.x = x
        Me.y = y
        Me.Radius = Radius
        Me.Farbe = drawColor
        Me.PB = Picturebox
        Me.Schritte = Schritte
        Me.DBG = DBG
        Me.genesungsZeit = 0
        Me.Wartezeit = 0
        Me.Tod = 0
        Me.Kollisionen = 0
        Me.AGS = AGS
        Me.BackColor = BackColor
        Me.Vorschau = Vorschau

        'Debug.Print(BackColor.ToArgb)
        'Debug.Print(BackColor.ToKnownColor)
        'Debug.Print(BackColor.ToString)
        'Debug.Print(drawColor.ToString)

    End Sub

    Sub show()
        Using g = Graphics.FromImage(Me.PB.Image), Brush = New SolidBrush(Me.farbe)

            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.FillEllipse(Brush, Me.x, Me.y, Me.radius, Me.radius)
        End Using

        'Me.PB.Invalidate()

    End Sub

    Sub move_first()

        Dim R As New Random
        Dim Z1, Z2, Z3 As Integer
        Dim Y1, Y2, Y3 As Integer
        Dim X1, X2, X3 As Integer
        'Dim Col As String
        Dim col As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.x
        y_old = Me.y

        Randomize()
        'z = R.Next(1, 14)
        Z1 = CInt(Int((4 * Rnd()) + 1)) 'R.Next(1, 3)
        Z2 = CInt(Int((200 * Rnd()) + 1)) 'R.Next(1, 3)
        Z3 = CInt(Int((4 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        Y1 = CInt(Int((10 * Rnd()) + 1))
        X1 = CInt(Int((10 * Rnd()) + 1))
        Y2 = CInt(Int((500 * Rnd()) + 1))
        X2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        Y3 = CInt(Int((10 * Rnd()) + 1))
        X3 = CInt(Int((10 * Rnd()) + 1))

        If Me.AGS = True Then
            X1 = 0
            X2 = 0
            Y1 = 0
            Y2 = 0
            Z2 = 0
        End If


        If Z1 = 1 Then
            Me.x = Me.x + Me.Schritte
        End If

        If Z1 = 2 Then
            Me.x = Me.x - Me.Schritte
        End If

        If Z1 = 3 Then
            Me.y = Me.y + Me.Schritte
        End If

        If Z1 = 4 Then
            Me.y = Me.y - Me.Schritte
        End If


        If Me.x > 590 Then
            Me.x = 590 - Me.Schritte - 10
        End If

        If Me.y > 590 Then
            Me.y = 590 - Me.Schritte - 10
        End If

        If Me.x <= 0 Then
            Me.x = 0 + Me.Schritte + 10
        End If

        If Me.y <= 0 Then
            Me.y = 0 + Me.Schritte + 10
        End If

        col = getcolor(Me.x, Me.y)

        'col2 = Me. .getcolor(Me.x, Me.y)

        If col.R <> 255 Then
            'Debug.Print(col2.ToString)
        End If

        If col.R = 128 Then
            Me.x = X_old
            Me.y = y_old
        End If

        If col.R = 191 Then
            Me.x = X_old
            Me.y = y_old
        End If

        'Me.DBG = True

        If Me.DBG = True Then

            Debug.Print("Move First z1: " + Z1.ToString)
            Debug.Print("Move First z2: " + Z2.ToString)
            Debug.Print("Move First X: " + Me.x.ToString)
            Debug.Print("Move First Y: " + Me.y.ToString)
            Debug.Print("Move First y1: " + Y1.ToString)
            Debug.Print("Move First x1: " + X1.ToString)
            Debug.Print("Move First y2: " + Y2.ToString)
            Debug.Print("Move First x2: " + X2.ToString)
            Debug.Print("Move First y3: " + Y3.ToString)
            Debug.Print("Move First x3: " + X3.ToString)
        End If

        'Me.DBG = False

    End Sub

    Sub move_first_old()

        Dim R As New Random
        Dim Z1, Z2, Z3 As Integer
        Dim Y1, Y2, Y3 As Integer
        Dim X1, X2, X3 As Integer
        'Dim Col As String
        Dim col2 As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.x
        y_old = Me.y

        Randomize()
        'z = R.Next(1, 14)
        Z1 = CInt(Int((8 * Rnd()) + 1)) 'R.Next(1, 3)
        Z2 = CInt(Int((200 * Rnd()) + 1)) 'R.Next(1, 3)
        Z3 = CInt(Int((4 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        Y1 = CInt(Int((10 * Rnd()) + 1))
        X1 = CInt(Int((10 * Rnd()) + 1))
        Y2 = CInt(Int((500 * Rnd()) + 1))
        X2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        Y3 = CInt(Int((10 * Rnd()) + 1))
        X3 = CInt(Int((10 * Rnd()) + 1))

        If Me.AGS = True Then
            X1 = 0
            X2 = 0
            Y1 = 0
            Y2 = 0
            Z2 = 0
        End If


        If Z1 = 1 Then
            Me.x = Me.x + Me.Schritte
        End If

        If Z1 = 2 Then
            Me.x = Me.x + Me.Schritte + X1
        End If

        If Z1 = 3 Then
            Me.x = Me.x - Me.Schritte
        End If

        If Z1 = 4 Then
            Me.x = Me.x - Me.Schritte - X1
        End If

        If Z1 = 5 Then
            Me.y = Me.y + Me.Schritte
        End If

        If Z1 = 6 Then
            Me.y = Me.y + Me.Schritte + Y1
        End If

        If Z1 = 7 Then
            Me.y = Me.y - Me.Schritte
        End If

        If Z1 = 8 Then
            Me.y = Me.y - Me.Schritte - Y1
        End If

        If Z2 = 10 Then
            Me.x = 0 + X2
            Me.y = 0 + Y2
        End If

        If Z2 = 20 Then
            Me.x = 0 + X2
            Me.y = 0 + Y2
        End If


        If Me.x > 590 Then
            Me.x = 590 - Me.Schritte - X3
        End If

        If Me.y > 590 Then
            Me.y = 590 - Me.Schritte - Y3
        End If

        If Me.x <= 0 Then
            Me.x = 0 + Me.Schritte + X3
        End If

        If Me.y <= 0 Then
            Me.y = 0 + Me.Schritte + Y3
        End If

        'Col = getcolor(Me.x, Me.y)

        'col2 = Me. .getcolor(Me.x, Me.y)

        If col2.R <> 255 Then
            'Debug.Print(col2.ToString)
        End If

        If col2.R = 128 Then
            Me.x = X_old
            Me.y = y_old
        End If

        If col2.R = 191 Then
            Me.x = X_old
            Me.y = y_old
        End If

        'Me.DBG = True

        If Me.DBG = True Then

            Debug.Print("Move First z1: " + Z1.ToString)
            Debug.Print("Move First z2: " + Z2.ToString)
            Debug.Print("Move First X: " + Me.x.ToString)
            Debug.Print("Move First Y: " + Me.y.ToString)
            Debug.Print("Move First y1: " + Y1.ToString)
            Debug.Print("Move First x1: " + X1.ToString)
            Debug.Print("Move First y2: " + Y2.ToString)
            Debug.Print("Move First x2: " + X2.ToString)
            Debug.Print("Move First y3: " + Y3.ToString)
            Debug.Print("Move First x3: " + X3.ToString)
        End If

        'Me.DBG = False

    End Sub
    Sub move_subject()

        Dim R As New Random
        Dim z1, z2 As Integer
        Dim y1, y2, y3 As Integer
        Dim X1, x2, x3 As Integer
        'Dim Col As String
        Dim col As Color
        Dim col_old As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.x
        y_old = Me.y

        If Me.Tod = True Then Exit Sub

        Randomize()
        'z = R.Next(1, 14)
        z1 = CInt(Int((4 * Rnd()) + 1)) 'R.Next(1, 3)
        z2 = CInt(Int((200 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        y1 = CInt(Int((10 * Rnd()) + 1))
        X1 = CInt(Int((10 * Rnd()) + 1))
        y2 = CInt(Int((500 * Rnd()) + 1))
        x2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        y3 = CInt(Int((10 * Rnd()) + 1))
        x3 = CInt(Int((10 * Rnd()) + 1))

        If Me.AGS = True Then
            X1 = 0
            x2 = 0
            y1 = 0
            y2 = 0
        End If

        If z1 = 1 Then
            Me.x = Me.x + Me.Schritte
        End If

        If z1 = 2 Then
            Me.x = Me.x - Me.Schritte
        End If


        If z1 = 3 Then
            Me.y = Me.y + Me.Schritte
        End If

        If z1 = 4 Then
            Me.y = Me.y - Me.Schritte
        End If


        If Me.x > 590 Then
            Me.x = 590 - Me.Schritte '- 10
        End If

        If Me.y > 590 Then
            Me.y = 590 - Me.Schritte '- 10
        End If

        If Me.x <= 0 Then
            Me.x = 0 + Me.Schritte '+ 10
        End If

        If Me.y <= 0 Then
            Me.y = 0 + Me.Schritte '+ 10
        End If

        'Me.DBG = True
        'Col = getcolor(Me.x, Me.y)

        If Me.Vorschau = True Then

            Dim IDFont As New Font("Arial", 8)

            Using g = Graphics.FromImage(Form1.picOut.Image), Brush = New SolidBrush(Color.DeepPink)
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.FillEllipse(Brush, Me.x, Me.y, Me.Radius, Me.Radius)
                g.DrawString(Me.id, IDFont, Brushes.Black, Me.x + 10, Me.y)
            End Using

            Form1.picOut.Invalidate()
            'Form1.picOut.Invalidate()
            Application.DoEvents()

        End If

        'Form2.picOut.Image =Me.
        col_old = getcolor(X_old, y_old)
        col = getcolor(Me.x, Me.y)

        Form1.txtFarbmesswert_1.Text = Me.id.ToString + " " + ColorNameBack(col_old)
        Form1.txtFarbmesswert_1.BackColor = col_old
        'Form1.txtFarbmesswert_1.ForeColor = col_old

        Form1.txtFarbmesswert_2.Text = Me.id.ToString + " " + ColorNameBack(col)
        Form1.txtFarbmesswert_2.BackColor = col
        'Form1.txtFarbmesswert_2.ForeColor = col
        Application.DoEvents()

        'Debug.Print("col_old :" + ColorNameBack(col_old))
        'Debug.Print("col :" + ColorNameBack(col))

        Me.BackColor = col

        If col.R <> 255 And col.G <> 255 And col.B <> 255 Then
            RaiseEvent Kollision(Me, Me, col)
            'Debug.Print(col2.ToString)
        End If

        'Grau
        If col.R = 128 And col.G = 128 And col.B = 128 Then
            RaiseEvent Kollision(Me, Me, col)
        End If

        'Grau
        If col.R = 191 And col.G = 191 And col.B = 191 Then
            RaiseEvent Kollision(Me, Me, col)
            Me.x = X_old
            Me.y = y_old
        End If

        'Grün
        If col.R = 8 And col.G = 132 And col.B = 8 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If

        'komisches Blau
        If col.R = 0 And col.G = 128 And col.B = 0 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If

        'komisches Blau
        If col.R = 0 And col.G = 72 And col.B = 156 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If


        'komisches Braun
        If col.R = 191 And col.G = 116 And col.B = 0 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If

        'komisches Braun
        If col.R = 255 And col.G = 72 And col.B = 0 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If

        'Pink
        If col.R = 266 And col.G = 20 And col.B = 147 Then
            RaiseEvent Kollision(Me, Me, col)
            'Me.x = X_old
            'Me.y = y_old
        End If

        'Red
        If col.R = 255 And col.G = 0 Then
            RaiseEvent KollisionWithRed(Me, Me)
            'Me.Farbe = Color.Red
            'MsgBox("Rot " + col.ToString)
        End If

        If col = Color.DarkRed Then
            RaiseEvent KollisionWithRed(Me, Me)
            'Me.Farbe = Color.Red
        End If

        'DarkRed 
        If col.R = 139 And col.G = 0 And col.B = 0 Then
            RaiseEvent KollisionWithRed(Me, Me)
            'Me.Farbe = Color.Red
        End If

        Form1.txtFarbmesswert_3.Text = Me.id.ToString + " " + ColorNameBack(col)
        Form1.txtFarbmesswert_3.BackColor = col
        'Form1.txtFarbmesswert_2.ForeColor = col
        Application.DoEvents()

        Me.BackColor = col

        If Me.Farbe = Color.Red Then
            Me.genesungsZeit = Me.genesungsZeit + 1

            If Me.genesungsZeit = Me.Wartezeit Then
                Me.Imun = True
            End If

        End If
        'Me.DBG = True

        If Me.DBG = True Then

            Debug.Print("Move Volk z1: " + z1.ToString)
            Debug.Print("Move Volk z2: " + z2.ToString)
            Debug.Print("Move Volk X: " + Me.x.ToString)
            Debug.Print("Move Volk Y: " + Me.y.ToString)
            Debug.Print("Move Volk y1: " + y1.ToString)
            Debug.Print("Move Volk x1: " + X1.ToString)
            Debug.Print("Move Volk y2: " + y2.ToString)
            Debug.Print("Move Volk x2: " + x2.ToString)
            Debug.Print("Move Volk y3: " + y3.ToString)
            Debug.Print("Move Volk x3: " + x3.ToString)
        End If

        'Me.DBG = False

    End Sub

    Sub move_volk_old()

        Dim R As New Random
        Dim z1, z2 As Integer
        Dim y1, y2, y3 As Integer
        Dim X1, x2, x3 As Integer
        'Dim Col As String
        Dim col As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.x
        y_old = Me.y

        If Me.Tod = 1 Then Exit Sub

        Randomize()
        'z = R.Next(1, 14)
        z1 = CInt(Int((8 * Rnd()) + 1)) 'R.Next(1, 3)
        z2 = CInt(Int((200 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        y1 = CInt(Int((10 * Rnd()) + 1))
        X1 = CInt(Int((10 * Rnd()) + 1))
        y2 = CInt(Int((500 * Rnd()) + 1))
        x2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        y3 = CInt(Int((10 * Rnd()) + 1))
        x3 = CInt(Int((10 * Rnd()) + 1))

        If Me.AGS = True Then
            X1 = 0
            x2 = 0
            y1 = 0
            y2 = 0
        End If

        If z1 = 1 Then
            Me.x = Me.x + Me.Schritte
        End If

        If z1 = 2 Then
            Me.x = Me.x + Me.Schritte + X1
        End If

        If z1 = 3 Then
            Me.x = Me.x - Me.Schritte
        End If

        If z1 = 4 Then
            Me.x = Me.x - Me.Schritte - X1
        End If

        If z1 = 5 Then
            Me.y = Me.y + Me.Schritte
        End If

        If z1 = 6 Then
            Me.y = Me.y + Me.Schritte + y1
        End If

        If z1 = 7 Then
            Me.y = Me.y - Me.Schritte
        End If

        If z1 = 8 Then
            Me.y = Me.y - Me.Schritte - y1
        End If


        If Me.x > 590 Then
            Me.x = 590 - Me.Schritte - x3
        End If

        If Me.y > 590 Then
            Me.y = 590 - Me.Schritte - y3
        End If

        If Me.x <= 0 Then
            Me.x = 0 + Me.Schritte + x3
        End If

        If Me.y <= 0 Then
            Me.y = 0 + Me.Schritte + y3
        End If

        'Me.DBG = True
        'Col = getcolor(Me.x, Me.y)
        col = getcolor(Me.x, Me.y)
        Me.BackColor = col

        If col.R <> 255 Then
            RaiseEvent Kollision(Me, Me, col)
            'Debug.Print(col2.ToString)
        End If

        If col.R = 128 Then
            RaiseEvent Kollision(Me, Me, col)
            Me.x = X_old
            Me.y = y_old
        End If

        If col.R = 191 Then
            RaiseEvent Kollision(Me, Me, col)
            Me.x = X_old
            Me.y = y_old
        End If

        If col.R = 139 Then
            RaiseEvent Kollision(Me, Me, col)
            Me.Farbe = Color.Red
        End If


        Me.BackColor = col

        'Me.DBG = True

        If Me.DBG = True Then

            Debug.Print("Move Volk z1: " + z1.ToString)
            Debug.Print("Move Volk z2: " + z2.ToString)
            Debug.Print("Move Volk X: " + Me.x.ToString)
            Debug.Print("Move Volk Y: " + Me.y.ToString)
            Debug.Print("Move Volk y1: " + y1.ToString)
            Debug.Print("Move Volk x1: " + X1.ToString)
            Debug.Print("Move Volk y2: " + y2.ToString)
            Debug.Print("Move Volk x2: " + x2.ToString)
            Debug.Print("Move Volk y3: " + y3.ToString)
            Debug.Print("Move Volk x3: " + x3.ToString)
        End If

        'Me.DBG = False

    End Sub

    Public Sub move()

        Dim R As New Random
        Dim R2 As Integer
        Dim R3 As Integer

        Dim z1 As Integer
        Dim z2 As Integer
        Dim Z3 As Integer

        'Dim x As Integer

        R2 = 0
        R3 = 0
        z1 = 0
        z2 = 0
        Z3 = 0

        Randomize()
        R2 = CInt(Int((3 * Rnd()) + 1)) 'R.Next(1, 3)
        R3 = CInt(Int((200 * Rnd()) + 1)) 'R.Next(200)
        Me.RD = R3

        Randomize()
        'z1 = CInt(Int((-20 * Rnd()) + 20)) 'R.Next(-20, 20)
        'Int((upperbound - lowerbound + 1) * Rnd + lowerbound)
        z1 = CInt(Int((20 - -20 + 1) * Rnd() + 20)) 'R.Next(-20, 20)
        z1 = CInt(Int((20 - -20 + 1) * Rnd() + -20)) 'R.Next(-20, 20)
        Randomize()
        'z2 = R.Next(-20, 20)
        z2 = CInt(Int((20 - -20 + 1) * Rnd() + -20)) 'R.Next(-20, 20)

        If R2 = 1 Then
            Z3 = Me.x + z1
            If Z3 > 590 Then
                If z1 < 0 Then
                    Z3 = 590 + z1
                Else
                    Z3 = 590 - z1 - z1 - z1
                End If
            End If

            If Z3 < 5 Then
                If z1 < 0 Then
                    Z3 = 5 - z1
                Else
                    Z3 = 5 + z1 + z1 + z1
                End If
            End If
            Me.x = Z3
        End If

        '            If Me.y > 590 Then Me.y = Me.y - z2 - z2

        If R2 = 2 Then
            Z3 = Me.y + z2
            If Z3 > 590 Then
                If z1 < 0 Then
                    Z3 = 590 + z2
                Else
                    Z3 = 590 - z2 - z2 - z2
                End If
            End If

            If Z3 < 5 Then
                If z1 < 0 Then
                    Z3 = 5 - z2
                Else
                    Z3 = 5 + z2 + z2 + z2
                End If
            End If
            Me.y = Z3
        End If

        If R3 = 20 Then
            Randomize()
            Me.x = CInt(Int((590 * Rnd()) + 5)) 'R.Next(5, 590)
            Randomize()
            Me.y = CInt(Int((590 * Rnd()) + 5)) 'R.Next(5, 590)           
        End If

        '        If x = 3 Then
        '        'Me.x = Me.x - z1
        '        Me.y = Me.y + z2
        '        'If Me.x > 590 Then Me.x = Me.x + z1 + z1
        '        If Me.y > 590 Then Me.y = Me.y - z2 - z2
        '        End If

        '        If x = 4 Then
        '        'Me.x = Me.x - z1
        '        Me.y = Me.y - z2
        '        'If Me.x > 590 Then Me.x = Me.x + z1 + z1
        '        If Me.y > 590 Then Me.y = Me.y + z2 + z2
        '        End If


        '        z1 = R.Next(-5, 10)
        '        z2 = R.Next(-5, 10)

        '        Me.x = Me.x + z1
        '        Me.y = Me.y + z2

        'If Me.x > 590 Then Me.x = 590 - z1
        'If Me.y > 590 Then Me.y = 590 - z2

        'If Me.x < 0 Then Me.x = 0 + z1
        'If Me.y < 0 Then Me.y = 0 + z2

        If Me.DBG = True Then
            Debug.Print("Move R2: " + R2.ToString)
            Debug.Print("Move X: " + Me.x.ToString)
            Debug.Print("Move Y: " + Me.y.ToString)
            Debug.Print("Move Z1: " + z1.ToString)
            Debug.Print("Move Z2: " + z2.ToString)
        End If

    End Sub

    Private Function getcolor(x As Integer, y As Integer) As Color

        Dim clr As String
        'Dim img As Bitmap = New Bitmap(Form1.picOut.Image)
        Dim img As Bitmap = New Bitmap(Me.PB.Image)
        Dim col = img.GetPixel(x, y).ToArgb
        Dim c As Color

        c = Color.FromArgb(col)

        'clr = col.R & col.G & col.B

        If Me.DBG = True Then
            Debug.Print("getC C:" + clr.ToString)
            'Debug.Print("getC CN:" + col.Name)
            'Debug.Print("getC x:" + x.ToString)
            'Debug.Print("getC y:" + y.ToString)
        End If

        img.Dispose()

        getcolor = c

        '247251247=
        '255255255 = white 
        '191191191
        '135195135
        '128128128 = gray
        'Debug.Print(Color.DarkRed.R & Color.DarkRed.G & Color.DarkRed.B)

    End Function

    Public Function ColorNameBack(c As Color) As String

        Dim mycolor As String

        'mycolor = "[" + c.Name + " A:" + c.A.ToString + " R:" + c.R.ToString + " G:" + c.G.ToString + " B:" + c.B.ToString + " ARGB:" + c.ToArgb.ToString + " TKC:" + c.ToKnownColor.ToString + "]"
        'mycolor = "[" + c.Name + " A:" + c.A.ToString + " R:" + c.R.ToString + " G:" + c.G.ToString + " B:" + c.B.ToString + " TKC:" + c.ToKnownColor.ToString + "]"
        mycolor = "(" + c.Name + ") A:" + c.A.ToString + " R:" + c.R.ToString + " G:" + c.G.ToString + " B:" + c.B.ToString + " TKC:" + c.ToKnownColor.ToString + " (" + c.ToString + ")"

        ColorNameBack = mycolor

    End Function

End Class

