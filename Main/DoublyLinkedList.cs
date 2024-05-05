namespace ConsoleApp1;

public class Node
{
    public TurnstileLogInfo Data;
    public Node Next;
    public Node Previous;

    public Node(TurnstileLogInfo data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }
}

public class DoublyLinkedList
{
    private Node head;
    private Node tail;

    public void Add(TurnstileLogInfo data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Previous = tail;
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void Display()
    {
        Node current = head;
        int i = 1;
        while (current != null)
        {
            Console.WriteLine($"{i}. Time: {current.Data.Time}, Action: {current.Data.Action}, Pass Name: {current.Data.GetPassName()}");
            current = current.Next;
            i++;
        }
    }

    public void Display(GateAction action)
    {
        Node current = head;
        int i = 1;
        while (current != null)
        {
            if (current.Data.Action == action)
            {
                Console.WriteLine($"{i}. Time: {current.Data.Time}, Action: {current.Data.Action}, Pass Name: {current.Data.GetPassName()}");
                i++;
            }
            current = current.Next;
        }
    }
}
