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
    class LevelState : State
    {
        public override void Init()
        {
            base.Init();
            LoadLevel(0);
        }

        private void LoadLevel(int number)
        {
            string data = ResourceManager.Instance.Get<string>("level" + number + ".txt");
            var x = 0;
            var y = 0;

            foreach (char t in data)
            {
                if(t == '\n')
                {
                    x = -1;
                    y++;
                }
                else if(t == 'R')
                {
                    EntityManager.Instance.Add(EntityFactory.Box(x, y));
                    EntityManager.Instance.Add(EntityFactory.Floor(x, y));
                }
                else if(t == 'S')
                {
                    var player = EntityFactory.Player(x, y);
                    var camera = EntityFactory.Camera(player);
                    EntityManager.Instance.Add(player);
                    EntityManager.Instance.Add(camera);
                    EntityManager.Instance.Add(EntityFactory.Floor(x, y));
                }
                else if(t == '_')
                {
                    EntityManager.Instance.Add(EntityFactory.Floor(x, y));
                }
                x++;
            }
        }
    }
}
