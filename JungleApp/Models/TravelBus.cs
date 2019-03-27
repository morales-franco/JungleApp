using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JungleApp.Models
{
    public class TravelBus
    {
        public void Send(Provider provider)
        {
            Debug.WriteLine($"Serializabling to xml.. Provider {provider.CompletedName } -  Age { provider.Age} - Birth { provider.Birth.ToString("dd/MM/yyyy") } - stuffs: { string.Join(",", provider.Stuffs.Select(s => s).ToArray()) }" );

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Provider));

            string fileTxt = string.Empty;

            Debug.WriteLine("## Txt serializer ##");
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, provider);
                fileTxt = textWriter.ToString();
            }

            Debug.WriteLine("## file serializer ##");
            using (var stream = new FileStream("Sample.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(stream, provider);
            }

            Debug.WriteLine("## Deserialization ##");

            Provider providerAux = null;

            using (var stream = new FileStream("Sample.xml", FileMode.Open))
            {
                providerAux = (Provider)xmlSerializer.Deserialize(stream);
            }

            Debug.WriteLine("## Deserialization Txt ##");
            Debug.WriteLine(fileTxt);
            Debug.WriteLine(".........................");
            Debug.WriteLine($"Deserialization from xml.. Provider {providerAux.CompletedName } -  Age { providerAux.Age} - Birth { providerAux.Birth.ToString("dd/MM/yyyy") } - stuffs: { string.Join(",", providerAux.Stuffs.Select(s => s).ToArray()) }");



        }
    }
}
