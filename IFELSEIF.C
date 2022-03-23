#include<stdio.h>
#include<conio.h>
void main()
{
  int marks;
  clrscr();
  printf("enter the marks");
  scanf("%d", &marks);
  if(marks==100)
  {
    printf("genius");
  }
  else if(marks>=80 && marks<100)
   {
      printf("topper");
   }
   else if(marks>=60 && marks<=79)
   {
     printf("first");
   }
   else
   {
     printf("average student");
   }
   getch();
 }