using Oracle.DataAccess.Types;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace JLTA.Common.Core.DataAccess
{
    public class TypeVarchar2_4kNtSet : INullable, IOracleCustomType, IXmlSerializable
    {
        public const string TYPE_VARCHAR2_4K_NT = "TYPE_VARCHAR2_4K_NT";

        private bool _IsNull;

        private string[] _varchar2_4ks;

        public TypeVarchar2_4kNtSet()
        {
        }

        public TypeVarchar2_4kNtSet(string str)
        {
        }

        public virtual bool IsNull
        {
            get
            {
                return _IsNull;
            }
        }

        public static TypeVarchar2_4kNtSet Null
        {
            get
            {
                TypeVarchar2_4kNtSet obj = new TypeVarchar2_4kNtSet();
                obj._IsNull = true;
                return obj;
            }
        }

        [OracleArrayMappingAttribute()]
        public virtual string[] Value
        {
            get
            {
                return _varchar2_4ks;
            }
            set
            {
                _varchar2_4ks = value;
                _IsNull = false;
            }
        }

        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, 0, _varchar2_4ks);
        }

        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            _varchar2_4ks = ((string[])(OracleUdt.GetValue(con, pUdt, 0)));
        }

        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
        }

        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
        }

        public virtual XmlSchema GetSchema()
        {
            return null;
        }

        public override string ToString()
        {
            return "";
        }
    }

    // Factory to create an object for the above class
    [OracleCustomTypeMappingAttribute("TYPE_VARCHAR2_4K_NT")]
    public class TypeVarchar2_4kNtSetFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        public virtual IOracleCustomType CreateObject()
        {
            TypeVarchar2_4kNtSet obj = new TypeVarchar2_4kNtSet();
            return obj;
        }

        public virtual System.Array CreateArray(int length)
        {
            string[] collElem = new string[length];
            return collElem;
        }

        public virtual System.Array CreateStatusArray(int length)
        {
            return null;
        }
    }
}
