using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    // HashTable
    // Key, Value 로 데이터를 저장하는 구조 . 
    // Key 값에 해시 함수를 적용해서 고유한 index 를 생성하고 이 index 로 value 에 접근함
    // 해당 index 가 가리키는 장소를 버킷 / 슬롯 이라고 함
    //
    // 시간복잡도 :
    // - 추가 : O(1)
    // - 검색 : O(1)
    // - 삭제 : O(1)
    // - 인덱스접근 : 검색시 해시함수를 통해 인덱스 접근함

    // object 로 저장하기때문에 박싱/언박싱과정이 필요함
    // 박싱은 단순 참조로 할당하는것 보다 20배까지 시간이 소모되고, 언박싱은 단순 값 할당보다 4배정도 시간이 소모되므로
    // 되도록 제네릭형태(Dictionary) 를 사요앟는것이 좋다.
    //
    //
    // Key 를 위한 고유 index 를 생성하기위한 함수(해시 함수) 는 대표적으로 아래 4가지가 있음.
    // 1. Division Method : 입력값을 테이블의 크기로 나눈 값을 index 로 사용
    // 2. Digit Folding : 각 Key 의 문자열을 ASCII 코드로 바꾸고 값을 합한 데이터를 index 으로 사용
    // 3. Multiplication Method : 숫자로된 Key 값 * 0~1 사이 실수 % 1 * 2의 제곱수 로 index 생성
    // 4. Univeral Hashing : 다수의 해시함수를 만들어 집합 H 에 넣어두고, 무작위로 해시함수를 선택해서 해시값을 만듬.
    internal class Practice_HashTable
    {
        Hashtable hashtable = new Hashtable();

        public void DoExample()
        {
            hashtable.Add("수소", "Hydrogen");
            hashtable.Add("산소", "Oxygen");
            hashtable.Add("염소", "Chlorine");

            if (hashtable.Contains("산소"))
            {
                hashtable.Remove("산소");
                Console.WriteLine("Removed [산소] ");
            }
            

            hashtable.Clear();
            Hashtable_Print();


        }
        private void Hashtable_Print()
        {
            Console.Write("Hashtable : ");
            foreach (var item in hashtable)
            {
                Console.Write($"({item},{hashtable[item]})");
            }
            Console.WriteLine();
        }
    }
}
