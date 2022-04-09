using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{

    // 레드블랙트리
    // 빨간색 과 검은색 노드로 구성되는 이진트리
    // 새로운 노드가 들어올때는 빨간색으로 간주하고, 
    // 레드의자식이 레드가 되는 상황을 더블레드 라고하고
    // 이 더블레드 상황에서는 노드를 재배치하여 균형을 맞춘다.
    // 루트 노드는 블랙이어야 하며, 더블 블랙은 허용된다.
    // 
    // 새로 들어온 레드노드의 부모의 부모의 자식노드를 삼촌노드 라고하면 
    // 삼촌 노드가 블랙이면 Restructing
    // 삼촌 노드가 레드면 Recoloring 

    // 새로 들어온 레드노드를 N, 부모노드를 P, 조상노드를 G, 삼촌노드를 U 라 했을떄
    // 
    // Restructing 은
    // 1. N, P, G 를 오름차순 정렬함
    // 2. 셋 중 중간값을 G 위치에 놓고 나머지 둘을 각각 P, U 위치에 둔다.
    // 3. P의 색을 블랙으로 바꾸고 P, U 를 레드로 바꾼다 (P의 자식 둘을 레드로 바꿈)
    //
    // Recoloring 은
    // P, U 를 블랙으로 바꾸고 G 는 레드로 바꾼다. 
    // G 가 루트이면 블랙으로 바꾼다.
    // 더블레드가 없어질때까지 반복한다.

    internal class Practice_RedBlackTree
    {
    }
}
