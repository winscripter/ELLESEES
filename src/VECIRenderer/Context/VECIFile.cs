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

namespace VECIRenderer.Context;

internal class VECIFile
{
    public const string Header = "ELLESEES VECI";
    internal string? _projectDir;
    public VECIProject? Project { get; set; } = null;
    public bool IsUnsaved { get; set; } = false;
    private readonly string _fileName;

    public VECIFile(VECIProject? project, string filename)
    {
        Project = project;
        _fileName = filename;
    }

    public VECIFile SetProjectDirectory(string path)
    {
        this._projectDir = path;
        return this;
    }

    public static VECIFile Load(string projectDir)
    {
        if (!File.Exists(Path.Combine(projectDir, "project.veci")))
        {
            throw new FileNotFoundException($"Project file project.veci can't be found.");
        }

        var reader = new BinaryReader(File.OpenRead(Path.Combine(projectDir, "project.veci")));

        var project = new VECIProject
        {
            Header = reader.ReadString(),
            DataDirectory = reader.ReadString(),
            MinimumElleseesVersion = reader.ReadSingle(),
            Tasks = ReadPairs(reader)
        };

        reader.Dispose();

        return new VECIFile(project, "project.veci").SetProjectDirectory(projectDir);
    }

    private static VECIPair[] ReadPairs(BinaryReader reader)
    {
        int length = reader.ReadInt32();

        List<VECIPair> pairs = new();

        for (int i = 0; i < length; i++)
        {
            pairs.Add(ReadPair(reader));
        }

        return pairs.ToArray();
    }

    private static VECIPair ReadPair(BinaryReader reader)
    {
        return new VECIPair
        {
            Type = reader.ReadUInt16(),
            Arguments = reader.ReadString()
        };
    }

    public bool DataFileExists(string fileName)
        => File.Exists(Path.Combine(Directory.GetCurrentDirectory(), this.Project!.Value.DataDirectory, Path.GetFileName(fileName)));

    public string[] GetData()
        => Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), this.Project!.Value.DataDirectory));

    public void SetTasks(VECIPair[] pairs)
    {
        this.Project = new()
        {
            DataDirectory = this.Project!.Value.DataDirectory,
            Header = this.Project.Value.Header,
            MinimumElleseesVersion = this.Project.Value.MinimumElleseesVersion,
            Tasks = pairs
        };

        this.IsUnsaved = true;
    }

    private static void WritePairs(VECIPair[] pairs, BinaryWriter bw)
    {
        bw.Write(pairs.Length);

        foreach (VECIPair pair in pairs)
        {
            bw.Write(pair.Type);
            bw.Write(pair.Arguments ?? string.Empty);
        }
    }

    public void Save()
    {
        File.Delete(Path.Combine(_projectDir!, _fileName));

        using (var fs = File.Create(Path.Combine(_projectDir!, _fileName)))
        {
        }

        using BinaryWriter bw = new(File.Open(Path.Combine(_projectDir!, _fileName), FileMode.Open), Encoding.UTF8, false);

        bw.Write(Header);
        bw.Write(this.Project!.Value.DataDirectory);
        bw.Write(this.Project!.Value.MinimumElleseesVersion);

        WritePairs(this.Project!.Value.Tasks, bw);
    }
}
