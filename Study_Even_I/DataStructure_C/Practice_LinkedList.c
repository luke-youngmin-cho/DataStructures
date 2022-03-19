#include <stdio.h>
#include <stdlib.h>
#include "Practice_LinkedList.h"

struct Node {
	int id;
	int value;
	struct Node *next;
} *head, *tail, *ptr;

int DoExample_LinkedList() {
	head = NULL;
	int index, flag = 0;
	while (flag == 0) {
		printf("Enter [(1) Input, (2) Print, (3) Update, (4) Delete, (5) Exit");
		scanf_s("%d", &index);
		if (index == 1) LL_Input();
		else if (index == 2) LL_Print();
		else if (index == 3) LL_Update();
		else if (index == 4) LL_Delete();
		else if (index == 5) LL_Exit();
	}
	return 0;
}

void LL_Input() {
	int in_id, in_value;
	printf("\tid, value :"); scanf_s("%d %d", &in_id, &in_value);
	ptr = (struct Node *)malloc(sizeof(struct Node));
	if (head == NULL) { head = ptr; }
	else { tail->next = ptr; }
	ptr->id = in_id;
	ptr->value = in_value;
	ptr->next = NULL;
	tail = ptr;
	LL_Print();
}

void LL_Print() {
	ptr = head;
	printf("(id, value) :");
	while (ptr != NULL) {
		printf("(%d, %d)", ptr->id, ptr->value);
		ptr = ptr->next;
	}
	printf("\n");
}

void LL_Update() {
	int update_id, update_value;
	printf("\tid for update: "); scanf_s("%d", &update_id);
	ptr = head;
	while (ptr != NULL){
		if (ptr->id == update_id) {
			printf("\tEnter the value for this id : ");
			scanf_s("%d", &update_value);
			ptr->value = update_value;
			LL_Print();
			return;
		}
		ptr = ptr->next;
	}
}

void LL_Delete() {
	int delete_id;
	printf("\tid for delete : "); scanf_s("%d", &delete_id);
	ptr = head;
	if (ptr->id == delete_id) {
		head = ptr->next;
		free(ptr);
		LL_Print();
		return;
	}
	while (ptr != NULL) {
		tail = ptr;
		ptr = ptr->next;
		if (ptr->id == delete_id) {
			tail->next = ptr->next;
			free(ptr);
			while (tail->next != NULL) {
				tail = tail->next;
			}
			LL_Print();
			return;
		}
	}
}

void LL_Exit() {
	
}