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
using Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Ellesees.ProjectParser;

internal class TimelineInfoXmlParser
{
    private readonly string _path;

    private static readonly ProjectException XmlInvalidRootTag = new(
        "Root tag of timeline information XML must be equal to <ProjectTimeline>"
    );

    public TimelineInfoXmlParser(string path)
    {
        _path = path;
    }

    public TimelineProvider Parse()
    {
        var doc = XDocument.Load(_path);
        
        if (doc.Root!.Name != "ProjectTimeline")
        {
            throw XmlInvalidRootTag;
        }

        var timelineTag = doc.Descendants();

        List<ICommonImport> imports = new();
        List<IImageObjectModel> objects = new();
        List<IHasTimeStamps> effects = new();
        PrimaryVideo? primaryVideo = null;

        foreach (var rootTag in timelineTag)
        {
            foreach (var childTag in rootTag.Descendants())
            {
                string name = childTag.Name.LocalName;

                if (Project.TagAndEffectAssociations.ContainsKey(name))
                {
                    var serializer = new XmlSerializer(Project.TagAndEffectAssociations[name]);
                    using var reader = new StringReader(childTag.ToString().Trim());
                    var value = serializer.Deserialize(reader);
                    effects.Add((IHasTimeStamps)value!);

                    continue;
                }

                // Fine, this is prune to FormatExceptions...
                // The callee doesn't catch the exception. The
                // caller does. And it's for a good reason.

                switch (name)
                {
                    case "PrimaryVideo":
                        {
                            primaryVideo = new PrimaryVideo
                            {
                                Path = childTag.Attribute("Path")!.Value
                            };

                            break;
                        }
                    case "VideoImport":
                        {
                            imports.Add(new VideoImport
                            {
                                Path = childTag.Attribute("Path")!.Value,
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                                Speed = Convert.ToSingle(childTag.Attribute("Speed")!.Value, CultureInfo.InvariantCulture),
                                AllowAudio = Convert.ToBoolean(childTag.Attribute("AllowAudio")!.Value)
                            });

                            break;
                        }
                    case "AudioImport":
                        {
                            imports.Add(new AudioImport
                            {
                                Path = childTag.Attribute("Path")!.Value,
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                            });

                            break;
                        }
                    case "ImageImport":
                        {
                            imports.Add(new ImageImport
                            {
                                Path = childTag.Attribute("Path")!.Value,
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                            });

                            break;
                        }
                    case "Text":
                        {
                            objects.Add(new Text
                            {
                                Value = childTag.Attribute("Content")!.Value,
                                X = Convert.ToSingle(childTag.Attribute("X")!.Value, CultureInfo.InvariantCulture),
                                Y = Convert.ToSingle(childTag.Attribute("Y")!.Value, CultureInfo.InvariantCulture),
                                Width = Convert.ToInt32(childTag.Attribute("Width")!.Value),
                                Height = Convert.ToInt32(childTag.Attribute("Height")!.Value),
                                Color = childTag.Attribute("Color")!.Value,
                                FontSize = Convert.ToInt32(childTag.Attribute("Size")!.Value),
                                FontName = childTag.Attribute("Font")!.Value,
                                ShadowColor = childTag.Attribute("ShadowColor")!.Value,
                                ShadowSigma = Convert.ToSingle(childTag.Attribute("ShadowSigma")!.Value, CultureInfo.InvariantCulture),
                                StartDuration = childTag.Attribute("StartDuration")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("EndDuration")!.Value.ToTimeSpan()
                            });
                            break;
                        }
                    case "TextWithShadow":
                        {
                            objects.Add(new Text
                            {
                                Value = childTag.Attribute("Content")!.Value,
                                X = Convert.ToSingle(childTag.Attribute("X")!.Value, CultureInfo.InvariantCulture),
                                Y = Convert.ToSingle(childTag.Attribute("Y")!.Value, CultureInfo.InvariantCulture),
                                Width = Convert.ToInt32(childTag.Attribute("Width")!.Value),
                                Height = Convert.ToInt32(childTag.Attribute("Height")!.Value),
                                Color = childTag.Attribute("Color")!.Value,
                                FontSize = Convert.ToInt32(childTag.Attribute("Size")!.Value),
                                FontName = childTag.Attribute("Font")!.Value,
                                ShadowColor = childTag.Attribute("ShadowColor")!.Value,
                                ShadowSigma = Convert.ToSingle(childTag.Attribute("Sigma")!.Value, CultureInfo.InvariantCulture),
                                StartDuration = childTag.Attribute("StartDuration")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("EndDuration")!.Value.ToTimeSpan()
                            });
                            break;
                        }
                    case "Fill":
                        {
                            objects.Add(new Fill
                            {
                                Color = childTag.Attribute("Color")!.Value,
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan()
                            });
                            break;
                        }
                    case "RectangleFill":
                        {
                            objects.Add(new RectangleFill
                            {
                                X = Convert.ToSingle(childTag.Attribute("X")!.Value, CultureInfo.InvariantCulture),
                                Y = Convert.ToSingle(childTag.Attribute("Y")!.Value, CultureInfo.InvariantCulture),
                                Width = Convert.ToInt32(childTag.Attribute("Width")!.Value),
                                Height = Convert.ToInt32(childTag.Attribute("Height")!.Value),
                                Color = childTag.Attribute("Color")!.Value,
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan()
                            });
                            break;
                        }
                    case "RectangleStroke":
                        {
                            objects.Add(new RectangleStroke
                            {
                                X = Convert.ToSingle(childTag.Attribute("X")!.Value, CultureInfo.InvariantCulture),
                                Y = Convert.ToSingle(childTag.Attribute("Y")!.Value, CultureInfo.InvariantCulture),
                                Width = Convert.ToInt32(childTag.Attribute("Width")!.Value),
                                Height = Convert.ToInt32(childTag.Attribute("Height")!.Value),
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                                Color = childTag.Attribute("Color")!.Value
                            });
                            break;
                        }
                    case "Image":
                        {
                            objects.Add(new Image
                            {
                                Path = childTag.Attribute("Path")!.Value,
                                Width = Convert.ToInt32(childTag.Attribute("Width")!.Value),
                                Height = Convert.ToInt32(childTag.Attribute("Height")!.Value),
                                X = Convert.ToInt32(childTag.Attribute("X")!.Value),
                                Y = Convert.ToInt32(childTag.Attribute("Y")!.Value),
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                                GaussianBlur = childTag.Attribute("GaussianBlur")!.Value == "True",
                                RotationDegrees = Convert.ToInt32(childTag.Attribute("RotationDegrees")!.Value),
                                Sigma = Convert.ToSingle(childTag.Attribute("Sigma")!.Value, CultureInfo.InvariantCulture)
                            });
                            break;
                        }
                    case "Effect":
                        {
                            objects.Add(new Effect
                            {
                                StartDuration = childTag.Attribute("Start")!.Value.ToTimeSpan(),
                                EndDuration = childTag.Attribute("End")!.Value.ToTimeSpan(),
                                Metadata = childTag.Attribute("Metadata")!.Value
                            });
                            break;
                        }
                    default:
                        throw new ProjectException($"Unrecognized child XML tag \"{name}\"");
                }
            }
        }

        return new TimelineProvider(imports.ToArray(), objects.ToArray(), effects.ToArray(), primaryVideo);
    }
}
