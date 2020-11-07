Public Class Form1

    Dim WithEvents newArea As New Area
    Dim TS As Integer
    Dim DBG As Boolean
    Dim Tick As Integer


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        picOut.Image = New Bitmap(picOut.Width, picOut.Height)

    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click

        newArea.Map_Init()
        newArea.Map_Clear()
        picOut.Image = newArea.Map.Image

        Exit Sub

        ' Graphics-Objekt erstellen
        Using g = Graphics.FromImage(picOut.Image)
            g.Clear(Color.White)
        End Using

        ' Ergebnis anzeigen

        picOut.Invalidate()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'init

        Tick = 0

        ' Graphics-Objekt erstellen
        Using g = Graphics.FromImage(picOut.Image)
            g.Clear(Color.White)
        End Using

        ' Ergebnis anzeigen
        picOut.Invalidate()

        newArea.Vorschau = chkVorschau.Checked
        newArea.Schritte = CInt(txtSchritte.Text)
        newArea.SubjectRadius = CInt(txtRadius.Text)
        newArea.ShowID = chkID.Enabled
        newArea.SubjectListeAnzahl = CInt(txtAnzahl.Text)
        newArea.TodMatch = CInt(txttod.Text)
        newArea.GeneseungsZeit = CInt(txtGenZeit.Text)
        newArea.Ausgangssperre = chkAGS.Checked ' False
        newArea.Grenzen = chkGrenzen.Checked
        newArea.DBG = False
        'newArea.Map2 = Form2.picOut
        newArea.Map_Init()
        newArea.Map_Clear()
        'Me.picOut.Image = newArea.Map.Image
        'Me.picOut.Invalidate()

        newArea.Grenzen_draw()
        Me.picOut.Image = newArea.Map.Image
        Me.picOut.Invalidate()

        newArea.FirstSubject_set()
        newArea.FirstSubject_show()
        newArea.SubjectList_set()

        newArea.show()

        'Me.picOut.Image = newArea.Map.Image
        'Me.picOut.Invalidate()

        newArea.Grid_init(Me.GridControl1)
        newArea.Grid_init(Me.GridControl2)
        newArea.Grid_Show(Me.GridControl1)
        newArea.GridFirst_Show(Me.GridControl2)
        newArea.Grid_Fill(Me.GridControl1, Me.GridControl2)

        Me.picOut.Image = newArea.Map.Image
        Me.picOut.Invalidate()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Timer starten/stoppen

        Tick = 0
        txtZeit.Text = Tick.ToString

        Timer1.Interval = CInt(txtTimer.Text)

        If TS = 0 Then
            Timer1.Start()
            TS = 1
        Else
            Timer1.Stop()
            TS = 0
        End If

        If DBG = True Then
            Debug.Print("Timer: " + Timer1.Enabled.ToString)
            Debug.Print("Timer: " + TS.ToString)
        End If
        '        ' Graphics-Objekt erstellen
        '        Using g = Graphics.FromImage(picOut.Image)
        '        g.Clear(Color.White)
        '        End Using

        ' Ergebnis anzeigen
        '        picOut.Invalidate()

        '        first.move_first()
        '        first.show()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Tick = Tick + 1
        txtZeit.Text = Tick.ToString

        newArea.FirstSubject_move()
        newArea.SubjectList_move()
        newArea.show()

        newArea.Grid_Fill(Me.GridControl1, Me.GridControl2)

        '        newArea.HelpGrid_Fill(Form2.GridControl1)

        Me.picOut.Image = newArea.Map.Image
        Me.picOut.Invalidate()

        txtG.Text = newArea.ColorCount.Grün.ToString
        txtR.Text = newArea.ColorCount.Rot.ToString
        txtS.Text = newArea.ColorCount.Schwarz.ToString
        txtY.Text = newArea.ColorCount.Gelb.ToString
        txtV.Text = newArea.ColorCount.Violet.ToString
        txtB.Text = newArea.ColorCount.Blau.ToString

        Application.DoEvents()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        newArea.FirstSubject_move()
        newArea.SubjectList_move()
        newArea.show()

        newArea.Grid_Fill(Me.GridControl1, Me.GridControl2)

        Me.picOut.Image = newArea.Map.Image
        Me.picOut.Invalidate()

        txtG.Text = newArea.ColorCount.Grün.ToString
        txtR.Text = newArea.ColorCount.Rot.ToString
        txtS.Text = newArea.ColorCount.Schwarz.ToString
        txtY.Text = newArea.ColorCount.Orange.ToString
        txtV.Text = newArea.ColorCount.Violet.ToString
        Application.DoEvents()

    End Sub

    Private Sub GridControl1_CellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs) Handles GridControl1.CellClick

    End Sub

    Private Sub txtTimer_TextChanged(sender As Object, e As EventArgs) Handles txtTimer.TextChanged

    End Sub
End Class
