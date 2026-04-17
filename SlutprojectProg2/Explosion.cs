
using System.Numerics;

public class Explosion
{
    public bool Active;

    public float Life;

    public Vector2 Posistion;

    public float Radius;

    public void Update(float dt)
    {

        if (!Active) return;

        Radius += 100 * dt;
        Life -= dt;
        if (Life <= 0)
            Active = false;
    }
    public void draw()
    {
        if (Active)
        {
            Raylib_cs.Raylib.DrawCircleLines((int)Posistion.X, (int)Posistion.Y, Radius, Raylib_cs.Color.Orange);
        }
    }
}
