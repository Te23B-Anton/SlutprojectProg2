
using Raylib_cs;
using static Raylib_cs.Raylib;


    Raylib.InitWindow(800, 800, "game");
    SetTargetFPS(60);


    while (!WindowShouldClose())
    {   
        
        BeginDrawing();
        ClearBackground(Color.Black);
        DrawText("Hello Huzz",200,200,100,Color.White);

      
        EndDrawing();

    }









