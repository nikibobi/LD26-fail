namespace LD26.Entitys.Components
{
    class ScriptComponent : Component
    {
        public override void Destroy()
        {
            MyEntity.Destroy();
        }
    }
}
