package com.itheima;

public class Example35 {
    public static void main(String[] args) {
        int a = 20;                      //声明一个基本数据类型
        Integer in = new Integer(a);     //装箱：将基本数据类型变为包装类
        System.out.println(in);
        int temp = in.intValue();        //拆箱：将一个包装类变为基本数据类型
        System.out.println(temp);
    }
}
