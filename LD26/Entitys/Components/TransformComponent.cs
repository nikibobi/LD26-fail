using SFML.Graphics;
using SFML.Window;

namespace LD26.Entitys.Components
{
    class TransformComponent : Component
    {
        private readonly Transformable transform;

        public TransformComponent()
            :this(new Vector2f(), 0)
        {
            
        }

        public TransformComponent(Vector2f position, float rotation)
            :base()
        {
            transform = new Transformable {Position = position, Rotation = rotation};
        }

        public Vector2f Position
        {
            get { return transform.Position; }
            set { transform.Position = value; }
        }

         public Vector2f Origin
        {
            get { return transform.Origin; }
            set { transform.Origin = value; }
        }

        public float Rotation
        {
            get { return transform.Rotation; }
            set { transform.Rotation = value; }
        }

        public Vector2f Scale
        {
            get { return transform.Scale; }
            set { transform.Scale = value; }
        }
    }
}
