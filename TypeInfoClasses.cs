using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

using System;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace TypeInfoClasses {

    /// <summary>
    /// Описание типа тэга
    /// Хранит имя типа и список полей с их типом данных
    /// </summary>
    public class TypeInfo
    {
        [JsonPropertyName("TypeName")]
        public string name { get; set; }

        /// <summary>
        /// Хранит имя свойства(как ключ) и его тип данных
        /// </summary>
        [JsonPropertyName("Propertys")]
        public Dictionary<string, string> Property { get; set; }


        public override bool Equals(object obj)
        {
            TypeInfo t = (TypeInfo)obj;
            return t.name.Equals(this.name);
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }

        public List<string> GetPropertyList()
        {
            List<string> result = Property.Keys.ToList();
            return result;
        }


        public int GetSize(string property)
        {
            int size;
            if (Property.TryGetValue(property, out string typename))
                switch (typename)
                {
                    case "double": size = sizeof(double); break;
                    case "int": size = sizeof(int); break;
                    case "bool": size = sizeof(bool); break;
                    case "float": size = sizeof(float); break;
                    case "byte": size = sizeof(byte); break;
                    default: throw new UndefinedTypeNameExcpeption("Undefined type of property " + property);
                }
            else
                throw new UndefinedPropertyExcpeption("Undefined property " + property);
            return size;
        }
    }


    /// <summary>
    /// Коллекция возможных типов данных
    /// Загружается из файла JSON
    /// </summary>
    public class TypeList
    {
        [JsonPropertyName("TypeInfos")]
        public HashSet<TypeInfo> TypeInfos { get; set; }

        public TypeInfo GetTagType(string typeName)
        {
            return this.TypeInfos.First(x => x.name == typeName);
        }


    }


    public class UndefinedTypeNameExcpeption : ApplicationException
    {
        public UndefinedTypeNameExcpeption() : base() { }
        public UndefinedTypeNameExcpeption(string message) : base(message) { }
        public UndefinedTypeNameExcpeption(string message, System.Exception inner) : base(message, inner) { }
    }

    public class UndefinedPropertyExcpeption : ApplicationException
    {
        public UndefinedPropertyExcpeption() : base() { }
        public UndefinedPropertyExcpeption(string message) : base(message) { }
        public UndefinedPropertyExcpeption(string message, System.Exception inner) : base(message, inner) { }
    }
}

