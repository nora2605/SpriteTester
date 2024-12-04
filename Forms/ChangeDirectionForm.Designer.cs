
namespace SpriteTester.Forms;

partial class ChangeDirectionForm
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
        this.dropDownDirection = new System.Windows.Forms.ComboBox();
        this.labelDirection = new System.Windows.Forms.Label();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.buttonOK = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // dropDownDirection
        // 
        this.dropDownDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.dropDownDirection.FormattingEnabled = true;
        this.dropDownDirection.Items.AddRange(new object[] {
        "Left",
        "Right",
        "Top",
        "Bottom"});
        this.dropDownDirection.Location = new System.Drawing.Point(12, 29);
        this.dropDownDirection.Name = "dropDownDirection";
        this.dropDownDirection.Size = new System.Drawing.Size(157, 21);
        this.dropDownDirection.TabIndex = 0;
        // 
        // labelDirection
        // 
        this.labelDirection.AutoSize = true;
        this.labelDirection.Location = new System.Drawing.Point(12, 9);
        this.labelDirection.Name = "labelDirection";
        this.labelDirection.Size = new System.Drawing.Size(52, 13);
        this.labelDirection.TabIndex = 1;
        this.labelDirection.Text = "Direction:";
        // 
        // buttonCancel
        // 
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.Location = new System.Drawing.Point(12, 56);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.TabIndex = 2;
        this.buttonCancel.Text = "Cancel";
        this.buttonCancel.UseVisualStyleBackColor = true;
        // 
        // buttonOK
        // 
        this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.buttonOK.Location = new System.Drawing.Point(94, 55);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(75, 23);
        this.buttonOK.TabIndex = 3;
        this.buttonOK.Text = "OK";
        this.buttonOK.UseVisualStyleBackColor = true;
        // 
        // ChangeDirectionForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(196, 92);
        this.Controls.Add(this.buttonOK);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.labelDirection);
        this.Controls.Add(this.dropDownDirection);
        this.Name = "ChangeDirectionForm";
        this.Text = "Change Direction...";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox dropDownDirection;
    private System.Windows.Forms.Label labelDirection;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.Button buttonOK;
}