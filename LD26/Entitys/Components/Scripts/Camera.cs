using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using LD26.Helpers;
using SFML.Window;

namespace LD26.Entitys.Components.Scripts
{
    class Camera : Component
    {
        private View camera;

        public Entity Target { get; set; }

        public override void Init(Entity entity)
        {
            base.Init(entity);
            camera = new View(Target.Transform.Position, Global.Screen);
            camera.Zoom(3f);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            camera.Center = Target.Transform.Position;
            Global.Window.SetView(camera);
        }
    }
}
