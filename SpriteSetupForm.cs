using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteTester
{
    public partial class SpriteSetupForm : Form
    {
        public SpriteSetupForm()
        {
            InitializeComponent();
            initListViews();
        }

        // ok listen im too lazy to do the same thing 4 times so fuck you im sacrificing the "beauty" of my code
        private void initListViews()
        {
            // array of list views in the form
            ListView[] listViews = { listActionSprites, listIdleSprites, listJumpingSprites, listWalkingSprites };
            for (int i = 0; i < listViews.Length; i++) // iterate over them idfk
            {
                ColumnHeader[] columns = new ColumnHeader[2]; //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                columns[0] = new ColumnHeader();
                columns[0].Text = "Sprite";
                columns[0].Name = "SpriteColumn";
                columns[0].Width = 80;

                columns[1] = new ColumnHeader();
                columns[1].Text = "Direction";
                columns[1].Name = "DirectionColumn";
                columns[1].Width = 80;

                listViews[i].Columns.AddRange(columns); // add those
            }
            // yay we got columns
        }

        private void openPlayground(object sender, EventArgs e)
        {
            PlaygroundForm playground = new PlaygroundForm();

        }
    }
}
