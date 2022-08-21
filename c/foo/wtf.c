#include <stdio.h>

int * x(int*);

int main() {
	int a = (int)0x1337;
	return (int)(a && x((void*)a));
}

int * x(int * a) {
	return a;
}
