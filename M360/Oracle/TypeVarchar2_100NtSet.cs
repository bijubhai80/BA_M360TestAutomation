using Oracle.DataAccess.Types;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace JLTA.Common.Core.DataAccess
{
    public class TypeVarchar2_100NtSet : INullable, IOracleCustomType, IXmlSerializable
    {
        public const string TYPE_VARCHAR2_100_NT = "TYPE_VARCHAR2_100_NT";

        private bool _IsNull;

        private string[] _varchar2_100s;

        public TypeVarchar2_100NtSet()
        {
        }

        public TypeVarchar2_100NtSet(string str)
        {
        }

        public virtual bool IsNull
        {
            get
            {
                return _IsNull;
            }
        }

        public static TypeVarchar2_100NtSet Null
        {
            get
            {
                TypeVarchar2_100NtSet obj = new TypeVarchar2_100NtSet();
                obj._IsNull = true;
                return obj;
            }
        }

        [OracleArrayMappingAttribute()]
        public virtual string[] Value
        {
            get
            {
                return _varchar2_100s;
            }
            set
            {
                _varchar2_100s = value;
                _IsNull = false;
            }
        }

        public virtual void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            OracleUdt.SetValue(con, pUdt, 0, _varchar2_100s);
        }

        public virtual void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, System.IntPtr pUdt)
        {
            _varchar2_100s = ((string[])(OracleUdt.GetValue(con, pUdt, 0)));
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
    [OracleCustomTypeMappingAttribute(TypeVarchar2_100NtSet.TYPE_VARCHAR2_100_NT)]
    public class TypeVarchar2_100NtSetFactory : IOracleCustomTypeFactory, IOracleArrayTypeFactory
    {
        public virtual IOracleCustomType CreateObject()
        {
            TypeVarchar2_100NtSet obj = new TypeVarchar2_100NtSet();
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
