using System;
using SFML.Graphics;

namespace LD26.Entitys.Components
{
    class SpriteComponent : Component
    {
        private readonly Sprite sprite;

        public SpriteComponent(Texture texture)
        {
            sprite = new Sprite(texture);
        }

        public Texture Texture
        {
            get { return sprite.Texture; }
            set { sprite.Texture = value; }
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            sprite.Origin = MyEntity.Transform.Origin;
            sprite.Position = MyEntity.Transform.Position;
            sprite.Rotation = MyEntity.Transform.Rotation;
            sprite.Scale = MyEntity.Transform.Scale;
        }

        public override void Draw(RenderTarget rt, RenderStates rs)
        {
            base.Draw(rt, rs);
            rt.Draw(sprite, rs);
        }
    }
}
