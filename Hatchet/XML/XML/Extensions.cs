using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System.Xml;

namespace Hatchet.XML
{
    public static class Extensions
    {
        public static void Save(this XMLContent content, string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };

            using (XmlWriter writer = XmlWriter.Create(path, settings))
            {
                IntermediateSerializer.Serialize(writer, content, null);
            }
        }
    }
}
