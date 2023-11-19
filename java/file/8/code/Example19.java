package com.itheima;

import java.math.BigInteger;

public class Example19 {
    public static void main(String[] args) {
        BigInteger bi1 = new BigInteger("123456789");  // 创建BigInteger对象
        BigInteger bi2 = new BigInteger("987654321");  // 创建BigInteger对象
        System.out.println("bi2与bi1的和: " + bi2.add(bi1));
        System.out.println("bi2与bi1的差: " + bi2.subtract(bi1));
        System.out.println("bi2与bi1的积: " + bi2.multiply(bi1));
        System.out.println("bi2与bi1的商: " + bi2.divide(bi1));
        System.out.println("bi2与bi1之间的较大值: " + bi2.max(bi1));
        System.out.println("bi2与bi1之间的较小值: " + bi2.min(bi1));
        //创建BigInteger数组接收bi2除以bi1的商和余数
        BigInteger result[] = bi2.divideAndRemainder(bi1);
        System.out.println("bi2除以bi1的商: " + result[0]+
                ":bi2除以bi1的余数："+result[1]);
    }
}
