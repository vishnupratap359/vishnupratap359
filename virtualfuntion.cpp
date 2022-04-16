#include<iostream>
using namespace std;
class abc{
      public:
              virtual void get(){
                  cout<<"Hello abc ";
                  
              }
};
class xyz:public abc{
    public:
            void get(){
                cout<<"hello xyz ";
            }
};
 int main()
 {
      abc *obj;
      xyz obj1;
      obj=&obj1;
      obj->get();
      return 0;
 }