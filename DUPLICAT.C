#include<stdio.h>
#include<conio.h>
void main()
{
int i,rang,j;
int a[100];
clrscr();
printf("Enter the range");
scanf("%d\n", & rang);
for(i=0; i<rang; i++)
{
 printf("enter the element");
 scanf("%d\n", & a[i]);
 }
  for(i=0; i<rang; i++)
  for(j=i+1; j<rang; j++)
  {
  if(a[i] == a[j])
  {
  printf("%d\n", a[i]);
  }
  }
  getch();
  }

















