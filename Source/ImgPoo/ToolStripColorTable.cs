using System.Windows.Forms;
using System.Drawing;

namespace ImgPoo {
    class ToolStripColorTable : ProfessionalColorTable {
        private Color DarkThemeBG;

        public ToolStripColorTable() {
            DarkThemeBG = ColorTranslator.FromHtml("#242424");
            UseSystemColors = false;
        }

        public override Color MenuItemBorder => DarkThemeBG;
        public override Color MenuBorder => DarkThemeBG;

        public override Color MenuItemPressedGradientBegin => DarkThemeBG;
        public override Color MenuItemPressedGradientEnd => DarkThemeBG;

        public override Color MenuItemSelected => DarkThemeBG;
        public override Color MenuItemSelectedGradientBegin => DarkThemeBG;
        public override Color MenuItemSelectedGradientEnd => DarkThemeBG;

        public override Color MenuStripGradientBegin => DarkThemeBG;
        public override Color MenuStripGradientEnd => DarkThemeBG;

        public override Color ToolStripBorder => DarkThemeBG;
        public override Color ToolStripDropDownBackground => DarkThemeBG;

        public override Color ToolStripGradientBegin => DarkThemeBG;
        public override Color ToolStripGradientEnd => DarkThemeBG;
        public override Color ToolStripGradientMiddle => DarkThemeBG;
    }
}
