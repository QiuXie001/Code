package com.v1;

class Student {
	String name;
	static String className;
	public Student(String name) {
		this.name=name;
	}
	public Student(String name,String className) {
		this.name=name;
		this.className=className;
	}
	public void speak() {
		System.out.println(name);
		System.out.println(className);
	}
}
public class T5 {
public static void main(String[] arg) {
	Student.className = "三年级二班";
	Student stu1=new Student("张三");
	stu1.speak();
	Student stu2=new Student("李四");
	stu2.speak();
	Student stu3=new Student("王五");
	stu3.speak();
	
}
}
