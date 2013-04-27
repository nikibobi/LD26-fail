using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LD26.States;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using LD26.Managers;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Helpers;

namespace LD26
{
    class Program
    {
        static void Main(string[] args)
        {
            var videoMode = new VideoMode(1000, 700);
            var contextSettings = new ContextSettings(0, 0, 4);
            RenderWindow window = new RenderWindow(videoMode, "Luda Diaria", Styles.Default, contextSettings);
            window.SetActive(true);
            window.Closed += (sender, e) => window.Close();
            Global.Window = window;

            var input = InputManager.Instance;
            input.Init();

            StateManager.Instance.CurrentState = new LoadingState();

            var lastTick = DateTime.Now;
            const float maxTimeStep = 0.5f;

            while (window.IsOpen())
            {
                float dt = (float)((DateTime.Now - lastTick).TotalSeconds);
                lastTick = DateTime.Now;

                window.DispatchEvents();
                window.Clear(new Color(97, 14, 14));

                if (input.IsKeyPressed(Keyboard.Key.Escape))
                {
                    window.Close();
                }

                while (dt > 0)
                {
                    //---UPDATE
                    var deltatTime = dt < maxTimeStep ? dt : maxTimeStep;
                    StateManager.Instance.CurrentState.Update(deltatTime);
                    dt -= maxTimeStep;
                }
                //---DRAW

                StateManager.Instance.CurrentState.Draw(window, RenderStates.Default);
                window.Display();
            }
        }
    }
}
