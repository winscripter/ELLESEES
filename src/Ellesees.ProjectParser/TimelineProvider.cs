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

using Ellesees.ProjectParser.ProjectInfo;

namespace Ellesees.ProjectParser;

/// <summary>
/// Items displayed in the timeline.
/// </summary>
public class TimelineProvider
{
    /// <summary>
    /// File imports.
    /// </summary>
    public ICommonImport[] Imports;

    /// <summary>
    /// Common image models.
    /// </summary>
    public IImageObjectModel[] Models;

    /// <summary>
    /// Effects.
    /// </summary>
    public IHasTimeStamps[] Effects;

    /// <summary>
    /// Primary Video.
    /// </summary>
    public PrimaryVideo? PrimaryVideo;

    /// <summary>
    /// Initializes a new instance of <see cref="TimelineProvider" />.
    /// </summary>
    /// <param name="imports">File imports.</param>
    /// <param name="models">Common image models.</param>
    /// <param name="effects">Effects.</param>
    /// <param name="primaryVideo">Primary video.</param>
    public TimelineProvider(ICommonImport[] imports, IImageObjectModel[] models, IHasTimeStamps[] effects, PrimaryVideo? primaryVideo)
    {
        Imports = imports;
        Models = models;
        Effects = effects;
        PrimaryVideo = primaryVideo;
    }

    /// <summary>
    /// Changes image object models to a specified value.
    /// </summary>
    /// <param name="models">New object models.</param>
    public void SetModels(IImageObjectModel[] models) => Models = models;
}
