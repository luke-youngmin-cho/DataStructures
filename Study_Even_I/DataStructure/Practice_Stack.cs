using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // Stack
    // 후입선출 시스템
    //
    // 시간복잡도 
    // 추가 : O(1) 
    // 검색 : 불가능
    // 삭제 : O(1)
    // 인덱스 접근 : 불가능
    internal class Practice_Stack
    {
        Stack<int> stack = new Stack<int>();

        public void DoExample_Stack()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Console.WriteLine($"Head is {stack.Peek()}");
            stack.Pop();
            stack.Pop();
            Console.WriteLine($"Head is {stack.Peek()}");
            stack.Clear();
        }
    }
}
