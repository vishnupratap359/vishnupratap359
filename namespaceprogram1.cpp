#include<iostream>
using namespace std;
namespace vishnu{
    int value=500;
    
}
   int value=600;
   int main()
   {
        int value=700;
        cout<<vishnu::value<<endl;
        cout<<::value<<endl;
        cout<<value;
        return 0;
   }