#include<iostream.h>
#include<conio.h>
class base {
private:
	 int num, num1;
public:
	base();
	int getvalue();
	int getvalue1();
};
    class derived:public base{
public:
       int num2;
       void hello();
       void multiply();
       void result();
 };
      base::base(){
       num = 50;
       num1 = 60;
 };
    int base :: getvalue()
    {
      return num;
    };
      int base :: getvalue1()
      {
      return num1;
    };
      void derived::multiply()
      {
       num2 = getvalue() * getvalue1();
   };
      void derived::result(){
      cout<<"number1 "<<getvalue()<<endl;
      cout<<"number2 "<<getvalue()<<endl;
      cout<<"result "<<num2<<endl;
   };
      void main()
      {
	derived object;
	object.multiply();
	object.result();
	getch();
      }