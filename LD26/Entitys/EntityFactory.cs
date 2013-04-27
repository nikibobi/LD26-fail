using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using SFML.Graphics;

namespace LD26.Entitys
{
    //build all entities here
    static class EntityFactory
    {
        public static Entity Player()
        {
            var entity = new Entity();
            var texture = ResourceManager.Instance.Get<Texture>("something.png");
            var sprite = new SpriteComponent(texture);
            var hitbox = new FloatRect(0, 0, texture.Size.X, texture.Size.Y);
            var colider = new ColiderComponent(hitbox);
            var player = new Player();
            entity.AddComponent(sprite);
            entity.AddComponent(colider);
            entity.AddComponent(player);
            return entity;
        }
    }
}
