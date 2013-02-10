using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMetro
{
    using System.Xml.Linq;
    using Dto;

    public class Agent
    {
        private const string Url = "http://webkamera.vegvesen.no/metadata";

        public IEnumerable<Camera> GetCameras()
        {
            XElement xElement = XElement.Load(Url);

            var items = xElement.Descendants("webkamera");
            foreach (var element in items)
            {
                var camera = new Camera();
                camera.Id = element.Attribute("id").Value;
                camera.Url = element.Element("url").Value;
                camera.Name = element.Element("stedsnavn").Value;
                camera.Latitude = element.Element("breddegrad").Value;
                camera.Longtitude = element.Element("lengdegrad").Value;

                yield return camera;
            }
        }
    }
}
