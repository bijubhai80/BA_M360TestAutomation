namespace JLTA.Common.Core.DataAccess
{
    using Oracle.DataAccess.Types;
    using System.Xml.Serialization;
    using System.Xml.Schema;

    public class TypeNumber28NtSet : INullable, IOracleCustomType, IXmlSerializable
    {
        public const string TYPE_NUMBER28_NT = "TYPE_NUMBER28_NT";

        private bool m_IsNull;

        private decimal[] m_number28s;

        public TypeNumber28NtSet()
        {
            // TODO : Add code to initialise the object
        }

        public TypeNumber28NtSet(string str)
        {
            // TODO : Add code to initialise the object based on the given string 
        }

        public decimal[] AsArrayOfDecimals()
        {
            var copyOfArray = new decimal[m_number28s.Length];
            m_number28s.CopyTo(copyOfArray,0);
            return copyOfArray;
        }

        public virtual bool IsNull
        {
            get
            {
                return this.m_IsNull;
            }
        }

        public static TypeNumber28NtSet Null
        {
            get
            {
                TypeNumber28NtSet obj = new TypeNumber28NtSet();
                obj.m_IsNull = true;
                return obj;
            }
        }

        [OracleArrayMappingAttribute()]
        public virtual decimal[] Value
        {
            get
            {
                return this.m_number28s;
            }
            set
            {
                this.m_number28s = value;
                m_IsNull = false;
            }
        }

        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, 0, this.m_number28s);
        }

        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            this.m_number28s = ((decimal[])(OracleUdt.GetValue(con, pUdt, 0)));
        }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            // TODO : Read Serialized Xml Data
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            // TODO : Serialize object to xml data
        }

        public virtual XmlSchema GetSchema()
        {
            // TODO : Implement GetSchema
            return null;
        }

        public override string ToString()
        {
            // TODO : Return a string that represents the current object
            return "";
        }

        public static EntityIdSet Parse(string str)
        {
            // TODO : Add code needed to parse the string and get the object represented by the string
            return new EntityIdSet();
        }
    }

    // Factory to create an object for the above class
    [OracleCustomTypeMappingAttribute("TYPE_NUMBER28_NT")]
    public class TypeNumber28NtSetFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        public virtual IOracleCustomType CreateObject()
        {
            TypeNumber28NtSet obj = new TypeNumber28NtSet();
            return obj;
        }

        public virtual System.Array CreateArray(int length)
        {
            decimal[] collElem = new decimal[length];
            return collElem;
        }

        public virtual System.Array CreateStatusArray(int length)
        {
            return null;
        }
    }
}
