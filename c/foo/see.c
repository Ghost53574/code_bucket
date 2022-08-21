#include <stdio.h>

int main(int argc, char *argv[]) {
	float *d = (float *)&argv[1];
	float *f = (float *)&argv[2];
	printf("1:%x 2:%x : 1 - 2 = %x\n",(char)&d,(char)&f,(char)(&d - &f));
	return 0;
}
