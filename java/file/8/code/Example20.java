package com.itheima;

import java.math.BigDecimal;

public class Example20 {
    public static void main(String[] args) {
        BigDecimal bd1 = new BigDecimal("0.001");  // 创建BigDecimal对象
        BigDecimal bd2 = BigDecimal.valueOf(0.009);// 创建BigDecimal对象
        System.out.println("bd2与bd1的和: " + bd2.add(bd1));
        System.out.println("bd2与bd1的差: " + bd2.subtract(bd1));
        System.out.println("bd2与bd1的积: " + bd2.multiply(bd1));
        System.out.println("bd2与bd1的商: " + bd2.divide(bd1));
        System.out.println("bd2与bd1之间的较大值: " + bd2.max(bd1));
        System.out.println("bd2与bd1之间的较小值: " + bd2.min(bd1));
    }
}
