using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpriteTester.Forms
{
    public partial class ChangeDirectionForm : Form
    {
        public Direction GetDirection()
        {
            switch (this.dropDownDirection.Text)
            {
                case "Left":
                    return Direction.Left;
                case "Right":
                    return Direction.Right;
                case "Top":
                    return Direction.Top;
                case "Bottom":
                    return Direction.Bottom;
                default:
                    return Direction.Right;
            }
        }

        public ChangeDirectionForm()
        {
            InitializeComponent();

            this.CancelButton = buttonCancel;
            this.AcceptButton = buttonOK;

            this.dropDownDirection.SelectedIndex = 0;
        }
    }
}
