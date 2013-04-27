using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace LD26.Entitys.Components
{
    class ColiderComponent : Component
    {
        public ColiderComponent(FloatRect hitbox)
        {
            Hitbox = hitbox;
        }

        public FloatRect Hitbox { get; set; }

        public event OnColide Colides;

        public void Colide(Entity entity, FloatRect overlap)
        {
            var handler = Colides;
            if (handler != null)
                handler(entity, overlap);
        }

        public delegate void OnColide(Entity entity, FloatRect overlap);
    }
}
