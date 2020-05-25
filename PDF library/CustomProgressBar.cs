using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace PDF_library
{

    public enum ProgressBarDisplayText
    {
        Percentage,
        CustomText
    }

    class CustomProgressBar : ProgressBar
    {
        //Property to set to decide whether to print a % or Text
        public CustomProgressBar()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private ProgressBarDisplayText m_DisplayStyle;
        public ProgressBarDisplayText DisplayStyle
        {
            get { return m_DisplayStyle; }
            set { m_DisplayStyle = value; }
        }

        //Property to hold the custom text
        private string m_CustomText;
        public string CustomText
        {
            get { return m_CustomText; }
            set
            {
                m_CustomText = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - rec.Height;
            e.Graphics.FillRectangle(Brushes.LightGray, 2, 2, rec.Width, rec.Height);
        }

        private const int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            //base.WndProc(m);
            switch (m.Msg)
            {
                case WM_PAINT:
                    int m_Percent = Convert.ToInt32((Convert.ToDouble(Value) / Convert.ToDouble(Maximum)) * 100);
                    dynamic flags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.WordEllipsis;

                    using (Graphics g = Graphics.FromHwnd(Handle))
                    {
                        using (Brush textBrush = new SolidBrush(ForeColor))
                        {

                            switch (DisplayStyle)
                            {
                                case ProgressBarDisplayText.CustomText:
                                    TextRenderer.DrawText(g, CustomText, new Font("Arial", Convert.ToSingle(8.25), FontStyle.Regular), new Rectangle(0, 0, this.Width, this.Height), Color.Black, flags);
                                    break;
                                case ProgressBarDisplayText.Percentage:
                                    TextRenderer.DrawText(g, string.Format("{0}%", m_Percent), new Font("Arial", Convert.ToSingle(8.25), FontStyle.Regular), new Rectangle(0, 0, this.Width, this.Height), Color.Black, flags);
                                    break;
                            }

                        }


                    }

                    break;
            }

        }

    }
}
