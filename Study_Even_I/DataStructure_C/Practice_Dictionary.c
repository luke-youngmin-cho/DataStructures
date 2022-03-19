#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Practice_Dictionary.h"

void DoExample_Dictionary() {
	dictionary dic;
	Dictionary_Init(&dic);
	Dictionary_Add(&dic, "key1", "value1");
	Dictionary_Add(&dic, "key2", "value2");
	Dictionary_Show(dic);
}

void Dictionary_Init(dictionary* dic) {
	if (dic == NULL) {
		dic = (dictionary*)malloc(sizeof(dictionary));
	}
}

void Dictionary_Show(dictionary dic) {
	_dictionary* tmp = dic.head;
	int i = 0;

	printf("total count : %d\n", dic.count);
	while (tmp != NULL) {
		printf("[%d] %s\n", i, tmp->key);
		i++; tmp = tmp->link;
	}
}

int Dictionary_Add(dictionary* head, char* key, void* value) {
	_dictionary* tmp = head->head;

	while (1)
	{
		// ����� �������
		if (head->count == 0) {
			tmp = (_dictionary*)malloc(sizeof(_dictionary));
			tmp->key = key;
			tmp->value = value;
			tmp->link = NULL;
			head->head = tmp;
			break;
		}
		// Ű�� �̹� �����Ҷ�
		else if (strcmp(tmp->key, key) == 0) {
			return 0;
		}
		// ���� ��尡 �������϶�
		else if (tmp->link == NULL) {
			tmp->link = (_dictionary*)malloc(sizeof(_dictionary));
			tmp->link->key = key;
			tmp->link->value = value;
			tmp->link->link = NULL;
			break;
		}
		// ���� ��尡 ������ ��
		else {
			tmp = tmp->link;
		}
	}
	head->count++;
	return 1;
}