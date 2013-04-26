using System;
using System.Collections.Generic;
using System.Linq;
using LD26.Entitys.Components;
using SFML.Graphics;

namespace LD26.Entitys
{
    class Entity
    {
        private readonly List<Component> components; 

        public Entity()
        {
            components = new List<Component>();
        }

        public TransformComponent Transform { get; private set; }

        public void Init()
        {
            Transform = new TransformComponent();
            components.Add(Transform);
            foreach (var component in components)
            {
                component.Init(this);
            }
        }

        public void Update(float dt)
        {
            foreach (var component in components)
            {
                component.Update(dt);
            }
        }

        public void Draw(RenderTarget rt, RenderStates rs)
        {
            foreach (var component in components)
            {
                component.Draw(rt, rs);
            }
        }

        public void Destroy()
        {
            foreach (var component in components)
            {
                component.Destroy();
            }
        }

        public void AddComponent<T>(T component) where T : Component
        {
            components.Add(component);
        }

        public IEnumerable<T> GetComponents<T>() where T : Component
        {
            return components.OfType<T>();
        }

        public T GetComponent<T>() where T : Component
        {
            return GetComponents<T>().FirstOrDefault();
        }

        public bool HasComponent<T>() where T : Component
        {
            return components.Any(c => c is T);
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }
    }
}
