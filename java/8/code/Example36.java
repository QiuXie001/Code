package com.itheima;

public class Example36 {
    public static void main(String[] args) {
        Integer num = new Integer(20);     //手动装箱
        int sum = num.intValue() + 10;     //手动拆箱
        System.out.println("将Integer类值转化为int类型后与10求和为："+ sum);
        System.out.println("返回表示10的Integer实例为：" +
                Integer.valueOf(10));
        int w = Integer.parseInt("20")+32;
        System.out.println("将字符串转化为整数位：" + w);
    }
}
