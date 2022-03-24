#include <stdio.h>

int main() {
   int a=50;
   int *b=&a;
   int **c=&b;
   int ***d=&c;
   int *x, **y;
   x=&a;
   y=&x;
   ***d=12;
   printf("A%d\n",a);
    
    return 0;
}