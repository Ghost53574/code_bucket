#include <stdio.h>
#include <stdlib.h>
#define NIBBLE 4
#define BYTE 8

struct __data {
    int x: 8;
    int y: 8;
    int z: 8;
    int a: 8;
    int b: 8;
    int c: 8;
    int f: 8;
    int h: 8;
} t_data;

void _data(int i, int packed);
int _write(int pd, int d, int s);
int _read(int pd, int s);
void _writer(int pd, int d[], int s[], int size);
void _reader(int pd, int size);

void _data(int i, int packed) {
	printf("%i:\t%x\t10%u\n",i,packed,packed);
}

int _write(int pd, int d, int s) {
	unsigned int lpd;
	lpd = pd;
	lpd = lpd | d << s;
	return lpd;
}

int _read(int pd, int s) {
	unsigned int lpd;
	lpd = pd;
	return (lpd >> s) & 0xff;
}

void _wrier(int pd, int d[], int s[], int size) {
}

void _reader(int pd, int size) {
}

/*
	packed_data[32] = [8][8][8][8];
	packed_data = num1 num2 num3 num4
	num1 = 256
	num2 = 256
	num3 = 256
	num4 = 256
*/

int main() {
    struct __data* data = malloc((sizeof(struct __data) * 1));
	int i = 0;

    data->x = 127;
    data->y = 25;
    data->z = 3;
    data->a = 48;
    data->b = (-4);
    data->c = 69;
    data->f = 13;
    data->h = 8;
	
	printf("Address: %p\t-Value: %x %d\n", (void*)&data[0], data->x);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[4], data->y);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[16], data->z);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[24], data->a);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[32], data->b);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[40], data->c);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[48], data->f);
    printf("Address: %p\t-Value: %x %d\n", (void*)&data[56], data->h);
	return 0;
}
