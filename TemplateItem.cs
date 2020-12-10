using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorJSONTransform
{
    public class TemplateItem
    {
        public string FieldName { get; set; }
        public string FieldNameJsonPath { get; set; }
        public string JsonPath { get; set; }
        public string FixedValue { get; set; }
        public bool IsArray { get; set; }
        public bool IsFixedValue { get; set; }
        public List<TemplateItem> Child { get; set; }
    }
}
