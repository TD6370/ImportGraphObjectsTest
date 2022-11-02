using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportGraphObjectsTest.Models
{
    public class ObjectParams
    {
        private readonly string m_name;
        private readonly string m_value;
        private readonly Type m_typeParam;

        public string Name => m_name;
        public string Value => m_value;

        public ObjectParams(string name, string value) 
        {
            m_name = name;
            m_value = value;
        }
    }
}
