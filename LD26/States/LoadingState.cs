using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using LD26.Helpers;

namespace LD26.States
{
    class LoadingState : State
    {
        private RectangleShape loadingBar;
        private IEnumerator<float> progress;

        public override void Init()
        {
            loadingBar = new RectangleShape
                             {
                                 Size = new Vector2f(Global.Screen.X, 64),
                                 Position = new Vector2f(0, Global.Screen.Y / 2f),
                                 FillColor = Color.Yellow
                             };
            progress = ResourceManager.Instance.LoadAll().GetEnumerator();
        }

        public override void Update(float dt)
        {
            if (progress.MoveNext())
            {
                loadingBar.Scale = new Vector2f(progress.Current, 1);
            }
            else
            {
                StateManager.Instance.CurrentState = new LevelState();
            }
        }

        public override void Draw(RenderTarget rt, RenderStates rs)
        {
            loadingBar.Draw(rt, rs);
        }
    }
}
