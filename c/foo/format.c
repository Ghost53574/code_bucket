#include <stdio.h>
#include <stdlib.h>

void _print(int len, char *val[]);
void __print(int len, char val);

void _print(int len, char *val[]) {
	printf("Value:%s,\tLength:%u\n",val,len);
}

void __print(int len, char val) {
	printf("Value:%c,\tCount:%u\n",val,len);
}

int main(int argc, char *argv[]) {
	int i = 0, k = 0;
	for (i = 0; i < argc; ++i) {
		_print(i, argv[i]);
		char s[] = argv[i];
		do {
			__print(k, (char)s[k]);
			++k;
		} while (&argv[i] != '\0');
	}
	return 0;
}
