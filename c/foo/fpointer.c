#include <stdio.h>

//int (*Fpointer)(int);

int main(void) {
    int** temp;

    printf("Address: %p %x\n", (void*)&temp, temp);

    temp = (void*)(int(*))(10);
    printf("Address: %p %x\n", (void*)&temp, temp);
    printf("Address: %p %x\n", (void*)&temp, temp);
    return 0;
}
