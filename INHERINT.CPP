 #include<iostream.h>
 #include<conio.h>

 class student{
 protected:
	    int roll_no;
public:
	void set_roll_no(int);
	void get_value();
};
	class exam:public student{
	public:
	       float math,english;
	       void set_value(float,float);
	       void pdata();
      };
	class result:public exam{
	float per;
	public:
	void get_per();
	};

    //*******student**********

      void student::set_roll_no(int x)
      {
	roll_no=x;
    };
       void student::get_value()
       {
	 cout<<"rollno "<<roll_no;
     };
     //******examination***********
     void exam::set_value(float x,float y){
       math=x;
       english=y;
    };
     void exam::pdata(){
     cout<<"math :"<<math<<endl;
     cout<<"english :"<<english<<endl;
   };
      //**********result**************
      void result::get_per(){
      float per,sum;
      sum=math+english;
      per=sum/2;
      cout<<"sum :"<<sum<<endl;
      cout<<"per"<<per;
   };

    void main()
    {
     result obj;
     obj.set_roll_no(205);
     obj.get_value();
     obj.set_value(70.0,80.0);
     obj.pdata();
     obj.get_per();
     getch();
    }