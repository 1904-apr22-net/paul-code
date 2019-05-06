using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Serialization
{
    public class Person
    {
        [XmlAttribute]
        public int Id { get; set; }
        [XmlElement(ElementName = "FullName")]
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
