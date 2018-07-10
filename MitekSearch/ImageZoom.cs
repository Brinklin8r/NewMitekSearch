using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitekSearch {
    public partial class ImageZoom : Form {
        public ImageZoom() {
            InitializeComponent();
        }

        private void ImageZoom_Load(object sender, EventArgs e) {

        }

        private void ImageZoom_DoubleClick(object sender, EventArgs e) {
            BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            Refresh();
        }
    }
}
