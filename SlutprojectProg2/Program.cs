
using Raylib_cs;
using static Raylib_cs.Raylib;

int MaxExplosion = 10;
int MaxMissiles = 20;

    static void Main()
{
    
    Raylib.InitWindow(800, 800, "game");
    SetTargetFPS(60);


        Missile[ ] missiles = new Missile[MaxMissiles];
        Explosion [ ] explosions = new Explosion [MaxExplosion];
        

    while (!WindowShouldClose())
    {   
        BeginDrawing();
        ClearBackground(Color.Black);







      
        EndDrawing();



    }










}