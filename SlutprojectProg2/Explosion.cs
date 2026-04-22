
using System.Numerics;

public class Explosion
{
    public bool Active;

    public float Life;

    public Vector2 Position;

    public float Radius;

    public void Update(float dt)
    {

        if (!Active) return;

        Radius += 100 * dt;
        Life -= dt;
        if (Life <= 0)
            Active = false;
    }
    public void Draw()
    {
        if (Active)
        {
            Raylib_cs.Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, Radius, Raylib_cs.Color.Orange);
        }
    }
}
