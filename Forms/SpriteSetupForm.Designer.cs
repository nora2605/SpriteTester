
namespace SpriteTester.Forms;

partial class SpriteSetupForm
{
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.listIdleSprites = new System.Windows.Forms.ListView();
        this.itemEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
        this.MIChangeDirection = new System.Windows.Forms.ToolStripMenuItem();
        this.labelIdleSprites = new System.Windows.Forms.Label();
        this.buttonOpenIdleSprites = new System.Windows.Forms.Button();
        this.buttonOpenJumpingSprites = new System.Windows.Forms.Button();
        this.labelJumpingSprites = new System.Windows.Forms.Label();
        this.listJumpingSprites = new System.Windows.Forms.ListView();
        this.buttonOpenWalkingSprites = new System.Windows.Forms.Button();
        this.labelWalkingSprites = new System.Windows.Forms.Label();
        this.listWalkingSprites = new System.Windows.Forms.ListView();
        this.buttonOpenActionSprites = new System.Windows.Forms.Button();
        this.labelActionSprites = new System.Windows.Forms.Label();
        this.listActionSprites = new System.Windows.Forms.ListView();
        this.buttonOpenPlayground = new System.Windows.Forms.Button();
        this.buttonHelp = new System.Windows.Forms.Button();
        this.radioButtonTopDownView = new System.Windows.Forms.RadioButton();
        this.radioButtonSideView = new System.Windows.Forms.RadioButton();
        this.openFileDialogA = new System.Windows.Forms.OpenFileDialog();
        this.numSpriteDelay = new System.Windows.Forms.NumericUpDown();
        this.labelSpriteDelay = new System.Windows.Forms.Label();
        this.buttonChangeBackground = new System.Windows.Forms.Button();
        this.buttonSave = new System.Windows.Forms.Button();
        this.buttonLoad = new System.Windows.Forms.Button();
        this.saveFileDialogConf = new System.Windows.Forms.SaveFileDialog();
        this.openFileDialogConf = new System.Windows.Forms.OpenFileDialog();
        this.itemEditor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numSpriteDelay)).BeginInit();
        this.SuspendLayout();
        // 
        // listIdleSprites
        // 
        this.listIdleSprites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.listIdleSprites.ContextMenuStrip = this.itemEditor;
        this.listIdleSprites.GridLines = true;
        this.listIdleSprites.HideSelection = false;
        this.listIdleSprites.Location = new System.Drawing.Point(12, 29);
        this.listIdleSprites.Name = "listIdleSprites";
        this.listIdleSprites.Size = new System.Drawing.Size(414, 150);
        this.listIdleSprites.TabIndex = 0;
        this.listIdleSprites.UseCompatibleStateImageBehavior = false;
        this.listIdleSprites.View = System.Windows.Forms.View.Details;
        // 
        // itemEditor
        // 
        this.itemEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.MIChangeDirection});
        this.itemEditor.Name = "itemEditor";
        this.itemEditor.Size = new System.Drawing.Size(176, 26);
        // 
        // MIChangeDirection
        // 
        this.MIChangeDirection.Name = "MIChangeDirection";
        this.MIChangeDirection.Size = new System.Drawing.Size(175, 22);
        this.MIChangeDirection.Text = "Change Direction...";
        this.MIChangeDirection.Click += new System.EventHandler(this.ChangeDirection);
        // 
        // labelIdleSprites
        // 
        this.labelIdleSprites.AutoSize = true;
        this.labelIdleSprites.Location = new System.Drawing.Point(9, 13);
        this.labelIdleSprites.Name = "labelIdleSprites";
        this.labelIdleSprites.Size = new System.Drawing.Size(62, 13);
        this.labelIdleSprites.TabIndex = 1;
        this.labelIdleSprites.Text = "Idle Sprites:";
        // 
        // buttonOpenIdleSprites
        // 
        this.buttonOpenIdleSprites.Location = new System.Drawing.Point(100, 9);
        this.buttonOpenIdleSprites.Name = "buttonOpenIdleSprites";
        this.buttonOpenIdleSprites.Size = new System.Drawing.Size(75, 20);
        this.buttonOpenIdleSprites.TabIndex = 2;
        this.buttonOpenIdleSprites.Tag = "idle";
        this.buttonOpenIdleSprites.Text = "Choose...";
        this.buttonOpenIdleSprites.UseVisualStyleBackColor = true;
        this.buttonOpenIdleSprites.Click += new System.EventHandler(this.chooseSprites);
        // 
        // buttonOpenJumpingSprites
        // 
        this.buttonOpenJumpingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOpenJumpingSprites.Location = new System.Drawing.Point(771, 9);
        this.buttonOpenJumpingSprites.Name = "buttonOpenJumpingSprites";
        this.buttonOpenJumpingSprites.Size = new System.Drawing.Size(75, 20);
        this.buttonOpenJumpingSprites.TabIndex = 5;
        this.buttonOpenJumpingSprites.Tag = "jump";
        this.buttonOpenJumpingSprites.Text = "Choose...";
        this.buttonOpenJumpingSprites.UseVisualStyleBackColor = true;
        this.buttonOpenJumpingSprites.Click += new System.EventHandler(this.chooseSprites);
        // 
        // labelJumpingSprites
        // 
        this.labelJumpingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.labelJumpingSprites.AutoSize = true;
        this.labelJumpingSprites.Location = new System.Drawing.Point(680, 13);
        this.labelJumpingSprites.Name = "labelJumpingSprites";
        this.labelJumpingSprites.Size = new System.Drawing.Size(84, 13);
        this.labelJumpingSprites.TabIndex = 4;
        this.labelJumpingSprites.Text = "Jumping Sprites:";
        // 
        // listJumpingSprites
        // 
        this.listJumpingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.listJumpingSprites.ContextMenuStrip = this.itemEditor;
        this.listJumpingSprites.GridLines = true;
        this.listJumpingSprites.HideSelection = false;
        this.listJumpingSprites.Location = new System.Drawing.Point(432, 29);
        this.listJumpingSprites.Name = "listJumpingSprites";
        this.listJumpingSprites.Size = new System.Drawing.Size(414, 150);
        this.listJumpingSprites.TabIndex = 3;
        this.listJumpingSprites.UseCompatibleStateImageBehavior = false;
        this.listJumpingSprites.View = System.Windows.Forms.View.Details;
        // 
        // buttonOpenWalkingSprites
        // 
        this.buttonOpenWalkingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonOpenWalkingSprites.Location = new System.Drawing.Point(100, 185);
        this.buttonOpenWalkingSprites.Name = "buttonOpenWalkingSprites";
        this.buttonOpenWalkingSprites.Size = new System.Drawing.Size(75, 20);
        this.buttonOpenWalkingSprites.TabIndex = 8;
        this.buttonOpenWalkingSprites.Tag = "walk";
        this.buttonOpenWalkingSprites.Text = "Choose...";
        this.buttonOpenWalkingSprites.UseVisualStyleBackColor = true;
        this.buttonOpenWalkingSprites.Click += new System.EventHandler(this.chooseSprites);
        // 
        // labelWalkingSprites
        // 
        this.labelWalkingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.labelWalkingSprites.AutoSize = true;
        this.labelWalkingSprites.Location = new System.Drawing.Point(9, 189);
        this.labelWalkingSprites.Name = "labelWalkingSprites";
        this.labelWalkingSprites.Size = new System.Drawing.Size(84, 13);
        this.labelWalkingSprites.TabIndex = 7;
        this.labelWalkingSprites.Text = "Walking Sprites:";
        // 
        // listWalkingSprites
        // 
        this.listWalkingSprites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.listWalkingSprites.ContextMenuStrip = this.itemEditor;
        this.listWalkingSprites.GridLines = true;
        this.listWalkingSprites.HideSelection = false;
        this.listWalkingSprites.Location = new System.Drawing.Point(12, 205);
        this.listWalkingSprites.Name = "listWalkingSprites";
        this.listWalkingSprites.Size = new System.Drawing.Size(414, 150);
        this.listWalkingSprites.TabIndex = 6;
        this.listWalkingSprites.UseCompatibleStateImageBehavior = false;
        this.listWalkingSprites.View = System.Windows.Forms.View.Details;
        // 
        // buttonOpenActionSprites
        // 
        this.buttonOpenActionSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOpenActionSprites.Location = new System.Drawing.Point(771, 185);
        this.buttonOpenActionSprites.Name = "buttonOpenActionSprites";
        this.buttonOpenActionSprites.Size = new System.Drawing.Size(75, 20);
        this.buttonOpenActionSprites.TabIndex = 11;
        this.buttonOpenActionSprites.Text = "Choose...";
        this.buttonOpenActionSprites.UseVisualStyleBackColor = true;
        this.buttonOpenActionSprites.Click += new System.EventHandler(this.chooseSprites);
        // 
        // labelActionSprites
        // 
        this.labelActionSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.labelActionSprites.AutoSize = true;
        this.labelActionSprites.Location = new System.Drawing.Point(680, 189);
        this.labelActionSprites.Name = "labelActionSprites";
        this.labelActionSprites.Size = new System.Drawing.Size(75, 13);
        this.labelActionSprites.TabIndex = 10;
        this.labelActionSprites.Tag = "action";
        this.labelActionSprites.Text = "Action Sprites:";
        // 
        // listActionSprites
        // 
        this.listActionSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.listActionSprites.ContextMenuStrip = this.itemEditor;
        this.listActionSprites.GridLines = true;
        this.listActionSprites.HideSelection = false;
        this.listActionSprites.Location = new System.Drawing.Point(432, 205);
        this.listActionSprites.Name = "listActionSprites";
        this.listActionSprites.Size = new System.Drawing.Size(414, 150);
        this.listActionSprites.TabIndex = 9;
        this.listActionSprites.UseCompatibleStateImageBehavior = false;
        this.listActionSprites.View = System.Windows.Forms.View.Details;
        // 
        // buttonOpenPlayground
        // 
        this.buttonOpenPlayground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonOpenPlayground.Location = new System.Drawing.Point(733, 462);
        this.buttonOpenPlayground.Name = "buttonOpenPlayground";
        this.buttonOpenPlayground.Size = new System.Drawing.Size(112, 23);
        this.buttonOpenPlayground.TabIndex = 12;
        this.buttonOpenPlayground.Text = "Open Playground";
        this.buttonOpenPlayground.UseVisualStyleBackColor = true;
        this.buttonOpenPlayground.Click += new System.EventHandler(this.OpenPlayground);
        // 
        // buttonHelp
        // 
        this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonHelp.Location = new System.Drawing.Point(13, 461);
        this.buttonHelp.Name = "buttonHelp";
        this.buttonHelp.Size = new System.Drawing.Size(75, 23);
        this.buttonHelp.TabIndex = 13;
        this.buttonHelp.Text = "Help";
        this.buttonHelp.UseVisualStyleBackColor = true;
        this.buttonHelp.Click += new System.EventHandler(this.ShowHelpDialog);
        // 
        // radioButtonTopDownView
        // 
        this.radioButtonTopDownView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.radioButtonTopDownView.AutoSize = true;
        this.radioButtonTopDownView.Location = new System.Drawing.Point(13, 436);
        this.radioButtonTopDownView.Name = "radioButtonTopDownView";
        this.radioButtonTopDownView.Size = new System.Drawing.Size(101, 17);
        this.radioButtonTopDownView.TabIndex = 14;
        this.radioButtonTopDownView.TabStop = true;
        this.radioButtonTopDownView.Text = "Top Down View";
        this.radioButtonTopDownView.UseVisualStyleBackColor = true;
        // 
        // radioButtonSideView
        // 
        this.radioButtonSideView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.radioButtonSideView.AutoSize = true;
        this.radioButtonSideView.Checked = true;
        this.radioButtonSideView.Location = new System.Drawing.Point(13, 415);
        this.radioButtonSideView.Name = "radioButtonSideView";
        this.radioButtonSideView.Size = new System.Drawing.Size(72, 17);
        this.radioButtonSideView.TabIndex = 15;
        this.radioButtonSideView.TabStop = true;
        this.radioButtonSideView.Text = "Side View";
        this.radioButtonSideView.UseVisualStyleBackColor = true;
        // 
        // openFileDialogA
        // 
        this.openFileDialogA.Filter = "Image Files|*.png; *.jpg; *.bmp";
        this.openFileDialogA.Multiselect = true;
        this.openFileDialogA.Title = "Choose Sprites...";
        // 
        // numSpriteDelay
        // 
        this.numSpriteDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.numSpriteDelay.Location = new System.Drawing.Point(725, 436);
        this.numSpriteDelay.Name = "numSpriteDelay";
        this.numSpriteDelay.Size = new System.Drawing.Size(120, 20);
        this.numSpriteDelay.TabIndex = 16;
        this.numSpriteDelay.Value = new decimal(new int[] {
        50,
        0,
        0,
        0});
        // 
        // labelSpriteDelay
        // 
        this.labelSpriteDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.labelSpriteDelay.AutoSize = true;
        this.labelSpriteDelay.Location = new System.Drawing.Point(725, 417);
        this.labelSpriteDelay.Name = "labelSpriteDelay";
        this.labelSpriteDelay.Size = new System.Drawing.Size(89, 13);
        this.labelSpriteDelay.TabIndex = 17;
        this.labelSpriteDelay.Text = "Sprite Delay (ms):";
        // 
        // buttonChangeBackground
        // 
        this.buttonChangeBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.buttonChangeBackground.Location = new System.Drawing.Point(12, 386);
        this.buttonChangeBackground.Name = "buttonChangeBackground";
        this.buttonChangeBackground.Size = new System.Drawing.Size(141, 23);
        this.buttonChangeBackground.TabIndex = 18;
        this.buttonChangeBackground.Text = "Change Background...";
        this.buttonChangeBackground.UseVisualStyleBackColor = true;
        this.buttonChangeBackground.Click += new System.EventHandler(this.OpenBackground);
        // 
        // buttonSave
        // 
        this.buttonSave.Location = new System.Drawing.Point(690, 361);
        this.buttonSave.Name = "buttonSave";
        this.buttonSave.Size = new System.Drawing.Size(75, 23);
        this.buttonSave.TabIndex = 19;
        this.buttonSave.Text = "Save...";
        this.buttonSave.UseVisualStyleBackColor = true;
        this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
        // 
        // buttonLoad
        // 
        this.buttonLoad.Location = new System.Drawing.Point(771, 361);
        this.buttonLoad.Name = "buttonLoad";
        this.buttonLoad.Size = new System.Drawing.Size(75, 23);
        this.buttonLoad.TabIndex = 20;
        this.buttonLoad.Text = "Load...";
        this.buttonLoad.UseVisualStyleBackColor = true;
        this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
        // 
        // saveFileDialogConf
        // 
        this.saveFileDialogConf.Filter = "Config Files|*.conf";
        this.saveFileDialogConf.Title = "Save Configuration...";
        // 
        // openFileDialogConf
        // 
        this.openFileDialogConf.Filter = "Config Files|*.conf";
        this.openFileDialogConf.Title = "Load Configuarion...";
        // 
        // SpriteSetupForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(857, 497);
        this.Controls.Add(this.buttonLoad);
        this.Controls.Add(this.buttonSave);
        this.Controls.Add(this.buttonChangeBackground);
        this.Controls.Add(this.labelSpriteDelay);
        this.Controls.Add(this.numSpriteDelay);
        this.Controls.Add(this.radioButtonSideView);
        this.Controls.Add(this.radioButtonTopDownView);
        this.Controls.Add(this.buttonHelp);
        this.Controls.Add(this.buttonOpenPlayground);
        this.Controls.Add(this.buttonOpenActionSprites);
        this.Controls.Add(this.labelActionSprites);
        this.Controls.Add(this.listActionSprites);
        this.Controls.Add(this.buttonOpenWalkingSprites);
        this.Controls.Add(this.labelWalkingSprites);
        this.Controls.Add(this.listWalkingSprites);
        this.Controls.Add(this.buttonOpenJumpingSprites);
        this.Controls.Add(this.labelJumpingSprites);
        this.Controls.Add(this.listJumpingSprites);
        this.Controls.Add(this.buttonOpenIdleSprites);
        this.Controls.Add(this.labelIdleSprites);
        this.Controls.Add(this.listIdleSprites);
        this.MinimumSize = new System.Drawing.Size(600, 500);
        this.Name = "SpriteSetupForm";
        this.Text = "Sprite Tester";
        this.itemEditor.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.numSpriteDelay)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ListView listIdleSprites;
    private System.Windows.Forms.Label labelIdleSprites;
    private System.Windows.Forms.Button buttonOpenIdleSprites;
    private System.Windows.Forms.Button buttonOpenJumpingSprites;
    private System.Windows.Forms.Label labelJumpingSprites;
    private System.Windows.Forms.ListView listJumpingSprites;
    private System.Windows.Forms.Button buttonOpenWalkingSprites;
    private System.Windows.Forms.Label labelWalkingSprites;
    private System.Windows.Forms.ListView listWalkingSprites;
    private System.Windows.Forms.Button buttonOpenActionSprites;
    private System.Windows.Forms.Label labelActionSprites;
    private System.Windows.Forms.ListView listActionSprites;
    private System.Windows.Forms.Button buttonOpenPlayground;
    private System.Windows.Forms.Button buttonHelp;
    private System.Windows.Forms.RadioButton radioButtonTopDownView;
    private System.Windows.Forms.RadioButton radioButtonSideView;
    private System.Windows.Forms.OpenFileDialog openFileDialogA;
    private System.Windows.Forms.NumericUpDown numSpriteDelay;
    private System.Windows.Forms.Label labelSpriteDelay;
    private System.Windows.Forms.ContextMenuStrip itemEditor;
    private System.Windows.Forms.ToolStripMenuItem MIChangeDirection;
    private System.Windows.Forms.Button buttonChangeBackground;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.SaveFileDialog saveFileDialogConf;
    private System.Windows.Forms.OpenFileDialog openFileDialogConf;
}

