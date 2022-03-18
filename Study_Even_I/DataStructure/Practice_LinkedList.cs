using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // LinkedList : 리스트의 구조 단위인 노드들로 구성되고 각 노드들은 다른 노드에 대한 정보를 가지고 있어서 연결되어있는 형태의 리스트.
    //
    // 노드 : Linked List 의 단위 자료구조 
    // head : 가장 앞에있는 노드를 가리키는 포인터
    // tail : 가장 뒤에있는 노드를 가리키는 포인터
    // 
    // Singly linked list : 노드가 한 방향의 다른 노드와 연결되어있을때
    // Doubly linked list : 노드가 두 방향의 다른 노드들과 각각 연결되어있을 때
    //
    // 시간복잡도
    // 
    // 노드를 추가할 때 : O(1)
    // 노드를 삭제할 때 : O(1)
    // 특정 노드를 찾을 때 : O(n)
    // 
    
    internal class Practice_LinkedList
    {
        // doubly linked list 노드 구현
        // c# 에서는 포인터를 사용하지 않으므로 노드를 만들때 구조체로 사용하지않음
        //=================================================================
        class Node
        {
            public int id;
            public int value;
            public Node prev;
            public Node next;
        } Node head; Node tail; Node refNode;
        List<Node> nodes = new List<Node>();
        public void DoExample_Nodes()
        {
            int index = 0, flag = 0;
            while (flag == 0)
            {
                Console.WriteLine("Enter [(1) Input, (2) Print, (3) Update, (4) Delete, (5) Exit");
                index = Convert.ToInt32(Console.ReadLine());
                if (0 < index && index < 5)
                {
                    if (index == 1) Nodes_Input();
                    else if (index == 2) Nodes_Print();
                    else if (index == 3) Nodes_Update();
                    else if (index == 4) Nodes_Delete();
                }
                else
                    Console.WriteLine("Wrong command !");
            }
        }


        private void Nodes_Input()
        {
            Node tmpNode = new Node();
            refNode = nodes.FindLast(x => x.next == null);
            if(refNode != null) refNode.next = tmpNode;
            Console.WriteLine($"input id , value");
            Console.WriteLine($"id : ");
            tmpNode.id = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine($"value : ");
            tmpNode.value = Convert.ToInt32(Console.ReadLine());
            
            tmpNode.prev = refNode;
            nodes.Add(tmpNode);

            if (head == null)
                head = tmpNode;
            tail = tmpNode;
            Nodes_Print();
        }

        private void Nodes_Print()
        {
            Console.Write("nodes : ");
            foreach (Node node in nodes)
            {
                Console.Write($"({node.id},{node.value}),");
            }
            Console.WriteLine($"Head : ({head.id},{head.value}), Tail : ({tail.id},{tail.value})");
        }

        private void Nodes_Update()
        {
            int update_id, update_value;
            Console.WriteLine("Enter update id, value");
            Console.WriteLine("id to update : ");
            update_id = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("value to update : ");
            update_value = Convert.ToInt32( Console.ReadLine());
            refNode = head;
            while (refNode != null)
            {
                if (refNode.id == update_id)
                    refNode.value = update_value;
                refNode = refNode.next;
            }
            Nodes_Print();
        }

        private void Nodes_Delete()
        {
            int delete_id;
            Console.WriteLine("id to delete : ");
            delete_id = Convert.ToInt32( Console.ReadLine());
            refNode = head;
            if (refNode.id == delete_id)
            {
                head = refNode.next;
                nodes.Remove(refNode);
                Nodes_Print();
                return;
            }
            while (refNode != null)
            {
                tail = refNode;
                refNode = refNode.next;
                if (refNode.id == delete_id)
                {
                    tail.next = refNode.next;
                    refNode.next.prev = tail;
                    nodes.Remove(refNode);
                    while (tail.next != null)
                    {
                        tail = tail.next;
                    }
                    Nodes_Print();
                    return;
                }
            }
        }


        // C# LinkedList 멤버 써보기
        //================================================================
        LinkedList<int> linkedList = new LinkedList<int>();

        public void DeExample_LinkedList()
        {
            linkedList.AddFirst(0);
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            Console.WriteLine("Added 0,1,2 at First");
            LL_Print();

            linkedList.AddLast(4);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            Console.WriteLine("Added 4,3,2 at Last");
            LL_Print();

            LinkedListNode<int> found2 = linkedList.Find(2);
            linkedList.Remove(found2);
            Console.WriteLine("Found 2 and removed it");
            LL_Print();

            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(2);
            Console.WriteLine("Added 2,3,2 at Last");
            LinkedListNode<int> foundLast2 = linkedList.FindLast(2);
            linkedList.Remove(foundLast2);
            Console.WriteLine("Found last 2 and removed it");
            LL_Print();

            linkedList.RemoveFirst();
            Console.WriteLine("Removed first");
            LL_Print();

            linkedList.RemoveLast();
            Console.WriteLine("Removed last");
            LL_Print();

            LinkedListNode<int> found4 = linkedList.Find(4);
            linkedList.AddBefore(found4, 5);
            Console.WriteLine("added 5 before 4");
            LL_Print();

            linkedList.AddAfter(found4, 6);
            Console.WriteLine("added 6 after 4");
            LL_Print();

            linkedList.Append(6);
            Console.WriteLine("Appended 6");
            LL_Print();

            Console.WriteLine($"Next of 4 : {found4.Next}");
            Console.WriteLine($"Previous of 4 : {found4.Previous}");

            Console.WriteLine($"linked list contains 2 ? {linkedList.Contains(2)}") ;

            linkedList.Clear();
            Console.WriteLine("is cleared");
            LL_Print();
        }


        private void LL_Print()
        {
            Console.Write("linked list : ");
            foreach (var item in linkedList)
                Console.Write($"{item},");
            Console.WriteLine();
        }

    }
}
