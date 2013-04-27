using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Managers;
using SFML.Window;

namespace LD26.Entitys.Components.Scripts
{
    class Player : ScriptComponent
    {
        public override void Update(float dt)
        {
            base.Update(dt);
            if(InputManager.Instance.IsKeyHold(Keyboard.Key.W))
            {
                MyEntity.Transform.Position += new Vector2f(0, -300 * dt);
            }
            if (InputManager.Instance.IsKeyHold(Keyboard.Key.A))
            {
                MyEntity.Transform.Position += new Vector2f(-300 * dt, 0);
            }
            if (InputManager.Instance.IsKeyHold(Keyboard.Key.S))
            {
                MyEntity.Transform.Position += new Vector2f(0, 300 * dt);
            }
            if (InputManager.Instance.IsKeyHold(Keyboard.Key.D))
            {
                MyEntity.Transform.Position += new Vector2f(300 * dt, 0);
            }
        }
    }
}
