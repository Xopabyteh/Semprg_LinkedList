using System.Text;

namespace Semprg_LinkedList;

public class DoubleLinkedList<T>
{
    private Node<T>? _firstNode;
    private Node<T>? _lastNode;
    public void AddStart(T item)
    {
        Node<T> newNode = new Node<T>(item)
        {
            NextNode = _firstNode
        };

        if (_firstNode != null)
        {
            _firstNode.PrevNode = newNode;
        }
        
        _firstNode = newNode;

        if (_lastNode == null)
        {
            _lastNode = _firstNode;
        }
    }


    public void AddEnd(T item)
    {
        Node<T> newNode = new Node<T>(item)
        {
            PrevNode = _lastNode
        };
        if (_lastNode != null)
        {
            _lastNode.NextNode = newNode;
        }

        _lastNode = newNode;
        if (_firstNode == null)
        {
            _firstNode = _lastNode;
        }
    }

    public void AddBefore(T itemToAdd, T beforeItem)
    {
        Node<T> newNode = new Node<T>(itemToAdd);
        Node<T>? prevBeforeNode = GetNodeWithValue(beforeItem);
        
        if(prevBeforeNode == null)
            return;

        if (prevBeforeNode == _firstNode)
        {
            AddStart(itemToAdd);
            return;
        }

        if (prevBeforeNode.PrevNode != null)
        {
            prevBeforeNode.PrevNode.NextNode = newNode;
            newNode.PrevNode = prevBeforeNode.PrevNode;
        }

        prevBeforeNode.PrevNode = newNode;
        newNode.NextNode = prevBeforeNode;
    }

    public void RemoveFirst()
    {
        if (_firstNode?.NextNode != null)
        {
            _firstNode.NextNode.PrevNode = null;
            _firstNode = _firstNode.NextNode;
        }
        else
        {
            _firstNode = null;
        }
    }

    public void RemoveLast()
    {
        if (_lastNode?.PrevNode != null)
        {
            _lastNode.PrevNode.NextNode = null;
            _lastNode = _lastNode.PrevNode;
        }
        else
        {
            _lastNode = null;
        }
    }

    public void Remove(T item)
    {
        Node<T>? node = GetNodeWithValue(item);
        if (node == null)
            return;

        if (node.NextNode != null)
        {
            node.NextNode.PrevNode = node.PrevNode;
        }

        if (node.PrevNode != null)
        {
            node.PrevNode.NextNode = node.NextNode;
        }
    }

    public bool Contains(T item)
    {
        return GetNodeWithValue(item) != null;
    }

    private Node<T>? GetNodeWithValue(T value)
    {
        Node<T>? currentNode = _firstNode;
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(value))
            {
                break;
            }
            currentNode = currentNode.NextNode;
        }

        return currentNode ?? null;
    }
    public int IndexOf(T item)
    {
        int i = 0;

        Node<T>? currentNode = _firstNode;
        while (currentNode != null)
        {
            if (currentNode.Value!.Equals(item))
            {
                return i;
            }
            currentNode = currentNode.NextNode;
            i++;
        }

        return -1;
    }

    public void Insert(T item, int index)
    {
        Node<T>? currentNode = _firstNode;
        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode?.NextNode;
            //If index out of bounds just add to the end
            if (currentNode == null)
            {
                AddEnd(item);
                return;
            }
        }

        Node<T> newNode = new Node<T>(item);
        if (currentNode?.PrevNode != null)
        {
            currentNode.PrevNode.NextNode = newNode;
            newNode.PrevNode = currentNode.PrevNode;
        }

        currentNode!.PrevNode = newNode;
        newNode.NextNode = currentNode;
    }

    public int Count()
    {
        int c = 0;
        Node<T>? currentNode = _firstNode;
        while (currentNode != null)
        {
            c++;
            currentNode = currentNode!.NextNode;
        }
        return c;
    }


    public void Print()
    {
        if (_lastNode == null)
            return;

        StringBuilder builder = new StringBuilder();
        Node<T>? currentNode = _firstNode;
        while (currentNode != _lastNode)
        {
            builder.Append($"|{currentNode!.Value}| ");
            currentNode = currentNode!.NextNode;
        }

        builder.Append($"|{_lastNode!.Value}|");
        Console.WriteLine(builder.ToString());
    }
}
