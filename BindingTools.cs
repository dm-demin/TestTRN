using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

using TypeInfoClasses;

namespace BindingTool
{


    /// <summary>
    /// Класс хранит связку имени и смещения для каждого свойства
    /// </summary>
    /// 
    [XmlRoot("root")]
    [XmlType("item")]
    public class Binder
    {
        [XmlElement(ElementName = "node-path")]
        public string tagName { get; set; }


        private int tagOffset;
        [XmlElement(ElementName = "address")]
        public int Offset { get => tagOffset; set => tagOffset = value; }

        public Binder(string tagName, int tagAddress)
        {
            this.tagName = tagName;
            this.tagOffset = tagAddress;

        }

        public Binder() { }

    }




    [XmlRoot("root")]
    public class BinderList
    {
        [XmlArrayItem(Type = typeof(Binder))]
        public HashSet<Binder> Properties { get; set; }

        private int nextOffset;
        public int NextOffset { get => nextOffset; }


        public BinderList()
        {
            Properties = new HashSet<Binder>();
            this.nextOffset = 0;

        }


        public void AddBinder(string tagName, string tagType, int tagOffset, ref TypeList tList)
        {
            List<string> propList = tList.GetTagType(tagType).GetPropertyList();

            int offset = tagOffset;
            foreach (string prop in propList)
            {
                //   Для случая сквозной адресации
                //if (NextOffset > offset) offset = this.nextOffset;

                Binder b = new Binder(tagName + "." + prop, offset);
                Properties.Add(b);

                //   Для случая сквозной адресации
                //this.nextOffset += tList.GetTagType(tagType).GetSize(prop);

                //  Для случая расчета смещения для каждого тэга
                offset += tList.GetTagType(tagType).GetSize(prop);

            }

        }

        public void AddBinder(Binder b)
        {
            Properties.Add(b);
        }


        public XElement ToXML()
        {
            return new XElement("root", Properties.SelectMany(x => new[]
                                               {
                                     new XElement ("item",new XAttribute("Binding","Introduced"),
                                            new XElement ("node-path", x.tagName),
                                            new XElement ("address", x.Offset)
                                                    )
                                                }
                                             ));

        }

    }

   


}
