
using System.Numerics;

public class Missile
{
    public bool Active;
    public float Speed;
    public Vector2 Position;

    //returnerar true om missile når botten och tappar ett hjärta
    public void Updatee(float dt, int ScreenHight)
    {
        if (!Active) return false;
        Position.Y += Speed * dt;
        if (Position.Y > ScreenHight)
        {
            Active = false;
            return true;

        }
        return false;
    }

    public void draw()
    {
        if (Active)
            Raylib_cs.Raylib.DrawCircleV(Position, 4, Raylib_cs.Color.Red);
    }

}
