 #include<stdio.h>
 #include<conio.h>
 struct student{
 int x;
 char y;
 float z;
 };
 void main()
 {
  struct student a;
  clrscr();
  a.x = 15;
  a.y = 'c';
  printf("%c\n%d",a.y,a.x);
  getch();
  }