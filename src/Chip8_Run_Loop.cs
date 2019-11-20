using System;
using System.Diagnostics;
using System.Threading;

namespace Chip8_GUI.src
{
    public class Game_Loop
    {
        Chip8 chip8;

        // TODO: Make A path manager class & use it in the Driver class to select the Rom title?
        string rom_title;

        readonly Stopwatch stopWatch = Stopwatch.StartNew();
        readonly TimeSpan targetElapsedTime60Hz = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 60);
        readonly TimeSpan targetElapsedTime = TimeSpan.FromTicks(TimeSpan.TicksPerSecond / 1000);
        TimeSpan last_time;

        public Game_Loop()
        {
            while (true)
            {
                var current_time = stopWatch.Elapsed;
                var elapsed_time = stopWatch.Elapsed - last_time;

                while(elapsed_time >= targetElapsedTime60Hz)
                {
                    chip8.Tick();
                    elapsed_time -= targetElapsedTime60Hz;
                    last_time += targetElapsedTime60Hz;
                }

                chip8.Process_OpCode();
                // TODO: Refresh the screen here too
                Thread.Sleep(targetElapsedTime);

            }

        }
        
    }
}