#include<stdio.h>
#include<conio.h>
int add(int a=5,int b=10)
{
 return a+b;
 }
  void main()
  {
   int x,y,n,i,c;
   clrscr();
   printf("enter the vlaue of n");
   scanf("%d", &n);
   for(i=0;i<n;i++);
   {
    scanf("%d%d", &x,&y);
    c=add(x,y);
    printf("%d", c*c);
    getch();
    }
    }