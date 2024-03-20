using Ellesees.Base;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

var image = Image.Load<Rgba32>("sillycat.jpg");

var obj = new ImageObject(image);
obj.Rotate(130);

obj.Image.Save("sillycatnew.jpg");
