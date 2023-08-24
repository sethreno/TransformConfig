using Microsoft.Web.XmlTransform;

if (args.Length != 3)
{
    Console.WriteLine($"error: missing args, expected: 3, actual: {args.Length}");
    Console.WriteLine("");
    Console.WriteLine("usage: transform-config [source] [transform] [output]");
    Console.WriteLine("");
    Console.WriteLine("example: transform-config Web.config Web.Debug.config Out.config");
    Environment.Exit(1);
}

var source = args[0];
var transform = args[1];
var output = args[2];

Console.WriteLine($"transforming {source} using {transform} into {output}");

var document = new XmlTransformableDocument
{
    PreserveWhitespace = true
};
document.Load(source);

var transformation = new XmlTransformation(transform);
if (!transformation.Apply(document))
{
    throw new Exception("Transformation Failed");
}
document.Save(output);
