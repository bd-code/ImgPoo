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
        private bool _imgChanged;

        public Form1() {
            _imagefiles = new List<string>();
            _dirIndex = 0;

            _zoomLevel = 1;
            _imgChanged = false;

            InitializeComponent();
            CustomizeComponent();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
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

            zoomStatusLabel.Text = "Zoom: " + _zoomLevel.ToString();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName)) {
                string path = Path.GetDirectoryName(openFileDialog1.FileName);
                openFileDialog1.InitialDirectory = path;
                getFiles(path);

                if (isValidImage(openFileDialog1.FileName)) {
                    _dirIndex = _imagefiles.IndexOf(openFileDialog1.FileName);
                    changeImage(openFileDialog1.FileName);
                }

            }
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            if (Directory.Exists(folderBrowserDialog1.SelectedPath)) {
                getFiles(folderBrowserDialog1.SelectedPath);

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

            if (_imgChanged) {
                resetImgBox();
                _imgChanged = false;
            }

            if (_img is Bitmap) {
                Rectangle rect = new Rectangle(
                    0,
                    0,
                    imgBox.Width,
                    imgBox.Height);
                e.Graphics.DrawImage(_img, rect);

                menuBar.BringToFront();
            }
        }

        private void Form1_Resize(object sender, EventArgs e) {
            resetImgBox();
            imgBox.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up) {
                zoomIn();
            }
            else if (e.KeyCode == Keys.Down) {
                zoomOut();
            }
            else if (e.KeyCode == Keys.Right) {
                nextImage();
            }
            else if (e.KeyCode == Keys.Left) {
                prevImage();
            }
        }

        private void Form1_MouseWheel(object sender, MouseEventArgs e) {
            /* 
            We're not doing zoom on scroll anymore.
            Should use scrollbar instead.
            if (e.Delta > 0)
                zoomIn();
            else if (e.Delta < 0)
                zoomOut();*/
        }

        //*////////////////////////////////////////////////////////////////////

        private void getFiles(string dir) {
            var exts = new List<string> {
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
            filePathStatusLabel.Text = filename;
            sizeStatusLabel.Text = "Size: " + _img.Width + " x " + _img.Height + "";
            _zoomLevel = 1;
            zoomStatusLabel.Text = "Zoom: " + _zoomLevel.ToString();
            _imgChanged = true;
            imgBox.Refresh();
        }

        private bool isValidImage(string filename) {
            try {
                Image.FromFile(filename);
            }
            catch (OutOfMemoryException ex) {
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
            _zoomLevel = (_zoomLevel < 8) ? _zoomLevel+1 : _zoomLevel;
            zoomStatusLabel.Text = "Zoom: " + _zoomLevel.ToString();
            resetImgBox();
            imgBox.Refresh();
        }

        private void zoomOut() {
            _zoomLevel = (_zoomLevel > 1) ? _zoomLevel-1 : _zoomLevel;
            zoomStatusLabel.Text = "Zoom: " + _zoomLevel.ToString();
            resetImgBox();
            imgBox.Refresh();
        }

        private void zoomReset() {
            _zoomLevel = 1;
            zoomStatusLabel.Text = "Zoom: " + _zoomLevel.ToString();
            resetImgBox();
            imgBox.Refresh();
        }

        private void resetImgBox() {
            if (_img is Bitmap) {
                int imgWidth = _img.Width * _zoomLevel;
                int imgHeight = _img.Height * _zoomLevel;
                imgBox.Width = imgWidth;
                imgBox.Height = imgHeight;

                imgBox.Location = new Point(
                    Math.Max((Width - imgWidth) / 2, 0),
                    Math.Max((Height - imgHeight) / 2, 0 + menuBar.Size.Height)
                    );
            }
        }

        private void changeBGColorToolStripMenuItem_Click(object sender, EventArgs e) {
            colorDialog1.ShowDialog();
            imgPanel.BackColor = colorDialog1.Color;
        }
    }
}
