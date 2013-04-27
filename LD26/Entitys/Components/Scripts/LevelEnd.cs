using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;
using LD26.States;

namespace LD26.Entitys.Components.Scripts
{
    class LevelEnd : Component
    {
        public override void Init(Entity entity)
        {
            base.Init(entity);
            MyEntity.GetComponent<ColiderComponent>().Colides += OnColides;
        }

        private void OnColides(ColiderComponent colider, FloatRect overlap)
        {
            if(colider.MyEntity.HasComponent<Player>() &&
               StateManager.Instance.CurrentState is LevelState )
            {
                var levelState = StateManager.Instance.CurrentState as LevelState;
                levelState.CurrentLevel++;
            }
        }
    }
}
