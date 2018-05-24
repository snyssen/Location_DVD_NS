using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Location_DVD_NS
{
    public partial class NotificationButton : Button
    {
        /// <summary>
        /// Source code from https://classpattern.com/notification-button (author unknown) on 2013-02-01
        /// Modified by Nyssen Simon on 2018-22-05 https://github.com/snyssen
        /// </summary>
        private int _NotificationNbr;
        private bool _NotificationEnabled;
        private Color _ExteriorColor = Color.OrangeRed;
        private Color _InteriorColor = Color.OrangeRed, _NumberColor = Color.White;

        public NotificationButton()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [Description("Number of notifications to show")]
        public int NotificationNbr
        {
            get { return _NotificationNbr; }
            set
            {
                if (_NotificationNbr == value || value < 0)
                    return;
                _NotificationNbr = value;
                Invalidate();
            }
        }

        [Category("Behavior")]
        [Description("Indicates whether the notification icon is active or not")]
        public bool NotificationEnabled
        {
            get { return _NotificationEnabled; }
            set { _NotificationEnabled = value; }
        }

        [Category("Appearance")]
        [Description("Color on the outside of the notification icon")]
        public Color ExteriorColor
        {
            get { return _ExteriorColor; }
            set
            {
                _ExteriorColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Color on the inside of the notification icon")]
        public Color InteriorColor
        {
            get { return _InteriorColor; }
            set
            {
                _InteriorColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [Description("Color of the number of notifications")]
        public Color NumberColor
        {
            get { return _NumberColor; }
            set
            {
                _NumberColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            if (NotificationNbr == 0) return;
            int height = 25;
            var rect = new Rectangle(this.Width - (height), (this.Height - height) / 2, height, height);
            graphics.FillEllipse(new SolidBrush(InteriorColor), rect);
            graphics.DrawEllipse(new Pen(ExteriorColor, 2), rect);
            string text = NotificationNbr.ToString();
            SizeF textsize = graphics.MeasureString(text, Font);
            graphics.DrawString(text, Font, new SolidBrush(NumberColor), rect.X + ((height - textsize.Width) / 2), rect.Y + ((height - textsize.Height) / 2));
        }
    }
}
