using System;

namespace SlackDotNet.Enums
{
    internal class TypeAttribute : Attribute
    {
        public Type ImplementingType { get; set; }
        public TypeAttribute(Type implementingType)
        {
            ImplementingType = implementingType;
        }
    }
}
