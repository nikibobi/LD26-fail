using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;

namespace LD26.Managers
{
    class EntityManager
    {
        #region Singlation
        private static EntityManager instance;

        public static EntityManager Instance
        {
            get { return instance ?? (instance = new EntityManager()); }
        }

        private EntityManager()
        {
            
        }
        #endregion

        private Queue<Entity> createQueue;
        private List<Entity> entities;
        private Queue<Entity> removeQueue;

        public void Init()
        {
            Clear();
        }

        public void Update(float dt)
        {
            //Check for colisions
            foreach (var entity1 in entities)
            {
                if (!(entity1.HasComponent<ColiderComponent>()))
                    continue;
                foreach (var entity2 in entities)
                {
                    if (entity1 == entity2 || (!(entity1.HasComponent<ColiderComponent>())))
                        continue;
                    ColiderComponent colider1 = entity1.GetComponent<ColiderComponent>();
                    ColiderComponent colider2 = entity2.GetComponent<ColiderComponent>();
                    FloatRect overlap;
                    if (colider1.Hitbox.Intersects(colider2.Hitbox, out overlap))
                    {
                        colider1.Colide(entity2, overlap);
                    }
                }
            }
            //Update
            foreach (var entity in entities)
            {
                entity.Update(dt);
            }

            //Add entries and Init them if they are not
            while (createQueue.Count > 0)
            {
                entities.Add(createQueue.Dequeue());
            }

            //Add to be removed
            foreach (var entity in entities.Where(e => e.Destroying))
            {
                removeQueue.Enqueue(entity);
            }
            //Remove entries
            while (removeQueue.Count > 0)
            {
                entities.Remove(removeQueue.Dequeue());
            }
        }

        public void Draw(RenderTarget rt, RenderStates rs)
        {
            //Draw
            for (var i = entities.Count - 1; i >= 0; i--)
            {
                entities[i].Draw(rt, rs);
            }
        }

        public void Clear()
        {
            createQueue = new Queue<Entity>();
            entities = new List<Entity>();
            removeQueue = new Queue<Entity>();
        }

        public void Add(Entity entity)
        {
            if (!entity.Initialized)
            {
                entity.Init();
            }
            createQueue.Enqueue(entity);
        }

        public bool Has<T>() where T : ScriptComponent
        {
            return entities.Any(e => e.HasComponent<T>());
        }

        public IEnumerable<Entity> GetEntitys<T>() where T : ScriptComponent
        {
            return entities.Where(e => e.HasComponent<T>());
        }

        public Entity GetEntity<T>() where T : ScriptComponent
        {
            return GetEntitys<T>().FirstOrDefault();
        }

        public IEnumerable<Entity> All()
        {
            return entities.AsEnumerable();
        }
    }
}
