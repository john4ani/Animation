using System.Drawing;

namespace Animation
{
    public interface IAnimationManager
    {
        void MoveParticles();
        void DrawOn(Graphics graphics);
        bool AnimationEnded();
    }
}