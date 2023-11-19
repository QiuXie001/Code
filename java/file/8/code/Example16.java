package com.itheima;

import java.util.Random;

public class Example16 {
    public static void main(String args[]) {
        Random random = new Random(); // 不传入种子
        // 随机产生10个[0,100)之间的整数
        for (int x = 0; x < 10; x++) {
            System.out.println(random.nextInt(100));
        }
    }
}
