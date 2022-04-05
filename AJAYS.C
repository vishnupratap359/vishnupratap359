#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#include<string.h>
void main()
{
 char c='a';
 FILE *p;
 p=fopen("abc.txt","W");
 if(p=NULL)
 {
 prinf("error");
 exit(1);
 }
 fputc(c,p);
 fclose(p);
 getch();
 }