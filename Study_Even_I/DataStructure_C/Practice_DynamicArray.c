#include <stdio.h>
#include <stdlib.h>

void Add(int item);
int Remove(int item), RemoveAt(int index);
void Clear();

static const int DEFAULT_SIZE = 1;
int* data;
int count;
static int capacity;
static int* tmpData;

int main() {
	for (int i = 0; i < 1200; i++)
	{
		Add(0);
	}

	Add(3);
	Add(5);
	Add(5);
	Add(5);
	printf("%d\n", count);
	printf("%d\n", capacity);
	for (int i = 0; i < count; i++)
	{
		printf("%d", data[i]);
	}

	Clear();
	return 0;
}

void Add(int item)
{
	if (count == 0) {
		data = (int*)malloc(DEFAULT_SIZE * sizeof(int));
		capacity = DEFAULT_SIZE;
	}
	else if (count >= capacity)
	{
		tmpData = (int*)malloc(count * 2 * sizeof(int));
		capacity = count * 2;
		for (int i = 0; i < count; i++)
			tmpData[i] = data[i];
		free(data);
		data = (int*)malloc(count * 2 * sizeof(int));
		for (int i = 0; i < count; i++)
			data[i] = tmpData[i];
		free(tmpData);
	}
	data[count] = item;
	count++;
}

int Remove(int item)
{
	int isRemoved = 0;
	for (int i = 0; i < count; i++)
	{
		if (data[i] == item) {
			isRemoved = RemoveAt(i);
			break;
		}
	}
	return isRemoved;
}

int RemoveAt(int index)
{
	int isRemoved = 0;
	if (index < count - 1) {
		for (int i = index; i < count - 1; i++)
		{
			data[i] = data[i + 1];
		}
		//data[count - 1] = NULL;
		count--;
		isRemoved = 1;
	}
	return isRemoved;
}

void Clear()
{
	free(data);
	count = 0;
	capacity = 0;
}
