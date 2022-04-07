namespace TreeStructure;

public class Node<T>
{
    public Node(T root)
    {
        Root = root;
    }

    public T Root { get; }
    public List<Node<T>> Children { get; } = new();

    public void AddChild(Node<T> child)=>this.Children.Add(child);
}