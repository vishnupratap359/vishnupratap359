#include<stdio.h>
#include<conio.h>
void main()
{
 FILE *p;
 int id;
 char name[20];
 int mobileno;
 char designation[20];
 char address[20];
 clrscr();
 p = fopen("emprec.txt","w");
 if(p == NULL)
 {
  printf("file does not exits \n");
  return;
  }
  printf("enter the name \n");
  gets(name);
  fprintf(p,"name = %c\n",name);
  printf("enter the id\n");
  scanf("%d",&id);
  fprintf(p,"id  = %d\n", id);
  printf("enter the mobileno");
  scanf("%d",&mobileno);
  fprintf(p,"mobile = %d\n",mobileno);
  printf("enter the designation\n");
  scanf("%c", &designation);
  fprintf(p,"designation = %c\n",designation);
  printf("enter the address");
  scanf("%c",&address);
  fprintf(p,"address = %c\n", address);
  fclose(p);
  getch();
  }




