using System.Collections.ObjectModel;

namespace Hatchet.Graphics.Collections
{
    public abstract class FrameCollectionBase : Collection<IFrame>, IFrameCollection
    {
        public virtual void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
