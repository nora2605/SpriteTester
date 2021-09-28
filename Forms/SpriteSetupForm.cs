using SpriteTester.Forms;
using SpriteTester.HelperClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SpriteTester
{
    public partial class SpriteSetupForm : Form
    {
        private Image backgroundImage;

        ListView[] listViews;

        public SpriteSetupForm()
        {
            InitializeComponent();
            initListViews();
        }

        // ok listen im too lazy to do the same thing 4 times
        private void initListViews()
        {
            // array of list views in the form
            listViews = new ListView[] { listActionSprites, listIdleSprites, listJumpingSprites, listWalkingSprites };
            for (int i = 0; i < listViews.Length; i++) // iterate over them
            {
                ColumnHeader[] columns = new ColumnHeader[3]; //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
                columns[0] = new ColumnHeader();
                columns[0].Text = "Sprite";
                columns[0].Name = "SpriteColumn";
                columns[0].Width = 300;

                columns[1] = new ColumnHeader();
                columns[1].Text = "Direction";
                columns[1].Name = "DirectionColumn";
                columns[1].Width = 100;

                columns[2] = new ColumnHeader();
                columns[2].Text = "Path";
                columns[2].Name = "PathColumn";
                columns[2].Width = 100;

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
                radioButtonSideView.Checked ? ViewType.Side : ViewType.TopDown,
                backgroundImage
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
                Regex regex = new Regex(@"[^\\]+$");
                ListViewItem item = new ListViewItem(regex.Match(file).Value);
                ListViewItem.ListViewSubItem subdirection = new ListViewItem.ListViewSubItem(item, Enum.GetName(typeof(Direction), Direction.Right));
                ListViewItem.ListViewSubItem subpath = new ListViewItem.ListViewSubItem(item, file);
                item.SubItems.Add(subdirection);
                item.SubItems.Add(subpath);
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

        #region Config

        private string GetConfig()
        {
            /*
             * Output format:
             * List {
             *     file.png;Left;C:\path\to\file.png
             * }
             */

            string config = "";
            for (int i = 0; i < listViews.Length; i++)
            {
                if (listViews[i].Items.Count == 0) continue;
                config += $"{listViews[i].Name}{{\n";
                foreach (ListViewItem t in listViews[i].Items)
                {
                    config += $"\t{t.Text};{t.SubItems[1].Text};{t.SubItems[2].Text}\n";
                }
                config += $"}}\n";
            }
            return config;
        }

        private void SetConfig(string config)
        {
            /*
             * Input format:
             * List {
             *     file.png;Left;C:\path\to\file.png
             * }
             */
            string[] listConfigs = config.Split('{', '}');
            /*
             * [List,
             *     file.png;Left;C:\path\to\file.png]
             */
            string curList = "";
            foreach (string s in listConfigs)
            {
                if (curList == "") // "List  "
                {
                    curList = s.Trim(); // "List"
                    continue;
                }
                for (int i = 0; i < listViews.Length; i++)
                {
                    if (listViews[i].Name == curList)
                    {
                        foreach (string l in s.Split('\n')) // For every item in the original list
                        {
                            if (string.IsNullOrEmpty(l)) continue;
                            string[] sitems = l.Trim().Split(';');
                            ListViewItem item = new ListViewItem(sitems[0]);
                            ListViewItem.ListViewSubItem subdirection = new ListViewItem.ListViewSubItem(item, sitems[1]);
                            ListViewItem.ListViewSubItem subpath = new ListViewItem.ListViewSubItem(item, sitems[2]);
                            item.SubItems.Add(subdirection);
                            item.SubItems.Add(subpath);
                            listViews[i].Items.Add(item);
                        }
                        break;
                    }
                }
                curList = "";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string config = GetConfig();
            if (string.IsNullOrEmpty(config))
            {
                MessageBox.Show("Nothing to Save!");
                return;
            }
            DialogResult DR = saveFileDialogConf.ShowDialog();
            if (DR != DialogResult.OK) return;
            System.IO.File.WriteAllText(saveFileDialogConf.FileName, config);
            MessageBox.Show("Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            DialogResult DR = openFileDialogConf.ShowDialog();
            if (DR != DialogResult.OK) return;
            string config = System.IO.File.ReadAllText(openFileDialogConf.FileName);
            if (string.IsNullOrEmpty(config))
            {
                MessageBox.Show("Failed to load! (Empty File?)");
                return;
            }
            SetConfig(config);
            MessageBox.Show("Loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

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
            MessageBox.Show("not implemented yet");
        }

        #region Get Functions

        private Sprite[] GetIdleSprites()
        {
            List<Sprite> sprites = new List<Sprite>();
            foreach (ListViewItem lvi in listIdleSprites.Items)
            {
                sprites.Add(
                    new Sprite(
                        Image.FromFile(lvi.SubItems[2].Text),
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
                        Image.FromFile(lvi.SubItems[2].Text),
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
                        Image.FromFile(lvi.SubItems[2].Text),
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
                        Image.FromFile(lvi.SubItems[2].Text),
                        (Direction)Enum.Parse(typeof(Direction), lvi.SubItems[1].Text)
                    )
                );
            }
            return sprites.ToArray();
        }

        #endregion

        private void openBackground(object sender, EventArgs e)
        {
            DialogResult DR = openFileDialogA.ShowDialog();
            if (DR != DialogResult.OK)
                return;

            backgroundImage = Image.FromFile(openFileDialogA.FileName);
        }


    }
}