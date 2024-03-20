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

using Ellesees.ProjectParser;
using Ellesees.ProjectParser.ProjectInfo;
using Ellesees.ProjectParser.ProjectInfo.Abstractions;
using Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;
using ElleseesUI.EX;
using ElleseesUI.ReadOnly;
using System.Text;

namespace ElleseesUI.Extensions;

/// <summary>
/// Extensions for <see cref="TimelineProvider" />.
/// </summary>
internal static class TimelineProviderExtensions
{
    /// <summary>
    /// Saves <see cref="TimelineProvider" /> into its XML Document.
    /// </summary>
    /// <param name="provider">Input <see cref="TimelineProvider" />.</param>
    /// <param name="path">Output path.</param>
    /// <param name="primaryVideo">Path to primary video.</param>
    public static void Save(this TimelineProvider provider, string path, string primaryVideo)
    {
        StringBuilder sb = new();

        sb.AppendLine(XmlStringConstants.Header);
        sb.AppendLine("<!-- Auto-generated by ELLESEES.");
        sb.AppendLine("     Do not make changes to this file. You may damage the project. Keep it as is. -->");
        sb.AppendLine("<ProjectTimeline>");

        sb.AppendLine("<!--");
        sb.AppendLine("      IMPORTS");
        sb.AppendLine("-->");

        sb.AppendLine();

        sb.AppendLine($"    <PrimaryVideo Path=\"{primaryVideo}\" />");

        foreach (var import in provider.Imports)
        {
            if (import is AudioImport audioImport)
            {
                sb.AppendLine($"    <AudioImport Type=\"Mp3\" Path=\"{audioImport.Path}\" Start=\"{audioImport.StartDuration.Stringify()}\" End=\"{audioImport.EndDuration.Stringify()}\" />");
            }
            else if (import is VideoImport videoImport)
            {
                sb.AppendLine($"    <VideoImport Type=\"Mp4\" Path=\"{videoImport.Path}\" Start=\"{videoImport.StartDuration.Stringify()}\" End=\"{videoImport.EndDuration.Stringify()}\" Speed=\"{videoImport.Speed}\" AllowAudio=\"{videoImport.AllowAudio.ToString().ToLower()}\" />");
            }
            else if (import is ImageImport imageImport)
            {
                sb.AppendLine($"    <ImageImport Type=\"Png\" Path=\"{imageImport.Path}\" Start=\"{imageImport.StartDuration.Stringify()}\" End=\"{imageImport.EndDuration.Stringify()}\" />");
            }
        }

        sb.AppendLine("<!--");
        sb.AppendLine("      MODELS");
        sb.AppendLine("-->");

        sb.AppendLine();

        foreach (var model in provider.Models)
        {
            if (model is Effect effect)
            {
                sb.AppendLine($"    <Effect {StringifyDurations(effect)} Metadata=\"{effect.Metadata}\" />");
            }
            else if (model is Fill fill)
            {
                sb.AppendLine($"    <Fill {StringifyDurations(fill)} Color=\"{fill.Color}\" />");
            }
            else if (model is Image image)
            {
                sb.AppendLine($"    <Image {StringifyDurations(image)} X=\"{image.X}\" Y=\"{image.Y}\" Width=\"{image.Width}\" Height=\"{image.Height}\" GaussianBlur=\"{image.GaussianBlur}\" Sigma=\"{image.Sigma}\" RotationDegrees=\"{image.RotationDegrees}\" Path=\"{image.Path}\" />");
            }
            else if (model is RectangleFill rectangleFill)
            {
                sb.AppendLine($"    <RectangleFill {StringifyDurations(rectangleFill)} X=\"{rectangleFill.X}\" Y=\"{rectangleFill.Y}\" Width=\"{rectangleFill.Width}\" Height=\"{rectangleFill.Height}\" Color=\"{rectangleFill.Color}\" />");
            }
            else if (model is RectangleStroke rectangleStroke)
            {
                sb.AppendLine($"    <RectangleStroke {StringifyDurations(rectangleStroke)} X=\"{rectangleStroke.X}\" Y=\"{rectangleStroke.Y}\" Width=\"{rectangleStroke.Width}\" Height=\"{rectangleStroke.Height}\" Color=\"{rectangleStroke.Color}\" />");
            }
            else if (model is Text text)
            {
                sb.AppendLine($"    <Text {StringifyDurations(text)} X=\"{text.X}\" Y=\"{text.Y}\" Width=\"{text.Width}\" Height=\"{text.Height}\" Color=\"{text.Color}\" Content=\"{text.Value}\" ShadowColor=\"{text.ShadowColor}\" ShadowSigma=\"{text.ShadowSigma}\" Size=\"{text.FontSize}\" Font=\"{text.FontName}\" />");
            }

            static string StringifyDurations(IImageObjectModel model)
                => $"StartDuration=\"{model.StartDuration.Stringify()}\" EndDuration=\"{model.EndDuration.Stringify()}\"";
        }

        sb.AppendLine("</ProjectTimeline>");
        File.WriteAllText(path, sb.ToString());
    }

