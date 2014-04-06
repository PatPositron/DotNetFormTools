using System;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Aero : Form
{

    [DllImport("dwmapi.dll")]
    public static extern int DwmExtendFrameIntoClientArea(IntPtr hwnd, ref Margins margins);

    [StructLayout(LayoutKind.Sequential)]
    public struct Margins
    {
        public int Right, Left, Top, Bottom;

        public Margins(Padding padding)
        {
            this.Right = padding.Right;
            this.Left = padding.Left;
            this.Top = padding.Top;
            this.Bottom = padding.Bottom;
        }
    }

    [Description("When this property is true, the entire form will be Aero."), Category("Appearance")]
    public bool AeroCoverAll { get; set; }

    protected override void OnLoad(EventArgs e)
    {
        this.BackColor = Color.Black;
        Margins margins;
        if (AeroCoverAll)
            margins = new Margins(new Padding(-1));
        else
            margins = new Margins(this.Padding);
        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
        base.OnLoad(e);
    }
}