using System;
using SFML.Graphics;

namespace LD26.Entitys.Components
{
    class Component
    {
        protected Entitys.Entity MyEntity { get; private set; }

        public virtual void Init(Entitys.Entity entity)
        {
            MyEntity = entity;
        }

        public virtual void Update(float dt)
        {

        }

        public virtual void Draw(RenderTarget rt, RenderStates rs)
        {

        }

        public virtual void Destroy()
        {
            MyEntity.RemoveComponent(this);
        }
    }
}
