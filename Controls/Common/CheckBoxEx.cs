using System.Drawing;
using System.Windows.Forms;

namespace BoardGameSimulator.Controls.Common
{
    [ToolboxBitmap(typeof(CheckBox))]
    public sealed class CheckBoxEx : CheckBox
    {
        public CheckBoxEx()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020;
                return cp;
            }
        }
    }
}
