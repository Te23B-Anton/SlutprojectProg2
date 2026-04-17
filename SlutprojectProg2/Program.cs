
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

int ScreenHight = 800;
int ScreenWidth = 800;
int MaxExplosion = 5;
int MaxMissiles = 20;
int Hearts = 3;

bool gameover = false;

while (!WindowShouldClose() && !gameover)
{

    int score = 0;

    Raylib.InitWindow(ScreenWidth, ScreenHight, "Missile Command");
    SetTargetFPS(60);


    List<Missile> missiles = new List<Missile>();
    List<Explosion> explosions = new List<Explosion>();

    for (int i = 0; i < MaxMissiles; i++) missiles.Add(new Missile());
    for (int i = 0; i < MaxExplosion; i++) explosions.Add(new Explosion());


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
            if (m.Updatee(dt, ScreenHight))
                Hearts = Math.Max(0, Hearts - 1);
            
        

        // updatera explosionerna
        foreach (var e in explosions)
        {
            e.Update(dt);

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


    if (Hearts <= 0)
    {
        gameover = true;
    }



        //vad den ska rita ut
        BeginDrawing();
        ClearBackground(Color.Black);

        foreach (var m in missiles) m.draw();
        foreach (var e in explosions) e.draw();

        DrawText($"Hearts: {Hearts}", 10, 20, 25, Color.White);
        DrawText($"score: {score}", 10, 40, 25, Color.White);

        if (gameover)
        {
            DrawText("Game Over!", ScreenWidth / 2 - 100, ScreenHight / 2, 40, Color.Red);
        }

        EndDrawing();



    }

    CloseWindow();
}