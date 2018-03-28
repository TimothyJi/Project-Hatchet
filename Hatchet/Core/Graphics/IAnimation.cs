namespace Hatchet.Graphics
{
    public interface IAnimation
    {
        ITexturedFrame[] Frames { get; }
        bool Loop { get; }
    }
}
