using System;

namespace Cwiczenia3FirtApi.Models
{
    internal class JsonPropertiesAttribute : Attribute
    {
        private string v;

        public JsonPropertiesAttribute(string v)
        {
            this.v = v;
        }
    }
}