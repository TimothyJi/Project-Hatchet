using Microsoft.Xna.Framework;

namespace Hatchet.Graphics
{
    public class AnimatedSprite : Sprite
    {
        public IAnimation Animation => Animator.CurrentAnimation;
        public IAnimator Animator { get; private set; }
        
        public override Rectangle SourceRect => Animator.CurrentFrame.SourceRect;
        
        public bool Play(IAnimation animation)
        {
            return Animator.Play(animation);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Animator.Update(gameTime);
        }
    }
}
