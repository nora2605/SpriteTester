namespace SpriteTester.HelperClasses;

public class Character
{
    public int posX, posY;
    public Direction facing;
    public ActionType actiontype;

    public Character() { }
    public Character(int posX, int posY)
    {
        this.posX = posX;
        this.posY = posY;
    }
}