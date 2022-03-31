#include<stdio.h>
#include<conio.h>
void main()
{
 int x = 0;
 # ifdef fact
 x = 12;
 clrscr();
 printf("%d",x);
 #else
 scanf("%d",&x);
 printf("%d", x);
 #endif
 getch();
 }