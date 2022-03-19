using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DataStructure
{
    // Dictionary : Hashtable 을 제네릭으로 구현한 클래스
    //
    // 제네릭 타입이어서 Hashtable 과 다르게 boxing / unboxing 을 하지 않음.
    // key/ value 가 각각 한가지 타입을 가진다면 Dictionary 를 사용하고
    // 그렇지 않다면 Hashtable 을 사용한다.
    //
    // 시간복잡도
    // - 추가 : O(1)
    // - 검색 : O(1)
    // - 삭제 : O(1)
    // - 인덱스접근 : 검색시 Key 값으로 해시함수를 통해 인덱스 접근함
    //================================================================

    // C# Dictionary 멤버 써보기
    //================================================================
    internal class Practice_Dictionary
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        void DoExample_Dictionary()
        {
            dictionary.Add(1, 2);
            dictionary.Add(2, 3);
            dictionary.Add(3, 4);
            dictionary.Add(4, 5);
            dictionary.Add(5, 6);
            Dictionary_Print();
            dictionary.Remove(1);
            Console.WriteLine($"removed key 1");
            Dictionary_Print();
            Console.WriteLine($"dictionary includes key 2? : {dictionary.ContainsKey(2)}");
            Console.WriteLine($"dictionary includes value 4? : {dictionary.ContainsValue(4)}");
            int tmpValue = 0;
            if (dictionary.TryGetValue(3, out tmpValue)){
                Console.WriteLine($"got key 3's value( {tmpValue} ) in dicionary");
            }
            Console.WriteLine($"first element : {dictionary.First()}") ;
            Console.WriteLine($"min, max : {dictionary.Min()}, {dictionary.Max()}");
            Console.WriteLine($"is single ?: {dictionary.Single()}");
            Console.WriteLine($"last element: {dictionary.Last()}");
            dictionary.Clear();

        }

        void Dictionary_Print()
        {
            Console.Write("dictionary : ");
            foreach (var pair in dictionary)
                Console.Write($"({pair.Key},{pair.Value})");
            Console.WriteLine();
        }
    }
}
