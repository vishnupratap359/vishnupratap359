#include<stdio.h>
#include<stdlib.h>

struct stack{
    int size;
    int top;
    int *arr;
};

int isempty(struct stack *ptr){
    if(ptr->top==-1){
        return 1;
    }
    else{
        return 0;
    }
}
int isfull(struct stack *ptr){
    if(ptr->top==ptr->size-1){
        return 1;
    }
    else{
        return 0;
    }
}


void push(struct stack *ptr,int val)
{
    if(isfull(ptr))
    {
        printf("Stack Overflow");
    }
    else{
    ptr->top++;
    ptr->arr[ptr->top]=val;
    }}
int pop(struct stack *ptr){
    if(isempty(ptr)){
        printf("Stack UnderFlow");
        return -1;
    }
    else{
        int res=ptr->arr[ptr->top];
        ptr->top--;
        return res;
    }
}
int main()
{
int ch,num;
    struct stack *st=(struct stack *)malloc(sizeof(struct stack));
   printf("Enter the Size of Stack");
   scanf("%d",&st->size);
   do{
   printf("1 Push\n 2 Pop\n3 Empty\n4 Full");
   scanf("%d",&ch);
   switch(ch){
       
       case 1:
                printf("Enter Elemenet");
                scanf("%d",&num);
                push(st,num);
                break;
        case 2:
                printf("%d",pop(st));
                break;
        case 3:
            printf("Empty :- %d",isempty(st));
            break;
        case 4:
          printf("Full :- %d",isfull(st));
            break;
        
   }
   }while(1);
   return 0;
   
   
   
}