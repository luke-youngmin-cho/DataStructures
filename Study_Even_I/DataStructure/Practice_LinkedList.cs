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
    // head : 가장 앞에있는 노드
    // tail : 가장 뒤에있는 노드
    // 
    // Singly linked list : 노드가 한 방향의 다른 노드와 연결되어있을때
    // Doubly linked list : 노드가 두 방향의 다른 노드들과 각각 연결되어있을 때
    //
    
    public class Practice_LinkedList
    {
        // doubly linked list 노드 구현
        // c# 에서는 포인터를 사용하지 않으므로 노드를 만들때 구조체로 사용하지않음
        //=================================================================
        public class MyLinkedList<T> 
        {
            public class Node<K>
            {
                public K value;
                public Node<K> prev;
                public Node<K> next;
            }
            Node<T> head, tail, tmp, tmp2;

            public int count
            {
                get
                {
                    int tmpCount = 0;
                    tmp = head;
                    while (tmp != null)
                    {
                        tmp = tmp.next;
                        tmpCount++;
                    }
                    return tmpCount;
                }
            }

            // O(1)
            public void AddFirst(T value)
            {
                tmp = new Node<T>();
                tmp.value = value;
                if(head != null)
                {
                    tmp.next = head;
                    head.prev = tmp;
                }   
                if (tail == null)
                    tail = tmp;
                head = tmp;
                
            }

            // O(1)
            public void AddLast(T value)
            {
                tmp = new Node<T>();
                tmp.value = value;
                if(tail != null)
                {
                    tmp.prev = tail;
                    tail.next = tmp;
                }   
                if (head == null)
                    head = tmp;
                tail = tmp;
            }

            // O(n)
            public void AddBefore(Node<T> node, T value)
            {
                tmp = head;
                while (tmp != null)
                {
                    if(tmp == node)
                    {
                        tmp2 = new Node<T>();
                        if (tmp.prev != null)
                        {
                            tmp.prev.next = tmp2;
                            tmp2.prev = tmp.prev;
                        }                            
                        tmp.prev = tmp2;
                        tmp2.value = value;
                        tmp2.next = tmp;                        
                        return;
                    }
                    tmp = tmp.next;
                }
                return;
            }

            // O(n)
            public void AddAfter(Node<T> node, T value)
            {
                tmp = head;
                while (tmp != null)
                {
                    if (tmp == node)
                    {
                        tmp2 = new Node<T>();
                        if (tmp.next != null)
                        {
                            tmp.next.prev = tmp2;
                            tmp2.next = tmp.next;
                        }
                        tmp.next = tmp2;
                        tmp2.value = value;
                        tmp2.prev = tmp;
                        return;
                    }
                    tmp = tmp.next;
                }
                return;
            }

            // O(1)
            public T GetFirst()
            {
                if (head == null)
                    head = tail;
                return head.value;
            }

            // O(1)
            public T GetLast()
            {
                if (tail == null)
                    tail = head;
                return tail.value;
            }

            // O(n)
            public Node<T> Find(T value)
            {
                tmp = head;
                while(tmp != null)
                {
                    if (Comparer<T>.Default.Compare(value, tmp.value) == 0)
                        return tmp;
                    tmp = tmp.next;
                }
                return null;
            }

            // O(n)
            public Node<T> FindLast(T value)
            {
                tmp = tail;
                while (tmp != null)
                {
                    if (Comparer<T>.Default.Compare(value, tmp.value) == 0)
                        return tmp;
                    tmp = tmp.prev;
                }
                return null;
            }

            // O(n)
            public bool Remove(T value)
            {
                bool isRemoved = false;
                tmp = Find(value); // O(n)
                if (tmp != null)
                {
                    if(tmp.prev != null)
                        tmp.prev.next = tmp.next;
                    if(tmp.next != null)
                        tmp.next.prev = tmp.prev;
                    isRemoved = tmp == null ? false : true;
                }
                tmp = null; // Q. GC 가 알아서 힙 해제 해주므로 소멸자 강제호출 필요없이 이렇게만해도 되는것인지?
                return isRemoved;
            }

            // O(n)
            public bool RemoveLast(T value)
            {
                bool isRemoved = false;
                tmp = FindLast(value); // O(n)
                if (tmp != null)
                {
                    if (tmp.prev != null)
                        tmp.prev.next = tmp.next;
                    if (tmp.next != null)
                        tmp.next.prev = tmp.prev;
                    isRemoved = tmp == null ? false : true;
                }
                tmp = null; // Q. GC 가 알아서 힙 해제 해주므로 소멸자 강제호출 필요없이 이렇게만해도 되는것인지?
                return isRemoved;
            }

            // O(n)
            public Node<T>[] GetAllNodes()
            {
                Node<T>[] nodes = new Node<T>[count];
                tmp = head;
                for (int i = 0; i < nodes.Length; i++)
                {
                    nodes[i] = tmp;
                    tmp = tmp.next;
                }
                return nodes;
            }

            public void DoExample()
            {
                Console.WriteLine("-------- 링크드리스트 구현 테스트 --------");
                MyLinkedList<int> mll = new MyLinkedList<int>();
                mll.AddFirst(1);
                Console.WriteLine($"count : {mll.count}");
                mll.AddFirst(2);
                Console.WriteLine($"count : {mll.count}");
                mll.AddFirst(3);
                Console.WriteLine($"count : {mll.count}");
                mll.AddLast(0);
                mll.AddLast(7);
                mll.AddLast(9);
                mll.AddLast(8);
                foreach (var sub in mll.GetAllNodes()) Console.Write(sub.value);
                Console.WriteLine("0,7,9 added");
                Console.WriteLine($"count : {mll.count}");
                Console.WriteLine(mll.Find(0).value);
                mll.AddFirst(1);
                mll.AddFirst(2);
                mll.AddFirst(3);
                Console.WriteLine($"count : {mll.count}");
                foreach (var sub in mll.GetAllNodes()) Console.Write(sub.value);
                mll.AddLast(1);
                mll.AddLast(2);
                mll.AddLast(3);
                mll.AddLast(1);
                mll.AddLast(2);
                mll.AddLast(3);
                Console.WriteLine($"count : {mll.count}");
                MyLinkedList<int>.Node<int> node = mll.Find(1);
                if(node != null)
                {
                    Console.WriteLine("1 founded");
                    mll.AddBefore(node, 1);
                    mll.AddAfter(node, 1);
                }
                foreach (var sub in mll.GetAllNodes()) Console.Write(sub.value);
                Console.WriteLine();
                mll.Remove(1);
                mll.RemoveLast(1);
                foreach (var sub in mll.GetAllNodes()) Console.Write(sub.value);
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
