using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Managers;

namespace LD26.States
{
    abstract class State
    {
        public virtual void Init()
        {
            EntityManager.Instance.Init();
        }

        public virtual void Update(float dt)
        {
            EntityManager.Instance.Update(dt);
        }

        public virtual void Draw(RenderTarget rt, RenderStates rs)
        {
            EntityManager.Instance.Draw(rt, rs);
        }
    }
}
