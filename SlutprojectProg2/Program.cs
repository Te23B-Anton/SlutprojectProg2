
using Raylib_cs;
using static Raylib_cs.Raylib;


    Raylib.InitWindow(800, 800, "game");
    SetTargetFPS(60);


    while (!WindowShouldClose())
    {   
        
        BeginDrawing();
        ClearBackground(Color.Black);
        DrawText("hej",200,200,200,Color.White);

        DrawCircle(475,225,20,Color.White);
        EndDrawing();

    }









