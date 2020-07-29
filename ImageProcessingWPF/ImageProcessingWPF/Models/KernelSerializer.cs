using ImageProcessingWPF.Utility;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ImageProcessingWPF.Models
{
    class KernelSerializer
    {
        private XmlSerializer _serializer = new XmlSerializer(typeof(Kernel));

        public KernelSerializer()
        {
            _serializer.UnknownNode += new XmlNodeEventHandler((sender, eventArgs) =>
            {
                MessageBoxExtension.ShowError($"An error has occured during loading file.\nUnknown node: \"{eventArgs.Name}\"");
            });
            _serializer.UnknownAttribute += new XmlAttributeEventHandler((sender, eventArgs) =>
            {
                MessageBoxExtension.ShowError($"An error has occured during loading file.\nUnknown attibute: \n\"{eventArgs.Attr.Name}\"");
            });
        }

        public void Serialize(Kernel kernel)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "kernel";
            dialog.Filter = "XML File|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName);
                _serializer.Serialize(writer, kernel);
                writer.Close();
            }
        }
        public Kernel Deserialize()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML file|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var stream = dialog.OpenFile();
                    var kernel = _serializer.Deserialize(stream) as Kernel;
                    stream.Close();
                    return kernel;
                }
                catch (IOException exception)
                {
                    exception.ShowAsError();
                }
            }
            return null;
        }
    }
}
