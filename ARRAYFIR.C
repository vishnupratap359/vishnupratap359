#include<stdio.h>
#include<conio.h>
void main()
{
 int arr[10];
 int sum, product,i;
 printf("No of element :\n");
 for(i=0;i<10;i++)
 {
 printf("Enter arr %d",i);
 scanf("%d",&arr[i]);
 }
 sum=0;
 product=1;
 for(i=0;i<10;i++);
 {
 sum=sum+arr[i];
 product=product*arr[i];
 }
 printf("\n sum of array is :%d",sum);
 printf("product");
 ;
 //return 0;
 }











