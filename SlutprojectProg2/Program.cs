
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

int ScreenHight = 800;
int ScreenWidth = 800;
int MaxExplosion = 5;
int MaxMissiles = 20;
int Hearts = 3;


{
    int score = 0;

    Raylib.InitWindow(ScreenWidth, ScreenHight, "Missile Command");
    SetTargetFPS(60);


    Missile[] missiles = new Missile[MaxMissiles];
    Explosion[] explosions = new Explosion[MaxExplosion];

    for (int i = 0; i < MaxMissiles; i++) missiles[i] = new Missile();
    for (int i = 0; i < MaxExplosion; i++) explosions[i] = new Explosion();


    while (!WindowShouldClose())
    {
        // random missiler
        if (Raylib.GetRandomValue(0, 100) < 5)
        {
            foreach (var m in missiles)
            {
                if (!m.Active)
                {
                    m.Position = new Vector2(Raylib.GetRandomValue(0, ScreenWidth), 0);
                    m.Speed = Raylib.GetRandomValue(50, 120);
                    m.Active = true;
                    break;
                }
            }

        }

        // placera explosioner
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            foreach (var e in explosions)
            {
                if (!e.Active)
                {
                    e.Posistion = Raylib.GetMousePosition();
                    e.Radius = 5;
                    e.Life = 0.5f;
                    e.Active = true;
                    break;
                }
            }
        }

        float dt = Raylib.GetFrameTime();

        //updatera missilerna
        foreach (var m in missiles)
        {
            if (!m.Active) continue;

            m.Position.Y += m.Speed * dt;
            if (m.Position.Y > ScreenHight)
            {             
                      m.Active = false;

                      Hearts = Math.Max(0,Hearts - 1);

            }

        }

        // updatera explosionerna
        foreach (var e in explosions)
        {
            if (!e.Active) continue;

            e.Radius += 100 * dt;
            e.Life -= dt;
            if (e.Life <= 0)
                e.Active = false;

        }

        // collisoner 
        foreach (var m in missiles)
        {


            if (!m.Active) continue;

            foreach (var e in explosions)
            {

                if (!e.Active) continue;

                if (Vector2.Distance(m.Position, e.Posistion) < e.Radius)
                {

                    m.Active = false;
                    score += 10;
                    break;
                }

            }
        }





        //vad den ska rita ut
        BeginDrawing();
        ClearBackground(Color.Black);

        foreach (var m in missiles)
            if (m.Active)
                Raylib.DrawCircleV(m.Position, 4, Color.Red);

        foreach (var e in explosions)
            if (e.Active)
                Raylib.DrawCircleLines((int)e.Posistion.X, (int)e.Posistion.Y, e.Radius, Color.Orange);

                DrawText($"Hearts: {Hearts}", 10 , 20 , 25 , Color.White);
                DrawText($"score: {score}" , 10 , 40 , 25 , Color.White);

                if (Hearts <= 0)
                {
                    break;
                }

        EndDrawing();



    }

    CloseWindow();
}