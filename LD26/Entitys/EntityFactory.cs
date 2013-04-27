using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using SFML.Graphics;
using SFML.Window;

namespace LD26.Entitys
{
    //build all entities here
    static class EntityFactory
    {
        public static Entity Player(int x, int y)
        {
            var entity = new Entity();
            var texture = ResourceManager.Instance.Get<Texture>("BlueDude.png");
            entity.Transform.Origin = new Vector2f(texture.Size.X / 2f, texture.Size.Y / 2f);
            entity.Transform.Position = new Vector2f(x * texture.Size.X, y * texture.Size.Y);
            var sprite = new SpriteComponent(texture);
            var hitbox = new FloatRect(0, 0, texture.Size.X, texture.Size.Y);
            var colider = new ColiderComponent(hitbox);
            var player = new Player();
            entity.AddComponent(sprite);
            entity.AddComponent(colider);
            entity.AddComponent(player);
            return entity;
        }

        public static Entity Box(int x, int y)
        {
            var entity = new Entity();
            var texture = ResourceManager.Instance.Get<Texture>("rock.png");
            entity.Transform.Origin = new Vector2f(texture.Size.X / 2f, texture.Size.Y / 2f);
            entity.Transform.Position = new Vector2f(x * texture.Size.X, y * texture.Size.Y);
            var sprite = new SpriteComponent(texture);
            var hitbox = new FloatRect(0, 0, texture.Size.X, texture.Size.Y);
            var colider = new ColiderComponent(hitbox);
            var box = new Solid();
            entity.AddComponent(sprite);
            entity.AddComponent(colider);
            entity.AddComponent(box);
            return entity;
        }

        public static Entity Floor(int x, int y)
        {
            var entity = new Entity();
            var texture = ResourceManager.Instance.Get<Texture>("grass_tile.png");
            entity.Transform.Origin = new Vector2f(texture.Size.X / 2f, texture.Size.Y / 2f);
            entity.Transform.Position = new Vector2f(x * texture.Size.X, y * texture.Size.Y);
            var sprite = new SpriteComponent(texture);
            entity.AddComponent(sprite);
            return entity;
        }

        public static Entity Camera(Entity target)
        {
            var entity = new Entity();
            var camera = new Camera();
            camera.Target = target;
            entity.AddComponent(camera);
            return entity;
        }
    }
}
