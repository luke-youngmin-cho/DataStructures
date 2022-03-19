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

    // 삭제시..? 는 아직 이해가 되지않음

    internal class Practice_Tree
    {
        public class TreeNode<T> //: IEnumerable<TreeNode<T>>
        {
            public T Data { get; set; }
            public TreeNode<T> Parent { get; set; }
            public ICollection<TreeNode<T>> Children { get; set; }

            public TreeNode(T data)
            {
                this.Data = data;
                this.Children = new LinkedList<TreeNode<T>>();
            }

            public TreeNode<T> AddChild(T child)
            {
                TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
                this.Children.Add(childNode);
                return childNode;
            }

        }

        public void DoExample_Tree()
        {
            TreeNode<string> root = new TreeNode<string>("root");
            {
                TreeNode<string> node0 = root.AddChild("node0");
                TreeNode<string> node1 = root.AddChild("node1");
                TreeNode<string> node2 = root.AddChild("node2");
                {
                    TreeNode<string> node20 = node2.AddChild(null);
                    TreeNode<string> node21 = node2.AddChild("node21");
                    {
                        TreeNode<string> node210 = node21.AddChild("node210");
                        TreeNode<string> node211 = node21.AddChild("node211");
                    }
                }
                TreeNode<string> node3 = root.AddChild("node3");
                {
                    TreeNode<string> node30 = node3.AddChild("node30");
                }
            }
        }

    }
}
