using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ImageProcessingWPF.Models
{
    class KernelSerializer
    {
        private XmlSerializer _serializer = new XmlSerializer(typeof(Kernel));
        public void Serialize(Kernel kernel)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "kernel";
            dialog.Filter = "XML File|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(dialog.FileName);
                _serializer.Serialize(writer, kernel);
            }
        }
    }
}
