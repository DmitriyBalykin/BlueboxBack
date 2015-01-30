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
        public override string ToString()
        {
            return (Highlighted ? "High " : "") +Type.ToString();
        }
        public static short operator +(Element el1, Element el2)
        {
            if (el1.Type == ElementType.Cleared && el2.Type == ElementType.Cleared)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static short operator +(Element el1, int i)
        {
            if (el1.Type == ElementType.Cleared && i == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public static short operator +(int i, Element el1)
        {
            if (el1.Type == ElementType.Cleared && i == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
