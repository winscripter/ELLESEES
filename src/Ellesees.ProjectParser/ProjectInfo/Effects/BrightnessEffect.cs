﻿// MIT License
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

using System.Xml.Serialization;

namespace Ellesees.ProjectParser.ProjectInfo.Effects;

/// <summary>
/// A brightness effect.
/// </summary>
[Serializable]
[XmlRoot("BrightnessEffect")]
public class BrightnessEffect : IHasTimeStamps
{
    /// <summary>
    /// Amount of brightness.
    /// </summary>
    [XmlAttribute("By")]
    public string? By { get; set; }

    /// <summary>
    /// Initial time stamp when this effect starts to apply.
    /// </summary>
    [XmlAttribute("StartDuration")]
    public string? StartDuration { get; set; }

    /// <summary>
    /// Final time stamp when this effect vanishes.
    /// </summary>
    [XmlAttribute("EndDuration")]
    public string? EndDuration { get; set; }
}
