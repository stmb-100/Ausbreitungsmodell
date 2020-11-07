
Public Class Area

    Public DBG As Boolean
    Public ShowID As Boolean
    Public Grenzen As Boolean
    Public Map As New PictureBox
    Public Map2 As PictureBox
    Public RaumPointListe As New Raumpoints
    Public FirstSubject As New subject(0, 0, 0, 0, Color.DarkRed, Map, 10, True, False, Color.Transparent, RaumPointListe, False)
    Public Ausgangssperre As Boolean
    Public SubjectListeAnzahl As Integer
    Public SubjectRadius As Integer
    Public Schritte As Integer
    Public TodMatch As Integer
    Public ColorCount As New SubjectColorCount
    Public GeneseungsZeit As Integer
    Public Vorschau As Boolean

    '    Public Subject_Red As Integer
    '    Public Subject_Green As Integer
    '    Public Subject_Blue As Integer
    '    Public Subject_Schwarz As Integer
    '    Public Subject_Orange As Integer
    '   Public Subject_Gelb As Integer

    'Dim IDFont As New Font("Microsoft Sans Serif", 8)
    Dim IDFont As New Font("Arial", 8)
    Dim SubjectListe As New List(Of subject)

    'Public SubjectGrid As New Syncfusion.Windows.Forms.Grid.GridControl
    'Public SubjectGridRed As New Syncfusion.Windows.Forms.Grid.GridControl

    Public Event Kollision(ByRef sender As Object, ByRef e As subject)

    Private Sub myKollision(ByRef sender As Object, ByRef e As subject) Handles Me.Kollision

        Debug.Print("CL Area Kollision ID: " + e.id.ToString + " " + e.BackColor.ToString)
        'MsgBox("CL Area Kollision :  " + e.id.ToString)

    End Sub
    Public Sub Grid_init(SubjectGrid As GridControl)

        SubjectGrid.RowCount = SubjectListeAnzahl
        SubjectGrid.ColCount = 16

    End Sub
    Public Sub Grid_Show(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        'SubjectGrid.RowCount = 100
        'SubjectGridRed.RowCount = 100

        GridClear(SubjectGrid)
        GridHeader_set(SubjectGrid)


    End Sub
    Public Sub GridFirst_Show(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        'SubjectGrid.RowCount = 100
        'SubjectGridRed.RowCount = 100

        GridClear(SubjectGrid)
        GridFirstHeader_set(SubjectGrid)


    End Sub
    Public Sub HelpGrid_init(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        If Me.DBG = True Then
            SubjectGrid.RowCount = SubjectListeAnzahl
            SubjectGrid.ColCount = 5
        End If

    End Sub


    Public Sub HelpGrid_Show(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        'SubjectGrid.RowCount = 100
        'SubjectGridRed.RowCount = 100

        If Me.DBG = True Then
            GridClear(SubjectGrid)
            HelpGridHeader_set(SubjectGrid)
        End If

    End Sub

    Private Sub GridClear(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        For i = 1 To SubjectGrid.RowCount()
            For ii = 1 To SubjectGrid.ColCount
                SubjectGrid.Model(i, ii).CellValue = ""
            Next
        Next

    End Sub

    Public Sub HelpGrid_Fill(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        Dim x As Integer
        Dim I As Integer
        x = 1
        I = 1
        SubjectGrid.Model(1, 1).CellValue = FirstSubject.id
        SubjectGrid.Model(1, 2).CellValue = FirstSubject.x
        SubjectGrid.Model(1, 3).CellValue = FirstSubject.y
        SubjectGrid.Model(1, 4).CellValue = FirstSubject.ColorNameBack(FirstSubject.Farbe)
        SubjectGrid.Model(1, 5).CellValue = FirstSubject.ColorNameBack(FirstSubject.BackColor)

        'Debug.Print(FirstSubject.BackColor.ToString)
        'Debug.Print(FirstSubject.Farbe.ToString)

        For Each Subject In SubjectListe
            I = I + 1
            SubjectGrid.Model(I, 1).CellValue = Subject.id
            SubjectGrid.Model(I, 2).CellValue = Subject.x
            SubjectGrid.Model(I, 3).CellValue = Subject.y
            SubjectGrid.Model(I, 4).CellValue = Subject.ColorNameBack(Subject.Farbe)
            SubjectGrid.Model(I, 5).CellValue = Subject.ColorNameBack(Subject.BackColor)
        Next

    End Sub

    Private Sub HelpGridHeader_set(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        Me.GridClear(SubjectGrid)

        SubjectGrid.Model(0, 1).CellValue = "ID"
        SubjectGrid.Model(0, 2).CellValue = "X"
        SubjectGrid.Model(0, 3).CellValue = "Y"
        SubjectGrid.Model(0, 4).CellValue = "Farbe"
        SubjectGrid.Model(0, 5).CellValue = "HC"

        SubjectGrid.Model(1, 1).CellValue = FirstSubject.id
        SubjectGrid.Model(1, 2).CellValue = FirstSubject.x
        SubjectGrid.Model(1, 3).CellValue = FirstSubject.y
        SubjectGrid.Model(1, 4).CellValue = FirstSubject.Farbe.ToString
        SubjectGrid.Model(1, 5).CellValue = FirstSubject.BackColor.ToString

        Debug.Print("GridHeaderSet : " + SubjectGrid.ColCount.ToString + " " + SubjectGrid.ColCount.ToString)
        'Debug.Print("GridHeaderSet : " + SubjectGridRed.ColCount.ToString + " " + SubjectGridRed.ColCount.ToString)

    End Sub
    Private Sub GridFirstHeader_set(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        SubjectGrid.Model(0, 1).CellValue = "ID"
        SubjectGrid.Model(0, 2).CellValue = "X"
        SubjectGrid.Model(0, 3).CellValue = "Y"
        'SubjectGrid.Model(0, 4).CellValue = "Radius"
        SubjectGrid.Model(0, 4).CellValue = "Farbe"
        'SubjectGrid.Model(0, 6).CellValue = "Schritte"
        'SubjectGrid.Model(0, 7).CellValue = "RD"
        SubjectGrid.Model(0, 5).CellValue = "gen.Zeit"
        SubjectGrid.Model(0, 6).CellValue = "Koll"
        SubjectGrid.Model(0, 7).CellValue = "warteZeit"
        SubjectGrid.Model(0, 8).CellValue = "Tod"
        'SubjectGrid.Model(0, 12).CellValue = "AGS"
        SubjectGrid.Model(0, 9).CellValue = "HC"

        'SubjectGrid.Model(0, 14).CellValue = "DiffX"
        '        SubjectGrid.Model(0, 15).CellValue = "DiffY"

        SubjectGrid.Model(1, 1).CellValue = FirstSubject.id
        SubjectGrid.Model(1, 2).CellValue = FirstSubject.x
        SubjectGrid.Model(1, 3).CellValue = FirstSubject.y
        'SubjectGrid.Model(1, 4).CellValue = FirstSubject.Radius
        SubjectGrid.Model(1, 4).CellValue = FirstSubject.Farbe.ToString
        'SubjectGrid.Model(1, 6).CellValue = FirstSubject.Schritte
        'SubjectGrid.Model(1, 7).CellValue = FirstSubject.RD
        SubjectGrid.Model(1, 5).CellValue = FirstSubject.genesungsZeit
        SubjectGrid.Model(1, 6).CellValue = FirstSubject.Kollisionen
        SubjectGrid.Model(1, 7).CellValue = FirstSubject.Wartezeit
        SubjectGrid.Model(1, 8).CellValue = FirstSubject.Tod
        'SubjectGrid.Model(1, 12).CellValue = FirstSubject.AGS
        SubjectGrid.Model(1, 9).CellValue = FirstSubject.BackColor.ToString
        '       SubjectGrid.Model(1, 7).CellValue = FirstSubject.DiffX
        '       SubjectGrid.Model(1, 8).CellValue = FirstSubject.DiffY


        Debug.Print("GridHeaderSet : " + SubjectGrid.ColCount.ToString + " " + SubjectGrid.ColCount.ToString)
        'Debug.Print("GridHeaderSet : " + SubjectGridRed.ColCount.ToString + " " + SubjectGridRed.ColCount.ToString)


    End Sub

    Private Sub GridHeader_set(SubjectGrid As Syncfusion.Windows.Forms.Grid.GridControl)

        SubjectGrid.Model(0, 1).CellValue = "ID"
        SubjectGrid.Model(0, 2).CellValue = "X"
        SubjectGrid.Model(0, 3).CellValue = "Y"
        SubjectGrid.Model(0, 4).CellValue = "Radius"
        SubjectGrid.Model(0, 5).CellValue = "Farbe"
        SubjectGrid.Model(0, 6).CellValue = "Schritte"
        SubjectGrid.Model(0, 7).CellValue = "RD"
        SubjectGrid.Model(0, 8).CellValue = "gen.Zeit"
        SubjectGrid.Model(0, 9).CellValue = "Koll"
        SubjectGrid.Model(0, 10).CellValue = "warteZeit"
        SubjectGrid.Model(0, 111).CellValue = "Tod"
        SubjectGrid.Model(0, 12).CellValue = "AGS"
        SubjectGrid.Model(0, 13).CellValue = "HC"

        'SubjectGrid.Model(0, 14).CellValue = "DiffX"
        '        SubjectGrid.Model(0, 15).CellValue = "DiffY"

        SubjectGrid.Model(1, 1).CellValue = FirstSubject.id
        SubjectGrid.Model(1, 2).CellValue = FirstSubject.x
        SubjectGrid.Model(1, 3).CellValue = FirstSubject.y
        SubjectGrid.Model(1, 4).CellValue = FirstSubject.Radius
        SubjectGrid.Model(1, 5).CellValue = FirstSubject.Farbe.ToString
        SubjectGrid.Model(1, 6).CellValue = FirstSubject.Schritte
        SubjectGrid.Model(1, 7).CellValue = FirstSubject.RD
        SubjectGrid.Model(1, 8).CellValue = FirstSubject.genesungsZeit
        SubjectGrid.Model(1, 9).CellValue = FirstSubject.Kollisionen
        SubjectGrid.Model(1, 10).CellValue = FirstSubject.Wartezeit
        SubjectGrid.Model(1, 11).CellValue = FirstSubject.Tod
        SubjectGrid.Model(1, 12).CellValue = FirstSubject.AGS
        SubjectGrid.Model(1, 13).CellValue = FirstSubject.BackColor.ToString
        '       SubjectGrid.Model(1, 7).CellValue = FirstSubject.DiffX
        '       SubjectGrid.Model(1, 8).CellValue = FirstSubject.DiffY


        Debug.Print("GridHeaderSet : " + SubjectGrid.ColCount.ToString + " " + SubjectGrid.ColCount.ToString)
        'Debug.Print("GridHeaderSet : " + SubjectGridRed.ColCount.ToString + " " + SubjectGridRed.ColCount.ToString)

    End Sub
    Public Sub Grid_Fill(SubjectGridAll As Syncfusion.Windows.Forms.Grid.GridControl, SubjectGridRed As Syncfusion.Windows.Forms.Grid.GridControl)

        Dim x As Integer
        Dim I As Integer
        x = 1
        I = 1
        SubjectGridAll.Model(1, 1).CellValue = FirstSubject.id
        SubjectGridAll.Model(1, 2).CellValue = FirstSubject.x
        SubjectGridAll.Model(1, 3).CellValue = FirstSubject.y
        SubjectGridAll.Model(1, 4).CellValue = FirstSubject.Radius
        SubjectGridAll.Model(1, 5).CellValue = FirstSubject.Farbe.ToString
        SubjectGridAll.Model(1, 6).CellValue = FirstSubject.Schritte
        SubjectGridAll.Model(1, 7).CellValue = FirstSubject.RD
        SubjectGridAll.Model(1, 8).CellValue = FirstSubject.genesungsZeit
        SubjectGridAll.Model(1, 9).CellValue = FirstSubject.Kollisionen
        SubjectGridAll.Model(1, 10).CellValue = FirstSubject.Wartezeit
        SubjectGridAll.Model(1, 11).CellValue = FirstSubject.Tod
        SubjectGridAll.Model(1, 12).CellValue = FirstSubject.AGS
        SubjectGridAll.Model(1, 13).CellValue = FirstSubject.BackColor.ToString
        '        SubjectGridAll.Model(1, 14).CellValue = FirstSubject.AGS
        '        SubjectGridAll.Model(1, 15).CellValue = FirstSubject.BackColor.ToString

        SubjectGridRed.Model(1, 1).CellValue = FirstSubject.id
        SubjectGridRed.Model(1, 2).CellValue = FirstSubject.x
        SubjectGridRed.Model(1, 3).CellValue = FirstSubject.y
        'SubjectGridRed.Model(1, 4).CellValue = FirstSubject.Radius
        SubjectGridRed.Model(1, 4).CellValue = FirstSubject.Farbe.ToString
        'SubjectGridRed.Model(1, 6).CellValue = FirstSubject.Schritte
        'SubjectGridRed.Model(1, 7).CellValue = FirstSubject.RD
        SubjectGridRed.Model(1, 5).CellValue = FirstSubject.genesungsZeit
        SubjectGridRed.Model(1, 6).CellValue = FirstSubject.Kollisionen
        SubjectGridRed.Model(1, 7).CellValue = FirstSubject.Wartezeit
        SubjectGridRed.Model(1, 8).CellValue = FirstSubject.Tod
        'SubjectGridRed.Model(1, 12).CellValue = FirstSubject.AGS
        SubjectGridRed.Model(1, 9).CellValue = FirstSubject.BackColor.ToString
        '        SubjectGridRed.Model(1, 14).CellValue = FirstSubject.AGS
        '        SubjectGridRed.Model(1, 15).CellValue = FirstSubject.BackColor.ToString

        For Each Subject In SubjectListe
            I = I + 1
            SubjectGridAll.Model(I, 1).CellValue = Subject.id
            SubjectGridAll.Model(I, 2).CellValue = Subject.x
            SubjectGridAll.Model(I, 3).CellValue = Subject.y
            SubjectGridAll.Model(I, 4).CellValue = Subject.Radius
            SubjectGridAll.Model(I, 5).CellValue = Subject.Farbe.ToString
            SubjectGridAll.Model(I, 6).CellValue = Subject.Schritte
            'SubjectGridAll.Model(I, 7).CellValue = Subject.DiffX
            'SubjectGridAll.Model(I, 8).CellValue = Subject.DiffY
            SubjectGridAll.Model(I, 7).CellValue = Subject.RD
            SubjectGridAll.Model(I, 8).CellValue = Subject.genesungsZeit
            SubjectGridAll.Model(I, 9).CellValue = Subject.Kollisionen
            SubjectGridAll.Model(I, 10).CellValue = Subject.Wartezeit
            SubjectGridAll.Model(I, 11).CellValue = Subject.Tod
            SubjectGridAll.Model(I, 12).CellValue = Subject.AGS
            SubjectGridAll.Model(I, 13).CellValue = Subject.BackColor.ToString

            If Subject.Farbe = Color.Red Or Subject.Farbe = Color.DarkOrchid Then
                x = x + 1
                SubjectGridRed.Model(x, 1).CellValue = Subject.id
                SubjectGridRed.Model(x, 2).CellValue = Subject.x
                SubjectGridRed.Model(x, 3).CellValue = Subject.y
                'SubjectGridRed.Model(x, 4).CellValue = Subject.Radius
                SubjectGridRed.Model(x, 4).CellValue = Subject.Farbe.ToString
                'SubjectGridRed.Model(x, 6).CellValue = Subject.Schritte
                'SubjectGridRed.Model(x, 7).CellValue = Subject.DiffX
                'SubjectGridRed.Model(x, 8).CellValue = Subject.DiffY
                'SubjectGridRed.Model(x, 7).CellValue = Subject.RD
                SubjectGridRed.Model(x, 5).CellValue = Subject.genesungsZeit
                SubjectGridRed.Model(x, 6).CellValue = Subject.Kollisionen
                SubjectGridRed.Model(x, 7).CellValue = Subject.Wartezeit
                SubjectGridRed.Model(x, 8).CellValue = Subject.Tod
                'SubjectGridRed.Model(x, 12).CellValue = Subject.AGS
                SubjectGridRed.Model(x, 9).CellValue = Subject.BackColor.ToString
            End If
        Next


    End Sub

    Public Sub Map_Init()

        Map.Image = New Bitmap(600, 600)

        'Map2.Image = New Bitmap(600, 600)
        'RaumPointListe.DBG = Me.DBG
        'RaumPointListe.Clear()
        'RaumPointListe.getPoints(Me.Map.Image)

    End Sub

    Public Sub Map_Clear()

        Using g = Graphics.FromImage(Me.Map.Image)
            g.Clear(Color.White)
        End Using

        ' Ergebnis anzeigen
        Me.Map.Invalidate()

    End Sub

    Public Sub Grenzen_draw()

        Dim Grenzbreite As Integer

        Grenzbreite = 15

        If Me.Grenzen = True Then

            Using g = Graphics.FromImage(Me.Map.Image), Brush = New SolidBrush(Color.Gray)

                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

                g.FillRectangle(Brush, 300, 0, Grenzbreite, 250)
                g.FillRectangle(Brush, 300, 350, Grenzbreite, 250)

                g.FillRectangle(Brush, 0, 200, 200, Grenzbreite)
                g.FillRectangle(Brush, 0, 400, 200, Grenzbreite)

                g.FillRectangle(Brush, 400, 200, 250, Grenzbreite)
                g.FillRectangle(Brush, 400, 400, 200, Grenzbreite)

            End Using

            'Me.Map.Invalidate()
            'picOut.Refresh()

        End If

        'RaumPointListe.getPoints(Me.Map.Image)

    End Sub
    Public Sub SubjectList_move()

        Me.ColorCount.Rot = 0
        Me.ColorCount.Grün = 0
        Me.ColorCount.Blau = 0
        Me.ColorCount.Schwarz = 0
        Me.ColorCount.Orange = 0
        Me.ColorCount.Gelb = 0
        Me.ColorCount.Violet = 0

        For Each Subject In SubjectListe
            Subject.move_subject()

            If Subject.Farbe = Color.Red And Subject.genesungsZeit >= Me.GeneseungsZeit Then
                Subject.Farbe = Color.Blue
                Subject.genesungsZeit = 0
            End If

            If Subject.Farbe = Color.Red And Subject.Kollisionen >= Me.TodMatch Then
                Subject.Farbe = Color.Black
                Subject.Tod = True
                Subject.genesungsZeit = 0
            End If


            If Subject.Farbe = Color.Red Then Me.ColorCount.Rot = Me.ColorCount.Rot + 1
            If Subject.Farbe = Color.Green Then Me.ColorCount.Grün = Me.ColorCount.Grün + 1
            If Subject.Farbe = Color.Blue Then Me.ColorCount.Blau = Me.ColorCount.Blau + 1
            If Subject.Farbe = Color.Black Then Me.ColorCount.Schwarz = Me.ColorCount.Schwarz + 1
            If Subject.Farbe = Color.Orange Then Me.ColorCount.Orange = Me.ColorCount.Orange + 1
            If Subject.Farbe = Color.Yellow Then Me.ColorCount.Gelb = Me.ColorCount.Gelb + 1
            If Subject.Farbe = Color.Violet Then Me.ColorCount.Violet = Me.ColorCount.Violet + 1

        Next

        '        For i = 0 To Me.SubjectListe.Count - 1 'Me.PointListAnzahl
        '        Me.SubjectListe(i).move_subject()

        '        If SubjectListe(i).Farbe = Color.Red And SubjectListe(i).genesungsZeit >= Me.GeneseungsZeit Then
        '        SubjectListe(i).Farbe = Color.Blue
        '        SubjectListe(i).genesungsZeit = 0
        '        End If

        '        If SubjectListe(i).Farbe = Color.Red And SubjectListe(i).Kollisionen >= Me.TodMatch Then
        '        SubjectListe(i).Farbe = Color.Black
        '        SubjectListe(i).Tod = True
        '        'SubjectListe(i).genesungsZeit = 0
        '        End If

        '        If SubjectListe(i).Farbe = Color.Red Then Me.ColorCount.Rot = Me.ColorCount.Rot + 1
        '        If SubjectListe(i).Farbe = Color.Green Then Me.ColorCount.Grün = Me.ColorCount.Grün + 1
        '        If SubjectListe(i).Farbe = Color.Blue Then Me.ColorCount.Blau = Me.ColorCount.Blau + 1
        '        If SubjectListe(i).Farbe = Color.Black Then Me.ColorCount.Schwarz = Me.ColorCount.Schwarz + 1
        '        If SubjectListe(i).Farbe = Color.Orange Then Me.ColorCount.Orange = Me.ColorCount.Orange + 1
        '        If SubjectListe(i).Farbe = Color.Yellow Then Me.ColorCount.Gelb = Me.ColorCount.Gelb + 1
        '        If SubjectListe(i).Farbe = Color.Violet Then Me.ColorCount.Violet = Me.ColorCount.Violet + 1

        '        Next

    End Sub
    Public Sub FirstSubject_move()

        'Dim R As New Random
        Dim z1, z2 As Integer
        Dim y1, y2, y3 As Integer
        Dim X1, x2, x3 As Integer
        Dim col As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.FirstSubject.x
        y_old = Me.FirstSubject.y

        If Me.DBG = True Then
            Debug.Print("First_move old:" + X_old.ToString + " " + y_old.ToString)
        End If

        Randomize()
        'z = R.Next(1, 14)
        z1 = CInt(Int((4 * Rnd()) + 1)) 'R.Next(1, 3)
        z2 = CInt(Int((20000 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        y1 = CInt(Int((5 * Rnd()) + 1))
        X1 = CInt(Int((5 * Rnd()) + 1))
        y2 = CInt(Int((500 * Rnd()) + 1))
        x2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        y3 = CInt(Int((10 * Rnd()) + 1))
        x3 = CInt(Int((10 * Rnd()) + 1))

        If Me.Ausgangssperre = True Then
            X1 = 0
            x2 = 0
            y1 = 0
            y2 = 0
            z2 = 0
        End If

        If z1 = 1 Then
            Me.FirstSubject.x = Me.FirstSubject.x + Me.FirstSubject.Schritte
        End If

        If z1 = 2 Then
            Me.FirstSubject.x = Me.FirstSubject.x - Me.FirstSubject.Schritte
        End If

        If z1 = 3 Then
            Me.FirstSubject.y = Me.FirstSubject.y + Me.FirstSubject.Schritte
        End If

        If z1 = 4 Then
            Me.FirstSubject.y = Me.FirstSubject.y - Me.FirstSubject.Schritte
        End If

        If Me.FirstSubject.x > 590 Then
            Me.FirstSubject.x = 590 - Me.FirstSubject.Schritte - 10
        End If

        If Me.FirstSubject.y > 590 Then
            Me.FirstSubject.y = 590 - Me.FirstSubject.Schritte - 10
        End If

        If Me.FirstSubject.x <= 0 Then
            Me.FirstSubject.x = 0 + Me.FirstSubject.Schritte + 10
        End If

        If Me.FirstSubject.y <= 0 Then
            Me.FirstSubject.y = 0 + Me.FirstSubject.Schritte + 10
        End If

        If Me.Vorschau = True Then
            'Getcolor neu definieren
            Using g = Graphics.FromImage(Me.Map.Image), Brush = New SolidBrush(Color.Yellow)
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.FillEllipse(Brush, FirstSubject.x, FirstSubject.y, FirstSubject.Radius, FirstSubject.Radius)
                If Me.ShowID = True Then g.DrawString("0", IDFont, Brushes.Black, Me.FirstSubject.x + 10, Me.FirstSubject.y)
            End Using

            Me.Map.Invalidate()
            Form1.picOut.Invalidate()
            Application.DoEvents()
        End If

        col = getColor(Me.FirstSubject.x, Me.FirstSubject.y)
        Me.FirstSubject.BackColor = col

        If col.R <> 255 And col.G <> 255 And col.B <> 255 Then
            Debug.Print(col.ToString)
        End If

        If col.R = 128 Then
            RaiseEvent Kollision(Me, Me.FirstSubject)
            Me.FirstSubject.x = X_old
            Me.FirstSubject.y = y_old
        End If

        If col.R = 191 Then
            RaiseEvent Kollision(Me, Me.FirstSubject)
            Me.FirstSubject.x = X_old
            Me.FirstSubject.y = y_old
        End If

        col = getColor(Me.FirstSubject.x, Me.FirstSubject.y)
        Me.FirstSubject.BackColor = col

        If Me.DBG = True Then
            Debug.Print("First_move new:" + Me.FirstSubject.x.ToString + " " + Me.FirstSubject.y.ToString)
        End If

        If Me.DBG = True Then
            Debug.Print("Move First z1: " + z1.ToString)
            Debug.Print("Move First z2: " + z2.ToString)
            Debug.Print("Move First X: " + Me.FirstSubject.x.ToString)
            Debug.Print("Move First Y: " + Me.FirstSubject.y.ToString)
            Debug.Print("Move First y1: " + y1.ToString)
            Debug.Print("Move First x1: " + X1.ToString)
            Debug.Print("Move First y2: " + y2.ToString)
            Debug.Print("Move First x2: " + x2.ToString)
            Debug.Print("Move First y3: " + y3.ToString)
            Debug.Print("Move First x3: " + x3.ToString)
        End If

    End Sub

    Public Sub FirstSubject_move_old()

        'Dim R As New Random
        Dim z1, z2 As Integer
        Dim y1, y2, y3 As Integer
        Dim X1, x2, x3 As Integer
        Dim col As Color

        Dim X_old As Integer
        Dim y_old As Integer

        X_old = Me.FirstSubject.x
        y_old = Me.FirstSubject.y

        If Me.DBG = True Then
            Debug.Print("First_move old:" + X_old.ToString + " " + y_old.ToString)
        End If

        Randomize()
        'z = R.Next(1, 14)
        z1 = CInt(Int((8 * Rnd()) + 1)) 'R.Next(1, 3)
        z2 = CInt(Int((20000 * Rnd()) + 1)) 'R.Next(1, 3)

        Randomize()
        y1 = CInt(Int((5 * Rnd()) + 1))
        X1 = CInt(Int((5 * Rnd()) + 1))
        y2 = CInt(Int((500 * Rnd()) + 1))
        x2 = CInt(Int((500 * Rnd()) + 1))
        Randomize()
        y3 = CInt(Int((10 * Rnd()) + 1))
        x3 = CInt(Int((10 * Rnd()) + 1))

        If Me.Ausgangssperre = True Then
            X1 = 0
            x2 = 0
            y1 = 0
            y2 = 0
            z2 = 0
        End If

        If z1 = 1 Then
            Me.FirstSubject.x = Me.FirstSubject.x + Me.FirstSubject.Schritte
        End If

        If z1 = 2 Then
            Me.FirstSubject.x = Me.FirstSubject.x + Me.FirstSubject.Schritte + X1
        End If

        If z1 = 3 Then
            Me.FirstSubject.x = Me.FirstSubject.x - Me.FirstSubject.Schritte
        End If

        If z1 = 4 Then
            Me.FirstSubject.x = Me.FirstSubject.x - Me.FirstSubject.Schritte - X1
        End If

        If z1 = 5 Then
            Me.FirstSubject.y = Me.FirstSubject.y + Me.FirstSubject.Schritte
        End If

        If z1 = 6 Then
            Me.FirstSubject.y = Me.FirstSubject.y + Me.FirstSubject.Schritte + y1
        End If

        If z1 = 7 Then
            Me.FirstSubject.y = Me.FirstSubject.y - Me.FirstSubject.Schritte
        End If

        If z1 = 8 Then
            Me.FirstSubject.y = Me.FirstSubject.y - Me.FirstSubject.Schritte - y1
        End If

        '        If z2 = 10 Then
        '        Me.FirstSubject.x = 0 + x2
        '        Me.FirstSubject.y = 0 + y2
        '        End If

        '        If z2 = 20 Then
        '        Me.FirstSubject.x = 0 + x2
        '        Me.FirstSubject.y = 0 + y2
        '        End If


        If Me.FirstSubject.x > 590 Then
            Me.FirstSubject.x = 590 - Me.FirstSubject.Schritte - x3
        End If

        If Me.FirstSubject.y > 590 Then
            Me.FirstSubject.y = 590 - Me.FirstSubject.Schritte - y3
        End If

        If Me.FirstSubject.x <= 0 Then
            Me.FirstSubject.x = 0 + Me.FirstSubject.Schritte + x3
        End If

        If Me.FirstSubject.y <= 0 Then
            Me.FirstSubject.y = 0 + Me.FirstSubject.Schritte + y3
        End If

        'Col = getcolor(Me.x, Me.y)

        'Getcolor neu definieren
        col = getColor(Me.FirstSubject.x, Me.FirstSubject.y)
        Me.FirstSubject.BackColor = col

        If col.R <> 255 Then
            'Debug.Print(col2.ToString)
        End If

        If col.R = 128 Then
            RaiseEvent Kollision(Me, Me.FirstSubject)
            Me.FirstSubject.x = X_old
            Me.FirstSubject.y = y_old
        End If

        If col.R = 191 Then
            RaiseEvent Kollision(Me, Me.FirstSubject)
            Me.FirstSubject.x = X_old
            Me.FirstSubject.y = y_old
        End If

        col = getColor(Me.FirstSubject.x, Me.FirstSubject.y)
        Me.FirstSubject.BackColor = col

        If Me.DBG = True Then
            Debug.Print("First_move new:" + Me.FirstSubject.x.ToString + " " + Me.FirstSubject.y.ToString)
        End If

        If Me.DBG = True Then
            Debug.Print("Move First z1: " + z1.ToString)
            Debug.Print("Move First z2: " + z2.ToString)
            Debug.Print("Move First X: " + Me.FirstSubject.x.ToString)
            Debug.Print("Move First Y: " + Me.FirstSubject.y.ToString)
            Debug.Print("Move First y1: " + y1.ToString)
            Debug.Print("Move First x1: " + X1.ToString)
            Debug.Print("Move First y2: " + y2.ToString)
            Debug.Print("Move First x2: " + x2.ToString)
            Debug.Print("Move First y3: " + y3.ToString)
            Debug.Print("Move First x3: " + x3.ToString)
        End If

    End Sub
    Public Sub FirstSubject_show()

        If Me.DBG = True Then
            Debug.Print("First_show: " + FirstSubject.x.ToString + " " + FirstSubject.y.ToString + " " + FirstSubject.Radius.ToString)
        End If

        Using g = Graphics.FromImage(Me.Map.Image), Brush = New SolidBrush(FirstSubject.Farbe)
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.FillEllipse(Brush, FirstSubject.x, FirstSubject.y, FirstSubject.Radius, FirstSubject.Radius)
            If Me.ShowID = True Then g.DrawString("0", IDFont, Brushes.Black, Me.FirstSubject.x + 10, Me.FirstSubject.y)
        End Using

        'Me.Map.Invalidate()
        'Me.Map2 = Map
        'Me.Map2.Invalidate()

    End Sub
    Private Function getColor(x As Integer, y As UInteger) As Color

        Dim clr As String
        Dim img As Bitmap = New Bitmap(Me.Map.Image)
        Dim col = img.GetPixel(x, y)

        clr = col.R & col.G & col.B

        getColor = col

        img.Dispose()

    End Function
    Public Sub FirstSubject_set()

        Dim R As New Random

        Dim s As Integer
        'Dim RD As Integer
        Dim PointColor As Color

        FirstSubject.id = 0
        FirstSubject.Farbe = Color.DarkRed
        Debug.Print(Color.DarkRed.R & Color.DarkRed.G & Color.DarkRed.B)

        FirstSubject.x = R.Next(10, 550)
        FirstSubject.y = R.Next(10, 550)
        PointColor = getColor(FirstSubject.x, FirstSubject.y)
        FirstSubject.BackColor = PointColor

        'FirstSubject.PL = RaumPointListe
        'PointColor = Me.getColor(FirstSubject.x, FirstSubject.y)

        'PointColor = getcolor2(first.x, first.y, RaumPointListe, DBG)

        If PointColor.G <> 255 And PointColor.G <> 0 Then
            Debug.Print(PointColor.ToString)
        End If

        While PointColor.R = 128
            RaiseEvent Kollision(Me, FirstSubject)
            FirstSubject.x = R.Next(5, 590)
            FirstSubject.y = R.Next(5, 590)
            'CL = getcolor(X, y)
            'PointColor = getcolor2(first.x, first.y, PointListe, DBG)
            PointColor = RaumPointListe.getcolor(FirstSubject.x, FirstSubject.y)
        End While

        While PointColor.R = 191
            RaiseEvent Kollision(Me, FirstSubject)
            FirstSubject.x = R.Next(5, 590)
            FirstSubject.y = R.Next(5, 590)
            PointColor = RaumPointListe.getcolor(FirstSubject.x, FirstSubject.y)
            'PointColor = getcolor2(first.x, first.y, PointListe, DBG)
        End While

        FirstSubject.Radius = 10
        'FirstSubject.PB = Me.Map
        'first.Schritte = 10
        FirstSubject.BackColor = PointColor

        If Ausgangssperre = True Then
            FirstSubject.Schritte = 5
            s = 3
            FirstSubject.AGS = Me.Ausgangssperre
        Else
            FirstSubject.Schritte = 10
            s = 5
            FirstSubject.AGS = Me.Ausgangssperre
        End If

        FirstSubject.DBG = False 'Me.DBG
        FirstSubject.Wartezeit = 0
        FirstSubject.genesungsZeit = 0
        FirstSubject.Tod = 0

        'Me.First_show()
        'Map.Invalidate()

    End Sub

    Public Sub show()

        Me.Map_Clear()

        Me.Grenzen_draw()

        Me.FirstSubject_show()

        Me.SubjectList_show()



    End Sub

    Public Sub SubjectList_set()

        Dim newPointColor, Pointcolor As Color
        Dim Z, X, Y As Integer
        Dim R As New Random
        Dim KR As New subject(0, 0, 0, Me.SubjectRadius, Color.White, Me.Map, 5, DBG, Me.Ausgangssperre, Pointcolor, RaumPointListe, False)

        'IDFont.Style.Bold = FontStyle.Bold
        SubjectListe.Clear()

        For i = 1 To Me.SubjectListeAnzahl  '+ 1

            newPointColor = Color.Green
            Z = Z + 1
            X = R.Next(5, 590)
            Y = R.Next(5, 590)

            'CL = getcolor(X, y)
            'PointColor = getcolor2(X, y, PointListe, DBG)
            Pointcolor = RaumPointListe.getcolor(X, Y)

            KR.id = Z
            KR.x = X
            KR.y = Y
            'KR.farbe = newPointColor
            KR.BackColor = Pointcolor

            If Me.DBG = True Then
                Debug.Print("init PointList:" + Pointcolor.ToString)
            End If

            While Pointcolor.R = 128
                RaiseEvent Kollision(Me, KR)
                X = R.Next(5, 590)
                Y = R.Next(5, 590)
                newPointColor = Color.Green
                Pointcolor = RaumPointListe.getcolor(X, Y)
                RaiseEvent Kollision(Me, KR)
            End While

            While Pointcolor.R = 191
                RaiseEvent Kollision(Me, KR)
                X = R.Next(5, 590)
                Y = R.Next(5, 590)
                newPointColor = Color.Green
                Pointcolor = RaumPointListe.getcolor(X, Y)
                RaiseEvent Kollision(Me, KR)
            End While

            KR.BackColor = Pointcolor
            KR.x = X
            KR.y = Y
            KR.Farbe = newPointColor
            KR.Radius = Me.SubjectRadius
            KR.Schritte = Me.Schritte
            KR.Vorschau = Me.Vorschau

            SubjectListe.Add(New subject(KR.id, KR.x, KR.y, KR.Radius, KR.Farbe, Me.Map, KR.Schritte, Me.DBG, Me.Ausgangssperre, KR.BackColor, Me.RaumPointListe, KR.Vorschau))
            Application.DoEvents()

            'Debug.Print(kreisliste(kreisliste.Count).farbe.ToString)

            Using g = Graphics.FromImage(Me.Map.Image), Brush = New SolidBrush(newPointColor)

                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.FillEllipse(Brush, X, Y, Me.SubjectRadius, Me.SubjectRadius)
                If Me.ShowID = True Then g.DrawString(Z.ToString, IDFont, Brushes.Black, X + 10, Y)

            End Using

            ' Ergebnis anzeigen
            Me.Map.Invalidate()
            'picOut.Refresh()

            'If chkTestBild.Checked = True Then Form6.picOut.Image = picOut.Image

            If Me.DBG = True Then
                Debug.Print("init PLs i:" + i.ToString)
                Debug.Print("Init PLs z:" + Z.ToString)
                Debug.Print("init PLs cnt:" + SubjectListe.Count.ToString)
                Debug.Print("init PLs HC:" + SubjectListe(Z - 1).BackColor.ToString)
                Debug.Print("Font PLs :" + IDFont.ToString)
                Debug.Print("Font PLs Bold:" + IDFont.Bold.ToString)
            End If
        Next

    End Sub

    Public Sub SubjectList_show()

        Dim newPointColor, Pointcolor As Color
        Dim Z, X, Y As Integer
        Dim R As New Random
        Dim KR As New subject(0, 0, 0, Me.SubjectRadius, Color.White, Me.Map, 5, DBG, Me.Ausgangssperre, Pointcolor, RaumPointListe, False)

        'IDFont.Style.Bold = FontStyle.Bold

        For i = 0 To Me.SubjectListe.Count - 1  '+ 1

            Using g = Graphics.FromImage(Me.Map.Image), Brush = New SolidBrush(SubjectListe(i).Farbe)

                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.FillEllipse(Brush, SubjectListe(i).x, SubjectListe(i).y, SubjectListe(i).Radius, SubjectListe(i).Radius)
                If Me.ShowID = True Then g.DrawString(SubjectListe(i).id.ToString, IDFont, Brushes.Black, SubjectListe(i).x + 10, SubjectListe(i).y)

            End Using

            ' Ergebnis anzeigen
            Me.Map.Invalidate()
            'picOut.Refresh()

            'If chkTestBild.Checked = True Then Form6.picOut.Image = picOut.Image

            If Me.DBG = True Then
                Debug.Print("init PLs i:" + i.ToString)
                Debug.Print("Init PLs z:" + Z.ToString)
                Debug.Print("init PLs cnt:" + SubjectListe.Count.ToString)
                Debug.Print("init PLs HC:" + SubjectListe(Z - 1).BackColor.ToString)
                Debug.Print("Font PLs :" + IDFont.ToString)
                Debug.Print("Font PLs Bold:" + IDFont.Bold.ToString)
            End If
        Next

    End Sub
End Class
