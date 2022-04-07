using MoreLinq;

namespace TreeStructure;

public class TypesTree
{
    public  Node<Type> Root { get; }
    public TypesTree(Type root)
    {
        Root = new Node<Type>(root);
    }

    public void AddType( Type child)
    {
        AddType(Root,child);
    }
    public void AddType(Node<Type> root,Type child)
    {
        var target = root.Children.FirstOrDefault(node => node.Root.IsAssignableFrom(child));
        if (target == null)
        {
            var child1 = new Node<Type>(child);

            root.Children.Where(node => node.Root.IsAssignableTo(child)).ToList().ForEach(node =>
            {
                child1.Children.Add(node);
                root.Children.Remove(node);
            });
            root.AddChild(child1);
        }
        else
        {
            AddType(target, child);
        }
    }
    public IEnumerable<Node<Type>> Find(Type type)
    {
        var target = Root.Children.FirstOrDefault(rootChild => rootChild.Root.IsAssignableFrom(type));
        return target == null ? Enumerable.Empty<Node<Type>>() : new[] { target }.Union(Find(target, type));
    }
    public IEnumerable<Node<Type>> Find(Node<Type> root,Type type)
    {
        var target = root.Children.FirstOrDefault(rootChild => rootChild.Root.IsAssignableFrom(type));
        return target == null ? Enumerable.Empty<Node<Type>>() : new[] { target }.Union(Find(target, type));
    }


}