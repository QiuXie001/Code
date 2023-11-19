package com.itheima;

public class Example10 {
    public static void main(String[] args) {
        long startTime = System.currentTimeMillis();// 循环开始时的当前时间
        int sum = 0;
        for (int i = 0; i < 1000000000; i++) {
            sum += i;
        }
        long endTime = System.currentTimeMillis();// 循环结束后的当前时间
        System.out.println("程序运行的时间为："+(endTime - startTime)+
                "ms");
    }
}
