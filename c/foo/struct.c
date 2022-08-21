#include <stdio.h>

typedef struct {
	int x;
	int y;
	int z;
} Point;

int main() {
	Point thing = { 0, 0, 0 };
	printf("[%p] 0:%d 1:%d 2:%d\n",(void*)&thing, thing.x, thing.y, thing.z);
	return 0;
}
