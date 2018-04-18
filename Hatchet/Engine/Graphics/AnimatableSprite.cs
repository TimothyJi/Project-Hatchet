using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public class AnimatableSprite : Sprite
    {
        public IAnimation Animation => Animator.CurrentAnimation;
        public IAnimator Animator { get; private set; }
        
        public override Rectangle? SourceRect => Animator.CurrentFrame.SourceRect;
        
        public bool Play(IAnimation animation)
        {
            return Animator.Play(animation);
        }

        public void Update(GameTime gameTime)
        {
            Animator.Update(gameTime);
        }
    }
}
