#include <stdio.h>

int main() {
    int a =50;
    int *b= &a;
    int **c=&b;
    int ***d=&c;
    printf("A%d,B=%x,C=%x,%d",a,b,*c,**d);
    
    return 0;
}