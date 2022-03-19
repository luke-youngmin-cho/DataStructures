#pragma once
typedef struct _Dictionary {
	char* key;
	void* value;
	struct _Dictionary* link;
}_dictionary;

typedef struct Dictionary {
	int count;
	struct _Dictionary* head;
}dictionary;

void Dictionary_Init(), Dictionary_Show(dictionary dic), DoExample_Dictionary();
int Dictionary_Add(dictionary* head, char* key, void* value);