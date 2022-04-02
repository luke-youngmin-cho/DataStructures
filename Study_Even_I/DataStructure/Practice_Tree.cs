using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // 트리 ( Tree ) :
    //
    // 부모-자식 계층 구조를 표현하는 자료구조
    // 루트 노드 ( root node ) : 부모가 없는 최상위 노드
    // 단말 노드 ( leaf node ) : 자식이 없는 최하위 노드
    // 크기 ( size ) : 트리에 포함된 모든 노드 개수
    // 깊이 ( depth ) : 루트 노드부터의 거리
    // 높이 ( height ) : 깊이 중 최댓값
    // 차수 ( degree ) : 각 노드의 자식방향 간선 개수
    // 
    // 트리의 크기가 N 이면 전체 간선 개수는 N-1 개
    //
    // 이진탐색 트리 ( Binary Search Tree )
    // 
    // 부모 노드 값보다 작은 노드를 한 방향에 배치하고 큰 노드를 반대 방향으로 배치하고 
    // 이 행위를 모든 노드에 대해 구현함
    // 일반적인 콜렉션의 탐색은 시간복잡도가 O(N) 이지만 
    // 이진 탐색 트리는 
    // 현재 노드값과 크기를 비교해서 작으면 작은노드로, 크면 큰노드로 탐색을 이어나가는 방식이기때문에 
    // 탐색시간이 2^N에 반비례 하므로 시간 복잡도가 O(log_2 N) 임.(이상적인 이진트리일 경우에 한해서)
    // 삽입도 크기비교하여(탐색하여) 진행하므로 시간복잡도는 동일

    // 삭제시
    // 삭제할 노드 검색에 O(LogN) , 
    // 삭제할 노드를 대체할 자식 노드를 검색하는데 O(LogN) 이므로 
    // O(2LogN) = O(LogN)

    internal class Practice_Tree
    {
        public class BinaryTree<T> 
        { 
            public class Node<K>
            {
                public K value;
                public Node<K> left;
                public Node<K> right;
            }
            Node<T> root, tmp, tmp2;


            // O(n)
            public Node<T> Find(T item)
            {
                if (root != null)
                {
                    tmp = root;

                    while (tmp != null)
                    {
                        if (Comparer<T>.Default.Compare(item, tmp.value) < 0)
                            tmp = tmp.left;
                        else if (Comparer<T>.Default.Compare(item, tmp.value) > 0)
                            tmp = tmp.right;
                        else
                            return tmp;
                    }
                }
                return null;
            }

            // O(n)
            public void Add(T item)
            {
                if (root != null)
                {
                    tmp = root;
                    while (tmp != null)
                    {
                        if (Comparer<T>.Default.Compare(item, tmp.value) < 0)
                        {
                            if (tmp.left != null)
                                tmp = tmp.left;
                            else
                            {
                                tmp.left = new Node<T>(); 
                                tmp.left.value = item;
                                return;
                            }
                                
                        }
                        else if (Comparer<T>.Default.Compare(item, tmp.value) > 0) 
                        { 
                            if (tmp.right != null)
                                tmp = tmp.right;
                            else
                            {
                                tmp.right = new Node<T>(); 
                                tmp.right.value = item;
                                return;
                            }   
                        }
                        else
                            throw new Exception("해당 값의 노드가 이미 존재함");
                    }                    
                }
                else
                {
                    root = new Node<T>();
                    root.value = item;
                }
            }

            // O(logN)
            public bool Delete(T item)
            {
                bool isOK = false;
                if (root != null)
                {
                    tmp = root;

                    while (tmp != null)
                    {
                        if (Comparer<T>.Default.Compare(item, tmp.value) < 0)
                            tmp = tmp.left;
                        else if (Comparer<T>.Default.Compare(item, tmp.value) > 0)
                            tmp = tmp.right;
                        else // found
                        {
                            isOK = true;
                            break;
                        }
                    }

                    if (isOK)
                    {
                        if (tmp.left == null && tmp.right == null)
                            tmp = null;
                        else if (tmp.left == null && tmp.right != null)
                            tmp = tmp.right;
                        else if (tmp.left != null && tmp.right == null)
                            tmp = tmp.left;
                        else
                        {
                            // 오른쪽 자식노드로부터 가장 왼쪽 노드찾기
                            tmp2 = tmp.right;
                            while (tmp2.left != null)
                            {
                                tmp2 = tmp2.left;
                            }
                            tmp2.left = tmp.left;
                            tmp2.right = tmp.right;                            
                            tmp = tmp2;
                        }
                    }

                }
                return isOK;
            }

            public void DoExample()
            {
                Console.WriteLine("-------- 이진트리 구현 테스트 --------");
                BinaryTree<int> bt = new BinaryTree<int>();
                bt.Add(0);
                bt.Add(1);
                bt.Add(2);
                bt.Add(3);
                bt.Add(5);
                bt.Add(4);
                bt.Add(8);
                Console.WriteLine($"root value : {bt.root.value}");
                Console.WriteLine($"root - right value : {bt.root.right.value}");
                var node = bt.Find(2);
                if (node != null)
                    Console.WriteLine("2 founded");

                if(bt.Delete(5))
                    Console.WriteLine("5 deleted!");

                node = bt.Find(8);
                if (node != null)
                    Console.WriteLine("8 founded");

            }
        }
        
    }
}
