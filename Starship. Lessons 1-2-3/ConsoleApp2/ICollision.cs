using System.Drawing;

namespace ConsoleApp2
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
