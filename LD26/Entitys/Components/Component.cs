using System;
using SFML.Graphics;

namespace LD26.Entitys.Components
{
    class Component
    {
        public Entity MyEntity { get; private set; }

        public virtual void Init(Entity entity)
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
