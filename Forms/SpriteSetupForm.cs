using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpriteTester.Forms;
using SpriteTester.HelperClasses;

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
                columns[0].Width = 300;

                columns[1] = new ColumnHeader();
                columns[1].Text = "Direction";
                columns[1].Name = "DirectionColumn";
                columns[1].Width = 100;

                listViews[i].Columns.AddRange(columns); // add those
            }
            // yay we got columns
        }

        private void openPlayground(object sender, EventArgs e)
        {
            PlaygroundForm playground = new PlaygroundForm();
            playground.options = new PGOptions(
                GetIdleSprites(), 
                GetWalkingSprites(), 
                GetJumpingSprites(), 
                GetActionSprites(), 
                (int)numSpriteDelay.Value, 
                radioButtonSideView.Checked ? ViewType.Side : ViewType.TopDown
            );
            playground.ShowDialog();
        }

        private void chooseSprites(object sender, EventArgs e)
        {
            DialogResult DR = openFileDialogA.ShowDialog();
            if (DR != DialogResult.OK)
                return;

            List<ListViewItem> itemlist = new List<ListViewItem>();

            foreach (string file in openFileDialogA.FileNames) 
            {
                ListViewItem item = new ListViewItem(file);
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, Enum.GetName(typeof(Direction), Direction.Right));
                item.SubItems.Add(subitem);
                itemlist.Add(item);
            }

            ListViewItem[] items = itemlist.ToArray();

            switch (((Button)sender).Tag)
            {
                case "idle":
                    listIdleSprites.Items.AddRange(items);
                    break;
                case "jump":
                    listJumpingSprites.Items.AddRange(items);
                    break;
                case "walk":
                    listWalkingSprites.Items.AddRange(items);
                    break;
                case "action":
                    listActionSprites.Items.AddRange(items);
                    break;
            }
        }

        private void changeDirection(object sender, EventArgs e)
        {
            ListView caller = itemEditor.SourceControl as ListView;
            ChangeDirectionForm cdf = new ChangeDirectionForm();
            DialogResult DR = cdf.ShowDialog();
            if (DR != DialogResult.OK) return;
            foreach (int i in caller.SelectedIndices)
            {
                caller.Items[i].SubItems[1].Text = Enum.GetName(typeof(Direction), cdf.GetDirection());
            }
        }

        private void showHelpDialog(object sender, EventArgs e)
        {

        }

        #region Boring Get Functions

        private Sprite[] GetIdleSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (ListViewItem lvi in listIdleSprites.Items)
            {
                sprites.Add(
                    new Sprite(
                        Image.FromFile(lvi.Text),
                        (Direction)Enum.Parse(typeof(Direction), lvi.SubItems[1].Text)
                    )
                );
            }
            return sprites.ToArray();
        }

        private Sprite[] GetWalkingSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (ListViewItem lvi in listWalkingSprites.Items)
            {
                sprites.Add(
                    new Sprite(
                        Image.FromFile(lvi.Text),
                        (Direction)Enum.Parse(typeof(Direction), lvi.SubItems[1].Text)
                    )
                );
            }
            return sprites.ToArray();
        }

        private Sprite[] GetJumpingSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (ListViewItem lvi in listJumpingSprites.Items)
            {
                sprites.Add(
                    new Sprite(
                        Image.FromFile(lvi.Text),
                        (Direction)Enum.Parse(typeof(Direction), lvi.SubItems[1].Text)
                    )
                );
            }
            return sprites.ToArray();
        }

        private Sprite[] GetActionSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (ListViewItem lvi in listActionSprites.Items)
            {
                sprites.Add(
                    new Sprite(
                        Image.FromFile(lvi.Text),
                        (Direction)Enum.Parse(typeof(Direction), lvi.SubItems[1].Text)
                    )
                );
            }
            return sprites.ToArray();
        }

        #endregion
    }
}
