// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Diagnostics.Windows.Configs;
using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis.CSharp;
using TreeStructure;

var tree=new TypesTree(typeof(object));
tree.AddType(typeof(Student));
tree.AddType(typeof(FemaleGraduateStudent));
tree.AddType(typeof(GraduateStudent));
tree.AddType(typeof(UniverstyStudent));
tree.AddType(typeof(MaleGraduateStudent));
tree.AddType(typeof(MaleUniverstyStudent));
tree.AddType(typeof(FemaleUniverstyStudent));

Print(tree.Root);
Console.WriteLine();
Console.WriteLine(string.Join("->",tree.Find(typeof(UniverstyStudent)).Select(node =>node.Root.Name )));
static void Print(Node<Type> tree,int level=1)
{
    foreach (var rootChild in tree.Children)
    {
        for (int l = 0; l < level; l++)
        {
            Console.Write("\t");
        }
        Console.WriteLine(rootChild.Root.Name);
        if (rootChild.Children.Any())
        {
            Print(rootChild,level+1);
        }
    }
}

