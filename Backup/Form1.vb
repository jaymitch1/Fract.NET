
Public Class Form1
    Inherits System.Windows.Forms.Form

    'Dim Pens(255) As Pen
    Dim Colors(255) As Integer
    Dim bColors(255, 2) As Byte

    Dim Values(,) As Integer
    Dim iOffset As Integer
    Dim bmpDouble As Bitmap
    'Dim palletizer As BitmapMarshaler.BitmapMarshaler
    Dim gMain As Graphics
    'Dim buffer() As Byte
    Dim buffer() As Integer

    Dim scaleX, scaleY As Double
    Dim NewMinX, NewMinY, NewMaxX, NewMaxY As Double

    'these variables used for drawing the rectangle on screen

    Dim bmpRect As Bitmap
    Dim gRect As Graphics

    Dim bRefreshScale As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMinX As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxX As System.Windows.Forms.TextBox
    Friend WithEvents txtMinY As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxY As System.Windows.Forms.TextBox
    Friend WithEvents txtIterations As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdDraw As System.Windows.Forms.Button
    Friend WithEvents lblElapsedTime As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblDrawTime As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAnimSpeed As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents cmdRotate As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblX As System.Windows.Forms.Label
    Friend WithEvents lblY As System.Windows.Forms.Label
    Friend WithEvents cmdDefault As System.Windows.Forms.Button
    Friend WithEvents optOut As System.Windows.Forms.RadioButton
    Friend WithEvents optIn As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents cmdOut As System.Windows.Forms.Button
    Friend WithEvents cmdIn As System.Windows.Forms.Button
    Friend WithEvents cmdright As System.Windows.Forms.Button
    Friend WithEvents cmdLeft As System.Windows.Forms.Button
    Friend WithEvents cmdDown As System.Windows.Forms.Button
    Friend WithEvents cmdUp As System.Windows.Forms.Button
    Friend WithEvents cmdAntiAlias As System.Windows.Forms.Button
    Friend WithEvents chk4to1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkUseCSharp As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtMinX = New System.Windows.Forms.TextBox
        Me.txtMaxX = New System.Windows.Forms.TextBox
        Me.txtMinY = New System.Windows.Forms.TextBox
        Me.txtMaxY = New System.Windows.Forms.TextBox
        Me.txtIterations = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdDraw = New System.Windows.Forms.Button
        Me.lblElapsedTime = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.lblDrawTime = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.optIn = New System.Windows.Forms.RadioButton
        Me.optOut = New System.Windows.Forms.RadioButton
        Me.lblAnimSpeed = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.cmdRotate = New System.Windows.Forms.Button
        Me.lblX = New System.Windows.Forms.Label
        Me.lblY = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdDefault = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdOut = New System.Windows.Forms.Button
        Me.cmdIn = New System.Windows.Forms.Button
        Me.cmdright = New System.Windows.Forms.Button
        Me.cmdLeft = New System.Windows.Forms.Button
        Me.cmdDown = New System.Windows.Forms.Button
        Me.cmdUp = New System.Windows.Forms.Button
        Me.cmdAntiAlias = New System.Windows.Forms.Button
        Me.chk4to1 = New System.Windows.Forms.CheckBox
        Me.chkUseCSharp = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtY = New System.Windows.Forms.TextBox
        Me.txtX = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(16, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 328)
        Me.Panel1.TabIndex = 0
        '
        'txtMinX
        '
        Me.txtMinX.Location = New System.Drawing.Point(64, 352)
        Me.txtMinX.Name = "txtMinX"
        Me.txtMinX.TabIndex = 1
        Me.txtMinX.Text = "-2.5"
        '
        'txtMaxX
        '
        Me.txtMaxX.Location = New System.Drawing.Point(64, 382)
        Me.txtMaxX.Name = "txtMaxX"
        Me.txtMaxX.TabIndex = 2
        Me.txtMaxX.Text = "1.5"
        '
        'txtMinY
        '
        Me.txtMinY.Location = New System.Drawing.Point(280, 352)
        Me.txtMinY.Name = "txtMinY"
        Me.txtMinY.TabIndex = 3
        Me.txtMinY.Text = "-1.5"
        '
        'txtMaxY
        '
        Me.txtMaxY.Location = New System.Drawing.Point(280, 382)
        Me.txtMaxY.Name = "txtMaxY"
        Me.txtMaxY.TabIndex = 4
        Me.txtMaxY.Text = "1.5"
        '
        'txtIterations
        '
        Me.txtIterations.Location = New System.Drawing.Point(473, 352)
        Me.txtIterations.Name = "txtIterations"
        Me.txtIterations.TabIndex = 5
        Me.txtIterations.Text = "100"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Min X"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 382)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Max X"
        '
        'lbl
        '
        Me.lbl.Location = New System.Drawing.Point(240, 352)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(40, 23)
        Me.lbl.TabIndex = 8
        Me.lbl.Text = "Min Y"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(240, 382)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 23)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Max Y"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(416, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 23)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Iterations"
        '
        'cmdDraw
        '
        Me.cmdDraw.Location = New System.Drawing.Point(592, 512)
        Me.cmdDraw.Name = "cmdDraw"
        Me.cmdDraw.TabIndex = 10
        Me.cmdDraw.Text = "Draw!"
        '
        'lblElapsedTime
        '
        Me.lblElapsedTime.Location = New System.Drawing.Point(504, 384)
        Me.lblElapsedTime.Name = "lblElapsedTime"
        Me.lblElapsedTime.TabIndex = 11
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem1.Text = "File"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Open"
        '
        'lblDrawTime
        '
        Me.lblDrawTime.Location = New System.Drawing.Point(648, 320)
        Me.lblDrawTime.Name = "lblDrawTime"
        Me.lblDrawTime.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(648, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Time to draw"
        '
        'Timer1
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optIn)
        Me.GroupBox1.Controls.Add(Me.optOut)
        Me.GroupBox1.Controls.Add(Me.lblAnimSpeed)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.HScrollBar1)
        Me.GroupBox1.Controls.Add(Me.cmdRotate)
        Me.GroupBox1.Location = New System.Drawing.Point(600, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 248)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Animation"
        '
        'optIn
        '
        Me.optIn.Location = New System.Drawing.Point(16, 56)
        Me.optIn.Name = "optIn"
        Me.optIn.TabIndex = 23
        Me.optIn.Text = "Cycle In"
        '
        'optOut
        '
        Me.optOut.Checked = True
        Me.optOut.Location = New System.Drawing.Point(16, 24)
        Me.optOut.Name = "optOut"
        Me.optOut.TabIndex = 22
        Me.optOut.TabStop = True
        Me.optOut.Text = "Cycle Out"
        '
        'lblAnimSpeed
        '
        Me.lblAnimSpeed.Location = New System.Drawing.Point(24, 192)
        Me.lblAnimSpeed.Name = "lblAnimSpeed"
        Me.lblAnimSpeed.Size = New System.Drawing.Size(100, 16)
        Me.lblAnimSpeed.TabIndex = 21
        Me.lblAnimSpeed.Text = "100"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Animation Speed"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(24, 168)
        Me.HScrollBar1.Maximum = 1500
        Me.HScrollBar1.Minimum = 25
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(88, 16)
        Me.HScrollBar1.TabIndex = 19
        Me.HScrollBar1.Value = 100
        '
        'cmdRotate
        '
        Me.cmdRotate.Location = New System.Drawing.Point(24, 216)
        Me.cmdRotate.Name = "cmdRotate"
        Me.cmdRotate.TabIndex = 18
        Me.cmdRotate.Text = "Start"
        '
        'lblX
        '
        Me.lblX.Location = New System.Drawing.Point(656, 352)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(136, 16)
        Me.lblX.TabIndex = 19
        '
        'lblY
        '
        Me.lblY.Location = New System.Drawing.Point(656, 376)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(136, 16)
        Me.lblY.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(616, 352)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "X:"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(616, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 16)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Y:"
        '
        'cmdDefault
        '
        Me.cmdDefault.Location = New System.Drawing.Point(592, 480)
        Me.cmdDefault.Name = "cmdDefault"
        Me.cmdDefault.TabIndex = 23
        Me.cmdDefault.Text = "Default"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtInterval)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmdOut)
        Me.GroupBox2.Controls.Add(Me.cmdIn)
        Me.GroupBox2.Controls.Add(Me.cmdright)
        Me.GroupBox2.Controls.Add(Me.cmdLeft)
        Me.GroupBox2.Controls.Add(Me.cmdDown)
        Me.GroupBox2.Controls.Add(Me.cmdUp)
        Me.GroupBox2.Location = New System.Drawing.Point(24, 408)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 128)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Navigation Controls"
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(144, 64)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.TabIndex = 7
        Me.txtInterval.Text = "0.1"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(144, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Movement Interval"
        '
        'cmdOut
        '
        Me.cmdOut.Location = New System.Drawing.Point(48, 72)
        Me.cmdOut.Name = "cmdOut"
        Me.cmdOut.Size = New System.Drawing.Size(32, 24)
        Me.cmdOut.TabIndex = 5
        Me.cmdOut.Text = "-"
        '
        'cmdIn
        '
        Me.cmdIn.Location = New System.Drawing.Point(48, 48)
        Me.cmdIn.Name = "cmdIn"
        Me.cmdIn.Size = New System.Drawing.Size(32, 24)
        Me.cmdIn.TabIndex = 4
        Me.cmdIn.Text = "+"
        '
        'cmdright
        '
        Me.cmdright.Location = New System.Drawing.Point(88, 56)
        Me.cmdright.Name = "cmdright"
        Me.cmdright.Size = New System.Drawing.Size(32, 24)
        Me.cmdright.TabIndex = 3
        Me.cmdright.Text = ">"
        '
        'cmdLeft
        '
        Me.cmdLeft.Location = New System.Drawing.Point(8, 56)
        Me.cmdLeft.Name = "cmdLeft"
        Me.cmdLeft.Size = New System.Drawing.Size(32, 24)
        Me.cmdLeft.TabIndex = 2
        Me.cmdLeft.Tag = "<"
        Me.cmdLeft.Text = "<"
        '
        'cmdDown
        '
        Me.cmdDown.Location = New System.Drawing.Point(48, 96)
        Me.cmdDown.Name = "cmdDown"
        Me.cmdDown.Size = New System.Drawing.Size(32, 24)
        Me.cmdDown.TabIndex = 1
        Me.cmdDown.Text = "v"
        '
        'cmdUp
        '
        Me.cmdUp.Location = New System.Drawing.Point(48, 24)
        Me.cmdUp.Name = "cmdUp"
        Me.cmdUp.Size = New System.Drawing.Size(32, 24)
        Me.cmdUp.TabIndex = 0
        Me.cmdUp.Text = "^  "
        '
        'cmdAntiAlias
        '
        Me.cmdAntiAlias.Location = New System.Drawing.Point(672, 512)
        Me.cmdAntiAlias.Name = "cmdAntiAlias"
        Me.cmdAntiAlias.TabIndex = 25
        Me.cmdAntiAlias.Text = "Anti-Alias"
        '
        'chk4to1
        '
        Me.chk4to1.Location = New System.Drawing.Point(592, 448)
        Me.chk4to1.Name = "chk4to1"
        Me.chk4to1.TabIndex = 26
        Me.chk4to1.Text = "Use 4:1 scaling"
        '
        'chkUseCSharp
        '
        Me.chkUseCSharp.Location = New System.Drawing.Point(592, 416)
        Me.chkUseCSharp.Name = "chkUseCSharp"
        Me.chkUseCSharp.Size = New System.Drawing.Size(160, 24)
        Me.chkUseCSharp.TabIndex = 27
        Me.chkUseCSharp.Text = "Use c# drawing code"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtY)
        Me.GroupBox3.Controls.Add(Me.txtX)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(304, 416)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(192, 120)
        Me.GroupBox3.TabIndex = 28
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Initial Values"
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(40, 72)
        Me.txtY.Name = "txtY"
        Me.txtY.TabIndex = 3
        Me.txtY.Text = "0.0"
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(40, 32)
        Me.txtX.Name = "txtX"
        Me.txtX.TabIndex = 2
        Me.txtX.Text = "0.0"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 23)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Y:"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 23)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "X:"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 553)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.chkUseCSharp)
        Me.Controls.Add(Me.chk4to1)
        Me.Controls.Add(Me.cmdAntiAlias)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdDefault)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblDrawTime)
        Me.Controls.Add(Me.lblElapsedTime)
        Me.Controls.Add(Me.cmdDraw)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtIterations)
        Me.Controls.Add(Me.txtMaxY)
        Me.Controls.Add(Me.txtMinY)
        Me.Controls.Add(Me.txtMaxX)
        Me.Controls.Add(Me.txtMinX)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Fractal Test"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDraw.Click
        Me.Cursor = Cursors.WaitCursor
        Call CalculateValues()
        Call Draw()
        Me.Cursor = Cursors.Default

        'Else

        '    ' Julia set
        '    For y = 0 To Picture1.ScaleHeight - 1
        '        For x = 0 To Picture1.ScaleWidth - 1
        '            ' work out the coordinate of the pixel
        '            initx = Xmin + xs * x
        '            inity = Ymin + ys * y
        '            ' iterate with these parameters
        '            i = IterateJ(initx, inity, MaxIter, P, Q)
        '            ' plot the pixel
        '    Picture1.PSet (x, y), QBColor((i Mod 15) + 1)
        '        Next
        '    Next
        'End If
    End Sub
    Private Sub CalculateValues()
        Dim Xmin, Xmax, Ymin, Ymax, initx, inity, perturbX, perturbY As Double
        Dim MaxIter As Integer
        Dim lStart, lEnd As Long
        Dim iScale As Integer
        If chk4to1.Checked Then
            iScale = 4
        Else
            iScale = 1
        End If
        Xmin = Val(txtMinX.Text)
        Xmax = Val(txtMaxX.Text)
        Ymin = Val(txtMinY.Text)
        Ymax = Val(txtMaxY.Text)
        perturbX = Val(txtX.Text)
        perturbY = Val(txtY.Text)

        MaxIter = CInt(txtIterations.Text)

        ' This works out the scaling factor for each pixel
        scaleX = (Xmax - Xmin) / (Panel1.Width * iScale)
        scaleY = (Ymax - Ymin) / (Panel1.Height * iScale)

        lStart = Environment.TickCount
        ReDim Values(Panel1.Height * iScale, Panel1.Width * iScale)

        For y As Integer = 0 To Panel1.Height * iScale - 1
            For x As Integer = 0 To Panel1.Width * iScale - 1
                ' work out the coordinate of the pixel
                initx = Xmin + scaleX * x
                inity = Ymin + scaleY * y
                ' iterate with these parameters
                Values(y, x) = IterateM(initx, inity, MaxIter, perturbX, perturbY)
            Next
        Next
        lEnd = Environment.TickCount
        lStart = lEnd - lStart
        lblElapsedTime.Text = lStart.ToString
    End Sub
    Private Function IterateM(ByVal initx As Double, ByVal inity As Double, ByVal MaxIter As Integer, ByVal perturbX As Double, ByVal perturbY As Double) As Integer
        ' this function works out how many iterations are needed for a given point on the
        ' mandelbrot set

        ' x->x*x-y*y+x0
        ' y->2*x*y+y0
        Dim x, y, xsq, ysq As Double
        Dim i As Integer

        ' precalculate the first iteration
        'real
        x = initx + initx * initx - inity * inity 'perturbX +
        'imaginary
        y = inity + initx * inity + initx * inity 'perturbY +
        ysq = y * y
        xsq = x * x

        For i = 2 To MaxIter
            ' new imaginary value
            y = inity + 2 * x * y   '+ x * y
            ' new real value
            x = initx - ysq + xsq
            ' work out the squared values
            ysq = y * y
            xsq = x * x
            ' check the bailout condition
            If (xsq + ysq) > 4 Then Exit For
        Next i
        Return i

    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadPallette(Application.StartupPath & "\default.map")
        gMain = Panel1.CreateGraphics
        Call CalculateValues()
        Call Draw()

    End Sub
    'Private Sub Palletize()
    '    Dim r As New Random

    '    For i As Integer = 0 To 15
    '        Pens(i) = New Pen(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)))
    '    Next
    'End Sub

    'Private Sub Draw()
    '    Dim lStart, lEnd As Integer

    '    lStart = Environment.TickCount


    '    If bmpDouble Is Nothing Then
    '        bmpDouble = New Bitmap(Panel1.Width, Panel1.Height)
    '        'gDouble = Graphics.FromImage(bmpDouble)
    '        'gDouble.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
    '        'gDouble.InterpolationMode = Drawing2D.InterpolationMode.Low
    '    End If

    '    'Dim buffer(bmpDouble.Width * 4 * bmpDouble.Height) As Byte

    '    'g.Clear(Color.Black)
    '    'gDouble.Clear(Color.Black)
    '    With bmpDouble
    '        For y As Integer = 0 To .Height - 1
    '            For x As Integer = 0 To .Width - 1
    '                .SetPixel(x, y, Colors((Values(y, x) Mod 255 + iOffset) Mod 255))
    '                'gDouble.DrawRectangle(Pens((Values(y, x) Mod 255) + 1 + iOffset), x, y, 1, 1)
    '            Next

    '        Next
    '    End With
    '    lEnd = Environment.TickCount
    '    lblDrawTime.Text = CStr(lEnd - lStart)
    '    gMain.DrawImage(bmpDouble, 0, 0)
    '    'Panel1.BackgroundImage = bmpDouble
    'End Sub

    Private Sub Draw()
        Dim lStart, lEnd, iScale As Integer
        If chk4to1.Checked Then
            iScale = 4
        Else
            iScale = 1
        End If

        lStart = Environment.TickCount
        If bmpDouble Is Nothing Or bRefreshScale Then
            bmpDouble = New Bitmap(Panel1.Width * iScale, Panel1.Height * iScale, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            ReDim buffer(bmpDouble.Width * bmpDouble.Height)  '*4
            bRefreshScale = False

            ' palletizer = New BitmapMarshaler.BitmapMarshaler(bmpDouble)
        End If
        If chkUseCSharp.Checked Then
            Dim palletizer As New BitmapMarshaler.BitmapMarshaler(bmpDouble)
            palletizer.Palletize(Values, Colors, iOffset)
        Else

            'palletizer.Palletize(Values, Colors, iOffset)

            Dim bmd As System.Drawing.Imaging.BitmapData

            With bmpDouble
                bmd = .LockBits(New Rectangle(0, 0, .Width, .Height), _
                Imaging.ImageLockMode.WriteOnly, Imaging.PixelFormat.Format32bppRgb)
                For y As Integer = 0 To .Height - 1
                    For x As Integer = 0 To .Width - 1
                        Dim bufferIndex, Index As Integer
                        Index = (Values(y, x) Mod 256 + iOffset) Mod 256
                        buffer(bufferIndex) = Colors(Index)

                        'buffer(bufferIndex) = bColors(Index, 0)
                        'buffer(bufferIndex + 1) = bColors(Index, 1)
                        'buffer(bufferIndex + 2) = bColors(Index, 2)
                        'bufferIndex += 4
                        bufferIndex += 1
                    Next
                Next

                Runtime.InteropServices.Marshal.Copy(buffer, 0, bmd.Scan0, .Width * .Height)   '*4
                .UnlockBits(bmd)
            End With
        End If
        gMain.DrawImage(bmpDouble, 0, 0, Panel1.Width, Panel1.Height)
        lEnd = Environment.TickCount
        lblDrawTime.Text = CStr(lEnd - lStart)

    End Sub
    Private Sub LoadPallette(ByVal sFileName As String)
        Dim numbers As Char() = {"0"c, "1"c, "2"c, "3"c, "4"c, "5"c, "6"c, "7"c, "8"c, "9"c}

        Dim sr As New System.IO.StreamReader(sFileName)
        Dim s As String
        Dim elements() As String

        s = sr.ReadLine

        While s <> vbNullString And s <> "" And Not s Is Nothing
            Dim i, r, g, b As Integer
            If i >= 256 Then Exit While
            'elements = s.Split(" "c)
            Dim pos1, pos2 As Integer

            pos1 = s.IndexOfAny(numbers)
            pos2 = s.IndexOf(" "c, pos1)

            'MsgBox(s.Substring(pos1, pos2))

            r = Integer.Parse(s.Substring(pos1, pos2 - pos1))
            pos1 = s.IndexOfAny(numbers, pos2)
            pos2 = s.IndexOf(" "c, pos1)

            g = Integer.Parse(s.Substring(pos1, pos2 - pos1))
            pos1 = s.IndexOfAny(numbers, pos2)
            pos2 = s.IndexOf(" "c, pos1)
            If pos2 = -1 Then pos2 = s.Length
            b = Integer.Parse(s.Substring(pos1, pos2 - pos1))

            bColors(i, 0) = CByte(r)
            bColors(i, 1) = CByte(g)
            bColors(i, 2) = CByte(b)
            Colors(i) = Color.FromArgb(r, g, b).ToArgb

            s = sr.ReadLine()
            i += 1
        End While
        sr.Close()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim sFile As String
        OpenFileDialog1.InitialDirectory = Application.StartupPath
        OpenFileDialog1.Filter = "*.map|*.map"
        OpenFileDialog1.ShowDialog()

        sFile = OpenFileDialog1.FileName
        If sFile <> vbNullString Then
            Call LoadPallette(sFile)
            iOffset = 0
            Call Draw()
        End If

    End Sub

    Private Sub cmdRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRotate.Click
        If cmdRotate.Text = "Start" Then
            cmdRotate.Text = "Stop"
        Else
            cmdRotate.Text = "Start"
        End If
        Timer1.Enabled = Not Timer1.Enabled
    End Sub

    Private Sub Rotate()
        If optOut.Checked Then
            iOffset += 1
        Else
            iOffset -= 1
            If iOffset < 0 Then iOffset = 254
        End If

        Call Draw()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call Rotate()
    End Sub

    'Private Sub Test(ByVal bmpBuffer As Bitmap)
    '    Dim bts As Drawing.Imaging.BitmapData
    '    Dim b() As Byte
    '    Dim Y, iBDIndex, X As Integer
    '    Dim bmTemp As New Bitmap(bmpBuffer.Width, bmpBuffer.Height, Drawing.Imaging.PixelFormat.Format32bppRgb)

    '    Dim g As Graphics = Graphics.FromImage(bmTemp)

    '    ReDim b((bmpBuffer.Width * 4) * (bmpBuffer.Height))

    '    g.DrawImage(bmpBuffer, 0, 0)
    '    g.Dispose()

    '    bts = bmTemp.LockBits(New Rectangle(0, 0, bmpBuffer.Width, _
    '        bmpBuffer.Height), Drawing.Imaging.ImageLockMode.ReadWrite, _
    '        Drawing.Imaging.PixelFormat.Format32bppArgb)

    '    Runtime.InteropServices.Marshal.Copy(bts.Scan0, b, 0, ((bmpBuffer.Width) * 4) * (bmpBuffer.Height))

    '    iBDIndex = 0

    '    '// divides by 4, and steps by 4 because it is ARGB 32bpp

    '    For Y = 0 To (bmpBuffer.Height - 1)
    '        For X = 0 To CInt((UBound(b) / 4) / (bmpBuffer.Height)) - 1
    '            b(iBDIndex) = Not b(iBDIndex)
    '            b(iBDIndex + 1) = Not b(iBDIndex + 1)
    '            b(iBDIndex + 2) = Not b(iBDIndex + 2)
    '            iBDIndex += 4
    '        Next
    '    Next

    '    Runtime.InteropServices.Marshal.Copy(b, 0, bts.Scan0, ((bmpBuffer.Width) * 4) * (bmpBuffer.Height))

    '    bmTemp.UnlockBits(bts)

    '    picMain.Image.Dispose()
    '    bmpBuffer.Dispose()
    '    bmpBuffer = New Bitmap(bmTemp)
    '    bmTemp.Dispose()

    'End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        lblAnimSpeed.Text = CStr(HScrollBar1.Value)
        Timer1.Interval = HScrollBar1.Value
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        lblX.Text = CStr(Double.Parse(txtMinX.Text) + scaleX * e.X())
        lblY.Text = CStr(Double.Parse(txtMinY.Text) + scaleY * e.Y())
    End Sub


    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        NewMinX = Double.Parse(txtMinX.Text) + scaleX * e.X()
        NewMinY = Double.Parse(txtMinY.Text) + scaleY * e.Y()
        'If bmpRect Is Nothing Then
        'bmpRect = New Bitmap(bmpDouble)
        'gRect = Graphics.FromImage(bmpRect)

        'End If
        'bmprect = graphics.FromImage(panel1.CreateGraphics.

    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        NewMaxX = Double.Parse(txtMinX.Text) + scaleX * e.X()
        NewMaxY = Double.Parse(txtMinY.Text) + scaleY * e.Y()
        txtMinX.Text = CStr(NewMinX)
        txtMinY.Text = CStr(NewMinY)
        txtMaxX.Text = CStr(NewMaxX)
        txtMaxY.Text = CStr(NewMaxY)

        'Call cmdDraw_Click(Nothing, Nothing)
    End Sub

    Private Sub cmdDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDefault.Click
        txtMinX.Text = "-2.5"
        txtMinY.Text = "-1.5"
        txtMaxX.Text = "1.5"
        txtMaxY.Text = "1.5"
        Call CalculateValues()
        Call Draw()
    End Sub

    Private Sub Navigate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click, cmdDown.Click, cmdLeft.Click, cmdright.Click, cmdIn.Click, cmdOut.Click
        Dim minY, maxY, minX, maxX, interval, aspect As Double
        Me.Cursor = Cursors.WaitCursor

        minX = Double.Parse(txtMinX.Text)
        maxX = Double.Parse(txtMaxX.Text)
        minY = Double.Parse(txtMinY.Text)
        maxY = Double.Parse(txtMaxY.Text)
        aspect = (maxX - minX) / (maxY - minY)

        interval = Double.Parse(txtInterval.Text)
        If sender Is cmdUp Then
            minY -= interval
            maxY -= interval
        ElseIf sender Is cmdDown Then
            minY += interval
            maxY += interval
        ElseIf sender Is cmdLeft Then
            minX -= interval
            maxX -= interval
        ElseIf sender Is cmdright Then
            minX += interval
            maxX += interval
        ElseIf sender Is cmdIn Then
            minX += interval * aspect
            maxX -= interval * aspect
            minY += interval
            maxY -= interval
        ElseIf sender Is cmdOut Then
            minX -= interval * aspect
            maxX += interval * aspect
            minY -= interval
            maxY += interval
        End If
        txtMaxX.Text = maxX.ToString
        txtMaxY.Text = maxY.ToString
        txtMinX.Text = minX.ToString
        txtMinY.Text = minY.ToString

        Call CalculateValues()
        Call Draw()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Call Draw()
    End Sub

    Private Sub cmdAntiAlias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAntiAlias.Click
        Dim bmpTmp As New Bitmap(bmpDouble)
        Dim c As Color
        Dim r, g, b As Integer
        Me.Cursor = Cursors.WaitCursor

        For y As Integer = 1 To bmpTmp.Height - 2
            For x As Integer = 1 To bmpTmp.Width - 2
                For i As Integer = -1 To 1
                    For j As Integer = -1 To 1
                        c = bmpTmp.GetPixel(x + i, y + j)
                        r = r + ((c.ToArgb And &HFF0000) >> 16)
                        g = g + ((c.ToArgb And &HFF00) >> 8)
                        b = b + (c.ToArgb And &HFF)
                    Next
                Next
                bmpTmp.SetPixel(x, y, Color.FromArgb(r \ 9, g \ 9, b \ 9))
                r = 0 : b = 0 : g = 0
            Next
        Next

        gMain.DrawImageUnscaled(bmpTmp, 0, 0, bmpTmp.Width, bmpTmp.Height)

        bmpTmp.Dispose()

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub chk4to1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk4to1.CheckedChanged
        bRefreshScale = True

    End Sub
End Class
