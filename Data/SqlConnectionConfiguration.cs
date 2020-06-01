using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzApp.Data
{
    public class SqlConnectionConfiguration
    {
        public SqlConnectionConfiguration(string value) => Value = value;
        public String Value { get; }
    }
}
