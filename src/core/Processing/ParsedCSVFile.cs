using System.Collections.Generic;

namespace YSQ.core.Processing
{
    internal class ParsedCSVFile
    {
        public IEnumerable<dynamic> Rows { get; set; }
        public IEnumerable<string> FieldNames { get; set; }

        protected ParsedCSVFile() { }
        public ParsedCSVFile(IEnumerable<dynamic> rows, IEnumerable<string> field_names)
        {
            Rows = rows;
            FieldNames = field_names;
        }
    }
}