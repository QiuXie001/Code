package com.itheima;

public class Example15 {
    public static void main(String[] args) {
        System.out.println("计算-10的绝对值: " + Math.abs(-10));
        System.out.println("求大于5.6的最小整数: " + Math.ceil(5.6));
        System.out.println("求小于-4.2的最大整数: " + Math.floor(-4.2));
        System.out.println("对-4.6进行四舍五入: " + Math.round(-4.6));
        System.out.println("求2.1和-2.1中的较大值: " + Math.max(2.1, -2.1));
        System.out.println("求2.1和-2.1中的较小值: " + Math.min(2.1, -2.1));
        System.out.println("生成一个大于等于0.0小于1.0随机值: " +
                Math.random());
        System.out.println("计算1.57的正弦结果: "+Math.sin(1.57));
        System.out.println("计算4的开平方的结果: "+Math.sqrt(4));
        System.out.println("计算指数函数2的3次方的值: "+Math.pow(2, 3));
    }
}
