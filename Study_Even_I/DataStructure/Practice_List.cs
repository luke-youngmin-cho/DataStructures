using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // List
    // 제네릭 동적 배열. 
    // 데이터의 수가 현재 크기를 초과할 경우 메모리할당량을 증가시킴.
    //
    // 시간복잡도 :
    // - 추가 : ADD() 는 가장 마지막에 추가하므로 O(1), Insert() 는 특정 인덱스에 추가한 후 나머지 
    //           요소들을 뒤로 밀어내야하므로 O(n) 이 걸림.
    // - 검색 : O(n)
    // - 삭제 : O(n)
    // - 인덱스 접근 : O(1)

    internal class Practice_List
    {
        public void DoExample()
        {
            List<int> list = new List<int>();
            Console.WriteLine("Added 1, 2 ");
            list.Add(1);
            list.Add(2);
            L_Print(list);
            Console.WriteLine("Inserted 3, 4 ");
            list.Insert(0, 3);
            list.Insert(1, 4);
            L_Print(list);

            int removeTargetValue = 5;
            int first1 = list.Find(x => x == removeTargetValue);
            if (list.Remove(first1))
            {
                Console.WriteLine($"Removed {removeTargetValue}");
                L_Print(list);
            }
            else
                Console.WriteLine($"Failed to remove {removeTargetValue}");
            L_Print(list);
            int removeTargetIndex = 0;
            list.RemoveAt(removeTargetIndex);
            Console.WriteLine($"Removed index {removeTargetIndex}");
            L_Print(list);
            Console.WriteLine("Added 4, 3, 4 ");
            list.Add(4);
            list.Add(3);
            list.Add(4);
            L_Print(list);

            int removeLastTargetValue = 4;
            int last3 = list.FindLast(x => x == removeLastTargetValue);
            if (list.Remove(last3))
            {
                Console.WriteLine($"Removed {removeLastTargetValue}");
                L_Print(list);
            }
            else
                Console.WriteLine($"Failed to remove {removeLastTargetValue}");

            int removeLastTarget = 4;
            int lastIndex3 = list.LastIndexOf(removeLastTarget);
            list.RemoveAt(lastIndex3);
            Console.WriteLine($"Removed last of {removeLastTarget}");
            L_Print(list);

            int targetValue = 4;
            int indexOfTargetValue = list.IndexOf(targetValue);
            Console.WriteLine($"{targetValue} is at index of {indexOfTargetValue}");
            list.Clear();
            L_Print(list);
        }


        private void L_Print(List<int> list)
        {
            Console.Write($"list elements total {list.Count} :");
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]},");
            Console.WriteLine();
        }
    }
}
