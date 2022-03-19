using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // Queue
    // 선입선출 시스템
    //
    // 시간복잡도 
    // 추가 : O(1) 
    // 검색 : 불가능
    // 삭제 : O(1)
    // 인덱스 접근 : 불가능
    internal class Practice_Queue
    {
        Queue<int> queue = new Queue<int>();
        public void DoExample()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine($"head :  {queue.Peek()}");
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine($"head :  {queue.Peek()}");
            queue.Clear();
        }
    }
}
