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
    // 시간복잡도 : 해시 함수에 따라 달라짐

    // object 로 저장하기때문에 박싱/언박싱과정이 필요함
    // 박싱은 단순 참조로 할당하는것 보다 20배까지 시간이 소모되고, 언박싱은 단순 값 할당보다 4배정도 시간이 소모되므로
    // 되도록 제네릭형태(Dictionary) 를 사용하는것이 좋다.
    //
    //
    // Key 를 위한 고유 index 를 생성하기위한 함수(해시 함수) 는 대표적으로 아래 4가지가 있음.
    // 1. Division Method : 입력값을 테이블의 크기로 나눈 값을 index 로 사용
    // 2. Digit Folding : 각 Key 의 문자열을 ASCII 코드로 바꾸고 값을 합한 데이터를 index 으로 사용
    // 3. Multiplication Method : 숫자로된 Key 값 * 0~1 사이 실수 % 1 * 2의 제곱수 로 index 생성
    // 4. Univeral Hashing : 다수의 해시함수를 만들어 집합 H 에 넣어두고, 무작위로 해시함수를 선택해서 해시값을 만듬.
    internal class Practice_HashTable
    {
        /// <summary>
        /// 해시테이블 구현
        /// 1. 모듈러 연산을 이용한 해시 키 연산
        /// 2. linkedlist 를 사용한 체이닝 방식으로 충돌 해결
        /// </summary>
        public class MyHashtable
        {
            const int DEFAULT_SIZE = 100;
            LinkedList<object>[] _bucket = new LinkedList<object>[DEFAULT_SIZE];
            int tmpHash;

            public void Add(object key, object value)
            {
                tmpHash = Hash(key.ToString());
                if(_bucket[tmpHash] == null)
                    _bucket[tmpHash] = new LinkedList<object>();
                _bucket[tmpHash].AddLast(value);
                Console.WriteLine($"{key} 가 해시키 {tmpHash} 로 추가되었습니다");
            }

            public bool Contains(object key)
            {
                tmpHash = Hash(key.ToString());
                if (_bucket[tmpHash].Count > 0)
                    return true;
                else
                    return false;
            }

            public bool ContainsKey(object key)
            {
                return Contains(key);
            }

            public bool ContainsValue(object value)
            {
                for (int i = 0; i < _bucket.Length; i++)
                {
                    for (int j = 0; j < _bucket[j].Count; j++)
                    {
                        if (_bucket[j].Find(value) != null)
                            return true;
                    }
                }
                return false;
            }

            public bool Remove(object key)
            {
                tmpHash = Hash(key.ToString());
                if(_bucket[tmpHash].Count > 0)
                {
                    _bucket[tmpHash].Clear();
                    return true;
                }
                else
                    return false;
            }

            public void Clear()
            {
                for (int i = 0; i < _bucket.Length; i++)
                {
                    if(_bucket[i] != null)
                        _bucket[i].Clear();
                }
            }

            private int Hash(string objName)
            {
                tmpHash = 0;
                for (int i = 0; i < objName.Length; i++)
                {
                    tmpHash += objName[i];
                }
                tmpHash %= DEFAULT_SIZE;
                return tmpHash;
            }
        }

        public void DoExample()
        {
            MyHashtable myHashTable = new MyHashtable();
            myHashTable.Add("수소", "Hydrogen");
            myHashTable.Add("산소", "Oxygen");
            myHashTable.Add("염소", "Chlorine");

            if (myHashTable.Contains("산소"))
            {
                myHashTable.Remove("산소");
                Console.WriteLine("Removed [산소] ");
            }


            myHashTable.Clear();
        }
    }
}
