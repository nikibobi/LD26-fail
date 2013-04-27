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
        private ColiderComponent myColider;

        public override void Init(Entity entity)
        {
            base.Init(entity);
            if(MyEntity.HasComponent<ColiderComponent>())
            {
                myColider = MyEntity.GetComponent<ColiderComponent>();
                myColider.Colides += OnColide;
            }
        }

        private RectangleShape rectangle;

        public override void Draw(RenderTarget rt, RenderStates rs)
        {
            base.Draw(rt, rs);
            if (rectangle != null)
                rt.Draw(rectangle);
        }

        private void OnColide(ColiderComponent otherColider, FloatRect overlap)
        {
            rectangle = new RectangleShape(new Vector2f(overlap.Width, overlap.Height));
            rectangle.Position = new Vector2f(overlap.Left, overlap.Top);
            rectangle.OutlineThickness = 4;
            rectangle.OutlineColor = Color.Yellow;
            rectangle.FillColor = new Color(0, 0, 0, 0);
            Console.WriteLine(overlap);

            Vector2f x = new Vector2f();
            Vector2f y = new Vector2f();

            if (overlap.Width < overlap.Height)
            {
                if (myColider.Hitbox.Left > otherColider.Hitbox.Left + otherColider.Hitbox.Width)
                {
                    x += new Vector2f(overlap.Width, 0);
                }
                else
                {
                    x -= new Vector2f(overlap.Width, 0);
                }
            }
            else
            {
                if (myColider.Hitbox.Top > otherColider.Hitbox.Top + otherColider.Hitbox.Height)
                {
                    y -= new Vector2f(0, overlap.Height);
                }
                else
                {
                    y += new Vector2f(0, overlap.Height);
                }
            }

            otherColider.MyEntity.Transform.Position += (x.X < y.Y ? x : y);
        }
    }
}
