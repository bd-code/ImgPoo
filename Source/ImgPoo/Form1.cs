using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImgPoo {
    public partial class Form1 : Form {

        private Bitmap _img;
        private List<string> _imagefiles;
        private int _dirIndex;
        private int _zoomLevel;

        private bool _isDragging;
        private Point _startDrag;

        public Form1() {
            _imagefiles = new List<string>();
            _dirIndex = 0;
            _zoomLevel = 1;

            InitializeComponent();
            CustomizeComponent();

            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (Environment.GetCommandLineArgs().Length > 1) {
                string imgpath = Environment.GetCommandLineArgs()[1];
                if (isValidImage(imgpath)) {
                    string path = Path.GetDirectoryName(imgpath);
                    getFiles(path);
                    _dirIndex = _imagefiles.IndexOf(imgpath);
                    changeImage(imgpath);
                }
            }

            statsZoom.Text = "Zoom: " + _zoomLevel.ToString();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e) {
            fileDialog.ShowDialog();
            if (File.Exists(fileDialog.FileName)) {
                string path = Path.GetDirectoryName(fileDialog.FileName);
                fileDialog.InitialDirectory = path;
                getFiles(path);

                if (isValidImage(fileDialog.FileName)) {
                    _dirIndex = _imagefiles.IndexOf(fileDialog.FileName);
                    changeImage(fileDialog.FileName);
                }

            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            folderDialog.ShowDialog();
            if (Directory.Exists(folderDialog.SelectedPath)) {
                getFiles(folderDialog.SelectedPath);

                if (_imagefiles.Count > 0 && isValidImage(_imagefiles[0])) {
                    _dirIndex = 0;
                    changeImage(_imagefiles[0]);
                }
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e) {
            zoomIn();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e) {
            zoomOut();
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e) {
            zoomReset();
        }

        private void toggleStatusBarToolStripMenuItem_Click(object sender, EventArgs e) {
            statusBar.Visible = !statusBar.Visible;
        }

        private void imgBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            if (_img is Bitmap) {
                Rectangle rect = new Rectangle(0, 0, imgBox.Width, imgBox.Height);
                e.Graphics.DrawImage(_img, rect);
                menuBar.BringToFront();
            }
        }

        private void Form1_Resize(object sender, EventArgs e) {
            centerImgBox();
            imgBox.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up)
                zoomIn();            
            else if (e.KeyCode == Keys.Down)
                zoomOut();            
            else if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                zoomReset();
            else if (e.KeyCode == Keys.Right)
                nextImage();            
            else if (e.KeyCode == Keys.Left)
                prevImage();            
        }

        private void changeBGColorToolStripMenuItem_Click(object sender, EventArgs e) {
            colorDialog.ShowDialog();
            imgPanel.BackColor = colorDialog.Color;
        }

        // Img Dragging

        private void imgBox_MouseDown(object sender, MouseEventArgs e) {            
            if (e.Button == MouseButtons.Left && imgOutsizesPanel()) {
                _isDragging = true;
                _startDrag = e.Location;
            }
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e) {
            if (_isDragging) {
                Point p = imgBox.Location;

                // Clamp
                if (imgBox.Size.Width > imgPanel.Size.Width) {
                    p.X = imgBox.Location.X + (e.Location.X - _startDrag.X);
                }
                if (imgBox.Size.Height > imgPanel.Size.Height) {
                    p.Y = imgBox.Location.Y + (e.Location.Y - _startDrag.Y);
                }

                imgBox.Location = clampPosition(p);
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e) {
            _isDragging = false;
        }

        //*////////////////////////////////////////////////////////////////////

        private void getFiles(string dir) {
            var exts = new string[] {
                ".bmp", ".gif",
                ".ico", ".jpg", ".jpeg",
                ".png", ".tif", ".tiff" };
            _imagefiles = new List<string>(
                Directory.EnumerateFiles(dir)
                .Where(s => exts.Contains(Path.GetExtension(s).ToLowerInvariant()))
                );
        }

        private void changeImage(string filename) {
            if (_img is Bitmap)
                _img.Dispose();
            _img = new Bitmap(filename);

            statsFilePath.Text = filename;
            _zoomLevel = 1;
            statsSize.Text = "Size: " + _img.Width + " x " + _img.Height + "";
            statsZoom.Text = "Zoom: " + _zoomLevel.ToString();

            resizeImgBox();
            centerImgBox();
            imgBox.Refresh();
        }

        private bool isValidImage(string filename) {
            try {
                Image.FromFile(filename);
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

        private void nextImage() {
            if (_imagefiles.Count() > 0) {
                _dirIndex = ++_dirIndex % _imagefiles.Count();
                changeImage(_imagefiles[_dirIndex]);
            }
        }

        private void prevImage() {
            if (_imagefiles.Count() > 0) {
                _dirIndex = (_dirIndex == 0) ? _imagefiles.Count() - 1 : --_dirIndex;
                changeImage(_imagefiles[_dirIndex]);
            }
        }

        private void zoomIn() {
            Point f = getFocusPoint();
            _zoomLevel = (_zoomLevel < 8) ? _zoomLevel+1 : _zoomLevel;
            statsZoom.Text = "Zoom: " + _zoomLevel.ToString();
            resizeImgBox();
            setFocusPoint(f);
            imgBox.Refresh();
        }

        private void zoomOut() {
            Point f = getFocusPoint();
            _zoomLevel = (_zoomLevel > 1) ? _zoomLevel-1 : _zoomLevel;
            statsZoom.Text = "Zoom: " + _zoomLevel.ToString();
            resizeImgBox();
            setFocusPoint(f);
            imgBox.Refresh();
        }

        private void zoomReset() {
            Point f = getFocusPoint();
            _zoomLevel = 1;
            statsZoom.Text = "Zoom: " + _zoomLevel.ToString();
            resizeImgBox();
            setFocusPoint(f);
            imgBox.Refresh();
        }

        bool imgOutsizesPanel() => imgBox.Size.Width > imgPanel.Size.Width || imgBox.Size.Height > imgPanel.Size.Height;

        /// <summary>
        /// Returns the point of the unzoomed image in the center of the viewport.
        /// </summary>
        /// <returns>Point: point of image at center of viewport.</returns>
        private Point getFocusPoint() {
            return new Point(
                (-imgBox.Location.X + (imgPanel.Width / 2)) / _zoomLevel,
                (-imgBox.Location.Y + (imgPanel.Height / 2)) / _zoomLevel
                );
        }

        private void setFocusPoint(Point focus) {
            Point zf = new Point(focus.X * _zoomLevel, focus.Y * _zoomLevel);
            Point pos = new Point(
                -zf.X + (imgPanel.Width / 2),
                -zf.Y + (imgPanel.Height / 2)
                );
            imgBox.Location = clampPosition(pos);
        }

        private void centerImgBox() {
            if (_img is Bitmap) {
                imgBox.Location = new Point(
                    Math.Max((imgPanel.Width - imgBox.Width) / 2, 0),
                    Math.Max((imgPanel.Height - imgBox.Height) / 2, 0 + menuBar.Size.Height)
                    );
            }
        }

        private void resizeImgBox() {
            if (_img is Bitmap) {
                imgBox.Width = _img.Width * _zoomLevel;
                imgBox.Height = _img.Height * _zoomLevel;                
            }
        }

        private Point clampPosition(Point p) {
            if (imgBox.Size.Width > imgPanel.Size.Width) {
                p.X = Math.Min(p.X, 1);
                p.X = Math.Max(p.X, imgPanel.Width - imgBox.Width);
            }
            if (imgBox.Size.Height > imgPanel.Size.Height) {
                p.Y = Math.Min(p.Y, menuBar.Size.Height);
                p.Y = Math.Max(p.Y, imgPanel.Height - imgBox.Height);
            }
            return p;
        }
    }
}
