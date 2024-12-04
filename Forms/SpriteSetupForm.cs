using SpriteTester.HelperClasses;
using System.Text.RegularExpressions;

namespace SpriteTester.Forms;
public partial class SpriteSetupForm : Form
{
    private Image? backgroundImage;

    ListView[] listViews;

    public SpriteSetupForm()
    {
        InitializeComponent();
        listViews = InitListViews();
    }

    // ok listen im too lazy to do the same thing 4 times
    private ListView[] InitListViews()
    {
        // array of list views in the form
        ListView[] lv = [listActionSprites, listIdleSprites, listJumpingSprites, listWalkingSprites];
        for (int i = 0; i < lv.Length; i++) // iterate over them
        {
            ColumnHeader[] columns =
            [
                new()
                {
                    Text = "Sprite",
                    Name = "SpriteColumn",
                    Width = 300
                },
                new()
                {
                    Text = "Direction",
                    Name = "DirectionColumn",
                    Width = 100
                },
                new()
                {
                    Text = "Path",
                    Name = "PathColumn",
                    Width = 100
                },
            ];

            lv[i].Columns.AddRange(columns); // add those
        }
        // yay we got columns
        return lv;
    }

    private void OpenPlayground(object sender, EventArgs e)
    {
        PlaygroundForm playground = new(new PGOptions(
            GetSprites(listIdleSprites),
            GetSprites(listWalkingSprites),
            GetSprites(listJumpingSprites),
            GetSprites(listActionSprites),
            (int)numSpriteDelay.Value,
            radioButtonSideView.Checked ? ViewType.Side : ViewType.TopDown,
            backgroundImage
        ));
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
                        ListViewItem item = new(sitems[0]);
                        ListViewItem.ListViewSubItem subdirection = new(item, sitems[1]);
                        ListViewItem.ListViewSubItem subpath = new(item, sitems[2]);
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

    private void ChangeDirection(object sender, EventArgs e)
    {
        ListView? caller = itemEditor.SourceControl as ListView;
        if (caller == null) return;
        ChangeDirectionForm cdf = new ChangeDirectionForm();
        DialogResult DR = cdf.ShowDialog();
        if (DR != DialogResult.OK) return;
        foreach (int i in caller.SelectedIndices)
            caller.Items[i].SubItems[1].Text = Enum.GetName(cdf.GetDirection());
    }

    private void ShowHelpDialog(object sender, EventArgs e)
    {
        MessageBox.Show("not implemented yet");
    }

    private Sprite[] GetSprites(ListView lv)
    {
        return lv.Items.Cast<ListViewItem>()
            .Select(i => new Sprite(
                Image.FromFile(i.SubItems[2].Text),
                Enum.Parse<Direction>(i.SubItems[1].Text)
            ))
            .ToArray();
    }

    private void OpenBackground(object sender, EventArgs e)
    {
        DialogResult DR = openFileDialogA.ShowDialog();
        if (DR != DialogResult.OK)
            return;

        backgroundImage = Image.FromFile(openFileDialogA.FileName);
    }
}