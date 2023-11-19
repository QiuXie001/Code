package com.itheima;

public class Example05 {
    public static void main(String[] args) {
        String s1 = "String"; // 定义一个字符串
        String s2 = "string";
        System.out.println("判断s1字符串对象是否以Str开头:" +
                s1.startsWith("Str"));
        System.out.println("判断是否以字符串ng结尾:" + s1.endsWith("ng"));
        System.out.println("判断是否包含字符串tri:" + s1.contains("tri"));
        System.out.println("判断字符串是否为空:" + s1.isEmpty());
        System.out.println("判断s1和s2内容是否相同:" + s1.equals(s2));
        System.out.println("忽略大小写的情况下判断s1和s2内容是否相同:" +
                s1.equalsIgnoreCase(s2));
        System.out.println("按对应字符的Unicode比较s1和s2的大小:" +
                s1.compareTo(s2));
    }
}
