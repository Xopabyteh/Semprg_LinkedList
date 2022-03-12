using Semprg_LinkedList;

DoubleLinkedList<double> list = new DoubleLinkedList<double>();

list.AddStart(2);
list.AddStart(3);
list.AddStart(4);
list.AddEnd(1);

list.Insert(5, 4);
list.AddBefore(4.5, 5);
list.Print();

Console.ReadLine();