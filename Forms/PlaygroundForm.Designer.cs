namespace SpriteTester.Forms;

partial class PlaygroundForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.timer = new System.Windows.Forms.Timer(this.components);
        this.SuspendLayout();
        // 
        // timer
        // 
        this.timer.Tick += new System.EventHandler(this.TimerTick);
        // 
        // PlaygroundForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Name = "PlaygroundForm";
        this.Text = "PlaygroundForm";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlaygroundForm_FormClosing);
        this.Load += new System.EventHandler(this.PlaygroundForm_Load);
        this.SizeChanged += new System.EventHandler(this.SizeChange);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyMove);
        this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StopMove);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Timer timer;
}