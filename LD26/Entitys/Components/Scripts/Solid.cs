using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using SFML.Window;

namespace LD26.Entitys.Components.Scripts
{
    class Solid : ScriptComponent
    {
        public override void Init(Entity entity)
        {
            base.Init(entity);
            if(MyEntity.HasComponent<ColiderComponent>())
            {
                MyEntity.GetComponent<ColiderComponent>().Colides += OnColide;
            }
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            
        }

        private RectangleShape rectangle;

        public override void Draw(RenderTarget rt, RenderStates rs)
        {
            base.Draw(rt, rs);
            if (rectangle != null)
                rt.Draw(rectangle);
        }

        private void OnColide(Entity entity, FloatRect overlap)
        {
            RectangleShape box = new RectangleShape(new Vector2f(overlap.Width, overlap.Height));
            box.Position = new Vector2f(overlap.Left, overlap.Top);
            box.OutlineThickness = 4;
            box.OutlineColor = Color.Yellow;
            box.FillColor = new Color(0, 0, 0, 0);
            Console.WriteLine(overlap);

            if (overlap.Width < overlap.Height)
            {
                entity.Transform.Position -= new Vector2f(overlap.Width, 0);
            }
            else
            {
                entity.Transform.Position -= new Vector2f(0, overlap.Height);
            }
        }
    }
}
