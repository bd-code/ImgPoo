using System.Windows.Forms;
using System.Drawing;

namespace ImgPoo {
    class ColorTable : ProfessionalColorTable {
        private Color DarkThemeBG;

        public ColorTable() {
            DarkThemeBG = ColorTranslator.FromHtml("#242424");
            UseSystemColors = false;
        }
        /*
        public override Color ImageMarginGradientBegin {
            get { return Color.MidnightBlue; }
        }
        public override Color ImageMarginGradientMiddle {
            get { return Color.MidnightBlue; }
        }
        public override Color ImageMarginGradientEnd {
            get { return Color.MidnightBlue; }
        }*/

        public override Color MenuItemBorder {
            get { return DarkThemeBG; }
        }
        public override Color MenuBorder {
            get { return DarkThemeBG; }
        }

        public override Color MenuItemPressedGradientBegin {
            get { return DarkThemeBG; }
        }
        public override Color MenuItemPressedGradientEnd {
            get { return DarkThemeBG; }
        }

        public override Color MenuItemSelected {
            get { return DarkThemeBG; }
        }
        public override Color MenuItemSelectedGradientBegin {
            get { return DarkThemeBG; }
        }
        public override Color MenuItemSelectedGradientEnd {
            get { return DarkThemeBG; }
        }

        public override Color MenuStripGradientBegin {
            get { return DarkThemeBG; }
        }
        public override Color MenuStripGradientEnd {
            get { return DarkThemeBG; }
        }

        public override Color ToolStripBorder {
            get { return DarkThemeBG; }
        }

        public override Color ToolStripDropDownBackground {
            get { return DarkThemeBG; }
        }

        public override Color ToolStripGradientBegin {
            get { return DarkThemeBG; }
        }
        public override Color ToolStripGradientEnd {
            get { return DarkThemeBG; }
        }
        public override Color ToolStripGradientMiddle {
            get { return DarkThemeBG; }
        }
    }
}
