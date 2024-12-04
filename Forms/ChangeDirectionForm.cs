using SpriteTester.HelperClasses;

namespace SpriteTester.Forms;

public partial class ChangeDirectionForm : Form
{
    public Direction GetDirection()
    {
        switch (dropDownDirection.Text)
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

        CancelButton = buttonCancel;
        AcceptButton = buttonOK;

        dropDownDirection.SelectedIndex = 0;
    }
}
