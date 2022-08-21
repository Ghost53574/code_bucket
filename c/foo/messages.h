#ifndef messages_h
#define messages_h
#endif

#define INFO(msg)
#define WARN(msg)
#define EROR(msg)

void _print(int n, char* msg) {
    switch(n) {
        case 0:
            INFO(msg) 
        case 1:
            WARN(msg) 
        case 2:
            EROR(msg) 
        default:
            //should not get here
            break;
    }
}
