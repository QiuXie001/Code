package com.itheima;

import java.util.Random;

public class Example18 {
    public static void main(String[] args) {
        Random r = new Random(); // 创建Random实例对象
        System.out.println("生成boolean类型的随机数: " + r.nextBoolean());
        System.out.println("生成float类型的随机数: " + r.nextFloat());
        System.out.println("生成double类型的随机数:" + r.nextDouble());
        System.out.println("生成int类型的随机数:" + r.nextInt());
        System.out.println("生成0~100之间int类型的随机数:" +
                r.nextInt(100));
        System.out.println("生成long类型的随机数:" + r.nextLong());
    }
}
