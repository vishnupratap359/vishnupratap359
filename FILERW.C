#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
void main()
{
 int i;
 char c[20];
FILE *p;
clrscr();
p=fopen("abc342.txt","w");
gets(c);
for(i=0;i<strlen(c);i++)
fputc(c[i],p);
fclose(p);
getch();
}