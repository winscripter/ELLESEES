// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System.Text;
using System.Xml.Serialization;

namespace ElleseesUI.EX;

/// <summary>
/// Class to XML converter. Not using standard .NET API libraries for XML
/// to do this heavy lifting for me because it adds unnecessary things such
/// as document header or XML namespace.
/// </summary>
/// <remarks>
/// EX stands for <b>E</b>LLESEES <b>X</b>ML, which is to distinguish from .NET API libraries. Bit
/// of an attracting name, really.
/// </remarks>
internal static class EXSerializer
{
    /// <summary>
    /// Serializes the object into XML.
    /// </summary>
    /// <param name="obj">Object name.</param>
    /// <returns>Serialized XML self-closing tag.</returns>
    public static string Serialize(this object obj)
    {
        StringBuilder sb = new();

        var tagName = obj.GetType()
                         .GetCustomAttributes(typeof(XmlRootAttribute), false)
                         .Cast<XmlRootAttribute>()
                         .FirstOrDefault()!
                         .ElementName;

        sb.Append($"<{tagName} ");

        List<string> propertyFormatting = new();

        var targetProps = obj.GetType()
                             .GetProperties()
                             .Where(prop => prop.CustomAttributes
                                                .Where(ca => ca.AttributeType.FullName == "System.Xml.Serialization.XmlAttributeAttribute").Any());

        foreach (var prop in targetProps)
        {
            propertyFormatting.Add($"{prop.Name}=\"{prop.GetValue(obj)}\"");
        }

        sb.Append($"{string.Join(" ", propertyFormatting.ToArray())} />");

        return sb.ToString();
    }
}
