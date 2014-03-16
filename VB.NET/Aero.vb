Option Strict On

Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Aero
    Inherits Form

    <DllImport("dwmapi.dll")> _
    Private Shared Function DwmExtendFrameIntoClientArea(ByVal hwnd As IntPtr, ByRef margins As Margins) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Margins
        Public Right, Left, Top, Bottom As Integer

        Sub New(ByVal padding As Padding)
            Me.Right = padding.Right
            Me.Left = padding.Left
            Me.Top = padding.Top
            Me.Bottom = padding.Bottom
        End Sub
    End Structure

    <Description("When this property is true, the entire form will be Aero."), Category("Appearance")>
    Public Property AeroCoverAll As Boolean

    Protected Overrides Sub OnLoad(e As EventArgs)
        Me.BackColor = Color.Black
        Dim margins As Margins
        If AeroCoverAll Then
            margins = New Margins(New Padding(-1))
        Else
            margins = New Margins(Me.Padding)
        End If
        DwmExtendFrameIntoClientArea(Me.Handle, margins)
        MyBase.OnLoad(e)
    End Sub
End Class