    /// <summary>
    /// Saves <see cref="TimelineProvider" /> into its XML Document, alongside with appending <paramref name="effects" />.
    /// </summary>
    /// <param name="provider">Input <see cref="TimelineProvider" />.</param>
    /// <param name="path">Output path.</param>
    /// <param name="effects">Effects XML string.</param>
    /// <param name="primaryVideo">Primary video.</param>
    public static void SaveWithEffects(this TimelineProvider provider, string path, string effects, string primaryVideo)
    {
        StringBuilder sb = new();

        sb.AppendLine(XmlStringConstants.Header);
        sb.AppendLine("<!-- Auto-generated by ELLESEES.");
        sb.AppendLine("     Do not make changes to this file. You may damage the project. Keep it as is. -->");
        sb.AppendLine("<ProjectTimeline>");

        sb.AppendLine("<!--");
        sb.AppendLine("      IMPORTS");
        sb.AppendLine("-->");

        sb.AppendLine();

        sb.AppendLine($"    <PrimaryVideo Path=\"{primaryVideo}\" />");

        foreach (var import in provider.Imports)
        {
            if (import is AudioImport audioImport)
            {
                sb.AppendLine($"    <AudioImport Type=\"Mp3\" Path=\"{audioImport.Path}\" Start=\"{audioImport.StartDuration.Stringify()}\" End=\"{audioImport.EndDuration.Stringify()}\" />");
            }
            else if (import is VideoImport videoImport)
            {
                sb.AppendLine($"    <VideoImport Type=\"Mp4\" Path=\"{videoImport.Path}\" Start=\"{videoImport.StartDuration.Stringify()}\" End=\"{videoImport.EndDuration.Stringify()}\" Speed=\"{videoImport.Speed}\" AllowAudio=\"{videoImport.AllowAudio.ToString().ToLower()}\" />");
            }
            else if (import is ImageImport imageImport)
            {
                sb.AppendLine($"    <ImageImport Type=\"Png\" Path=\"{imageImport.Path}\" Start=\"{imageImport.StartDuration.Stringify()}\" End=\"{imageImport.EndDuration.Stringify()}\" />");
            }
        }

        sb.AppendLine("<!--");
        sb.AppendLine("      MODELS");
        sb.AppendLine("-->");

        sb.AppendLine();

        foreach (var model in provider.Models)
        {
            if (model is Effect effect)
            {
                sb.AppendLine($"    <Effect {StringifyDurations(effect)} Metadata=\"{effect.Metadata}\" />");
            }
            else if (model is Fill fill)
            {
                sb.AppendLine($"    <Fill {StringifyDurations(fill)} Color=\"{fill.Color}\" />");
            }
            else if (model is Image image)
            {
                sb.AppendLine($"    <Image {StringifyDurations(image)} X=\"{image.X}\" Y=\"{image.Y}\" Width=\"{image.Width}\" Height=\"{image.Height}\" GaussianBlur=\"{image.GaussianBlur}\" Sigma=\"{image.Sigma}\" RotationDegrees=\"{image.RotationDegrees}\" Path=\"{image.Path}\" />");
            }
            else if (model is RectangleFill rectangleFill)
            {
                sb.AppendLine($"    <RectangleFill {StringifyDurations(rectangleFill)} X=\"{rectangleFill.X}\" Y=\"{rectangleFill.Y}\" Width=\"{rectangleFill.Width}\" Height=\"{rectangleFill.Height}\" Color=\"{rectangleFill.Color}\" />");
            }
            else if (model is RectangleStroke rectangleStroke)
            {
                sb.AppendLine($"    <RectangleStroke {StringifyDurations(rectangleStroke)} X=\"{rectangleStroke.X}\" Y=\"{rectangleStroke.Y}\" Width=\"{rectangleStroke.Width}\" Height=\"{rectangleStroke.Height}\" Color=\"{rectangleStroke.Color}\" />");
            }
            else if (model is Text text)
            {
                sb.AppendLine($"    <Text {StringifyDurations(text)} X=\"{text.X}\" Y=\"{text.Y}\" Width=\"{text.Width}\" Height=\"{text.Height}\" Color=\"{text.Color}\" Content=\"{text.Value}\" ShadowColor=\"{text.ShadowColor}\" ShadowSigma=\"{text.ShadowSigma}\" Size=\"{text.FontSize}\" Font=\"{text.FontName}\" />");
            }

            static string StringifyDurations(IImageObjectModel model)
                => $"StartDuration=\"{model.StartDuration.Stringify()}\" EndDuration=\"{model.EndDuration.Stringify()}\"";
        }

        sb.AppendLine();
        sb.AppendLine("<!--");
        sb.AppendLine("      EFFECTS");
        sb.AppendLine("-->");
        sb.AppendLine();

        sb.AppendLine(GetAndStringifyEffects(provider));
        sb.AppendLine(effects);
        sb.AppendLine();

        sb.AppendLine("</ProjectTimeline>");
        File.WriteAllText(path, sb.ToString());
    }

    /// <summary>
    /// Stringifies effects into XML line-by-line.
    /// </summary>
    public static string GetAndStringifyEffects(this TimelineProvider provider)
    {
        StringBuilder sb = new();

        foreach (var effect in provider.Effects)
        {
            sb.AppendLine($"    {EXSerializer.Serialize(effect)}");
        }

        return sb.ToString();
    }
}