#include <stdio.h>
#include <string.h>

int main(void) {
    char* a, b;

    a = &(*((char*)"this is fucking retarded"));
    b = &(*((int*)((char)0x41) + ((char)0x38)));

    printf("%s %d\n", a, b);
	return 0;
}
