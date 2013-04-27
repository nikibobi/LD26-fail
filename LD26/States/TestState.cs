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

namespace LD26.States
{
    class TestState : State
    {
        public override void Init()
        {
            base.Init();
            EntityManager.Instance.Add(EntityFactory.Box(new Vector2f(800, 200)));
            EntityManager.Instance.Add(EntityFactory.Player());
        }
    }
}
