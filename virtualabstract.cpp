#include<iostream>
#define pie 3.14
using namespace std;
class shape{
    public:
            double height,width;
            virtual double parameter()=0;     //pure virtual
};
class rectangle:public shape{
    public:
            double parameter()
            {
                return 2*(height+width);
            }
};
 class circle:public shape{
     public:
      double parameter(){
          return 2*pie*width;
      }
 };
  
  int main()
  {
      rectangle obj;
      circle obj1;
      obj.height=50.88;
      obj1.width=20.88;
      cout<<obj.parameter()<<endl;
      obj1.width=5.0;
      cout<<obj1.parameter();
      return 0;
  }