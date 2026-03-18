
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

int MaxExplosion = 10;
int MaxMissiles = 20;

     void Main()
{
    
    Raylib.InitWindow(800, 800, "game");
    SetTargetFPS(60);


        Missile[ ] missiles = new Missile[MaxMissiles];
        Explosion [ ] explosions = new Explosion [MaxExplosion];
        
        for (int i = 0; i < MaxMissiles; i++)missiles[i] = new Missile();
        for (int i = 0; i < MaxExplosion; i++)explosions[i] = new Explosion();
    

    while (!WindowShouldClose())
    {   

        if (Raylib.GetRandomValue(0, 100) < 2)
        {
            foreach ( var m in missiles)
            {
                if (!m.Active)
                {
                    m.Position = new Vector2(Raylib.GetRandomValue(0, 800));
                    m.Speed = Raylib.GetRandomValue(50 , 120);
                    m.Active = true;
                    break;
                }
            }
            
        }

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            foreach (var e in explosions)
            {
                if (!e.Active)
                {
                    e.Posistion = Raylib.GetMousePosition();
                    e.Radius = 5 ;
                    e.Life = 1;
                    e.Active = true;
                    break;
                }
            }
        }
        BeginDrawing();
        ClearBackground(Color.Black);

      
        EndDrawing();



    }










}