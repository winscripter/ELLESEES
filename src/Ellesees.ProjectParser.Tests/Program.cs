using Ellesees.ProjectParser;
using Ellesees.ProjectParser.ProjectInfo.ImageObjectModels;

var project = new Project($"proj_info");
Console.WriteLine(((Text)project.Provider.Models.Where(x => x is Text).First()).Width);
