using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyGame2
{
    internal class CircleButton : Button
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            //grPath.
            this.Region = new System.Drawing.Region(grPath);

            //ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            //SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
            base.OnPaint(e);
        }
    }
}
