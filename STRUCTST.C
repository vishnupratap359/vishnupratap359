#include<stdio.h>
#include<conio.h>
struct student{
int roll;
char name[20];
char grade;
float subject [4];
};
void display (struct student x)
{
 printf("here the details\n");

 printf("name:%s\n",x.name);
 printf("roll no:%d\n",x.roll);
 printf("grade:%c\n",x.grade);
 for(int i=0;i<4;i++)
 {
   printf("subject %d:%.2f\n",i+1,x.subject[i]);
   }
   }
    void main()
    {
    clrscr();
    struct student x = {10,"akash",'c', {77.22,56.33,56.55,45.22}};
    display(x);
    getch();

    }