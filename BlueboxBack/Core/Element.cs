using System;
using System.Collections.Generic;
using System.Text;

namespace BlueboxBack.Core
{
    public class Element
    {
        public enum ElementType
        {
            Undefined,
            Filled,
            Cleared
        }
        public bool Highlighted { get; private set; }
        public ElementType Type { get; private set; }
        public Element(Element el, bool highlighted)
        {
            this.Type = el.Type;
            this.Highlighted = highlighted;
        }
        public Element(ElementType type, bool highlighted)
        {
            this.Type = type;
            this.Highlighted = highlighted;
        }
        public Element(Element.ElementType type)
        {
            this.Type = type;
            this.Highlighted = false;
        }
    }
}
