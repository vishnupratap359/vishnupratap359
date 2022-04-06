#include<stdio.h>
#include<conio.h>
void main()
{
 int a = 5;
 void *x;
 x = &a;
 clrscr();
 printf("%d",*(int*)x);
 getch();
 }
