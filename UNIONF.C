#include<stdio.h>
#include<conio.h>
union student{
int x;
char y;
float z;
};
void main()
{
union student a;
clrscr();
a.x = 12;
a.y ='c';
printf("%c\n%d",a.y,a.x);
getch();
}