using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteTester.HelperClasses;

namespace SpriteTester.Forms
{
    public partial class PlaygroundForm : Form
    {
        public PGOptions options;

        public PlaygroundForm()
        {
            InitializeComponent();
            options = new PGOptions();
        }

        private void PlaygroundForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
