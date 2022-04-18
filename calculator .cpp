
  #include<iostream>
using namespace std;
class A{
    protected:
    int a,b,c;
    public:
    virtual void calc()=0;

};

class add:public A
{
    public:
    void calc()
    {
        cout<<"Enter your number:-";
        cin>>a>>b;
        c=a+b;
        cout<<"Add Two number:-"<<c;
    }
    
};

class mul:public A
{
    public:
    void calc()
    {
        cout<<"Enter your number:-";
        cin>>a>>b;
        c=a*b;
        cout<<"Add Two number:-"<<c;
    }
    
};

 class sub:public A
{
    public:
    void calc()
    {
        cout<<"Enter your number:-";
        cin>>a>>b;
        c=a-b;
        cout<<"Add Two number:-"<<c;
    }
    
};

class divv:public A
{
    public:
    void calc()
    {
        cout<<"Enter your number:-";
        cin>>a>>b;
        c=a/b;
        cout<<"Add Two number:-"<<c;
    }
    
};
int main()
{
    add obj;
    obj.calc();
    sub obj2;
    obj2.calc();
    mul obj1;
    
    obj1.calc();
    divv obj3;
    obj3.calc();
    return 0;
}